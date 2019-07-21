using CopaFilmes.Domain.MovieAggregate;
using CopaFilmes.Domain.Rules;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.ChampionShipAggregation
{
    public class ChampionShipPhase
    {
        public string PhaseName { get; private set; }
        public IEnumerable<Movie> Winners { get; private set; }
        public IEnumerable<Movie> Players { get; private set; }
        public IEnumerable<Game> Games { get; private set; }

        public ChampionShipPhase(string phaseName, IEnumerable<Movie> players)
        {
            PhaseName = phaseName;
            Players = players;
        }

        public void Start(ISwitchingRule switchingRule, ITiebreakerRule tiebreakerRule)
        {
            Games
                = switchingRule.PerformSwitching(Players.ToList());

            foreach (var game in Games)
                game.Play(tiebreakerRule);

            Winners
                = Games.Select(a => a.Winner);
        }
    }
}