using CalculadoraJuros.Controller;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Validator;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CalculadoraJuros.Testes.Controller
{ 
    public class ControllerTest
    {
        private readonly CalculadoraJurosController _controller;
        private readonly Mock<ICalculadoraService> _mockService;
        public ControllerTest()
        {
            _mockService = new Mock<ICalculadoraService>();
            _mockService.Setup(x => x.CalcularJuros(It.IsAny<RequestDTO>())).Returns(Task.FromResult(105.10m));
            _controller = new CalculadoraJurosController(_mockService.Object);
        }

        [Fact]
        public void CalcularJuros_5_meses_valorinicial_100_Retorna_105virgula10()
        {
            var request = new RequestDTO { Meses = 5, ValorInicial = 100 };

            // 105,10
            var result = _controller.CalcularJuros(request).GetAwaiter().GetResult();
            var valorTotal = result as OkObjectResult;

            Assert.Equal(105.10M, valorTotal.Value);
        }
    }
}
