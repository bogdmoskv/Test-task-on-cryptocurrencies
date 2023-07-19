using CryptocurrenciesProject.Commands;
using CryptocurrenciesProject.Models;
using CryptocurrenciesProject.Services;
using CryptocurrenciesProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptocurrenciesProject.ViewModels
{
    internal class HomeViewModel : ViewModelBase
    {
        private CryptoApiService cryptoApiService;
        private ObservableCollection<CryptoCurrency> cryptoCurrencies;
        private string searchText;
        private ObservableCollection<CryptoCurrency> filteredCryptoCurrencies;

        public ObservableCollection<CryptoCurrency> FilteredCryptoCurrencies
        {
            get { return filteredCryptoCurrencies; }
            set
            {
                filteredCryptoCurrencies = value;
                OnPropertyChanged(nameof(FilteredCryptoCurrencies));
            }
        }


        public HomeViewModel()
        {
            cryptoApiService = new CryptoApiService();
            LoadCryptoCurrencies();
            RefreshCommand = new RelayCommand(Refresh);
            TextChangedCommand = new RelayCommand(OnTextChanged);
           

        }


        public ICommand RefreshCommand { get; }
        public ICommand TextChangedCommand { get; }
        private ICommand showInformationCommand;
        public ICommand ShowInformationCommand
        {
            get
            {
                if (showInformationCommand == null)
                    showInformationCommand = new RelayCommand(ShowInformation);
                return showInformationCommand;
            }
        }

        private void ShowInformation(object parameter)
        {
            if (parameter is CryptoCurrency selectedCrypto)
            {
                // Используйте выбранную криптовалюту для получения информации или выполнения необходимых операций
                // Пример:
                MessageBox.Show($"Selected cryptocurrency: {selectedCrypto.Name}, Symbol: {selectedCrypto.Symbol}");

                CryptoCurrencyView cryptoCurrencyView = new CryptoCurrencyView();
                cryptoCurrencyView.ShowDialog();
            }
        }

        private CryptoCurrency selectedCryptoCurrency;
        public CryptoCurrency SelectedCryptoCurrency
        {
            get { return selectedCryptoCurrency; }
            set
            {
                selectedCryptoCurrency = value;
                OnPropertyChanged(nameof(SelectedCryptoCurrency));
            }
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

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateFilteredCryptoCurrencies();
            }
        }

        private async void LoadCryptoCurrencies()
        {
            List<CryptoCurrency> currencies = await cryptoApiService.GetCryptoCurrencies();
            CryptoCurrencies = new ObservableCollection<CryptoCurrency>(currencies);

            FilteredCryptoCurrencies = new ObservableCollection<CryptoCurrency>(CryptoCurrencies ?? Enumerable.Empty<CryptoCurrency>());
        }

        public void Refresh(object parameter)
        {
            LoadCryptoCurrencies();
            MessageBox.Show("Інформацію було оновлено!");
        }

        private void OnTextChanged(object parameter)
        {
            UpdateFilteredCryptoCurrencies();
        }

        private void UpdateFilteredCryptoCurrencies()
        {
            var filtered = CryptoCurrencies.Where(cryptoCurrency => cryptoCurrency.Name.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase));
            FilteredCryptoCurrencies = new ObservableCollection<CryptoCurrency>(filtered);
        }


    }
}
