using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CluedoServer
{
	using Regulus.Framework;
	using Regulus.Game;
	using Regulus.Remoting;
	using Regulus.Utility;

	public class User : IUser
	{
		private OnNewUser VerifySuccessEvent;

		private ISoulBinder _Binder;

		private OnQuit _KickEvent;

		public User(ISoulBinder binder)
		{
			_Binder = binder;
		}

		event OnQuit IUser.QuitEvent
		{
			add
			{
				_KickEvent += value;
			}

			remove
			{
				_KickEvent -= value;
			}
		}

		event OnNewUser IUser.VerifySuccessEvent
		{
			add
			{
				VerifySuccessEvent += value;
			}

			remove
			{
				VerifySuccessEvent -= value;
			}
		}

		void IBootable.Launch()
		{
			throw new NotImplementedException();
		}

		void IUser.OnKick(Guid id)
		{
			throw new NotImplementedException();
		}

		void IBootable.Shutdown()
		{
			throw new NotImplementedException();
		}

		bool IUpdatable.Update()
		{
			throw new NotImplementedException();
		}
	}

	public class Server : ICore
	{
		private Regulus.Game.Hall _Hall;

		public Server()
		{
			_Hall = new Hall();
		}

		/// <summary>
		/// 連線成功會呼叫
		///  create user 
		/// </summary>
		void ICore.AssignBinder(ISoulBinder binder)
		{
			this._Hall.PushUser(new User(binder));
			throw new NotImplementedException();
		}

		void IBootable.Launch()
		{
			throw new NotImplementedException();
		}

		void IBootable.Shutdown()
		{
			throw new NotImplementedException();
		}

		bool IUpdatable.Update()
		{
			throw new NotImplementedException();
		}
	}
}
