using _2.OnlineRouletteBusiness.Interface;
using _3.OnlineRouletteDataAccess.Interface;
using _4.OnlineRouletteBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2.OnlineRouletteBusiness
{
    public class OpenRouletteBusiness : IOpenRouletteBusiness
    {
        private readonly IOpenRouletteRepository _openRouletteRepository;
        public OpenRouletteBusiness(IOpenRouletteRepository OpenRouletteRepository)
        {
            _openRouletteRepository = OpenRouletteRepository;
        }

        public async Task<bool> OpenRoulette(IdRoulette_Wrapper Roulette)
        {
            var RouletteOpen = await _openRouletteRepository.OpenRoulete(Roulette).ConfigureAwait(false);

            return RouletteOpen;
        }
    }
}
