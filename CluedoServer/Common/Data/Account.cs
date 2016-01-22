using System;

using ProtoBuf;

namespace Common.Data
{
	[ProtoContract]
	public class Account
	{
		[ProtoMember(1)]
		public Guid Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public string Password { get; set; }
	}
}
