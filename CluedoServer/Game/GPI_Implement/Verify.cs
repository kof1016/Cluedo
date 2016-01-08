using System;

using Common;

using Regulus.Remoting;

namespace Game
{
	public class Verify : IVerify
	{
		public delegate bool DoneCallback();

		public event DoneCallback OnDoneEvent;

		Value<bool> IVerify.Login(string id, string password)
		{
			var result = new Value<bool>();

			OnDoneEvent?.Invoke();

			result.SetValue(true);

			return result;
		}
	}
}
