namespace TicTacToeLeague.Api.DTOs;

public record ApiResponse<T>(T Data, string? Message = null);

public record PlayerProfileDto(
    Guid Id,
    string Username,
    int Rating,
    int Wins,
    int Losses,
    int Draws,
    PlayerCustomizationDto Customization
);

public record PlayerCustomizationDto(
    string BackgroundId,
    string MarkXSkinId,
    string MarkOSkinId
);

public record GameStateDto(
    Guid Id,
    string Mode,
    string Status,
    string Result,
    string[] Board,
    string CurrentTurn,
    Guid? PlayerXId,
    Guid? PlayerOId
);

public record LeaderboardEntryDto(
    int Rank,
    string Username,
    int Rating,
    int Wins,
    int Losses
);
