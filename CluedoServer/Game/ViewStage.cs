using System;

using Common.GPI;

using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class ViewStage : IStage
	{
		public Action OnDoneEvent;

		private readonly ISoulBinder _Binder;

		private readonly GameZone _GameZone;

		public ViewStage(ISoulBinder binder, GameZone game_zone)
		{
			_Binder = binder;
			_GameZone = game_zone;
			
		}

		void IStage.Enter()
		{
			_Binder.Bind<IPosition>(_GameZone);
		}

		void IStage.Leave()
		{
			_Binder.Unbind<IPosition>(_GameZone);
		}

		void IStage.Update()
		{
			
		}
	}
}