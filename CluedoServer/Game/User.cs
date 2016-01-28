using System;

using Common.Data;
using Common.GPI;

using Regulus.Framework;
using Regulus.Game;
using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class User : IUser, IAccountStatus
	{
		private event Action _OnKickEvent;

		private event OnQuit _OnQuitEvent;

		private event OnNewUser _OnVerifySuccessEvent;

		public event Action OnDonePlayEvent;

		private readonly ISoulBinder _Binder;

		private readonly GameLobby _GameLobby;

		private readonly StageMachine _Machine;

		public PlayerPosition Position { get; set; }

		public User(ISoulBinder binder, GameLobby game_lobby)
		{
			_Binder = binder;
			_GameLobby = game_lobby;

			_Machine = new StageMachine();

			Position = new PlayerPosition();
        }

		event Action IAccountStatus.OnKickEvent
		{
			add { _OnKickEvent += value; }

			remove { _OnKickEvent -= value; }
		}

		event OnQuit IUser.QuitEvent
		{
			add { _OnQuitEvent += value; }

			remove { _OnQuitEvent -= value; }
		}

		event OnNewUser IUser.VerifySuccessEvent
		{
			add { _OnVerifySuccessEvent += value; }

			remove { _OnVerifySuccessEvent -= value; }
		}

		void IBootable.Launch()
		{
			_Binder.BreakEvent += _Quit;
			_Binder.Bind<IAccountStatus>(this);
			_ToVerify();
		}

		void IUser.OnKick(Guid id)
		{
			_OnKickEvent?.Invoke();
		}

		void IBootable.Shutdown()
		{
			_Binder.Unbind<IAccountStatus>(this);
			_Binder.BreakEvent -= _Quit;
			_Machine.Termination();
		}

		bool IUpdatable.Update()
		{
			_Machine.Update();
			return true;
		}

		private void _ToVerify()
		{
			var stage = new VerifyStage(_Binder);

			stage.OnDoneEvent += _VerifyDone;

			stage.OnFailEvent += _VerifyFail;

			_Machine.Push(stage);
		}

		private void _VerifyFail()
		{
			throw new SystemException("formula verify fail");
		}

		private void _VerifyDone(Account obj)
		{
			_OnVerifySuccessEvent?.Invoke(obj.Id);

			var room = _GameLobby.QueryRoom();

			room.OnToStartGameEvent += _OnToStartGame;

			room.Join(this);
		}

		private void _OnToStartGame(GameZone game_zone)
		{
			var stage = new LoadingMapStage(_Binder, game_zone);
			stage.OnDoneEvent += _LoadingMapDone;
			_Machine.Push(stage);
		}

		private void _LoadingMapDone(GameZone game_zone)
		{
			Play(game_zone);
		}

		private void _Quit()
		{
			_OnQuitEvent?.Invoke();
		}

		public void Play(GameZone game_zone)
		{
			var stage = new PlayStage(_Binder, game_zone);

			stage.OnDoneEvent += () => { OnDonePlayEvent?.Invoke(); };

			_Machine.Push(stage);
		}

		public void View(GameZone game_zone)
		{
			var stage = new ViewStage(_Binder, game_zone);

			_Machine.Push(stage);
		}
	}
}
