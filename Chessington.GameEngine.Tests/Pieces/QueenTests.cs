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
        public void Queen_CanMove_Laterally_And_Diagonally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);
            var expectedMoves = new List<Square>();
            
            foreach (var (directionsRow, directionsCol) in GameSettings.QueenMoves)
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
            moves.ShouldAllBeEquivalentTo(expectedMoves);
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

        [Test]
        public void Queen_CannnotPassThrough_OpposingPieces()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);
            var pieceToTake = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 6), pieceToTake);

            var moves = queen.GetAvailableMoves(board);
            moves.Should().NotContain(Square.At(4, 7));
        }

        [Test]
        public void Queen_CannnotPassThrough_FriendlyPieces()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);
            var friendlyPiece = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 6), friendlyPiece);

            var moves = queen.GetAvailableMoves(board);
            moves.Should().NotContain(Square.At(4, 7));
        }

        [Test]
        public void Queen_CanTake_OpposingPieces()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);
            var pieceToTake = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 6), pieceToTake);

            var moves = queen.GetAvailableMoves(board);
            moves.Should().Contain(Square.At(4, 6));
        }

        [Test]
        public void Queen_CannotTake_FriendlyPieces()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);
            var friendlyPiece = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 6), friendlyPiece);

            var moves = queen.GetAvailableMoves(board);
            moves.Should().NotContain(Square.At(4, 6));
        }
    }
}