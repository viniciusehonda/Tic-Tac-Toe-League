# Roadmap — Tic Tac Toe League

## Fase 0 — Setup ✅

- [x] Solução .NET + Web API
- [x] Frontend React + TypeScript (Vite)
- [x] Documentação para IA (`AGENTS.md`, arquitetura)
- [x] Docker Compose (PostgreSQL)
- [x] Modelos de domínio e interfaces de serviço
- [x] Health check endpoint

## Fase 1 — Fundação

- [ ] EF Core + migrations (Player, Game, RankedMatch)
- [ ] ASP.NET Identity ou JWT auth manual
- [ ] `POST /api/auth/register`, `POST /api/auth/login`
- [ ] `GET /api/players/me`
- [ ] Testes unitários de `GameLogic`

## Fase 2 — Jogo vs IA

- [ ] Implementar `IAiOpponentService` (minimax)
- [ ] `POST /api/games` (modo VsAi)
- [ ] `POST /api/games/{id}/moves`
- [ ] UI do tabuleiro 3×3 no frontend
- [ ] Feedback visual de vitória/empate

## Fase 3 — Personalização

- [ ] Catálogo de backgrounds e skins (assets estáticos)
- [ ] `PATCH /api/players/me/customization`
- [ ] Tela de perfil com preview ao vivo
- [ ] Aplicar customização durante partida

## Fase 4 — PvP Casual (tempo real)

- [ ] SignalR hub para salas de jogo
- [ ] Convite por link ou matchmaking simples
- [ ] Sincronização de estado do tabuleiro
- [ ] Tratamento de desconexão/abandono

## Fase 5 — Ranking

- [ ] Fila de matchmaking por rating (±200 inicial)
- [ ] `IRankingService` com ELO
- [ ] Persistir `RankedMatch` e atualizar stats
- [ ] `GET /api/leaderboard` (top 100)

## Fase 6 — Polish

- [ ] Animações de jogada e vitória
- [ ] Histórico de partidas no perfil
- [ ] Testes E2E (Playwright)
- [ ] CI/CD (GitHub Actions)
- [ ] Deploy (API + SPA + DB)

## Backlog / ideias futuras

- Torneios sazonais
- Skins desbloqueáveis por ranking
- Replay de partidas
- Modo 4×4 ou variantes
- Chat in-game
