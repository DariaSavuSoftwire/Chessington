using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        private (int, int)[] knightMovement =
            { (-2, -1), (-2, 1), (-1, 2), (1, 2), (2, -1), (2, 1), (1, -2), (-1, -2) };

        public Knight(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            foreach (var (row, col) in knightMovement)
            {
                Square nextSquare = Square.At(currentSquare.Row + row, currentSquare.Col + col);
                if (board.IsSquareInBoard(nextSquare) && board.GetPiece(nextSquare) == null)
                {
                    moves.Add(nextSquare);
                }
            }

            return moves;
        }
    }
}