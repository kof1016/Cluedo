using System.Linq;

using Regulus.Utility;

namespace Common.Data
{
	public class Resource : Singleton<Resource>
	{
		public GridData[] Boards;

		public GridData FindGridData(int index)
		{
			return (from e in Boards where e.Index == index select e).Single();
		}
	}
}