using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class QueenTests
    {
        [Test]
        public void Queen_CanMove_Laterally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);
            var expectedMoves = new List<Square>();
            
            foreach (var (directionsRow, directionsCol) in GameSettings.RookMoves)
            {
                for (int row = 4 + directionsRow, col = 4 + directionsCol;
                     board.IsSquareInBoard(Square.At(row, col));
                     row += directionsRow, col += directionsCol)
                {
                    Square nextSquare = Square.At(row, col);
                    if (board.GetPiece(nextSquare) == null)
                        expectedMoves.Add(nextSquare);
                }
            }
            moves.Should().Contain(expectedMoves);
        }

        [Test]
        public void Queen_CanMove_Diagonally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);
            var expectedMoves = new List<Square>();
            foreach (var (directionsRow, directionsCol) in GameSettings.BishopMoves)
            {
                for (int row = 4 + directionsRow, col = 4 + directionsCol;
                     board.IsSquareInBoard(Square.At(row, col));
                     row += directionsRow, col += directionsCol)
                {
                    Square nextSquare = Square.At(row, col);
                    if (board.GetPiece(nextSquare) == null)
                        expectedMoves.Add(nextSquare);
                }
            }
            
            moves.Should().Contain(expectedMoves);
        }

        [Test]
        public void Queen_CannotMakeAnyOtherMoves()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);
            
            moves.Should().HaveCount(27);
        }
    }
}