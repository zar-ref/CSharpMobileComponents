using CSharpMobileComponents.DataStores;
using CSharpMobileComponents.Pages;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents
{
    public partial class App : Application
    {
        public App()
        {
           

            InitializeComponent(); 
            
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
