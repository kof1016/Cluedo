using Common;

using Regulus.Remoting;
using Regulus.Utility;

namespace User
{
	public interface IUser : IUpdatable
	{
		Regulus.Remoting.User Remoting { get; }

		INotifier<IVerify> VerifyProvider { get; }

		INotifier<IAccountStatus> AccountStatusProvider { get; }
	}
}
