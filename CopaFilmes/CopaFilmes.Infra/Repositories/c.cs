using CopaFilmes.Domain.ChampionShipAggregation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Infra.Repositories
{
    public class ChampionShipRepositoryByMemory : IChampionShipRepository
    {
        private static ChampionShip _championShip;

        public ChampionShip Get()
        {
            return _championShip;
        }

        public void Save(ChampionShip championShip)
        {
            _championShip = championShip;
        }
    }
}