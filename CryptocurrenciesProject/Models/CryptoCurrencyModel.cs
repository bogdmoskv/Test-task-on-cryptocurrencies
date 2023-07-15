using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptocurrenciesProject.Models
{
    internal class CryptoCurrencyModel
    {
        private readonly HttpClient httpClient;

        public CryptoCurrencyModel()
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
            catch (Exception ex)
            {
             
            }

            return cryptoCurrencies;
        }
    }
}
