using CryptocurrenciesProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                MessageBox.Show("При завантаженні списку криптовалют виникла помилка!");
            }

            return cryptoCurrencies;
        }



        public async Task<CryptoCurrency> GetCryptoCurrencyById(string cryptoId)
        {
            try
            {
                string apiUrl = $"https://api.coincap.io/v2/assets/{cryptoId}";
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseBody);
                    JToken data = json["data"];

                    if (data != null)
                    {
                        CryptoCurrency cryptoCurrency = data.ToObject<CryptoCurrency>();
                        return cryptoCurrency;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Виникла помилка! Перевірте інтернет-з'єднання!");
            }

            return null;
        }



        //public async Task<List<MarketInfo>> GetCryptoCurrencyMarkets(string cryptoId)
        //{
        //    List<MarketInfo> markets = new List<MarketInfo>();

        //    try
        //    {
        //        string apiUrl = $"https://api.coincap.io/v2/assets/{cryptoId}/markets";
        //        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            MarketResponse marketResponse = JsonConvert.DeserializeObject<MarketResponse>(responseBody);
        //            markets = marketResponse.Data;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Обработка ошибок при запросе API
        //        //Console.WriteLine("Error: " + ex.Message);
        //    }

        //    return markets;
        //}



    }



}

