using System;
using System.Collections.Generic;
using System.Linq;

using Common.GPI;

using Game;

using Regulus.Framework;
using Regulus.Game;
using Regulus.Utility;

namespace CluedoServer
{
	public class GameLobby
	{
		private readonly List<GameRoom> _GameRooms;

		public GameLobby()
		{
			_GameRooms = new List<GameRoom>
			{
				new GameRoom(new Guid())
			};
		}

		public void PushUser(User user)
		{
			_GameRooms.FirstOrDefault(x=>x.Id == new Guid())?.Join(user);
		}
	}
}
