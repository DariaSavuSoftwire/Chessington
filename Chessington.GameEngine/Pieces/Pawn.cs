using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            Square nextSquare = Player == Player.White
                ? Square.At(currentSquare.Row - 1, currentSquare.Col)
                : Square.At(currentSquare.Row + 1, currentSquare.Col);
            if (nextSquare.Row >= 0 && nextSquare.Row < GameSettings.BoardSize && board.GetPiece(nextSquare) == null)
                moves.Add(nextSquare);
            bool hasNotMovedBefore = Player == Player.White && currentSquare.Row == GameSettings.BoardSize - 1 ||
                                     Player == Player.Black && currentSquare.Row == 1;
            Square initialMoveUp = Player == Player.White
                ? Square.At(currentSquare.Row - 2, currentSquare.Col)
                : Square.At(currentSquare.Row + 2, currentSquare.Col);
            if (hasNotMovedBefore && initialMoveUp.Row >= 0 && initialMoveUp.Row < GameSettings.BoardSize &&
                board.GetPiece(initialMoveUp) == null)
                moves.Add(initialMoveUp);
            return moves;
        }
    }
}