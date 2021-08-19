using Microsoft.AspNetCore.Mvc;

namespace TaxaJuros.Controllers
{
    [Route("")]
    public class TaxaJurosController : ControllerBase
    {
        public TaxaJurosController()
        {

        }

        [HttpGet("/taxaJuros")]
        public IActionResult TaxaJuros()
        {
            return Ok(0.01);
        }
    }
}
