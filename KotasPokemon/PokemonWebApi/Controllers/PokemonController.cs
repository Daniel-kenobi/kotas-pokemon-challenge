using Domain.Mediators.Pokemon.Commmand;
using Domain.Mediators.Pokemon.Query;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PokemonWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController(IMediator _mediator) : Controller
    {
        [HttpGet("get-random")]
        public async Task<IActionResult> GetRandom()
        {
            var response = new Response<List<Pokemon>>();

            try
            {
                response.Result = await _mediator.Send(new GetRandomPokemonQuery());    

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = new Response<Pokemon>();

            try
            {
                response.Result = await _mediator.Send(new GetPokemonByIdQuery() { Id = id});

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPost("capture/{id}")]
        public async Task<IActionResult> Capture([FromRoute] int id)
        {
            var response = new Response<Pokemon>();

            try
            {
                await _mediator.Send(new CapturePokemonCommand() { Id = id });
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("captured")]
        public async Task<IActionResult> Captured()
        {
            var response = new Response<List<Pokemon>>();

            try
            {
                response.Result = await _mediator.Send(new GetCapturedPokemonsQuery());

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return StatusCode(500, response);
            }
        }
    }
}
