using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculadoraService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<decimal> CalcularJuros(RequestDTO request)
        {
            decimal valor = default;

            try
            {
                var taxaJuros = await ObterTaxaDeJuros();
                valor = CalcularJurosRecursivamente(request.ValorInicial, request.Meses, 1, taxaJuros);

                return valor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return valor;
        }

        private decimal CalcularJurosRecursivamente(decimal valorInicial, int quantidadeMesesTotal, int mesAtual, decimal taxa)
        {
            valorInicial *= (1 + taxa);

            if (quantidadeMesesTotal == mesAtual)
            {
                return decimal.Round(valorInicial, 2);
            }

            return CalcularJurosRecursivamente(valorInicial, quantidadeMesesTotal, ++mesAtual, taxa);
        }

        private async Task<decimal> ObterTaxaDeJuros()
        {
            return await _taxaJurosService.ObterTaxaJuros();
        }
    }
}
