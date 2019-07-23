using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Models
{
    public class ChampionShipModel
    {
        public List<string> SelectedMovies { get; set; }

        public ChampionShipModel()
        {
            SelectedMovies = new List<string>();
        }
    }
}
