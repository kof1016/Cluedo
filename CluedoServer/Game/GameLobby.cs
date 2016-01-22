using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
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

		public GameRoom QueryRoom()
		{
			return _GameRooms.FirstOrDefault(x => x.Id == new Guid());
		}
	}
}
