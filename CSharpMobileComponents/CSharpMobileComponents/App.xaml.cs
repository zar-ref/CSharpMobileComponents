using CSharpMobileComponents.DataStores;
using CSharpMobileComponents.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents
{
    public partial class App : Application
    {
        public App()
        {
            //_ = ColorsDataStore.Instance;
            //_ = LanguagesDataStore.Instance;
            //_ = SizesDataStore.Instance;

            InitializeComponent();
            MainPage = new HomePage();
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
