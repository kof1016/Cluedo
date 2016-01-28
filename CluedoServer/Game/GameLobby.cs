using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	public class GameLobby
	{
		private readonly List<GameZone> _GameRooms;

		public GameLobby()
		{
			_GameRooms = new List<GameZone>
			{
				new GameZone(new Guid())
			};
		}

		public GameZone QueryRoom()
		{
			return _GameRooms.FirstOrDefault(x => x.Id == new Guid());
		}
	}
}
