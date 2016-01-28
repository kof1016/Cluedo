using System.Runtime.Remoting;

using Regulus.Utility;

namespace Common.Data
{
	public enum GRID_TYPE
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
		BATH_ROOM,

		[EnumDescription("�@��")]
		NORMAL,

		[EnumDescription("�L��")]
		INVALID,
	}
}