using CopaFilmes.Domain.MovieAggregate;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CopaFilmes.Infra.Services
{
    public class MoviesService : ServiceBase, IMovieService
    {
        private string address;
        public MoviesService(HttpClient httpClient, string address)
            : base(httpClient)
        {
            this.address = address;
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            return Get<IEnumerable<Movie>>(address);
        }
    }
}