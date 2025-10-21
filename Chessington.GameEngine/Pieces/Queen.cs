using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            int[] directionsRow = { -1, 1, -1, 1 };
            int[] directionsCol = { -1, -1, 1, 1 };
            
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            
            for (int i = 0; i < 4; i++)
            {
                for (int row = currentSquare.Row, col = currentSquare.Col;
                     board.IsSquareInBoard(Square.At(row, col));
                     row += directionsRow[i], col += directionsCol[i])
                {
                    Square nextSquare = Square.At(row, col);
                    if (board.GetPiece(nextSquare) == null)
                        moves.Add(nextSquare);
                }
            }

            for (int col = 0; col < GameSettings.BoardSize; col++)
            {
                Square nextSquare = Square.At(currentSquare.Row, col);
                if (board.GetPiece(nextSquare) == null)
                    moves.Add(nextSquare);
            }

            for (int row = 0; row < GameSettings.BoardSize; row++)
            {
                Square nextSquare = Square.At(row, currentSquare.Col);
                if (board.GetPiece(nextSquare) == null)
                    moves.Add(nextSquare);
            }

            return moves;
        }
    }
}