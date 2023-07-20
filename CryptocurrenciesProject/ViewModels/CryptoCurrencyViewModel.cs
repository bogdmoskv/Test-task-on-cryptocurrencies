using CryptocurrenciesProject.Commands;
using CryptocurrenciesProject.Models;
using CryptocurrenciesProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptocurrenciesProject.ViewModels
{
    class CryptoCurrencyViewModel : ViewModelBase
    {
        private string selectedCryptoId;
        private CryptoCurrency selectedCrypto;
        public ICommand RefreshCommand { get; }

        public CryptoCurrencyViewModel()
        {
            RefreshCommand = new RelayCommand(Refresh);
        }

        public string SelectedCryptoId
        {
            get { return selectedCryptoId; }
            set
            {
                if (selectedCryptoId != value)
                {
                    selectedCryptoId = value;
                    OnPropertyChanged(nameof(SelectedCryptoId));
                }
            }
        }

        public CryptoCurrency SelectedCrypto
        {
            get { return selectedCrypto; }
            set
            {
                selectedCrypto = value;
                OnPropertyChanged(nameof(SelectedCrypto));
            }
        }

        

        public async void Refresh(object parameter)
        {
            CryptoApiService cryptoApiService = new CryptoApiService();
            SelectedCrypto = await cryptoApiService.GetCryptoCurrencyById(SelectedCrypto.Id);
            MessageBox.Show("Інформацію було оновлено!");
        }
    }

}
