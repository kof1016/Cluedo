using System;

using ProtoBuf;

namespace Common.Data
{
	[ProtoContract]
	public class PlayerPosition
	{
		[ProtoMember(1)]
		public Guid Id { get; set; }

		[ProtoMember(2)]
		public int GridIndex { get; set; }

		public PlayerPosition()
		{
			GridIndex = 1;
		}
	}
}
