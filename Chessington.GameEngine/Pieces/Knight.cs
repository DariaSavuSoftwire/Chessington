using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            foreach (var (row, col) in GameSettings.KnightMoves)
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