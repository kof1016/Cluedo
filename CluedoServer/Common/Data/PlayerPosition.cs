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
		public int X { get; set; }

		[ProtoMember(3)]
		public int Y { get; set; }
	}
}
