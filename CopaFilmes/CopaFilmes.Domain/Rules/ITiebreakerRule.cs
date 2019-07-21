using System;
using System.Collections.Generic;
using System.Text;
using CopaFilmes.Domain.MovieAggregate;

namespace CopaFilmes.Domain.Rules
{
    public interface ITiebreakerRule
    {
        Movie ApplyAndGetWinner(Movie player1, Movie player2);
    }
}
