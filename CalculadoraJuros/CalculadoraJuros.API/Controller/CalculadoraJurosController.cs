using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculadoraJuros.Controller
{
    [Route("")]
    public class CalculadoraJurosController : ControllerBase
    {
        private readonly ICalculadoraService _service;

        public CalculadoraJurosController(ICalculadoraService service)
        {
            _service = service;
        }

        [HttpGet("calculajuros")]
        public async Task<ActionResult> CalcularJuros([FromQuery] RequestDTO request)
        {
            var data = await _service.CalcularJuros(request);
            return Ok(data);
        }
    }
}
