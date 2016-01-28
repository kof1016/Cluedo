using ProtoBuf;

namespace Common.Data
{
	[ProtoContract]
	public class GridData
	{
		[ProtoMember(1)]
		public GRID_TYPE GridType { get; set; }

		[ProtoMember(2)]
		public Neighbor Neighbors { get; set; }

		[ProtoMember(3)]
		public int X { get; set; }

		[ProtoMember(4)]
		public int Y { get; set; }

		public GridData()
		{
			Neighbors = new Neighbor();
		}

		public GridData(int x, int y, GRID_TYPE type)
		{
			X = x;
			Y = y;
			GridType = type;
			Neighbors = new Neighbor();
		}
	}
}
