using PharmacyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    public class MasterPageViewModel
    {

        public ICommand GoHomeCommand { get; set; }
        public ICommand GoUserProfile { get; set; }

        public MasterPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
            GoUserProfile = new Command(GoSecond);
        }

        void GoHome(object obj)
        {
            App.NavigationPage.Navigation.PopToRootAsync();
            App.MenuIsPresented = false;
        }

        void GoSecond(object obj)
        {
            App.NavigationPage.Navigation.PushAsync(new UsepProfilePage());
            App.MenuIsPresented = false;
        }
    }
}
        