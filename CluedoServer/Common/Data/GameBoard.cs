using System.Linq;

using ProtoBuf;

namespace Common.Data
{
	public class GameBoard
	{
		public readonly int Height = 23;

		public readonly int Width = 22;

		public GridData[] Board { get; set; }

		public GameBoard()
		{
			_CreateAllGrid();
			_CreateLink();
		}

		private void _CreateLink()
		{
			for(var i = 0; i < Board.Length; ++i)
			{
				if(Board[i].GridType == GRID_TYPE.INVALID)
				{
					continue;
				}

				if(i - Width > 0)
				{
					Board[i].Neighbors.Grids[(int)Neighbor.DIRECTION.UP] = Board[i - Width];
					Board[i - Width].Neighbors.Grids[(int)Neighbor.DIRECTION.DOWN] = Board[i];
				}

				if(i + 1 < Width)
				{
					Board[i].Neighbors.Grids[(int)Neighbor.DIRECTION.RIGHT] = Board[i + 1];
					Board[i + 1].Neighbors.Grids[(int)Neighbor.DIRECTION.LEFT] = Board[i];
				}
			}
		}

		private void _CreateAllGrid()
		{
			Board = new[]
			{
				//�Ĥ@��
				new GridData(0, 0, GRID_TYPE.INVALID),
				new GridData(1, 0, GRID_TYPE.INVALID),
				new GridData(2, 0, GRID_TYPE.INVALID),
				new GridData(3, 0, GRID_TYPE.INVALID),
				new GridData(4, 0, GRID_TYPE.INVALID),
				new GridData(5, 0, GRID_TYPE.INVALID),
				new GridData(6, 0, GRID_TYPE.INVALID),
				new GridData(7, 0, GRID_TYPE.NORMAL),
				new GridData(8, 0, GRID_TYPE.NORMAL),
				new GridData(9, 0, GRID_TYPE.INVALID),
				new GridData(10, 0, GRID_TYPE.INVALID),
				new GridData(11, 0, GRID_TYPE.INVALID),
				new GridData(12, 0, GRID_TYPE.INVALID),
				new GridData(13, 0, GRID_TYPE.INVALID),
				new GridData(14, 0, GRID_TYPE.INVALID),
				new GridData(15, 0, GRID_TYPE.NORMAL),
				new GridData(16, 0, GRID_TYPE.NORMAL),
				new GridData(17, 0, GRID_TYPE.INVALID),
				new GridData(18, 0, GRID_TYPE.INVALID),
				new GridData(19, 0, GRID_TYPE.INVALID),
				new GridData(20, 0, GRID_TYPE.INVALID),
				new GridData(21, 0, GRID_TYPE.INVALID),

				//�ĤG��
				new GridData(0, 1, GRID_TYPE.INVALID),
				new GridData(1, 1, GRID_TYPE.INVALID),
				new GridData(2, 1, GRID_TYPE.INVALID),
				new GridData(3, 1, GRID_TYPE.INVALID),
				new GridData(4, 1, GRID_TYPE.INVALID),
				new GridData(5, 1, GRID_TYPE.INVALID),
				new GridData(6, 1, GRID_TYPE.INVALID),
				new GridData(7, 1, GRID_TYPE.NORMAL),
				new GridData(8, 1, GRID_TYPE.NORMAL),
				new GridData(9, 1, GRID_TYPE.INVALID),
				new GridData(10, 1, GRID_TYPE.INVALID),
				new GridData(11, 1, GRID_TYPE.INVALID),
				new GridData(12, 1, GRID_TYPE.INVALID),
				new GridData(13, 1, GRID_TYPE.INVALID),
				new GridData(14, 1, GRID_TYPE.INVALID),
				new GridData(15, 1, GRID_TYPE.NORMAL),
				new GridData(16, 1, GRID_TYPE.NORMAL),
				new GridData(17, 1, GRID_TYPE.INVALID),
				new GridData(18, 1, GRID_TYPE.INVALID),
				new GridData(19, 1, GRID_TYPE.INVALID),
				new GridData(20, 1, GRID_TYPE.INVALID),
				new GridData(21, 1, GRID_TYPE.INVALID),

				//�ĤT��
				new GridData(0, 2, GRID_TYPE.INVALID),
				new GridData(1, 2, GRID_TYPE.INVALID),
				new GridData(2, 2, GRID_TYPE.INVALID),
				new GridData(3, 2, GRID_TYPE.INVALID),
				new GridData(4, 2, GRID_TYPE.INVALID),
				new GridData(5, 2, GRID_TYPE.INVALID),
				new GridData(6, 2, GRID_TYPE.INVALID),
				new GridData(7, 2, GRID_TYPE.NORMAL),
				new GridData(8, 2, GRID_TYPE.NORMAL),
				new GridData(9, 2, GRID_TYPE.INVALID),
				new GridData(10, 2, GRID_TYPE.INVALID),
				new GridData(11, 2, GRID_TYPE.INVALID),
				new GridData(12, 2, GRID_TYPE.INVALID),
				new GridData(13, 2, GRID_TYPE.INVALID),
				new GridData(14, 2, GRID_TYPE.INVALID),
				new GridData(15, 2, GRID_TYPE.NORMAL),
				new GridData(16, 2, GRID_TYPE.NORMAL),
				new GridData(17, 2, GRID_TYPE.INVALID),
				new GridData(18, 2, GRID_TYPE.INVALID),
				new GridData(19, 2, GRID_TYPE.INVALID),
				new GridData(20, 2, GRID_TYPE.INVALID),
				new GridData(21, 2, GRID_TYPE.INVALID),

				//�ĥ|��
				new GridData(0, 3, GRID_TYPE.NORMAL),
				new GridData(1, 3, GRID_TYPE.NORMAL),
				new GridData(2, 3, GRID_TYPE.NORMAL),
				new GridData(3, 3, GRID_TYPE.NORMAL),
				new GridData(4, 3, GRID_TYPE.NORMAL),
				new GridData(5, 3, GRID_TYPE.NORMAL),
				new GridData(6, 3, GRID_TYPE.NORMAL),
				new GridData(7, 3, GRID_TYPE.NORMAL),
				new GridData(8, 3, GRID_TYPE.NORMAL),
				new GridData(9, 3, GRID_TYPE.INVALID),
				new GridData(10, 3, GRID_TYPE.INVALID),
				new GridData(11, 3, GRID_TYPE.INVALID),
				new GridData(12, 3, GRID_TYPE.INVALID),
				new GridData(13, 3, GRID_TYPE.INVALID),
				new GridData(14, 3, GRID_TYPE.INVALID),
				new GridData(15, 3, GRID_TYPE.NORMAL),
				new GridData(16, 3, GRID_TYPE.NORMAL),
				new GridData(17, 3, GRID_TYPE.INVALID),
				new GridData(18, 3, GRID_TYPE.INVALID),
				new GridData(19, 3, GRID_TYPE.INVALID),
				new GridData(20, 3, GRID_TYPE.INVALID),
				new GridData(21, 3, GRID_TYPE.INVALID),

				//�Ĥ���
				new GridData(0, 4, GRID_TYPE.NORMAL),
				new GridData(1, 4, GRID_TYPE.NORMAL),
				new GridData(2, 4, GRID_TYPE.NORMAL),
				new GridData(3, 4, GRID_TYPE.NORMAL),
				new GridData(4, 4, GRID_TYPE.NORMAL),
				new GridData(5, 4, GRID_TYPE.NORMAL),
				new GridData(6, 4, GRID_TYPE.NORMAL),
				new GridData(7, 4, GRID_TYPE.NORMAL),
				new GridData(8, 4, GRID_TYPE.NORMAL),
				new GridData(9, 4, GRID_TYPE.INVALID),
				new GridData(10, 4, GRID_TYPE.INVALID),
				new GridData(11, 4, GRID_TYPE.INVALID),
				new GridData(12, 4, GRID_TYPE.INVALID),
				new GridData(13, 4, GRID_TYPE.INVALID),
				new GridData(14, 4, GRID_TYPE.INVALID),
				new GridData(15, 4, GRID_TYPE.NORMAL),
				new GridData(16, 4, GRID_TYPE.NORMAL),
				new GridData(17, 4, GRID_TYPE.INVALID),
				new GridData(18, 4, GRID_TYPE.INVALID),
				new GridData(19, 4, GRID_TYPE.INVALID),
				new GridData(20, 4, GRID_TYPE.INVALID),
				new GridData(21, 4, GRID_TYPE.INVALID),

				//�Ĥ���
				new GridData(0, 5, GRID_TYPE.INVALID),
				new GridData(1, 5, GRID_TYPE.INVALID),
				new GridData(2, 5, GRID_TYPE.INVALID),
				new GridData(3, 5, GRID_TYPE.INVALID),
				new GridData(4, 5, GRID_TYPE.INVALID),
				new GridData(5, 5, GRID_TYPE.NORMAL),
				new GridData(6, 5, GRID_TYPE.NORMAL),
				new GridData(7, 5, GRID_TYPE.NORMAL),
				new GridData(8, 5, GRID_TYPE.NORMAL),
				new GridData(9, 5, GRID_TYPE.INVALID),
				new GridData(10, 5, GRID_TYPE.INVALID),
				new GridData(11, 5, GRID_TYPE.INVALID),
				new GridData(12, 5, GRID_TYPE.INVALID),
				new GridData(13, 5, GRID_TYPE.INVALID),
				new GridData(14, 5, GRID_TYPE.INVALID),
				new GridData(15, 5, GRID_TYPE.NORMAL),
				new GridData(16, 5, GRID_TYPE.NORMAL),
				new GridData(17, 5, GRID_TYPE.NORMAL),
				new GridData(18, 5, GRID_TYPE.NORMAL),
				new GridData(19, 5, GRID_TYPE.NORMAL),
				new GridData(20, 5, GRID_TYPE.NORMAL),
				new GridData(21, 5, GRID_TYPE.NORMAL),

				//�ĤC��
				new GridData(0, 6, GRID_TYPE.INVALID),
				new GridData(1, 6, GRID_TYPE.INVALID),
				new GridData(2, 6, GRID_TYPE.INVALID),
				new GridData(3, 6, GRID_TYPE.INVALID),
				new GridData(4, 6, GRID_TYPE.INVALID),
				new GridData(5, 6, GRID_TYPE.INVALID),
				new GridData(6, 6, GRID_TYPE.NORMAL),
				new GridData(7, 6, GRID_TYPE.NORMAL),
				new GridData(8, 6, GRID_TYPE.NORMAL),
				new GridData(9, 6, GRID_TYPE.NORMAL),
				new GridData(10, 6, GRID_TYPE.NORMAL),
				new GridData(11, 6, GRID_TYPE.NORMAL),
				new GridData(12, 6, GRID_TYPE.NORMAL),
				new GridData(13, 6, GRID_TYPE.NORMAL),
				new GridData(14, 6, GRID_TYPE.NORMAL),
				new GridData(15, 6, GRID_TYPE.NORMAL),
				new GridData(16, 6, GRID_TYPE.NORMAL),
				new GridData(17, 6, GRID_TYPE.NORMAL),
				new GridData(18, 6, GRID_TYPE.NORMAL),
				new GridData(19, 6, GRID_TYPE.NORMAL),
				new GridData(20, 6, GRID_TYPE.NORMAL),
				new GridData(21, 6, GRID_TYPE.NORMAL),

				//�ĤK��
				new GridData(0, 7, GRID_TYPE.INVALID),
				new GridData(1, 7, GRID_TYPE.INVALID),
				new GridData(2, 7, GRID_TYPE.INVALID),
				new GridData(3, 7, GRID_TYPE.INVALID),
				new GridData(4, 7, GRID_TYPE.INVALID),
				new GridData(5, 7, GRID_TYPE.INVALID),
				new GridData(6, 7, GRID_TYPE.NORMAL),
				new GridData(7, 7, GRID_TYPE.NORMAL),
				new GridData(8, 7, GRID_TYPE.INVALID),
				new GridData(9, 7, GRID_TYPE.INVALID),
				new GridData(10, 7, GRID_TYPE.INVALID),
				new GridData(11, 7, GRID_TYPE.INVALID),
				new GridData(12, 7, GRID_TYPE.INVALID),
				new GridData(13, 7, GRID_TYPE.NORMAL),
				new GridData(14, 7, GRID_TYPE.NORMAL),
				new GridData(15, 7, GRID_TYPE.NORMAL),
				new GridData(16, 7, GRID_TYPE.NORMAL),
				new GridData(17, 7, GRID_TYPE.NORMAL),
				new GridData(18, 7, GRID_TYPE.NORMAL),
				new GridData(19, 7, GRID_TYPE.NORMAL),
				new GridData(20, 7, GRID_TYPE.NORMAL),
				new GridData(21, 7, GRID_TYPE.NORMAL),

				//�ĤE��
				new GridData(0, 8, GRID_TYPE.INVALID),
				new GridData(1, 8, GRID_TYPE.INVALID),
				new GridData(2, 8, GRID_TYPE.INVALID),
				new GridData(3, 8, GRID_TYPE.INVALID),
				new GridData(4, 8, GRID_TYPE.INVALID),
				new GridData(5, 8, GRID_TYPE.INVALID),
				new GridData(6, 8, GRID_TYPE.NORMAL),
				new GridData(7, 8, GRID_TYPE.NORMAL),
				new GridData(8, 8, GRID_TYPE.INVALID),
				new GridData(9, 8, GRID_TYPE.INVALID),
				new GridData(10, 8, GRID_TYPE.INVALID),
				new GridData(11, 8, GRID_TYPE.INVALID),
				new GridData(12, 8, GRID_TYPE.INVALID),
				new GridData(13, 8, GRID_TYPE.NORMAL),
				new GridData(14, 8, GRID_TYPE.NORMAL),
				new GridData(15, 8, GRID_TYPE.INVALID),
				new GridData(16, 8, GRID_TYPE.INVALID),
				new GridData(17, 8, GRID_TYPE.INVALID),
				new GridData(18, 8, GRID_TYPE.INVALID),
				new GridData(19, 8, GRID_TYPE.INVALID),
				new GridData(20, 8, GRID_TYPE.INVALID),
				new GridData(21, 8, GRID_TYPE.INVALID),

				//�ĤQ��
				new GridData(0, 9, GRID_TYPE.INVALID),
				new GridData(1, 9, GRID_TYPE.INVALID),
				new GridData(2, 9, GRID_TYPE.INVALID),
				new GridData(3, 9, GRID_TYPE.INVALID),
				new GridData(4, 9, GRID_TYPE.INVALID),
				new GridData(5, 9, GRID_TYPE.NORMAL),
				new GridData(6, 9, GRID_TYPE.NORMAL),
				new GridData(7, 9, GRID_TYPE.NORMAL),
				new GridData(8, 9, GRID_TYPE.INVALID),
				new GridData(9, 9, GRID_TYPE.INVALID),
				new GridData(10, 9, GRID_TYPE.INVALID),
				new GridData(11, 9, GRID_TYPE.INVALID),
				new GridData(12, 9, GRID_TYPE.INVALID),
				new GridData(13, 9, GRID_TYPE.NORMAL),
				new GridData(14, 9, GRID_TYPE.NORMAL),
				new GridData(15, 9, GRID_TYPE.INVALID),
				new GridData(16, 9, GRID_TYPE.INVALID),
				new GridData(17, 9, GRID_TYPE.INVALID),
				new GridData(18, 9, GRID_TYPE.INVALID),
				new GridData(19, 9, GRID_TYPE.INVALID),
				new GridData(20, 9, GRID_TYPE.INVALID),
				new GridData(21, 9, GRID_TYPE.INVALID),

				//��11��
				new GridData(0, 10, GRID_TYPE.NORMAL),
				new GridData(1, 10, GRID_TYPE.NORMAL),
				new GridData(2, 10, GRID_TYPE.NORMAL),
				new GridData(3, 10, GRID_TYPE.NORMAL),
				new GridData(4, 10, GRID_TYPE.NORMAL),
				new GridData(5, 10, GRID_TYPE.NORMAL),
				new GridData(6, 10, GRID_TYPE.NORMAL),
				new GridData(7, 10, GRID_TYPE.NORMAL),
				new GridData(8, 10, GRID_TYPE.INVALID),
				new GridData(9, 10, GRID_TYPE.INVALID),
				new GridData(10, 10, GRID_TYPE.INVALID),
				new GridData(11, 10, GRID_TYPE.INVALID),
				new GridData(12, 10, GRID_TYPE.INVALID),
				new GridData(13, 10, GRID_TYPE.NORMAL),
				new GridData(14, 10, GRID_TYPE.NORMAL),
				new GridData(15, 10, GRID_TYPE.INVALID),
				new GridData(16, 10, GRID_TYPE.INVALID),
				new GridData(17, 10, GRID_TYPE.INVALID),
				new GridData(18, 10, GRID_TYPE.INVALID),
				new GridData(19, 10, GRID_TYPE.INVALID),
				new GridData(20, 10, GRID_TYPE.INVALID),
				new GridData(21, 10, GRID_TYPE.INVALID),

				//��12��
				new GridData(0, 11, GRID_TYPE.INVALID),
				new GridData(1, 11, GRID_TYPE.INVALID),
				new GridData(2, 11, GRID_TYPE.INVALID),
				new GridData(3, 11, GRID_TYPE.INVALID),
				new GridData(4, 11, GRID_TYPE.INVALID),
				new GridData(5, 11, GRID_TYPE.NORMAL),
				new GridData(6, 11, GRID_TYPE.NORMAL),
				new GridData(7, 11, GRID_TYPE.NORMAL),
				new GridData(8, 11, GRID_TYPE.INVALID),
				new GridData(9, 11, GRID_TYPE.INVALID),
				new GridData(10, 11, GRID_TYPE.INVALID),
				new GridData(11, 11, GRID_TYPE.INVALID),
				new GridData(12, 11, GRID_TYPE.INVALID),
				new GridData(13, 11, GRID_TYPE.NORMAL),
				new GridData(14, 11, GRID_TYPE.NORMAL),
				new GridData(15, 11, GRID_TYPE.INVALID),
				new GridData(16, 11, GRID_TYPE.INVALID),
				new GridData(17, 11, GRID_TYPE.INVALID),
				new GridData(18, 11, GRID_TYPE.INVALID),
				new GridData(19, 11, GRID_TYPE.INVALID),
				new GridData(20, 11, GRID_TYPE.INVALID),
				new GridData(21, 11, GRID_TYPE.INVALID),

				//��13��
				new GridData(0, 12, GRID_TYPE.INVALID),
				new GridData(1, 12, GRID_TYPE.INVALID),
				new GridData(2, 12, GRID_TYPE.INVALID),
				new GridData(3, 12, GRID_TYPE.INVALID),
				new GridData(4, 12, GRID_TYPE.INVALID),
				new GridData(5, 12, GRID_TYPE.NORMAL),
				new GridData(6, 12, GRID_TYPE.NORMAL),
				new GridData(7, 12, GRID_TYPE.NORMAL),
				new GridData(8, 12, GRID_TYPE.INVALID),
				new GridData(9, 12, GRID_TYPE.INVALID),
				new GridData(10, 12, GRID_TYPE.INVALID),
				new GridData(11, 12, GRID_TYPE.INVALID),
				new GridData(12, 12, GRID_TYPE.INVALID),
				new GridData(13, 12, GRID_TYPE.NORMAL),
				new GridData(14, 12, GRID_TYPE.NORMAL),
				new GridData(15, 12, GRID_TYPE.INVALID),
				new GridData(16, 12, GRID_TYPE.INVALID),
				new GridData(17, 12, GRID_TYPE.INVALID),
				new GridData(18, 12, GRID_TYPE.INVALID),
				new GridData(19, 12, GRID_TYPE.INVALID),
				new GridData(20, 12, GRID_TYPE.INVALID),
				new GridData(21, 12, GRID_TYPE.INVALID),

				//��14��
				new GridData(0, 13, GRID_TYPE.INVALID),
				new GridData(1, 13, GRID_TYPE.INVALID),
				new GridData(2, 13, GRID_TYPE.INVALID),
				new GridData(3, 13, GRID_TYPE.INVALID),
				new GridData(4, 13, GRID_TYPE.INVALID),
				new GridData(5, 13, GRID_TYPE.NORMAL),
				new GridData(6, 13, GRID_TYPE.NORMAL),
				new GridData(7, 13, GRID_TYPE.NORMAL),
				new GridData(8, 13, GRID_TYPE.INVALID),
				new GridData(9, 13, GRID_TYPE.INVALID),
				new GridData(10, 13, GRID_TYPE.INVALID),
				new GridData(11, 13, GRID_TYPE.INVALID),
				new GridData(12, 13, GRID_TYPE.INVALID),
				new GridData(13, 13, GRID_TYPE.NORMAL),
				new GridData(14, 13, GRID_TYPE.NORMAL),
				new GridData(15, 13, GRID_TYPE.INVALID),
				new GridData(16, 13, GRID_TYPE.INVALID),
				new GridData(17, 13, GRID_TYPE.INVALID),
				new GridData(18, 13, GRID_TYPE.INVALID),
				new GridData(19, 13, GRID_TYPE.INVALID),
				new GridData(20, 13, GRID_TYPE.INVALID),
				new GridData(21, 13, GRID_TYPE.INVALID),

				//��15��
				new GridData(0, 14, GRID_TYPE.INVALID),
				new GridData(1, 14, GRID_TYPE.INVALID),
				new GridData(2, 14, GRID_TYPE.INVALID),
				new GridData(3, 14, GRID_TYPE.INVALID),
				new GridData(4, 14, GRID_TYPE.INVALID),
				new GridData(5, 14, GRID_TYPE.NORMAL),
				new GridData(6, 14, GRID_TYPE.NORMAL),
				new GridData(7, 14, GRID_TYPE.NORMAL),
				new GridData(8, 14, GRID_TYPE.NORMAL),
				new GridData(9, 14, GRID_TYPE.NORMAL),
				new GridData(10, 14, GRID_TYPE.NORMAL),
				new GridData(11, 14, GRID_TYPE.NORMAL),
				new GridData(12, 14, GRID_TYPE.NORMAL),
				new GridData(13, 14, GRID_TYPE.NORMAL),
				new GridData(14, 14, GRID_TYPE.NORMAL),
				new GridData(15, 14, GRID_TYPE.NORMAL),
				new GridData(16, 14, GRID_TYPE.NORMAL),
				new GridData(17, 14, GRID_TYPE.NORMAL),
				new GridData(18, 14, GRID_TYPE.INVALID),
				new GridData(19, 14, GRID_TYPE.INVALID),
				new GridData(20, 14, GRID_TYPE.INVALID),
				new GridData(21, 14, GRID_TYPE.INVALID),

				//��16��
				new GridData(0, 15, GRID_TYPE.INVALID),
				new GridData(1, 15, GRID_TYPE.INVALID),
				new GridData(2, 15, GRID_TYPE.INVALID),
				new GridData(3, 15, GRID_TYPE.INVALID),
				new GridData(4, 15, GRID_TYPE.INVALID),
				new GridData(5, 15, GRID_TYPE.NORMAL),
				new GridData(6, 15, GRID_TYPE.NORMAL),
				new GridData(7, 15, GRID_TYPE.NORMAL),
				new GridData(8, 15, GRID_TYPE.NORMAL),
				new GridData(9, 15, GRID_TYPE.NORMAL),
				new GridData(10, 15, GRID_TYPE.NORMAL),
				new GridData(11, 15, GRID_TYPE.NORMAL),
				new GridData(12, 15, GRID_TYPE.NORMAL),
				new GridData(13, 15, GRID_TYPE.NORMAL),
				new GridData(14, 15, GRID_TYPE.NORMAL),
				new GridData(15, 15, GRID_TYPE.NORMAL),
				new GridData(16, 15, GRID_TYPE.NORMAL),
				new GridData(17, 15, GRID_TYPE.NORMAL),
				new GridData(18, 15, GRID_TYPE.INVALID),
				new GridData(19, 15, GRID_TYPE.INVALID),
				new GridData(20, 15, GRID_TYPE.INVALID),
				new GridData(21, 15, GRID_TYPE.INVALID),

				//��17��
				new GridData(0, 16, GRID_TYPE.NORMAL),
				new GridData(1, 16, GRID_TYPE.NORMAL),
				new GridData(2, 16, GRID_TYPE.NORMAL),
				new GridData(3, 16, GRID_TYPE.NORMAL),
				new GridData(4, 16, GRID_TYPE.NORMAL),
				new GridData(5, 16, GRID_TYPE.NORMAL),
				new GridData(6, 16, GRID_TYPE.NORMAL),
				new GridData(7, 16, GRID_TYPE.INVALID),
				new GridData(8, 16, GRID_TYPE.INVALID),
				new GridData(9, 16, GRID_TYPE.INVALID),
				new GridData(10, 16, GRID_TYPE.INVALID),
				new GridData(11, 16, GRID_TYPE.INVALID),
				new GridData(12, 16, GRID_TYPE.INVALID),
				new GridData(13, 16, GRID_TYPE.INVALID),
				new GridData(14, 16, GRID_TYPE.INVALID),
				new GridData(15, 16, GRID_TYPE.NORMAL),
				new GridData(16, 16, GRID_TYPE.NORMAL),
				new GridData(17, 16, GRID_TYPE.NORMAL),
				new GridData(18, 16, GRID_TYPE.NORMAL),
				new GridData(19, 16, GRID_TYPE.NORMAL),
				new GridData(20, 16, GRID_TYPE.NORMAL),
				new GridData(21, 16, GRID_TYPE.NORMAL),

				//��18��
				new GridData(0, 17, GRID_TYPE.NORMAL),
				new GridData(1, 17, GRID_TYPE.NORMAL),
				new GridData(2, 17, GRID_TYPE.NORMAL),
				new GridData(3, 17, GRID_TYPE.NORMAL),
				new GridData(4, 17, GRID_TYPE.NORMAL),
				new GridData(5, 17, GRID_TYPE.NORMAL),
				new GridData(6, 17, GRID_TYPE.NORMAL),
				new GridData(7, 17, GRID_TYPE.INVALID),
				new GridData(8, 17, GRID_TYPE.INVALID),
				new GridData(9, 17, GRID_TYPE.INVALID),
				new GridData(10, 17, GRID_TYPE.INVALID),
				new GridData(11, 17, GRID_TYPE.INVALID),
				new GridData(12, 17, GRID_TYPE.INVALID),
				new GridData(13, 17, GRID_TYPE.INVALID),
				new GridData(14, 17, GRID_TYPE.INVALID),
				new GridData(15, 17, GRID_TYPE.NORMAL),
				new GridData(16, 17, GRID_TYPE.NORMAL),
				new GridData(17, 17, GRID_TYPE.INVALID),
				new GridData(18, 17, GRID_TYPE.INVALID),
				new GridData(19, 17, GRID_TYPE.INVALID),
				new GridData(20, 17, GRID_TYPE.INVALID),
				new GridData(21, 17, GRID_TYPE.INVALID),

				//��19��
				new GridData(0, 18, GRID_TYPE.INVALID),
				new GridData(1, 18, GRID_TYPE.INVALID),
				new GridData(2, 18, GRID_TYPE.INVALID),
				new GridData(3, 18, GRID_TYPE.INVALID),
				new GridData(4, 18, GRID_TYPE.NORMAL),
				new GridData(5, 18, GRID_TYPE.NORMAL),
				new GridData(6, 18, GRID_TYPE.NORMAL),
				new GridData(7, 18, GRID_TYPE.INVALID),
				new GridData(8, 18, GRID_TYPE.INVALID),
				new GridData(9, 18, GRID_TYPE.INVALID),
				new GridData(10, 18, GRID_TYPE.INVALID),
				new GridData(11, 18, GRID_TYPE.INVALID),
				new GridData(12, 18, GRID_TYPE.INVALID),
				new GridData(13, 18, GRID_TYPE.INVALID),
				new GridData(14, 18, GRID_TYPE.INVALID),
				new GridData(15, 18, GRID_TYPE.NORMAL),
				new GridData(16, 18, GRID_TYPE.NORMAL),
				new GridData(17, 18, GRID_TYPE.INVALID),
				new GridData(18, 18, GRID_TYPE.INVALID),
				new GridData(19, 18, GRID_TYPE.INVALID),
				new GridData(20, 18, GRID_TYPE.INVALID),
				new GridData(21, 18, GRID_TYPE.INVALID),

				//��20��
				new GridData(0, 19, GRID_TYPE.INVALID),
				new GridData(1, 19, GRID_TYPE.INVALID),
				new GridData(2, 19, GRID_TYPE.INVALID),
				new GridData(3, 19, GRID_TYPE.INVALID),
				new GridData(4, 19, GRID_TYPE.INVALID),
				new GridData(5, 19, GRID_TYPE.NORMAL),
				new GridData(6, 19, GRID_TYPE.NORMAL),
				new GridData(7, 19, GRID_TYPE.INVALID),
				new GridData(8, 19, GRID_TYPE.INVALID),
				new GridData(9, 19, GRID_TYPE.INVALID),
				new GridData(10, 19, GRID_TYPE.INVALID),
				new GridData(11, 19, GRID_TYPE.INVALID),
				new GridData(12, 19, GRID_TYPE.INVALID),
				new GridData(13, 19, GRID_TYPE.INVALID),
				new GridData(14, 19, GRID_TYPE.INVALID),
				new GridData(15, 19, GRID_TYPE.NORMAL),
				new GridData(16, 19, GRID_TYPE.NORMAL),
				new GridData(17, 19, GRID_TYPE.INVALID),
				new GridData(18, 19, GRID_TYPE.INVALID),
				new GridData(19, 19, GRID_TYPE.INVALID),
				new GridData(20, 19, GRID_TYPE.INVALID),
				new GridData(21, 19, GRID_TYPE.INVALID),

				//��21��
				new GridData(0, 20, GRID_TYPE.INVALID),
				new GridData(1, 20, GRID_TYPE.INVALID),
				new GridData(2, 20, GRID_TYPE.INVALID),
				new GridData(3, 20, GRID_TYPE.INVALID),
				new GridData(4, 20, GRID_TYPE.INVALID),
				new GridData(5, 20, GRID_TYPE.NORMAL),
				new GridData(6, 20, GRID_TYPE.NORMAL),
				new GridData(7, 20, GRID_TYPE.INVALID),
				new GridData(8, 20, GRID_TYPE.INVALID),
				new GridData(9, 20, GRID_TYPE.INVALID),
				new GridData(10, 20, GRID_TYPE.INVALID),
				new GridData(11, 20, GRID_TYPE.INVALID),
				new GridData(12, 20, GRID_TYPE.INVALID),
				new GridData(13, 20, GRID_TYPE.INVALID),
				new GridData(14, 20, GRID_TYPE.INVALID),
				new GridData(15, 20, GRID_TYPE.NORMAL),
				new GridData(16, 20, GRID_TYPE.NORMAL),
				new GridData(17, 20, GRID_TYPE.INVALID),
				new GridData(18, 20, GRID_TYPE.INVALID),
				new GridData(19, 20, GRID_TYPE.INVALID),
				new GridData(20, 20, GRID_TYPE.INVALID),
				new GridData(21, 20, GRID_TYPE.INVALID),

				//��22��
				new GridData(0, 21, GRID_TYPE.INVALID),
				new GridData(1, 21, GRID_TYPE.INVALID),
				new GridData(2, 21, GRID_TYPE.INVALID),
				new GridData(3, 21, GRID_TYPE.INVALID),
				new GridData(4, 21, GRID_TYPE.INVALID),
				new GridData(5, 21, GRID_TYPE.NORMAL),
				new GridData(6, 21, GRID_TYPE.NORMAL),
				new GridData(7, 21, GRID_TYPE.INVALID),
				new GridData(8, 21, GRID_TYPE.INVALID),
				new GridData(9, 21, GRID_TYPE.INVALID),
				new GridData(10, 21, GRID_TYPE.INVALID),
				new GridData(11, 21, GRID_TYPE.INVALID),
				new GridData(12, 21, GRID_TYPE.INVALID),
				new GridData(13, 21, GRID_TYPE.INVALID),
				new GridData(14, 21, GRID_TYPE.INVALID),
				new GridData(15, 21, GRID_TYPE.NORMAL),
				new GridData(16, 21, GRID_TYPE.NORMAL),
				new GridData(17, 21, GRID_TYPE.INVALID),
				new GridData(18, 21, GRID_TYPE.INVALID),
				new GridData(19, 21, GRID_TYPE.INVALID),
				new GridData(20, 21, GRID_TYPE.INVALID),
				new GridData(21, 21, GRID_TYPE.INVALID),

				//��23��
				new GridData(0, 22, GRID_TYPE.INVALID),
				new GridData(1, 22, GRID_TYPE.INVALID),
				new GridData(2, 22, GRID_TYPE.INVALID),
				new GridData(3, 22, GRID_TYPE.INVALID),
				new GridData(4, 22, GRID_TYPE.INVALID),
				new GridData(5, 22, GRID_TYPE.INVALID),
				new GridData(6, 22, GRID_TYPE.NORMAL),
				new GridData(7, 22, GRID_TYPE.NORMAL),
				new GridData(8, 22, GRID_TYPE.NORMAL),
				new GridData(9, 22, GRID_TYPE.INVALID),
				new GridData(10, 22, GRID_TYPE.INVALID),
				new GridData(11, 22, GRID_TYPE.INVALID),
				new GridData(12, 22, GRID_TYPE.INVALID),
				new GridData(13, 22, GRID_TYPE.NORMAL),
				new GridData(14, 22, GRID_TYPE.NORMAL),
				new GridData(15, 22, GRID_TYPE.NORMAL),
				new GridData(16, 22, GRID_TYPE.INVALID),
				new GridData(17, 22, GRID_TYPE.INVALID),
				new GridData(18, 22, GRID_TYPE.INVALID),
				new GridData(19, 22, GRID_TYPE.INVALID),
				new GridData(20, 22, GRID_TYPE.INVALID),
				new GridData(21, 22, GRID_TYPE.INVALID)
			};
		}
	}
}