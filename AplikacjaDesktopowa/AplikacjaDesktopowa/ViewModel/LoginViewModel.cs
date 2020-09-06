using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace AplikacjaDesktopowa.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        private RelayCommand _clickCommand;
        public ICommand clickCommand
        {
            get
            {
                return _clickCommand;
            }
        }
        public LoginViewModel(AppViewModel App)
        {
            _clickCommand = new RelayCommand((p) => {
                App.CurrentView = new AdminViewModel();
            });
        }

    }
}
