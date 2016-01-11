using System;

using Common;

using Regulus.Remoting;

namespace Game.GPI_Implement
{
	public class Verify : IVerify
	{
		public event Func<bool> OnDoneEvent;

		Value<bool> IVerify.Login(string id, string password)
		{
			var result = new Value<bool>();

			OnDoneEvent?.Invoke();

			result.SetValue(true);

			return result;
		}
	}
}
