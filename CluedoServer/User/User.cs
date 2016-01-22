using System;

using Common;
using Common.GPI;

using Regulus.Framework;
using Regulus.Remoting;
using Regulus.Utility;

namespace User
{
	internal class User : IUser
	{
		private readonly IAgent _Agent;

		private readonly Updater _Updater;

		private readonly Regulus.Remoting.User _User;

		public User(IAgent agent)
		{
			_Agent = agent;
			_Updater = new Updater();
			_User = new Regulus.Remoting.User(_Agent);
		}

		Regulus.Remoting.User IUser.Remoting => _User;

		INotifier<IAccountStatus> IUser.AccountStatusProvider => _Agent.QueryNotifier<IAccountStatus>();

		INotifier<IVerify> IUser.VerifyProvider => _Agent.QueryNotifier<IVerify>();

		INotifier<IPlayer> IUser.PlayerProvider => _Agent.QueryNotifier<IPlayer>();

		void IBootable.Launch()
		{
			_Updater.Add(_User);
		}

		void IBootable.Shutdown()
		{
			_Updater.Shutdown();
		}

		bool IUpdatable.Update()
		{
			_Updater.Working();
			return true;
		}
	}
}
