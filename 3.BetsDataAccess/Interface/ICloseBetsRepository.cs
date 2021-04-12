using _4.BetsBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3.BetsDataAccess.Interface
{
    public interface ICloseBetsRepository
    {
        public Task<WinnerNumber_Wrapper> CloseRoulette(IdRoulette_Wrapper IdRoulette);
        public Task<ICollection<Bets_Wrapper>> getBets(IdRoulette_Wrapper IdRoulette);
    }
}
