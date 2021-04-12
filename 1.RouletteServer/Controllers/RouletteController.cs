using _2.OnlineRouletteBusiness.Interface;
using _4.OnlineRouletteBusinessEntities.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRouletteServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly ICreateRouletteBusiness _businessCreateRoulette;
        private readonly IListRoulettesBusiness _businessListRoulettes;
        private readonly IOpenRouletteBusiness _businessOpenRoulette;
        public RouletteController(ICreateRouletteBusiness BusinessCreateRoulette, IListRoulettesBusiness BusinessListRoulettes, IOpenRouletteBusiness BusinessOpenRoulette)
        {
            _businessCreateRoulette = BusinessCreateRoulette;
            _businessListRoulettes = BusinessListRoulettes;
            _businessOpenRoulette = BusinessOpenRoulette;
        }


        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult> CreateRoulette()
        {
            try
            {
                var IdRuleta = await _businessCreateRoulette.CreateRoulette().ConfigureAwait(false);

                return Ok(IdRuleta);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [Route("Open")]
        [HttpPut]
        public async Task<ActionResult> OpenRoulette([FromBody]IdRoulette_Wrapper OpenRoulette)
        {
            try
            {
                var RouletteOpen = await _businessOpenRoulette.OpenRoulette(OpenRoulette).ConfigureAwait(false);

                return Ok(RouletteOpen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> ListRoulette()
        {
            try
            {
                var Roulettes = await _businessListRoulettes.ListRoulettes().ConfigureAwait(false);

                return Ok(Roulettes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
