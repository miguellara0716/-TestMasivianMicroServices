using _2.BetsBusiness.Interface;
using _3.BetsDataAccess.Interface;
using _4.BetsBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2.BetsBusiness
{
    public class AddBetsBusiness : IAddBetsBusiness
    {
        private readonly IAddBetsRepository _addBetsRepository;
        public AddBetsBusiness(IAddBetsRepository AddBetsRepository)
        {
            _addBetsRepository = AddBetsRepository;
        }

        public async Task<NumberBet_Wrapper> AddBet(AddBets_Wrappers bet)
        {
            var BetNumber = await _addBetsRepository.AddBet(bet).ConfigureAwait(false);
            return BetNumber;
        }
    }
}
