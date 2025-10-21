using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            Square nextSquare = Player == Player.White
                ? Square.At(currentSquare.Row - 1, currentSquare.Col)
                : Square.At(currentSquare.Row + 1, currentSquare.Col);
            if (board.IsSquareInBoard(nextSquare) && board.GetPiece(nextSquare) == null)
                moves.Add(nextSquare);
            return moves;
        }
    }
}