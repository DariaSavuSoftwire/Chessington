using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public int GetStartingRow(Player player)
        {
            return player == Player.White ? GameSettings.BoardSize - 1 : 1;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            bool hasNotMovedBefore = currentSquare.Row == GetStartingRow(Player);
            for (int move = 1; move <= 2; move++)
            {
                Square nextSquare = Player == Player.White
                    ? Square.At(currentSquare.Row - move, currentSquare.Col)
                    : Square.At(currentSquare.Row + move, currentSquare.Col);
                if (!board.IsSquareInBoard(nextSquare) || board.GetPiece(nextSquare) != null)
                    break;
                if (hasNotMovedBefore || move == 1)
                    moves.Add(nextSquare);
            }
            
            return moves;
        }
    }
}