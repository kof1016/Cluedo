using System;

using Common.Data;

using Regulus.Framework;
using Regulus.Remoting;
using Regulus.Utility;
using Regulus.Extension;

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
			_Command = command;
			_View = view;
			_User = user;
		}

		void ICommandParsable<IUser>.Clear()
		{
			_Command.Unregister("Agent");
		}

		void ICommandParsable<IUser>.Setup(IGPIBinderFactory factory)
		{
			_CreateConnent(factory);
			_CreateOnline(factory);
			_CreateVerify(factory);
			_CreateBoard(factory);
			_CreatePlayer(factory);
			_CreatePosition(factory);
		}

		private void _CreatePosition(IGPIBinderFactory factory)
		{
			var binder = factory.Create(_User.PositionProvider);

			binder.Bind(gpi => gpi.GetAllPlayerPosition(), _GetPositionResult);
		}

		private void _GetPositionResult(Value<PlayerPosition[]> obj)
		{
			obj.OnValue += player_positions =>
			{
				foreach(var data in player_positions)
				{
					_View.WriteLine($"Player Id{data.Id}, x is {data.X}, y is {data.Y}");
				}
			};
		}

		private void _CreateBoard(IGPIBinderFactory factory)
		{
			var binder = factory.Create(_User.BoardProvider);

			binder.Bind(gpi => gpi.GetBoard(), _GetMapResult);
		}

		private void _GetMapResult(Value<GridData[]> game_board)
		{
			game_board.OnValue += board =>
			{
				foreach(var gridData in board)
				{
					_View.WriteLine($"Grid x is {gridData.X}, y is {gridData.Y}");
				}
			};
		}

		private void _CreatePlayer(IGPIBinderFactory factory)
		{
			var binder = factory.Create(_User.PlayerProvider);

			binder.Bind(gpi => gpi.GetStep(), _GetStepResult);
		}

		private void _GetStepResult(Value<int> obj)
		{
			obj.OnValue += step => { _View.WriteLine($"Step is {step}"); };
		}

		private void _CreateVerify(IGPIBinderFactory factory)
		{
			var binder = factory.Create(_User.VerifyProvider);

			binder.Bind<string, string, Value<bool>>((gpi, id, password) => gpi.Login(id, password), _VerifyResult);
		}

		private void _VerifyResult(Value<bool> result)
		{
			result.OnValue += success => { _View.WriteLine($"Verify Result {success}"); };
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
