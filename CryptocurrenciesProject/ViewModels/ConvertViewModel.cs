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

        private async void LoadCryptoCurrencies()
        {
            List<CryptoCurrency> currencies = await cryptoApiService.GetCryptoCurrencies();
            CryptoCurrencies = new ObservableCollection<CryptoCurrency>(currencies);      
        }

    }
}
