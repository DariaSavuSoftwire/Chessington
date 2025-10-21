using System.Linq;

namespace Chessington.GameEngine
{
    public static class GameSettings
    {
        public const int BoardSize = 8;
        public static (int, int)[] RookMoves = { (-1, 0), (1, 0), (0, 1), (0, -1) };
        public static (int, int)[] BishopMoves = { (-1, -1), (1, -1), (-1, 1), (1, 1) };
        public static (int, int )[] QueenMoves = RookMoves.Concat(BishopMoves).ToArray();
    }
}