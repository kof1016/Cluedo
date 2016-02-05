using System;
using System.Collections.Generic;
using System.Linq;

using Common.Data;
using Common.GPI;
using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class StepCal
	{
		private int _Step;

		public int InitStep()
		{
			_Step = 1;
			return _Step;
		}

		public void Move()
		{
			_Step--;
		}

		public bool Over()
		{
			return _Step == 0;
		}
	}

	public class GameZone : IPosition, IBoardData, IPlayer
	{
		public event Action<GameZone> OnToStartGameEvent;

		private const int _MaxPlayers = 1;

		private readonly List<User> _Users;

		private int _Currect;

		private Suspect _Suspect;

		private Weapon _Weapon;

		public Guid Id;

		public StepCal StepCal;

		public GameZone(Guid id)
		{
			Id = id;
			_Users = new List<User>();
			StepCal = new StepCal();
		}

		Value<GridData[]> IBoardData.GetBoard()
		{
			var returnValue = new Value<GridData[]>();

			returnValue.SetValue(Singleton<Resource>.Instance.Boards);

			return returnValue;
		}

		Value<int> IPlayer.GetStep()
		{
			var returnValue = new Value<int>();
			
			returnValue.SetValue(StepCal.InitStep());

			return returnValue;
		}

		Value<bool> IPlayer.Move(Neighbor.DIRECTION dir)
		{
			var returnValue = new Value<bool>();

			var result = CheckMove(dir);

			returnValue.SetValue(result);

			return result;
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

		public bool CheckMove(Neighbor.DIRECTION move_direction)
		{
			var user = _Users[_Currect];

			var neighbors = Singleton<Resource>.Instance.FindGridData(user.Position.GridIndex)
												.Neighbors;

			var result = neighbors.Where(neighbor => neighbor.Dir == move_direction)
								.Any(neighbor => neighbor.Index != 0);

			if(result)
			{
				StepCal.Move();
			}

			return result;
		}

		private void _Run(User next_user)
		{
			next_user.Play(this);

			if (StepCal.Over())
			{
				 _Run(_GetNextUser());
			}

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
