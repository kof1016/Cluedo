using System.IO;

using Common.Data;

using Game;

using Regulus.Framework;
using Regulus.Remoting;
using Regulus.Utility;

namespace Server
{
	public class Server : ICore
	{
		private readonly StageMachine _Machine;

		private readonly Updater _Updater;

		private Center _Center;

		private ICore _Core => _Center;

		public Server()
		{
			_Machine = new StageMachine();
			_Updater = new Updater();
		}

		/// <summary>
		///     連線成功會呼叫
		///     create user
		/// </summary>
		void ICore.AssignBinder(ISoulBinder binder)
		{
			_Core.AssignBinder(binder);
		}

		void IBootable.Launch()
		{
			_LoadData();
			_ToPlay();
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

		private void _LoadData()
		{
			var buffer = File.ReadAllBytes("board.txt");
			var gridDatas = Serialization.Read<GridData[]>(buffer);
			Singleton<Resource>.Instance.Boards = gridDatas;
        }

		private void _ToPlay()
		{
			_Center = new Center();
			_Updater.Add(_Center);
		}
	}
}
