namespace TicTacToeLeague.Api.Models;

public enum Mark
{
    None = 0,
    X = 1,
    O = 2
}

public enum GameMode
{
    VsAi = 0,
    Casual = 1,
    Ranked = 2
}

public enum GameStatus
{
    WaitingForPlayer = 0,
    InProgress = 1,
    Finished = 2,
    Abandoned = 3
}

public enum GameResult
{
    None = 0,
    XWins = 1,
    OWins = 2,
    Draw = 3
}

public class Player
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Rating { get; set; } = 1000;
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Draws { get; set; }
    public PlayerCustomization Customization { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class PlayerCustomization
{
    public string BackgroundId { get; set; } = "default";
    public string MarkXSkinId { get; set; } = "classic-x";
    public string MarkOSkinId { get; set; } = "classic-o";
}

public class Game
{
    public Guid Id { get; set; }
    public GameMode Mode { get; set; }
    public GameStatus Status { get; set; }
    public GameResult Result { get; set; }
    public Mark[] Board { get; set; } = new Mark[9];
    public Mark CurrentTurn { get; set; } = Mark.X;
    public Guid? PlayerXId { get; set; }
    public Guid? PlayerOId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? FinishedAt { get; set; }
}

public class RankedMatch
{
    public Guid Id { get; set; }
    public Guid GameId { get; set; }
    public Guid PlayerXId { get; set; }
    public Guid PlayerOId { get; set; }
    public int RatingChangeX { get; set; }
    public int RatingChangeO { get; set; }
    public GameResult Result { get; set; }
    public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
}
