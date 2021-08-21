using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CSharpMobileComponents.ViewModels
{
    public class HomePageViewModel : NavigationViewModel
    {
        public ICommand GoToMenuPageCommand { get; set; }
        public int Test { get; set; } = 2;
        public HomePageViewModel()
        { 
            GoToMenuPageCommand = new Command(() => GoToMenu());

        }

        private void GoToMenu()
        {

        }
    }
}
