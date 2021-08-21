using CSharpMobileComponents.DataStores;
using CSharpMobileComponents.Pages;
using CSharpMobileComponents.Resources.Styles;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents
{
    public partial class App : Application
    {
        public App()
        {


            InitializeComponent();
            MainPage = new NavigationPage(new HomePage()) { BarBackgroundColor = CustomStyles.GetColorFromName(ColorNames.Primary.ToString()) };
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
