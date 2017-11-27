using PharmacyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PharmacyApp.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListPage : ContentPage
    {
        ApplicationViewModel viewModel;
        public ProductListPage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
            productsList.ItemSelected += ProductsList_ItemSelected;
            
        }

        private void ProductsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                    ((ListView)sender).SelectedItem = null;
        }
       
         private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
                {
                    productsList.BeginRefresh();

                    if (string.IsNullOrWhiteSpace(e.NewTextValue))
                        productsList.ItemsSource = viewModel.Products;
                    else
                         productsList.ItemsSource = viewModel.Products.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));

                    productsList.EndRefresh();
                }


        protected override async void OnAppearing()
        {
            await viewModel.GetProducts();
            base.OnAppearing();
        }

    }
}