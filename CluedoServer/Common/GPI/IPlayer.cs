using System;

using Common.Data;

using Regulus.Collection;
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

		Value<bool> Move(Neighbor.DIRECTION dir);
	}
}
