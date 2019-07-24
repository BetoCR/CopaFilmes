using CopaFilmes.Domain.MovieAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CopaFilmes.Domain.Rules;

namespace CopaFilmes.Domain.ChampionShipAggregation
{
    public class ChampionShip
    {
        private List<ChampionShipPhase> phases;

        public IEnumerable<Movie> Movies { get; private set; }
        public Movie ChampionShipWinner { get; set; }
        public Movie ChampionShipVice { get; set; }
        public IEnumerable<ChampionShipPhase> Phases
        {
            get
            {
                return phases;
            }
        }

        public ChampionShip(IEnumerable<Movie> movies)
        {
            if (movies.Count() % 2 != 0)
                throw new InvalidOperationException("A quantidade de filmes tem que ser par!");

            Movies = movies;
            phases = new List<ChampionShipPhase>();
        }

        public void Start(ISwitchingRule switchingRule, ITiebreakerRule tiebreakerRule)
        {
            var phaseNumber = 1;

            var players = new List<Movie>();

            players.AddRange(Movies); 

            var playersCount = players.Count();

            ChampionShipPhase phase = null;

            while (playersCount > 1)
            {
                phase
                    = new ChampionShipPhase($"Fase {phaseNumber}", players);

                phases.Add(phase);

                phase.Start(switchingRule, tiebreakerRule);

                players
                    = phase.Winners.OrderBy(a=> a.titulo).ToList();

                playersCount 
                    = players.Count();

                phaseNumber++;
            }

            ChampionShipWinner
                = phase.Winners.First();

            var lastGame =
                phase.Games.FirstOrDefault();

            ChampionShipVice 
                = lastGame.Player1.Equals(ChampionShipWinner) ? lastGame.Player2 : lastGame.Player1;
        }
    }
}
