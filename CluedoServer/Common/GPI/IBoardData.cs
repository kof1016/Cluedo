using Common.Data;
using Regulus.Remoting;

namespace Common.GPI
{
	public interface IBoardData
	{
		Value<GridData[]> GetBoard();
	}
}