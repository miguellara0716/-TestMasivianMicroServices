using _2.OnlineRouletteBusiness.Interface;
using _3.OnlineRouletteDataAccess.Interface;
using _4.OnlineRouletteBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2.OnlineRouletteBusiness
{
    public class CreateRouletteBusiness : ICreateRouletteBusiness
    {
        private readonly ICreateRouletteRepository _createRouletteRepository;
        public CreateRouletteBusiness(ICreateRouletteRepository CreateRouletteRepository)
        {
            _createRouletteRepository = CreateRouletteRepository;
        }

        public async Task<IdRoulette_Wrapper> CreateRoulette()
        {
            IdRoulette_Wrapper IdRoulette = await _createRouletteRepository.CreateRoulette().ConfigureAwait(false);

            return IdRoulette;
        }
    }
}
