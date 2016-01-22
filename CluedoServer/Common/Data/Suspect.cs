using ProtoBuf;

using Regulus.Utility;

namespace Common.Data
{
	[ProtoContract]
	public class Suspect
	{
		public enum KIND
		{
			[EnumDescription("���б�")]
			PLUM,
			[EnumDescription("�դӤ�")]
			WHITE,
			[EnumDescription("���p�j")]
			SCARLET,
			[EnumDescription("�����")]
			GREEN,
			[EnumDescription("���W��")]
			MUSTARD,
			[EnumDescription("�ŤҤH")]
			PEACOCK
		}

		public KIND Kind { get; set; }
	}
}