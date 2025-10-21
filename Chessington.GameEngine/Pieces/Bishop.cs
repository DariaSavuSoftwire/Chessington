using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        private bool IsPositionValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < GameSettings.BoardSize && col < GameSettings.BoardSize;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            int[] directionsRow = { -1, 1, -1, 1 };
            int[] directionsCol = { -1, -1, 1, 1 };
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            for (int i = 0; i < 4; i++)
            {
                for (int row = currentSquare.Row, col = currentSquare.Col;
                     IsPositionValid(row, col);
                     row += directionsRow[i], col += directionsCol[i])
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