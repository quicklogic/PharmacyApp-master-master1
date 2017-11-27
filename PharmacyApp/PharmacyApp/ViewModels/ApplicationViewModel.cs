using PharmacyApp.Models;
using PharmacyApp.Utility;
using PharmacyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   // была ли начальная инициализация
        Product selectedProduct;  // выбранный друг
        private bool isBusy;    // идет ли загрузка с сервера

        public ObservableCollection<Product> Products { get; set; }
        PharmacyService pharmacyService = new PharmacyService();
        public event PropertyChangedEventHandler PropertyChanged;

        
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ApplicationViewModel()
        {
            Products = new ObservableCollection<Product>();
            IsBusy = false;
            
            BackCommand = new Command(Back);
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (selectedProduct != value)
                {
                    Product tempProduct = new Product()
                    {
                        ID = value.ID,
                        Name = value.Name,
                        Category = value.Category,
                        Price = value.Price,
                        Type = value.Type,
                        Description = value.Description
                    };
                    selectedProduct = null;
                    OnPropertyChanged("SelectedProduct");
                    Navigation.PushAsync(new ProductPage(tempProduct, this));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        
        private void Back()
        {
            Navigation.PopAsync();
        }

       

        public async Task GetProducts()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Product> products = await pharmacyService.Get();

            
            Products.Clear();
            while (Products.Any())
                Products.RemoveAt(Products.Count - 1);

            
            foreach (Product p in products)
                Products.Add(p);
            IsBusy = false;
            initialized = true;
        }
 
    }

    }
