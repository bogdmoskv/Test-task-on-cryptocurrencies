using CryptocurrenciesProject.Models;
using CryptocurrenciesProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesProject.ViewModels
{
    class ConvertViewModel :ViewModelBase
    {
        private CryptoApiService cryptoApiService;
        private ObservableCollection<CryptoCurrency> cryptoCurrencies;

        private CryptoCurrency selectedFromCoin;
        private CryptoCurrency selectedToCoin;
        private decimal result;


        public ConvertViewModel()
        {
            cryptoApiService = new CryptoApiService();
            LoadCryptoCurrencies();
        }
        public ObservableCollection<CryptoCurrency> CryptoCurrencies
        {
            get { return cryptoCurrencies; }
            set
            {

                cryptoCurrencies = value;
                OnPropertyChanged(nameof(CryptoCurrencies));
            }
        }

        private double count;

        public double Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
                CalculateResult();
            }
        }



        private async void LoadCryptoCurrencies()
        {
            List<CryptoCurrency> currencies = await cryptoApiService.GetCryptoCurrencies();
            CryptoCurrencies = new ObservableCollection<CryptoCurrency>(currencies);      
        }

        public CryptoCurrency SelectedFromCoin
        {
            get { return selectedFromCoin; }
            set
            {
                selectedFromCoin = value;
                CalculateResult();
                OnPropertyChanged(nameof(SelectedFromCoin));
            }
        }

        public CryptoCurrency SelectedToCoin
        {
            get { return selectedToCoin; }
            set
            {
                selectedToCoin = value;
                CalculateResult();
                OnPropertyChanged(nameof(SelectedToCoin));
            }
        }

        public decimal Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }


        private void CalculateResult()
        {
            if (SelectedFromCoin != null && SelectedToCoin != null && Count > 0)
            {
                if (double.TryParse(Count.ToString(), out double amount))
                {
                    // Отримуємо курс першої криптовалюти до долара
                    decimal? fromCurrencyToUSD = SelectedFromCoin.PriceUsd;

                    // Отримуємо курс другої криптовалюти до долара
                    decimal? toCurrencyToUSD = SelectedToCoin.PriceUsd;

                    if (fromCurrencyToUSD.HasValue && toCurrencyToUSD.HasValue)
                    {
                        // Конвертуємо суму в першій криптовалюті в долари
                        decimal amountInUSD = (decimal)amount * (decimal)fromCurrencyToUSD.Value;

                        // Конвертуємо суму в доларах в еквівалентну суму в другій криптовалюті
                        decimal result = amountInUSD / (decimal)toCurrencyToUSD.Value;

                        // Оновлюємо значення Result
                        Result = result;
                    }
                    else
                    {
                        Result = 0;
                    }
                }
                else
                {
                    Result = 0;
                }
            }
            else
            {
                Result = 0;
            }
        }


    }
}
