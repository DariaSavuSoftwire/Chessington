using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            foreach (var (row, col) in GameSettings.KingMoves)
            {
                Square nextSquare = Square.At(currentSquare.Row + row, currentSquare.Col + col);
                if (board.IsSquareInBoard(nextSquare))
                {
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