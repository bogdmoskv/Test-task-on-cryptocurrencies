using CryptocurrenciesProject.Models;
using CryptocurrenciesProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesProject.ViewModels
{
    class CryptoCurrencyViewModel : ViewModelBase
    {
        private string selectedCryptoId;
        private CryptoCurrency selectedCrypto;

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
    }

}
