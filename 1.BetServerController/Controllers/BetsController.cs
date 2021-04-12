using _2.BetsBusiness.Interface;
using _4.BetsBusinessEntities.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.BetsServerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetsController : ControllerBase
    {
        private readonly IAddBetsBusiness _addBetsBusiness;
        private readonly ICloseBetsBusiness _closeBetsBusiness;
        public BetsController(IAddBetsBusiness AddBetsBusiness, ICloseBetsBusiness CloseBetsBusiness)
        {
            _addBetsBusiness = AddBetsBusiness;
            _closeBetsBusiness = CloseBetsBusiness;
        }

        [HttpPost]
        [Route("AddBets")]
        public async Task<ActionResult> AddBets(AddBets_Wrappers Bet)
        {
            try
            {
                var _request = Request;
                var _headers = _request.Headers;
                if (_headers.ContainsKey("UserId"))
                {
                    var UserId = _headers["UserId"].ElementAt(0);
                    Bet.IdUser = UserId;
                }
                else
                {
                    throw new ArgumentNullException("UserId");
                }
                var IdBet = await _addBetsBusiness.AddBet(Bet).ConfigureAwait(false);

                return Ok(IdBet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        [Route("CloseRoulette")]
        public async Task<ActionResult> CloseRoulette([FromBody]IdRoulette_Wrapper IdRoulette)
        {
            try
            {
                var IdBet = await _closeBetsBusiness.CloseRoulette(IdRoulette).ConfigureAwait(false);

                return Ok(IdBet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




    }
}
