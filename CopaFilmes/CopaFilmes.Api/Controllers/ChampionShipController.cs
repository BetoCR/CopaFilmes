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

    [ApiController]
    public class ChampionShipController : ControllerBase
    {
        ISwitchingRule switchingRule;
        ITiebreakerRule tiebreakRule;
        IMovieService movieService;
        IChampionShipRepository championShipRepository;

        public ChampionShipController(ISwitchingRule switchingRule,
            ITiebreakerRule tiebreakRule,
            IMovieService movieService,
            IChampionShipRepository championShipRepository)
        {
            this.switchingRule = switchingRule;
            this.tiebreakRule = tiebreakRule;
            this.movieService = movieService;
            this.championShipRepository = championShipRepository;
        }

        [DisableCors()]
        [HttpPost("Api/ChampionShip/Start")]
        public IActionResult Start(ChampionShipModel model)
        {
            if (!validateModel(model, out IActionResult result))
                return result;

            var movies
                = movieService.GetAllMovies()
                    .Where(a => model.SelectedMovies.Any(b => b.Equals(a.id)))
                    .ToList().OrderBy(a=> a.titulo);

            var championShip
                = new ChampionShip(movies);

            championShip.Start(switchingRule, tiebreakRule);

            championShipRepository.Save(championShip);

            return Ok(model);
        }

        [DisableCors()]
        [HttpGet("Api/ChampionShip/Winners")]
        public IActionResult Winners()
        {
            var championShip 
                = championShipRepository.Get();

            if (championShip == null)
                return NotFound("Nenhum campeonato foi realizado!");

            var model
                = new WinnersModel()
                {
                    Winner = championShip.ChampionShipWinner.titulo,
                    Vice = championShip.ChampionShipVice.titulo
                };

            return Ok(model);
        }

        private bool validateModel(ChampionShipModel model, out IActionResult actionResult)
        {
            actionResult = null;

            if (model == null)
            {
                actionResult = BadRequest("Requisição inválida!");
                return false;
            }

            if (model.SelectedMovies.Count != 8)
            {
                actionResult = BadRequest("A quantidade de filmes selecionados tem que ser 8!");
                return false;
            }

            return true;
        }
    }
}