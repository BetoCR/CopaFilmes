using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.MovieAggregate
{
    public class Movie
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public int ano { get; set; }
        public decimal nota { get; set; }
    }
}