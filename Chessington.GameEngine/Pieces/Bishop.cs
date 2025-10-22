using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            foreach (var (directionsRow, directionsCol) in GameSettings.BishopMoves)
            {
                for (int row = currentSquare.Row + directionsRow, col = currentSquare.Col + directionsCol;
                     board.IsSquareInBoard(Square.At(row, col));
                     row += directionsRow, col += directionsCol)
                {
                    Square nextSquare = Square.At(row, col);
                    if (board.GetPiece(nextSquare) != null)
                    {
                        if (board.GetPiece(nextSquare).Player != Player)
                            moves.Add(nextSquare);
                        break;
                    }
                    moves.Add(nextSquare);
                }
            }

            return moves;
        }
    }
}