using _2.OnlineRouletteBusiness.Interface;
using _3.OnlineRouletteDataAccess.Interface;
using _4.OnlineRouletteBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2.OnlineRouletteBusiness
{
    public class ListRoulettesBusiness : IListRoulettesBusiness
    {
        private readonly IListRoulettesRepository _listRoulettesRepository;
        public ListRoulettesBusiness(IListRoulettesRepository ListRoulettesRepository)
        {
            _listRoulettesRepository = ListRoulettesRepository;
        }

        public async Task<ICollection<Roulettes_Wrappers>> ListRoulettes()
        {
           var Roulettes = await _listRoulettesRepository.ListRoulette().ConfigureAwait(false);

            return Roulettes;
        }
    }
}
