using CryptocurrenciesProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesProject.Services
{
    class CryptoApiService
    {
        private readonly HttpClient httpClient;
        public CryptoApiService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<CryptoCurrency>> GetCryptoCurrencies()
        {
            List<CryptoCurrency> cryptoCurrencies = new List<CryptoCurrency>();

            try
            {
                string apiUrl = "https://api.coincap.io/v2/assets";
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    string responseBody = await response.Content.ReadAsStringAsync();


                    JObject json = JObject.Parse(responseBody);
                    JArray assets = (JArray)json["data"];
                    cryptoCurrencies = assets.ToObject<List<CryptoCurrency>>();
                }
                else
                {

                }
            }
            catch
            {

            }

            return cryptoCurrencies;
        }
    }
}

