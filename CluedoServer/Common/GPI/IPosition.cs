using Common.Data;

using Regulus.Remoting;

namespace Common.GPI
{
	public interface IPosition
	{
		Value<PlayerPosition[]> GetAllPlayerPosition();
	}
}