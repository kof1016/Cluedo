using System.Runtime.Remoting;

using Regulus.Utility;

namespace Common.Data
{
	public enum GRID_TYPE
	{
		[EnumDescription("庭院")]
		COURTYARD,

		[EnumDescription("遊戲室")]
		GAMES_ROOM,

		[EnumDescription("書房")]
		STUDY,

		[EnumDescription("飯廳")]
		DINING_ROOM,

		[EnumDescription("車庫")]
		GARAGE,

		[EnumDescription("客廳")]
		LIVING_ROOM,

		[EnumDescription("廚房")]
		KITCHEN,

		[EnumDescription("睡房")]
		BED_ROOM,

		[EnumDescription("浴室")]
		BATH_ROOM,

		[EnumDescription("一般")]
		NORMAL,

		[EnumDescription("無效")]
		INVALID,
	}
}