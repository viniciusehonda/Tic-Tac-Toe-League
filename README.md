# Tic Tac Toe League

Jogo da velha online com contas de usuário, partidas contra IA ou outros jogadores, ranking competitivo e personalização visual (fundos e skins para X/O).

## Stack

| Camada   | Tecnologia                    |
|----------|-------------------------------|
| Backend  | .NET 10 Web API               |
| Frontend | React 19 + TypeScript + Vite  |
| Banco    | PostgreSQL 16                 |

## Funcionalidades planejadas

- Registro e login de jogadores
- Partidas vs IA, casual PvP e ranqueadas
- Sistema de rating (ELO) com leaderboard
- Customização de fundo e skins dos símbolos

## Pré-requisitos

- [.NET SDK 10+](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/)
- [Docker](https://www.docker.com/) (para PostgreSQL local)

## Como rodar

### 1. Banco de dados

```bash
docker compose up -d
```

### 2. Backend

```bash
cd backend/TicTacToeLeague.Api
dotnet run
```

API disponível em http://localhost:5019  
Health check: http://localhost:5019/api/health

### 3. Frontend

```bash
cd frontend
cp .env.example .env   # opcional
npm install
npm run dev
```

App em http://localhost:5173 (proxy `/api` → backend)

## Estrutura do projeto

```
├── backend/TicTacToeLeague.Api/   # API REST (.NET)
├── frontend/                      # SPA React
├── docs/                          # Arquitetura e roadmap
├── AGENTS.md                      # Guia para desenvolvimento com IA
└── docker-compose.yml             # PostgreSQL
```

## Desenvolvimento com IA

Leia [`AGENTS.md`](AGENTS.md) antes de implementar features — contém convenções, domínio do jogo, endpoints planejados e ordem de implementação.

Documentação adicional:

- [Arquitetura](docs/ARCHITECTURE.md)
- [Roadmap](docs/ROADMAP.md)

## Scripts úteis

```bash
# Backend
dotnet build
dotnet run --project backend/TicTacToeLeague.Api

# Frontend
npm run dev      # desenvolvimento
npm run build    # build de produção
npm run lint     # oxlint
```

## Licença

Projeto pessoal — licença a definir.
