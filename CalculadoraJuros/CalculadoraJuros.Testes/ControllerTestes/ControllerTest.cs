using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculadoraJuros.Testes.ControllerTestes
{
    public class ControllerTest
    {
        private readonly CalculadoraJurosController _controller;
        public ControllerTest()
        {
            _controller = new CalculadoraJurosController();
        }

        [Fact]
        public void CalcularJuros12Meses_Retorna_Ok()
        {
            // 105,10
            var retorno = _controller.CalcularJuros(100, 12);

            Assert.Equal(105.10, retorno);
        }

        [Fact]
        public void CalcularJuros0Meses_Retorna_SemSucesso()
        {
            // 105,10
            var retorno = _controller.CalcularJuros(100, 0);

            Assert.NotEqual(105.10, retorno);
        }
    }
}
