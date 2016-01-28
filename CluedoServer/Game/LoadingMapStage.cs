using System;
using Common.GPI;
using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class LoadingMapStage : IStage
	{
		public Action<GameZone> OnDoneEvent;

		private readonly ISoulBinder _Binder;

		private readonly GameZone _GameZone;

		public LoadingMapStage(ISoulBinder binder, GameZone game_zone)
		{
			_Binder = binder;
			_GameZone = game_zone;
		}

		void IStage.Enter()
		{
			_Binder.Bind<IBoardData>(_GameZone);
			OnDoneEvent?.Invoke(_GameZone);
        }

		void IStage.Leave()
		{
			_Binder.Unbind<IBoardData>(_GameZone);
		}

		void IStage.Update()
		{
			
		}
	}
}