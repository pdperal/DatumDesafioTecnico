using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaxaJuros.Controllers;
using Xunit;

namespace TaxaJuros.Testes
{
    public class ControllerTest
    {
        private readonly TaxaJurosController _controller;
        public ControllerTest()
        {
            _controller = new TaxaJurosController();
        }

        [Fact]
        public void ChamarEndpointTaxaJuros_Retorna_Sucesso()
        {
            var result = _controller.ObterTaxaJuros();
            var taxaJuros = result as OkObjectResult;

            Assert.NotNull(taxaJuros);
            Assert.Equal(StatusCodes.Status200OK, taxaJuros.StatusCode);
            Assert.Equal(0.01m, taxaJuros.Value);
            Assert.IsType<decimal>(taxaJuros.Value);
        }
    }
}
