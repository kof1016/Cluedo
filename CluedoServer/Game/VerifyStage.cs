using System;

using Common;

using Regulus.Remoting;
using Regulus.Utility;

namespace Game
{
	public class VerifyStage : IStage
	{
		public event Verify.DoneCallback OnDoneEvent;

		private readonly ISoulBinder _Binder;

		private readonly Verify _Verify;

		public VerifyStage(Verify verify, ISoulBinder binder)
		{
			_Verify = verify;
			_Binder = binder;
		}

		void IStage.Enter()
		{
			_Verify.OnDoneEvent += OnDoneEvent;
			_Binder.Bind<IVerify>(_Verify);
		}

		void IStage.Leave()
		{
			_Binder.Unbind<IVerify>(_Verify);
			_Verify.OnDoneEvent -= OnDoneEvent;
		}

		void IStage.Update()
		{
			
		}
	}
}
