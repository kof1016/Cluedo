using System;

using Regulus.Framework;
using Regulus.Remoting;
using Regulus.Remoting.Ghost.Native;
using Regulus.Utility;

namespace User
{
	public class StandaloneuserFactory
	{
		private ICore _Standalone;

		public StandaloneuserFactory(ICore core)
		{
			_Standalone = core;
		}
	}
}
