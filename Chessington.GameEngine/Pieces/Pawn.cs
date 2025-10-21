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
            bool hasNotMovedBefore = Player == Player.White && currentSquare.Row == GameSettings.BoardSize - 1 ||
                                     Player == Player.Black && currentSquare.Row == 1;
            for (int move = 1; move <= 2; move++)
            {
                Square nextSquare = Player == Player.White
                    ? Square.At(currentSquare.Row - move, currentSquare.Col)
                    : Square.At(currentSquare.Row + move, currentSquare.Col);
                if ((hasNotMovedBefore || move == 1) && board.IsSquareInBoard(nextSquare) &&
                    board.GetPiece(nextSquare) == null)
                    moves.Add(nextSquare);
            }

            return moves;
        }
    }
}