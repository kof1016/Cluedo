using System;

using Common;
using Common.Data;
using Common.GPI;

using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class VerifyStage : IStage, IVerify
	{
		public event Action<Account> OnDoneEvent;

		public event Action OnFailEvent;

		public GameRoom.DoneCallback OnToPlayEvent;

		private readonly ISoulBinder _Binder;

		public VerifyStage(ISoulBinder binder)
		{
			_Binder = binder;
		}

		void IStage.Enter()
		{
			_Binder.Bind<IVerify>(this);
		}

		void IStage.Leave()
		{
			_Binder.Unbind<IVerify>(this);
		}

		void IStage.Update()
		{
		}

		Value<bool> IVerify.Login(string id, string password)
		{
			var returnValue = new Value<bool>();

			OnDoneEvent?.Invoke(new Account
			{
				Id = Guid.NewGuid(),
				Password = password,
				Name = "test"
			});

			returnValue.SetValue(true);

			return returnValue;
		}
	}
}
