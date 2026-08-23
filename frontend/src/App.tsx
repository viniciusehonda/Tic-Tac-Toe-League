import './App.css'

const features = [
  {
    title: 'Jogue contra IA ou jogadores',
    description: 'Partidas casuais ou ranqueadas contra o computador ou outros usuários.',
  },
  {
    title: 'Ranking competitivo',
    description: 'Suba no placar vencendo partidas ranqueadas com sistema de rating ELO.',
  },
  {
    title: 'Personalização',
    description: 'Escolha fundos e skins para os símbolos X e O.',
  },
]

function App() {
  return (
    <div className="app">
      <header className="hero">
        <p className="eyebrow">Tic Tac Toe League</p>
        <h1>Jogo da velha online com ranking e personalização</h1>
        <p className="subtitle">
          Projeto em desenvolvimento — backend .NET Web API + frontend React/TypeScript.
        </p>
        <div className="actions">
          <button type="button" className="primary" disabled>
            Entrar (em breve)
          </button>
          <button type="button" className="secondary" disabled>
            Criar conta (em breve)
          </button>
        </div>
      </header>

      <section className="features">
        {features.map((feature) => (
          <article key={feature.title} className="feature-card">
            <h2>{feature.title}</h2>
            <p>{feature.description}</p>
          </article>
        ))}
      </section>

      <footer className="footer">
        <p>Backend: <code>/api/health</code> · Frontend: Vite + React 19</p>
      </footer>
    </div>
  )
}

export default App
