using _2.BetsBusiness.Interface;
using _3.BetsDataAccess.Interface;
using _4.BetsBusinessEntities.Enums;
using _4.BetsBusinessEntities.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2.BetsBusiness
{
    public class CloseBetsBusiness : ICloseBetsBusiness
    {
        private readonly ICloseBetsRepository _closeBetsRepository;
        public CloseBetsBusiness(ICloseBetsRepository CloseBetsRepository)
        {
            _closeBetsRepository = CloseBetsRepository;
        }


        public async Task<BetsResults_Wrapper> CloseRoulette(IdRoulette_Wrapper IdRoulette)
        {
            WinnerNumber_Wrapper Winner = await _closeBetsRepository.CloseRoulette(IdRoulette).ConfigureAwait(false);
            ICollection<Bets_Wrapper> bets = await GetBets(IdRoulette).ConfigureAwait(false);
            BetsResults_Wrapper Results = await GetsWinners(Winner, bets).ConfigureAwait(false);
            Results.IdRoullete = IdRoulette.IdRoulette;
            return Results;

        }

        public async Task<ICollection<Bets_Wrapper>> GetBets(IdRoulette_Wrapper IdRoulette)
        {
            ICollection<Bets_Wrapper> Bets = await _closeBetsRepository.getBets(IdRoulette).ConfigureAwait(false);
            return Bets;
        }

        public async Task<BetsResults_Wrapper> GetsWinners(WinnerNumber_Wrapper WinnerNumber, ICollection<Bets_Wrapper> bets)
        {
            var ColorWinner = await GetWinnerColor(WinnerNumber).ConfigureAwait(false);
            BetsResults_Wrapper Results = new BetsResults_Wrapper();
            Results.ResultRoulette = WinnerNumber.WinnerNumber;
            Results.Winners = new List<Winners_Wrapper>();
            Parallel.ForEach(bets, bet =>
            {
                Winners_Wrapper Winner = new Winners_Wrapper();
                if (bet.IsColorBet)
                {
                    if (bet.BetColor == ColorWinner)
                    {
                        Winner.IdUser = bet.IdUser;
                        Winner.StakeValue = bet.BetValue;
                        Winner.WinnerValue = (long)(bet.BetValue * 1.8);
                        Results.Winners.Add(Winner);
                    }
                }
                else
                {
                    if (WinnerNumber.WinnerNumber == bet.BetNumber)
                    {
                        Winner.IdUser = bet.IdUser;
                        Winner.StakeValue = bet.BetValue;
                        Winner.WinnerValue = bet.BetValue * 5;

                    }
                }
                
            });
            return Results;
        }

        public async Task<int> GetWinnerColor(WinnerNumber_Wrapper Winner)
        {
            int ColorWinner;
            if (Winner.WinnerNumber % 2 == 0)
            {
                ColorWinner = 1;
            }
            else
            {
                ColorWinner = 2;
            }
            return ColorWinner;
        }
    }
}
