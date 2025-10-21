using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
         private (int , int)[] bishopMoves = { (-1, -1), (1, -1), (-1, 1), (1, 1)};
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            foreach(var (directionsRow, directionsCol) in bishopMoves)
            {
                for (int row = currentSquare.Row + directionsRow, col = currentSquare.Col + directionsCol;
                     board.IsSquareInBoard(Square.At(row, col));
                     row += directionsRow, col += directionsCol)
                {
                    Square nextSquare = Square.At(row, col);
                    if (board.GetPiece(nextSquare) == null)
                        moves.Add(nextSquare);
                }
            }

            return moves;
        }
    }
}