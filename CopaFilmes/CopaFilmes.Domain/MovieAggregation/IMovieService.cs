using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.MovieAggregate
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
    }
}
