using CopaFilmes.Domain.ChampionShipAggregation;
using CopaFilmes.Domain.MovieAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CopaFilmes.Domain.Rules
{
    public class SwitchingByLastAndFirst : ISwitchingRule
    {
        public IEnumerable<Game> PerformSwitching(IList<Movie> movies)
        {
            var moviesCount
                = movies.Count();

            if (moviesCount % 2 != 0)
                throw new Exception("A quantidade de filmes do campeonato tem que ser um numero par!");

            var games 
                = new List<Game>();
            
            var j 
                = moviesCount - 1;

            Game game;

            var breakCount
                = moviesCount / 2;

            for (int i = 0; i < moviesCount; i++, j--)
            {
                if (i >= breakCount)
                    break;

                game 
                    = new Game(movies[i], movies[j]);

                games.Add(game);
            }

            return games;
        }
    }
}
