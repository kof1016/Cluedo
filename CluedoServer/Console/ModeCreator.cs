using Regulus.Framework;
using Regulus.Remoting;
using Regulus.Remoting.Ghost.Native;
using Regulus.Utility;

using User;

namespace Console
{
	internal class ModeCreator
	{
		private ICore _Core;

		public ModeCreator(ICore core)
		{
			_Core = core;
		}

		public void Select(GameModeSelector<IUser> selector)
		{
			selector.AddFactoty("remoting", new RemotingUserFactory());
			var provider = selector.CreateUserProvider("remoting");

			provider.Spawn("1");
			provider.Select("1");
		}
	}

	
}
