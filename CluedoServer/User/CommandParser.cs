using System;

using Regulus.Framework;
using Regulus.Remoting;
using Regulus.Utility;

using Console = Regulus.Utility.Console;

namespace User
{
	internal class CommandParser : ICommandParsable<IUser>
	{
		private readonly Command _Command;

		private readonly IUser _User;

		private readonly Console.IViewer _View;

		public CommandParser(Command command, Console.IViewer view, IUser user)
		{
			this._Command = command;
			this._View = view;
			this._User = user;
		}

		void ICommandParsable<IUser>.Clear()
		{
			_Command.Unregister("Agent");
		}

		void ICommandParsable<IUser>.Setup(IGPIBinderFactory factory)
		{
			_CreateConnent(factory);
			_CreateOnline(factory);
		}

		private void _CreateOnline(IGPIBinderFactory factory)
		{
			var online = factory.Create(_User.Remoting.OnlineProvider);

			online.Bind("ping", gpi => new CommandParamBuilder().Build(() => _View.WriteLine($"Ping :{gpi.Ping}")));

			online.Bind(gpi => gpi.Disconnect());
		}

		private void _CreateConnent(IGPIBinderFactory factory)
		{
			var connect = factory.Create(_User.Remoting.ConnectProvider);
			connect.Bind("Connect[result, ipaddr, port]", gpi => new CommandParamBuilder().BuildRemoting<string, int, bool>(gpi.Connect, _ConnectResult));
		}

		private void _ConnectResult(bool result)
		{
			_View.WriteLine($"Connect result {result}");
		}
	}
}
