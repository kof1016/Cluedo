using Regulus.Framework;

using User;

namespace Console
{
	internal class ModeCreator
	{
		public void Select(GameModeSelector<IUser> selector)
		{
			selector.AddFactoty("remoting", new RemotingUserFactory());
			var provider = selector.CreateUserProvider("remoting");

			provider.Spawn("1");
			provider.Select("1");
		}
	}
}
