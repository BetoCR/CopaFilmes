using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.ChampionShipAggregation
{
    public interface IChampionShipRepository 
    {
        ChampionShip Get();
        void Save(ChampionShip championShip);
    }
}
