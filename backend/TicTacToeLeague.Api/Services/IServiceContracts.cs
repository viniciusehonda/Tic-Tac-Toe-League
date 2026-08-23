using TicTacToeLeague.Api.Models;

namespace TicTacToeLeague.Api.Services;

public interface IAuthService
{
    Task<Player?> RegisterAsync(string username, string email, string password);
    Task<Player?> LoginAsync(string email, string password);
}

public interface IGameService
{
    Task<Game> CreateGameAsync(Guid playerId, GameMode mode);
    Task<Game?> MakeMoveAsync(Guid gameId, Guid playerId, int cellIndex);
    Task<GameResult> CheckWinner(Mark[] board);
}

public interface IRankingService
{
    int CalculateRatingChange(int winnerRating, int loserRating, bool isDraw);
    Task ApplyRankedResultAsync(RankedMatch match);
}

public interface ICustomizationService
{
    Task<PlayerCustomization> UpdateCustomizationAsync(Guid playerId, PlayerCustomization customization);
}

public interface IAiOpponentService
{
    int GetBestMove(Mark[] board, Mark aiMark);
}
