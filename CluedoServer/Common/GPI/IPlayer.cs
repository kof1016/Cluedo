using System;

using Regulus.Remoting;

namespace Common.GPI
{
	public interface IPlayer
	{
		/// <summary>
		///     �B��
		/// </summary>
		/// <returns></returns>
		Value<int> GetStep();
	}
}
