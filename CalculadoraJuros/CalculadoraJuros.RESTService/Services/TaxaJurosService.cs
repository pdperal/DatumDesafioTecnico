using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTService.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        public TaxaJurosService()
        {

        }
        public async Task<decimal> ObterTaxaJuros()
        {
            return await Task.FromResult(0.01M);
        }
    }
}
