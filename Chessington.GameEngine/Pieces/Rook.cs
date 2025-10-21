using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            for (int col = 0; col <GameSettings.BoardSize; col++)
            {
                Square nextSquare = Square.At(currentSquare.Row, col);
                if(board.GetPiece(nextSquare) == null)
                    moves.Add(nextSquare);
            }
            for (int row = 0; row <GameSettings.BoardSize; row++)
            {
                Square nextSquare = Square.At(row, currentSquare.Col);
                if(board.GetPiece(nextSquare) == null)
                    moves.Add(nextSquare);
            }
            return moves;
        }
    }
}