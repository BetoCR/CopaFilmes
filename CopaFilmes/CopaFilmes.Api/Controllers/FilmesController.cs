using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Api.Models;
using CopaFilmes.Domain.ChampionShipAggregation;
using CopaFilmes.Domain.MovieAggregate;
using CopaFilmes.Domain.Rules;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers
{
    [DisableCors()]
    [ApiController]
    public class FilmesController : ControllerBase
    {   
        IMovieService movieService;

        public FilmesController(IMovieService movieService)
        {   
            this.movieService = movieService;
        }

        [HttpGet("Api/Filmes")]
        public IActionResult Get()
        {
            return Ok(movieService.GetAllMovies());
        }
    }
}