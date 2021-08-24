using Domain.Entities;
using Domain.Validator;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculadoraJuros.Testes.Validators
{
    public class ValidatorRequest
    {
        public ValidatorRequest()
        {

        }

        [Fact]
        public void FiltroMesNegativoRetornaErro()
        {
            var validator = new RequestValidator();
            var request = new RequestDTO { Meses = 0, ValorInicial = 100 };            
            
            var result= validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Meses);
        }

        [Fact]
        public void FiltroValorInicialNegativoRetornaErro()
        {
            var validator = new RequestValidator();
            var request = new RequestDTO { Meses = 5, ValorInicial = -15 };

            var result = validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.ValorInicial);
        }
    }
}
