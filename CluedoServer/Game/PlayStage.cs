﻿using System;

using Common.Data;
using Common.GPI;

using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	internal class PlayStage : IStage, IPlayer
	{
		private readonly ISoulBinder _Binder;

		private readonly GameRoom _GameRoom;

		private Suspect _Suspect;

		private Weapon _Weapon;

		public PlayStage(ISoulBinder binder, GameRoom game_room)
		{
			_Binder = binder;
			_GameRoom = game_room;
			_Weapon = new Weapon();
			_Suspect = new Suspect();
		}

		Value<int> IPlayer.GetStep()
		{
			var returnValue = new Value<int>();

			returnValue.SetValue(1);

			return returnValue;
		}

		void IStage.Enter()
		{
			_Binder.Bind<IPlayer>(this);
		}

		void IStage.Leave()
		{
			_Binder.Unbind<IPlayer>(this);
		}

		void IStage.Update()
		{
		}
	}
}