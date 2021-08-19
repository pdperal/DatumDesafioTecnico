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
        public IActionResult ObterTaxaJuros()
        {
            return Ok(0.01M);
        }
    }
}
