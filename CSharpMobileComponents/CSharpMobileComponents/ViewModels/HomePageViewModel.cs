using CSharpMobileComponents.Models.Lists;
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
        public List<ThemesModel> list { get; set; } = new List<ThemesModel>();
        public HomePageViewModel()
        { 
            GoToMenuPageCommand = new Command(() => GoToMenu());
            list.Add(new ThemesModel() { DisplayText = "yo"});
            list.Add(new ThemesModel() { DisplayText = "yoa"});
       

        }

        private void GoToMenu()
        {

        }
    }
}
