using _4.BetsBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3.BetsDataAccess.Interface
{
    public interface IAddBetsRepository
    {
        Task<NumberBet_Wrapper> AddBet(AddBets_Wrappers bet);
    }
}
