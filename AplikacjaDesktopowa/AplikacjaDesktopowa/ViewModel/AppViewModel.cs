using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AplikacjaDesktopowa.ViewModel
{
    public class AppViewModel : ViewModelBase
    {
        private ViewModelBase _CurrentView;
        public ViewModelBase CurrentView
        {
            get
            {
                return _CurrentView;
            }

            set
            {
                if (_CurrentView != value)
                {
                    _CurrentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }
        public AppViewModel()
        {
            CurrentView = new LoginViewModel(this);
        }

       
    }
}
