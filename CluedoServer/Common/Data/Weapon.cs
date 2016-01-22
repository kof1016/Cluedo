using ProtoBuf;

using Regulus.Utility;

namespace Common.Data
{
	[ProtoContract]
	public class Weapon
	{
		public enum KIND
		{
			[EnumDescription("Ã·¯Á")]
			ROPE,

			[EnumDescription("¤P­º")]
			DAGGER,

			[EnumDescription("Ãñµ·¹X")]
			WRENCH,

			[EnumDescription("¤âºj")]
			PISTOL,

			[EnumDescription("ÀëÂi")]
			CANDLE_STICK,

			[EnumDescription("¹]ºÞ")]
			LEAD_PIPE
		}

		public KIND Kind { get; set; }
	}

	public class Map
	{
		
	}
}
