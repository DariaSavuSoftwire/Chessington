using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        private (int, int )[] kingMoves = { (-1, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1) };

        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            foreach (var (row, col) in kingMoves)
            {
                Square nextSquare = Square.At(currentSquare.Row + row, currentSquare.Col + col);
                if (board.IsSquareInBoard(nextSquare) && board.GetPiece(nextSquare) == null)
                    moves.Add(nextSquare);
            }
            return moves;
        }
    }
}