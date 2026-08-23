export type Mark = 'none' | 'X' | 'O'

export type GameMode = 'vs-ai' | 'casual' | 'ranked'

export type GameStatus = 'waiting' | 'in-progress' | 'finished' | 'abandoned'

export type GameResult = 'none' | 'x-wins' | 'o-wins' | 'draw'

export interface PlayerCustomization {
  backgroundId: string
  markXSkinId: string
  markOSkinId: string
}

export interface PlayerProfile {
  id: string
  username: string
  rating: number
  wins: number
  losses: number
  draws: number
  customization: PlayerCustomization
}

export interface GameState {
  id: string
  mode: GameMode
  status: GameStatus
  result: GameResult
  board: Mark[]
  currentTurn: Mark
  playerXId?: string
  playerOId?: string
}

export interface LeaderboardEntry {
  rank: number
  username: string
  rating: number
  wins: number
  losses: number
}

export interface HealthResponse {
  status: string
  service: string
  timestamp: string
}
