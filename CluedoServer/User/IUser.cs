using Common;
using Common.GPI;

using Regulus.Remoting;
using Regulus.Utility;

namespace User
{
	public interface IUser : IUpdatable
	{
		Regulus.Remoting.User Remoting { get; }

		INotifier<IVerify> VerifyProvider { get; }

		INotifier<IAccountStatus> AccountStatusProvider { get; }

		INotifier<IBoardData> BoardProvider { get; }

		INotifier<IPosition> PositionProvider { get; }

		INotifier<IPlayer> PlayerProvider { get; }


	}
}
