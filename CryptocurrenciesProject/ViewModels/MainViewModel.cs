using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CryptocurrenciesProject.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowHomeViewCommand
        {
            get;
        }

        public ICommand ShowConvertViewCommand
        {
            get;
        }

        public MainViewModel()
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);
            ShowConvertViewCommand = new ViewModelCommand(ExecuteShowConvertViewCommand);
        }


        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Головна сторінка";
            Icon = IconChar.Home;
        }

        private void ExecuteShowConvertViewCommand(object obj)
        {
            CurrentChildView = new ConvertViewModel();
            Caption = "Конвертація";
            Icon = IconChar.Coins;
        }
    }
}
