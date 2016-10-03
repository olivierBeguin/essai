using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Labo4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Labo4.ViewModel
{
    class SecondViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public Student SelectedStudent { get; set; }
        private INavigationService _navigationService;

        [PreferredConstructor]
        public SecondViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

        public void OnNavigateTo(NavigationEventArgs e)
        {
            SelectedStudent = (Student)e.Parameter;
        }
    }
}
