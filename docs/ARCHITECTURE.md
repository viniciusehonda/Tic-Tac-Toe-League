# Arquitetura — Tic Tac Toe League

## Diagrama de alto nível

```mermaid
flowchart TB
    subgraph Client["Frontend (React + Vite)"]
        UI[Pages & Components]
        APIClient[API Service]
        WS[SignalR Client - futuro]
    end

    subgraph Server["Backend (.NET Web API)"]
        Controllers[Controllers]
        Services[Services]
        GameLogic[GameLogic - pure functions]
        Hubs[SignalR Hubs - futuro]
    end

    subgraph Data["Persistência"]
        PG[(PostgreSQL)]
    end

    UI --> APIClient
    UI --> WS
    APIClient --> Controllers
    WS --> Hubs
    Controllers --> Services
    Services --> GameLogic
    Services --> PG
    Hubs --> Services
```

## Camadas do backend

### Controllers

Responsáveis apenas por:

- Validação de entrada (model binding)
- Autenticação/autorização (`[Authorize]`)
- Mapeamento HTTP ↔ DTOs
- Códigos de status HTTP

### Services

- `IAuthService` — registro, login, hash de senha
- `IGameService` — criar partida, aplicar jogadas, finalizar
- `IRankingService` — cálculo ELO, histórico ranqueado
- `ICustomizationService` — persistir preferências visuais
- `IAiOpponentService` — escolha de jogada da IA

### GameLogic

Funções puras sem I/O. Testáveis unitariamente:

- `IsValidMove`
- `GetResult`
- `Opponent`

## Modelo de dados (planejado)

```mermaid
erDiagram
    Player ||--o{ Game : plays
    Player ||--|| PlayerCustomization : has
    Game ||--o| RankedMatch : "optional"
    Player {
        uuid id PK
        string username
        string email
        string password_hash
        int rating
        int wins
        int losses
        int draws
        datetime created_at
    }
    PlayerCustomization {
        uuid player_id PK
        string background_id
        string mark_x_skin_id
        string mark_o_skin_id
    }
    Game {
        uuid id PK
        enum mode
        enum status
        enum result
        mark[] board
        uuid player_x_id FK
        uuid player_o_id FK
        datetime created_at
        datetime finished_at
    }
    RankedMatch {
        uuid id PK
        uuid game_id FK
        int rating_change_x
        int rating_change_o
        datetime played_at
    }
```

## Fluxo de partida ranqueada

```mermaid
sequenceDiagram
    participant P1 as Jogador 1
    participant P2 as Jogador 2
    participant API as API
    participant MM as Matchmaking
    participant Hub as SignalR Hub

    P1->>API: POST /matchmaking/ranked
    P2->>API: POST /matchmaking/ranked
    MM->>MM: Parear por rating
    MM->>Hub: Criar sala de jogo
    Hub-->>P1: game-started
    Hub-->>P2: game-started
    P1->>Hub: move(cell)
    Hub-->>P2: opponent-move
    Note over Hub: Repete até fim
    Hub->>API: Finalizar + atualizar ELO
    Hub-->>P1: game-finished
    Hub-->>P2: game-finished
```

## Frontend — estrutura de rotas (planejada)

| Rota            | Página        | Auth |
|-----------------|---------------|------|
| `/`             | Home/Lobby    | Opcional |
| `/login`        | Login         | Não  |
| `/register`     | Registro      | Não  |
| `/play/ai`      | vs IA         | Sim  |
| `/play/casual`  | PvP casual    | Sim  |
| `/play/ranked`  | Fila ranqueada| Sim  |
| `/profile`      | Perfil + skins| Sim  |
| `/leaderboard`  | Ranking global| Não  |

## Segurança

- Senhas: **BCrypt** ou **ASP.NET Identity PasswordHasher**
- JWT com expiração curta + refresh token (fase 2)
- CORS restrito ao origin do frontend em produção
- Rate limiting em auth e matchmaking

## Infra local

- `docker-compose.yml` — PostgreSQL 16
- Connection string em `appsettings.Development.json` ou User Secrets
- Frontend proxy via Vite em desenvolvimento

## Decisões técnicas pendentes

| Decisão              | Opções                         | Recomendação     |
|----------------------|--------------------------------|------------------|
| ORM                  | EF Core / Dapper               | EF Core          |
| Auth                 | Identity / JWT manual          | ASP.NET Identity |
| IA                   | Minimax / Monte Carlo          | Minimax          |
| State management FE  | Context / Zustand / TanStack   | Context + hooks  |
| UI library           | CSS puro / Tailwind / shadcn   | A definir        |
