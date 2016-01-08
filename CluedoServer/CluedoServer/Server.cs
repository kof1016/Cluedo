using Regulus.Framework;
using Regulus.Game;
using Regulus.Remoting;
using Regulus.Utility;

namespace CluedoServer
{
	public class Server : ICore
	{
		private readonly Hall _Hall;

		private readonly StageMachine _Machine;

		private readonly Updater _Updater;

		public Server()
		{
			_Hall = new Hall();
			_Machine = new StageMachine();
			_Updater = new Updater();
		}

		/// <summary>
		///     連線成功會呼叫
		///     create user
		/// </summary>
		void ICore.AssignBinder(ISoulBinder binder)
		{
			_Hall.PushUser(new Game.User(binder));
		}

		void IBootable.Launch()
		{
			_Updater.Add(_Hall);
		}

		void IBootable.Shutdown()
		{
			_Updater.Shutdown();
		}

		bool IUpdatable.Update()
		{
			_Updater.Working();
			_Machine.Update();
			return true;
		}
	}
}
