using Regulus.Utility;

namespace Common.Data
{
	public class Room
	{
		public enum KIND
		{
			[EnumDescription("�x�|")]
			COURTYARD,

			[EnumDescription("�C����")]
			GAMES_ROOM,

			[EnumDescription("�ѩ�")]
			STUDY,

			[EnumDescription("���U")]
			DINING_ROOM,

			[EnumDescription("���w")]
			GARAGE,

			[EnumDescription("���U")]
			LIVING_ROOM,

			[EnumDescription("�p��")]
			KITCHEN,

			[EnumDescription("�Ω�")]
			BED_ROOM,

			[EnumDescription("�D��")]
			BATH_ROOM
		}

		public KIND Kind { get; set; }
	}
}