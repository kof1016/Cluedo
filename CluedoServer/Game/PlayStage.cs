using System;

using Common.Data;
using Common.GPI;

using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	internal class PlayStage : IStage, IPlayer
	{
		public event Action OnDoneEvent;

		private readonly ISoulBinder _Binder;

		private readonly GameZone _GameZone;

		

		public PlayStage(ISoulBinder binder, GameZone game_zone)
		{
			_Binder = binder;
			_GameZone = game_zone;
		}

		Value<int> IPlayer.GetStep()
		{
			OnDoneEvent?.Invoke();

			var returnValue = new Value<int>();

			returnValue.SetValue(1);

			return returnValue;
		}

		void IStage.Enter()
		{
			_Binder.Bind<IBoardData>(_GameZone);

			_Binder.Bind<IPlayer>(this);

			_Binder.Bind<IPosition>(_GameZone);
		}

		void IStage.Leave()
		{
			_Binder.Unbind<IBoardData>(_GameZone);
			_Binder.Unbind<IPlayer>(this);
			_Binder.Unbind<IPosition>(_GameZone);
		}

		void IStage.Update()
		{
		}
	}
}
