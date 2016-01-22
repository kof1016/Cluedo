using System;
using System.Collections.Generic;

namespace Game
{
	public class GameRoom
	{
		public delegate void DoneCallback(GameRoom game_room);
		
		public event DoneCallback OnToPlayEvent;

		private const int _MaxPlayers = 1;

		private readonly List<User> _Users;

		public Guid Id;

		public GameRoom(Guid id)
		{
			Id = id;
			_Users = new List<User>();
		}

		public void Join(User user)
		{
			
			_Users.Add(user);

			_CheckPlayerCount();
		}

		private void _CheckPlayerCount()
		{
			if(_Users.Count != _MaxPlayers)
			{
				return;
			}

			OnToPlayEvent?.Invoke(this);
		}
	}
}
