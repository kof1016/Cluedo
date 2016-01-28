using ProtoBuf;

namespace Common.Data
{
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
		public GridData[] Grids { get; set; }

		public Neighbor()
		{
			Grids = new GridData[(int)DIRECTION.COUNT];
		}
	}
}