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
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            
            foreach(var (moveRow,moveCol) in GameSettings.QueenMoves)
            {
                for (int row = currentSquare.Row+moveRow, col = currentSquare.Col+moveCol;
                     board.IsSquareInBoard(Square.At(row, col));
                     row += moveRow, col += moveCol)
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