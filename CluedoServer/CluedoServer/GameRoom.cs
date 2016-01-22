using System;
using System.Collections.Generic;

using Game;

namespace CluedoServer
{
	public class GameRoom
	{
		public event Action<GameRoom> OnToPlayerEvent;

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

			foreach(var user in _Users)
			{
				//user.dosomething
			}

			//或是傳這個事件
			OnToPlayerEvent?.Invoke(this);
		}
	}
}
