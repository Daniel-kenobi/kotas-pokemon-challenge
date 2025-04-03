using Domain.Mediators.PokemonMaster.Command;
using Domain.Mediators.PokemonMaster.Query;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PokemonWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonMasterController(IMediator _mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<Response<PokemonMaster>>> InsertPokemonMaster([FromBody] PokemonMaster pokemonMaster)
        {
            var response = new Response<PokemonMaster>();

            try
            {
                response = await _mediator.Send(new InsertPokemonMasterCommand() { PokemonMaster = pokemonMaster });
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<PokemonMaster>>>> GetAllPokemonMasters()
        {
            var response = new Response<List<PokemonMaster>>();

            try
            {
                response.Result = await _mediator.Send(new GetAllPokemonMastersQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
