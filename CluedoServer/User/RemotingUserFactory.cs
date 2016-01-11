﻿using System;

using Regulus.Framework;
using Regulus.Remoting.Ghost.Native;
using Regulus.Utility;

using Console = Regulus.Utility.Console;

namespace User
{
	public class RemotingUserFactory : IUserFactoty<IUser>
	{
		IUser IUserFactoty<IUser>.SpawnUser()
		{
			return new User(Agent.Create());
		}

		ICommandParsable<IUser> IUserFactoty<IUser>.SpawnParser(Command command, Console.IViewer view, IUser user)
		{
			return new CommandParser(command, view, user);
		}
	}
}
