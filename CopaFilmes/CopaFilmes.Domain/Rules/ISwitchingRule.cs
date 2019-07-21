using System.Collections.Generic;
using CopaFilmes.Domain.ChampionShipAggregation;
using CopaFilmes.Domain.MovieAggregate;

namespace CopaFilmes.Domain.Rules
{
    public interface ISwitchingRule
    {
        IEnumerable<Game> PerformSwitching(IList<Movie> movies);
    }
}