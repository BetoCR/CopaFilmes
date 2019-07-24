using CopaFilmes.Domain.MovieAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.Rules
{
    /// <summary>
    /// Implementação que aplica o critério de desempate por ordenação do titulo    
    /// </summary>
    public class TieBreakerByOrder : ITiebreakerRule
    {
        public Movie ApplyAndGetWinner(Movie player1, Movie player2)
        {
            var result 
                = string.Compare(player1.titulo, player2.titulo, true);

            if (result == 0)
                throw new Exception("O critério de desempate não é aplicavel para filmes com nomes iguais!");

            if (result < 0)
                return player1;
            else
                return player2;
        }
    }
}
