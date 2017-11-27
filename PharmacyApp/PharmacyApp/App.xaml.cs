using PharmacyApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PharmacyApp
{
    public partial class App : Application
    {
        //public App()
        //{
            //InitializeComponent();
            //MainPage = new NavigationPage(new ProductListPage());
        //}

        public static NavigationPage NavigationPage { get; private set; }
        private static RootPage RootPage;
        public static bool MenuIsPresented
        {
            get
            {
                return RootPage.IsPresented;
            }
            set
            {
                RootPage.IsPresented = value;
            }
        }
        

        public App()
        {
            InitializeComponent();
            var menuPage = new MenuPage();
            NavigationPage = new NavigationPage(new ProductListPage());
            RootPage = new RootPage();
            RootPage.Master = menuPage;
            RootPage.Detail = NavigationPage;
            MainPage = RootPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
