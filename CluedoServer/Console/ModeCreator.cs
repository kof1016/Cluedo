using Regulus.Framework;
using Regulus.Remoting;
using Regulus.Utility;

using User;

namespace Console
{
	internal class ModeCreator
	{
		private ICore _Core;

	    private readonly Command _Command;

	    public ModeCreator(ICore core , Command command)
	    {
	        _Core = core;
	        _Command = command;
	    }

	    public void Select(GameModeSelector<IUser> selector)
		{
			selector.AddFactoty("remoting", new RemotingUserFactory());
			var provider = selector.CreateUserProvider("remoting");

			var user = provider.Spawn("1");
	        
            provider.Select("1");
		}


	  
	}

	
}
