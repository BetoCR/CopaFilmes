using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Api.Models;
using CopaFilmes.Domain.ChampionShipAggregation;
using CopaFilmes.Domain.MovieAggregate;
using CopaFilmes.Domain.Rules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers
{
    
    [ApiController]
    public class ChampionShipController : ControllerBase
    {
        ISwitchingRule switchingRule;
        ITiebreakerRule tiebreakRule;
        IMovieService movieService;

        public ChampionShipController(ISwitchingRule switchingRule, 
            ITiebreakerRule tiebreakRule, IMovieService movieService)
        {
            this.switchingRule = switchingRule;
            this.tiebreakRule = tiebreakRule;
            this.movieService = movieService;
        }

        [HttpGet("Api/ChampionShip/Start")]
        public IActionResult Start()
        {
            var movies
                = movieService.GetAllMovies();

            var championShip
                = new ChampionShip(movies);

            championShip.Start(switchingRule, tiebreakRule);

            return Ok(championShip);
        }
    }
}