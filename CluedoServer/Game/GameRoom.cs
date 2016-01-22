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


		    _Run(_GetNextUser());
		}

	    public void Next()
	    {
            _Run(_GetNextUser());
        }
	    private void _Run(User next_user)
	    {
	        next_user.Play(this);
	       // next_user.Done += () => { _Run(_GetNextUser()); };

	        foreach(var user  in _Users)
	        {
                if(user == next_user)
                    continue;
	            
	            user.View(this);
	        }
	    }

	    public void Move()
	    {
	        
	    }

	    private User _GetNextUser()
	    {
	        throw new NotImplementedException();
	    }
	}
}
