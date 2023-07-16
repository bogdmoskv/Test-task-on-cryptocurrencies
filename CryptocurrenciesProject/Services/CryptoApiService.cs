using CryptocurrenciesProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

                    foreach (var item in assets)
                    {
                        CryptoCurrency cryptoCurrency = item.ToObject<CryptoCurrency>();

                        string symbol = cryptoCurrency.Symbol.ToLower();
                        string imageUrl = $"https://assets.coincap.io/assets/icons/{symbol}@2x.png";
                        try
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(imageUrl);
                            bitmap.EndInit();

                            cryptoCurrency.Icon = bitmap;
                        }
                        catch (Exception ex)
                        {
                           
                        }

                        cryptoCurrencies.Add(cryptoCurrency);
                    }
                }
            }
            catch
            {
           
            }

            return cryptoCurrencies;
        }






    }



}

