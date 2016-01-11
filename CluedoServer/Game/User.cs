using System;
using System.Runtime.Remoting.Channels;

using Common;

using Regulus.CustomType;
using Regulus.Framework;
using Regulus.Game;
using Regulus.Remoting;
using Regulus.Utility;

using Verify = Game.GPI_Implement.Verify;

namespace Game
{
	public class User : IUser, IAccountStatus
	{
		private event Action _OnKickEvent;

		private event OnQuit _OnQuitEvent;

		private event OnNewUser _OnVerifySuccessEvent;

		private readonly ISoulBinder _Binder;

		private readonly StageMachine _Machine;

		public User(ISoulBinder binder)
		{
			_Binder = binder;

			_Machine = new StageMachine();
		}

		event Action IAccountStatus.OnKickEvent
		{
			add
			{
				_OnKickEvent += value;
			}

			remove
			{
				_OnKickEvent -= value;
			}
		}

		event OnQuit IUser.QuitEvent
		{
			add
			{
				_OnQuitEvent += value;
			}

			remove
			{
				_OnQuitEvent -= value;
			}
		}

		event OnNewUser IUser.VerifySuccessEvent
		{
			add
			{
				_OnVerifySuccessEvent += value;
			}

			remove
			{
				_OnVerifySuccessEvent -= value;
			}
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
			var verify = new Verify();

			var stage = new VerifyStage(verify, _Binder);
			stage.OnDoneEvent += _VerifySuccess;
			_Machine.Push(stage);
		}

		private void _VerifySuccess(bool result)
		{
			_OnVerifySuccessEvent?.Invoke(new Guid());

			_ToPlayStage();
		}

		private void _ToPlayStage()
		{
			//new PlayStage(_Binder);
		}

		private void _Quit()
		{
			_OnQuitEvent?.Invoke();
		}
	}
}
