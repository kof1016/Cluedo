using System;

using Regulus.Framework;
using Regulus.Game;
using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class Center : ICore
	{
		private readonly GameLobby _GameLobby;

		private readonly Hall _Hall;

		private Updater _Updater;

		public Center()
		{
			_Updater = new Updater();
			_Hall = new Hall();
			_GameLobby = new GameLobby();
		}

		void ICore.AssignBinder(ISoulBinder binder)
		{
			var user = new User(binder, _GameLobby);

			_Hall.PushUser(user);
		}

		bool IUpdatable.Update()
		{
			_Updater.Working();
            return true;
		}

		void IBootable.Launch()
		{
			_Updater.Add(_Hall);
        }

		void IBootable.Shutdown()
		{
            _Updater.Shutdown();
        }
	}
}
