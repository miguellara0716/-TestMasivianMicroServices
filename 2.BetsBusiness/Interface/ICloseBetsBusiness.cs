using _4.BetsBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2.BetsBusiness.Interface
{
    public interface ICloseBetsBusiness
    {
        Task<BetsResults_Wrapper> CloseRoulette(IdRoulette_Wrapper IdRoulette);
    }
}
