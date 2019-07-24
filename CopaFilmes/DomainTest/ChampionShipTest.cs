using CopaFilmes.Domain.ChampionShipAggregation;
using CopaFilmes.Domain.MovieAggregate;
using CopaFilmes.Domain.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DomainTest
{
    [TestClass]
    public class ChampionShipTest
    {
        [ExpectedException(typeof(InvalidOperationException), "A quantidade de filmes tem que ser par!")]
        [TestMethod]
        public void Dado_uma_qtd_impar_de_filmes_tem_que_disparar_exception()
        {
            //7 Filmes
            var jsonMovies =
                 @"[{'id':'tt3606756','titulo':'Os Incríveis 2','ano':2018,'nota':8.5},
                 {'id':'tt4881806','titulo':'Jurassic World: Reino Ameaçado','ano':2018,'nota':6.7},
                 {'id':'tt5164214','titulo':'Oito Mulheres e um Segredo','ano':2018,'nota':6.3},
                 {'id':'tt7784604','titulo':'Hereditário','ano':2018,'nota':7.8},
                 {'id':'tt4154756','titulo':'Vingadores: Guerra Infinita','ano':2018,'nota':8.8},
                 {'id':'tt5463162','titulo':'Deadpool 2','ano':2018,'nota':8.1},
                 {'id':'tt3778644','titulo':'Han Solo: Uma História Star Wars','ano':2018,'nota':7.2}]"                 
                .Replace("'", "\"");

            var movies =
                JsonConvert.DeserializeObject<List<Movie>>(jsonMovies);

            var championShip
                = new ChampionShip(movies);
        }


        [TestMethod]
        public void Dado_uma_lista_de_8_filmes_conforme_o_enunciado_o_resultado_tem_que_ser_1_vingadores_e_2_os_incriveis()
        {
            //Vingadores
            var winner_id = "tt4154756";

            //Os Incriveis
            var vice_id = "tt3606756";

            var jsonMovies =
                 @"[{'id':'tt3606756','titulo':'Os Incríveis 2','ano':2018,'nota':8.5},
                 {'id':'tt4881806','titulo':'Jurassic World: Reino Ameaçado','ano':2018,'nota':6.7},
                 {'id':'tt5164214','titulo':'Oito Mulheres e um Segredo','ano':2018,'nota':6.3},
                 {'id':'tt7784604','titulo':'Hereditário','ano':2018,'nota':7.8},
                 {'id':'tt4154756','titulo':'Vingadores: Guerra Infinita','ano':2018,'nota':8.8},
                 {'id':'tt5463162','titulo':'Deadpool 2','ano':2018,'nota':8.1},
                 {'id':'tt3778644','titulo':'Han Solo: Uma História Star Wars','ano':2018,'nota':7.2},
                 {'id':'tt3501632','titulo':'Thor: Ragnarok','ano':2017,'nota':7.9}]"
                .Replace("'", "\"");

            var movies =
                JsonConvert.DeserializeObject<List<Movie>>(jsonMovies);
            
            var championShip
                = new ChampionShip(movies);

            ISwitchingRule switchingRule = new SwitchingByLastAndFirst();
            ITiebreakerRule tiebreakRule = new TieBreakerByOrder();

            championShip.Start(switchingRule, tiebreakRule);

            var result 
                = championShip.ChampionShipWinner.id == winner_id && championShip.ChampionShipVice.id == vice_id;

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Dado_uma_lista_de_8_filmes_conforme_o_enunciado_tem_que_criar_3_fases()
        {
            var jsonMovies =
                 @"[{'id':'tt3606756','titulo':'Os Incríveis 2','ano':2018,'nota':8.5},
                 {'id':'tt4881806','titulo':'Jurassic World: Reino Ameaçado','ano':2018,'nota':6.7},
                 {'id':'tt5164214','titulo':'Oito Mulheres e um Segredo','ano':2018,'nota':6.3},
                 {'id':'tt7784604','titulo':'Hereditário','ano':2018,'nota':7.8},
                 {'id':'tt4154756','titulo':'Vingadores: Guerra Infinita','ano':2018,'nota':8.8},
                 {'id':'tt5463162','titulo':'Deadpool 2','ano':2018,'nota':8.1},
                 {'id':'tt3778644','titulo':'Han Solo: Uma História Star Wars','ano':2018,'nota':7.2},
                 {'id':'tt3501632','titulo':'Thor: Ragnarok','ano':2017,'nota':7.9}]"
                .Replace("'", "\"");

            var movies =
                JsonConvert.DeserializeObject<List<Movie>>(jsonMovies);

            var championShip
                = new ChampionShip(movies);

            ISwitchingRule switchingRule = new SwitchingByLastAndFirst();
            ITiebreakerRule tiebreakRule = new TieBreakerByOrder();

            championShip.Start(switchingRule, tiebreakRule);

            /*
             *  são 3 fases sendo: quartas de final, semi-final e final.             
            */
            Assert.AreEqual(championShip.Phases.Count(), 3);
        }
    }
}
