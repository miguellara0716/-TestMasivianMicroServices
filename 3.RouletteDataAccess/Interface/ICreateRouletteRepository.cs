using _4.OnlineRouletteBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3.OnlineRouletteDataAccess.Interface
{
    public interface ICreateRouletteRepository
    {
        Task<IdRoulette_Wrapper> CreateRoulette();
    }
}
