using ProtoBuf;

using Regulus.Utility;

namespace Common.Data
{
	[ProtoContract]
	public class Suspect
	{
		public enum KIND
		{
			[EnumDescription("梅教授")]
			PLUM,
			[EnumDescription("白太太")]
			WHITE,
			[EnumDescription("紅小姐")]
			SCARLET,
			[EnumDescription("綠先生")]
			GREEN,
			[EnumDescription("黃上校")]
			MUSTARD,
			[EnumDescription("藍夫人")]
			PEACOCK
		}

		public KIND Kind { get; set; }
	}
}