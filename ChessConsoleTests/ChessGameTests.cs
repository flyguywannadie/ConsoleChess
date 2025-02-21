using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessConsole.Pieces;

namespace ChessConsole.Tests
{
	[TestClass()]
	public class ChessGameTests
	{
		[TestMethod()]
		public void ChessBoard_NormalBuild_PieceCount_Test()
		{
			ChessBoard board = new ChessBoard(0);

			Assert.IsTrue(board.getPieces().Count == 32);
		}

		[TestMethod()]
		public void ChessBoard_960Build_PieceCount_Test()
		{
			ChessBoard board = new ChessBoard(1);

			Assert.IsTrue(board.getPieces().Count == 32);
		}

		[TestMethod()]
		public void ChessBoard_NormalBuild_MirroredPieces_Test()
		{
			ChessBoard board = new ChessBoard(0);

			for (int i = 0; i < 8; i++)
			{
				Assert.IsTrue(board.GetCell(i, 7).Piece.GetType() == board.GetCell(i, 0).Piece.GetType());
			}
		}

		[TestMethod()]
		public void ChessBoard_960Build_MirrorPieces_Test()
		{
			ChessBoard board = new ChessBoard(1);

			for (int i = 0; i < 8; i++)
			{
				Assert.IsTrue(board.GetCell(i, 7).Piece.GetType() == board.GetCell(i, 0).Piece.GetType());
			}
		}

		[TestMethod()]
		public void ChessBoard_960Build_RookPosition_Test()
		{
			ChessBoard board = new ChessBoard(1);

			int rook1location = -1, rook2location = -1, kinglocation = -1;

			kinglocation = board.GetKing(PlayerColor.White).Parent.X;

			for (int i = 0; i < 8; i++)
			{
				if (board.GetCell(i, 0).Piece.GetType() == typeof(Rook))
				{
					if (rook1location == -1)
					{
						rook1location = i;
					} else
					{
						rook2location = i;
					}
				}
			}

			Assert.IsTrue(rook1location < kinglocation && rook2location > kinglocation);
		}

		[TestMethod()]
		public void ChessBoard_960Build_BishopPosition_Test()
		{
			ChessBoard board = new ChessBoard(1);

			int bishop1location = -1, bishop2location = -1;

			for (int i = 0; i < 8; i++)
			{
				if (board.GetCell(i, 0).Piece.GetType() == typeof(Bishop))
				{
					if (bishop1location == -1)
					{
						bishop1location = i;
					}
					else
					{
						bishop2location = i;
					}
				}
			}

			Assert.IsFalse(bishop1location % 2 == bishop2location % 2);
		}
	}
}