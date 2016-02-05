using System;

using Common.Data;
using Common.GPI;

using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	internal class PlayStage : IStage
	{
		private readonly ISoulBinder _Binder;

		private readonly GameZone _GameZone;

		public PlayStage(ISoulBinder binder, GameZone game_zone)
		{
			_Binder = binder;
			_GameZone = game_zone;
		}

		void IStage.Enter()
		{
			_Binder.Bind<IBoardData>(_GameZone);

			_Binder.Bind<IPlayer>(_GameZone);

			_Binder.Bind<IPosition>(_GameZone);
		}

		void IStage.Leave()
		{
			_Binder.Unbind<IBoardData>(_GameZone);
			_Binder.Unbind<IPlayer>(_GameZone);
			_Binder.Unbind<IPosition>(_GameZone);
		}

		void IStage.Update()
		{
		}
	}
}
