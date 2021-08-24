using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RESTService.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly string _endpoint;
        private readonly HttpClient _httpClient;

        public TaxaJurosService(IConfiguration configuration, HttpClient httpClient)
        {
            _endpoint = configuration.GetSection("TaxJurosEndpoint").Value;
            _httpClient = httpClient;
        }
        public async Task<decimal> ObterTaxaJuros()
        {
            return await _httpClient.GetFromJsonAsync<decimal>(_endpoint);
        }
    }
}
