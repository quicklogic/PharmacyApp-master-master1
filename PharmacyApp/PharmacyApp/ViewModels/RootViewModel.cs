using PharmacyApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    public class RootViewModel
    {
        public ICommand GoSearchCommand { get; set; }

        public RootViewModel()
        {
            GoSearchCommand = new Command(GoSearch);
        }

        void GoSearch(object obj)
        {
            App.NavigationPage.Navigation.PushAsync(new UsepProfilePage());
            App.MenuIsPresented = false;
        }

      
    }
}
