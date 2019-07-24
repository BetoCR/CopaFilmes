using CopaFilmes.Domain.MovieAggregate;
using CopaFilmes.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.ChampionShipAggregation
{
    public class Game
    {   
        public Movie Player1 { get; private set; }
        public Movie Player2 { get; private set; }
        public Movie Winner { get; private set; }
        public Game(Movie player1, Movie player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void Play(ITiebreakerRule tieBreakerRule)
        {
            if(Player1.nota.Equals(Player2.nota))
            {
                //Aplica critério de desempate
                Winner = tieBreakerRule.ApplyAndGetWinner(Player1, Player2);
                return;
            }

            if (Player1.nota > Player2.nota)
                Winner = Player1;
            else
                Winner = Player2;
        }
    }
}
