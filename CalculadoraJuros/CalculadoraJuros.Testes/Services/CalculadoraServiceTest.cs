using CalculadoraJuros.Controller;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CalculadoraJuros.Testes.Services
{
    public class CalculadoraServiceTest
    {
        private readonly CalculadoraService _service;
        private readonly Mock<ITaxaJurosService> _mockRestService;

        public CalculadoraServiceTest()
        {
            _mockRestService = new Mock<ITaxaJurosService>();
            _service = new CalculadoraService(_mockRestService.Object);

            _mockRestService.Setup(x => x.ObterTaxaJuros()).Returns(Task.FromResult(0.01m));
        }

        [Fact]
        public void CalcularJuros_5_meses_valorinicial_100_Retorna_105virgula10()
        {
            var request = new RequestDTO { Meses = 5, ValorInicial = 100 };

            // 105,10
            var resultado = _service.CalcularJuros(request).GetAwaiter().GetResult();

            Assert.Equal(105.10M, resultado);
        }
    }
}
