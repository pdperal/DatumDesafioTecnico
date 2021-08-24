using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validator
{
    public class RequestValidator : AbstractValidator<RequestDTO>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Meses)
                .GreaterThan(0)
                .WithMessage("Período em meses deve ser maior que Zero.");

            RuleFor(x => x.ValorInicial)
                .GreaterThan(0)
                .WithMessage("Valor inicial deve ser maior que Zero.");
        }
    }
}
