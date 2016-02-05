using ProtoBuf;

namespace Common.Data
{
	[System.Serializable]
	[ProtoContract]
	public class Neighbor
	{
		public enum DIRECTION
		{
			UP,

			DOWN,

			LEFT,

			RIGHT,

			COUNT
		}

		[ProtoMember(1)]
		public DIRECTION Dir { get; set; }

		[ProtoMember(2)]
		public int Index { get; set; }
	}

	[System.Serializable]
	[ProtoContract]
	public class GridData
	{
		[ProtoMember(1)]
		public int Index { get; set; }

		[ProtoMember(2)]
		public GRID_TYPE GridType { get; set; }

		[ProtoMember(3)]
		public Neighbor[] Neighbors { get; set; }

		public GridData()
		{
			Neighbors = new Neighbor[0];
		}

		public GridData(int index, GRID_TYPE type, Neighbor[] neighbors)
		{
			Index = index;

			GridType = type;

			Neighbors = neighbors;
		}
	}
}
