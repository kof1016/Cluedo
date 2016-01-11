using System;

using Common;

using Game.GPI_Implement;

using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class VerifyStage : IStage
	{
		public event Action<bool> OnDoneEvent; 

		private readonly ISoulBinder _Binder;

		private readonly Verify _Verify;

		public VerifyStage(Verify verify, ISoulBinder binder)
		{
			_Verify = verify;
			_Binder = binder;
		}

		void IStage.Enter()
		{
			_Verify.OnDoneEvent += _Verify_OnDoneEvent;
			_Binder.Bind<IVerify>(_Verify);
		}

		private bool _Verify_OnDoneEvent()
		{
			OnDoneEvent?.Invoke(true);

            return true;
		}

		void IStage.Leave()
		{
			_Binder.Unbind<IVerify>(_Verify);
			_Verify.OnDoneEvent -= _Verify_OnDoneEvent;
		}

		void IStage.Update()
		{
			
		}
	}
}
