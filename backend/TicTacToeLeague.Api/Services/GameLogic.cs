using TicTacToeLeague.Api.Models;

namespace TicTacToeLeague.Api.Services;

/// <summary>
/// Pure game logic helpers. No persistence — safe to unit test.
/// </summary>
public static class GameLogic
{
    private static readonly int[][] WinLines =
    [
        [0, 1, 2], [3, 4, 5], [6, 7, 8],
        [0, 3, 6], [1, 4, 7], [2, 5, 8],
        [0, 4, 8], [2, 4, 6]
    ];

    public static bool IsValidMove(Mark[] board, int cellIndex)
    {
        return cellIndex is >= 0 and <= 8 && board[cellIndex] == Mark.None;
    }

    public static GameResult GetResult(Mark[] board)
    {
        foreach (var line in WinLines)
        {
            var a = board[line[0]];
            var b = board[line[1]];
            var c = board[line[2]];

            if (a != Mark.None && a == b && b == c)
            {
                return a == Mark.X ? GameResult.XWins : GameResult.OWins;
            }
        }

        return board.All(cell => cell != Mark.None) ? GameResult.Draw : GameResult.None;
    }

    public static Mark Opponent(Mark mark) => mark == Mark.X ? Mark.O : Mark.X;
}
