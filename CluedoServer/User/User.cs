﻿using Common;

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

		INotifier<IVerify> IUser.VerifyProvider => _Agent.QueryNotifier<IVerify>();

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
