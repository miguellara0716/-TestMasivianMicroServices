using _4.OnlineRouletteBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2.OnlineRouletteBusiness.Interface
{
    public interface ICreateRouletteBusiness
    {
        Task<IdRoulette_Wrapper> CreateRoulette();
    }
}
