using ProtoBuf;

using Regulus.Utility;

namespace Common.Data
{
	[ProtoContract]
	public class Weapon
	{
		public enum KIND
		{
			[EnumDescription("÷��")]
			ROPE,

			[EnumDescription("�P��")]
			DAGGER,

			[EnumDescription("�񵷹X")]
			WRENCH,

			[EnumDescription("��j")]
			PISTOL,

			[EnumDescription("���i")]
			CANDLE_STICK,

			[EnumDescription("�]��")]
			LEAD_PIPE
		}

		public KIND Kind { get; set; }
	}

	public class Map
	{
		
	}
}
