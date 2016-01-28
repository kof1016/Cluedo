using System;
using System.Collections.Generic;
using System.Linq;

using Common.Data;
using Common.GPI;

using Regulus.Remoting;

namespace Game
{
	public class GameZone : IPosition, IBoardData
	{
		public event Action<GameZone> OnToStartGameEvent;

		private const int _MaxPlayers = 1;

		private readonly List<User> _Users;

		private int _Currect;

		private Suspect _Suspect;

		private Weapon _Weapon;

		public Guid Id;

		public GameZone(Guid id)
		{
			Id = id;
			_Users = new List<User>();
		}

		Value<GridData[]> IBoardData.GetBoard()
		{
			var returnValue = new Value<GridData[]>();

			returnValue.SetValue(new GameBoard().Board);

			return returnValue;
		}

		Value<PlayerPosition[]> IPosition.GetAllPlayerPosition()
		{
			var returnValue = new Value<PlayerPosition[]>();

			returnValue.SetValue(_Users.Select(user => user.Position)
						.ToArray());

			return returnValue;
		}

		public void Join(User user)
		{
			_Users.Add(user);

			_CheckPlayerCount();
		}

		/// <summary>
		///     檢查人數是否到齊
		/// </summary>
		private void _CheckPlayerCount()
		{
			if(_Users.Count != _MaxPlayers)
			{
				return;
			}

			OnToStartGameEvent?.Invoke(this);

			MoveNext();
		}

		public void MoveNext()
		{
			_Run(_GetNextUser());
		}

		private User _GetNextUser()
		{
			if(_Currect > _Users.Count - 1)
			{
				_Currect = 0;
			}
			var users = _Users.ToArray();

			return users[_Currect];
		}

		private void _Run(User next_user)
		{
			next_user.Play(this);

			next_user.OnDonePlayEvent += () => { _Run(_GetNextUser()); };

			foreach(var user in _Users)
			{
				if(user == next_user)
				{
					continue;
				}

				user.View(this);
			}
		}
	}
}
