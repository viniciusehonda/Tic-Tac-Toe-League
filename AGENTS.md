# Tic Tac Toe League — Guia para Agentes de IA

Este documento orienta assistentes de IA (Cursor, Copilot, etc.) sobre como trabalhar neste repositório.

## Visão geral do produto

Jogo da velha online com:

- **Contas de usuário** (registro, login, perfil)
- **Modos de jogo**: vs IA, casual PvP, ranqueado PvP
- **Ranking ELO** para partidas ranqueadas
- **Personalização**: fundo do tabuleiro + skins dos símbolos X e O

## Stack

| Camada    | Tecnologia                          |
|-----------|-------------------------------------|
| Backend   | .NET 10 Web API (controllers)       |
| Frontend  | React 19 + TypeScript + Vite        |
| Banco     | PostgreSQL (via Docker Compose)     |
| Auth      | JWT (a implementar)                 |
| Tempo real| SignalR (a implementar para PvP)    |

## Estrutura do repositório

```
Tic-Tac-Toe-League/
├── backend/TicTacToeLeague.Api/   # API REST
│   ├── Controllers/               # Endpoints HTTP
│   ├── Models/                    # Entidades de domínio
│   ├── DTOs/                      # Contratos de API
│   └── Services/                  # Lógica de negócio + interfaces
├── frontend/                      # SPA React
│   └── src/
│       ├── components/            # UI reutilizável
│       ├── pages/                 # Rotas/telas
│       ├── services/              # Cliente HTTP
│       └── types/                 # Tipos TypeScript espelhando DTOs
├── docs/                          # Arquitetura e roadmap
└── docker-compose.yml             # PostgreSQL local
```

## Convenções

### Backend (.NET)

- Use **controllers** (não Minimal APIs) para manter consistência.
- Lógica pura de jogo em `Services/GameLogic.cs` — sem dependências de infra.
- Interfaces em `Services/IServiceContracts.cs` antes das implementações.
- DTOs na pasta `DTOs/`; entidades em `Models/`.
- Nullable reference types habilitados — evite `null` desnecessário.
- Nomes de endpoints: plural, kebab-case na URL via `[Route("api/[controller]")]`.

### Frontend (React/TypeScript)

- Componentes funcionais com hooks.
- Tipos em `src/types/` devem espelhar DTOs do backend.
- Chamadas HTTP centralizadas em `src/services/api.ts`.
- Proxy de dev: Vite encaminha `/api` → `http://localhost:5019`.
- Preferir composição sobre prop drilling; Context para auth e tema quando necessário.

### Commits

- Mensagens em inglês ou português, mas consistentes no PR.
- Escopo pequeno: uma feature ou fix por commit quando possível.

## Domínio do jogo

### Tabuleiro

- Array de 9 células (`Mark.None | X | O`).
- Vitória: 3 em linha (horizontal, vertical, diagonal).
- Empate: tabuleiro cheio sem vencedor.

### Modos

| Modo     | Descrição                                      | Afeta rating |
|----------|------------------------------------------------|--------------|
| `VsAi`   | Jogador vs IA (minimax ou heurística)          | Não          |
| `Casual` | PvP sem impacto no ranking                     | Não          |
| `Ranked` | PvP com matchmaking por rating                 | Sim          |

### Ranking (ELO simplificado)

- Rating inicial: **1000** (`appsettings.json` → `Ranking:InitialRating`).
- K-factor: **32** (`Ranking:KFactor`).
- Implementar em `IRankingService`.

### Personalização

- `backgroundId`, `markXSkinId`, `markOSkinId` no perfil do jogador.
- Skins são IDs referenciando assets no frontend; backend persiste apenas IDs.

## Endpoints planejados

| Método | Rota                      | Descrição              |
|--------|---------------------------|------------------------|
| GET    | `/api/health`             | Health check ✅        |
| POST   | `/api/auth/register`      | Criar conta            |
| POST   | `/api/auth/login`         | Login → JWT            |
| GET    | `/api/players/me`         | Perfil autenticado     |
| PATCH  | `/api/players/me/customization` | Atualizar skins |
| POST   | `/api/games`              | Criar partida          |
| POST   | `/api/games/{id}/moves`   | Jogada                 |
| GET    | `/api/games/{id}`         | Estado da partida      |
| GET    | `/api/leaderboard`        | Top jogadores          |
| POST   | `/api/matchmaking/ranked` | Entrar na fila ranqueada |

## Como rodar localmente

```bash
# Banco de dados
docker compose up -d

# Backend (terminal 1)
cd backend/TicTacToeLeague.Api
dotnet run

# Frontend (terminal 2)
cd frontend
npm install
npm run dev
```

- API: http://localhost:5019
- Frontend: http://localhost:5173
- Swagger/OpenAPI: http://localhost:5019/openapi/v1.json (dev)

## Ordem sugerida de implementação

Consulte `docs/ROADMAP.md` para fases detalhadas. Resumo:

1. Auth (JWT + registro/login)
2. Persistência (EF Core + PostgreSQL)
3. Partida vs IA
4. UI do tabuleiro + personalização visual
5. PvP casual (SignalR)
6. Matchmaking + ranking ranqueado
7. Leaderboard e polish

## O que NÃO fazer

- Não commitar secrets (`.env`, chaves JWT reais).
- Não misturar lógica de jogo em controllers — use services.
- Não duplicar tipos: espelhe DTOs ↔ TypeScript em `frontend/src/types/`.
- Não implementar matchmaking antes de PvP em tempo real funcionar.

## Referências internas

- [Arquitetura](docs/ARCHITECTURE.md)
- [Roadmap](docs/ROADMAP.md)
