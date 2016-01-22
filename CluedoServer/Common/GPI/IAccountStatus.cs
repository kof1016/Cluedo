using System;

namespace Common.GPI
{
	public interface IAccountStatus
	{
		event Action OnKickEvent;
	}

	public interface IReady
	{
		event Action OnReadyEvent;
	}
}
