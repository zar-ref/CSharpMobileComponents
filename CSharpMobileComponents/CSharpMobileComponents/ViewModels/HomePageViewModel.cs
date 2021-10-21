using CSharpMobileComponents.Models.Lists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CSharpMobileComponents.ViewModels
{
    public class HomePageViewModel : NavigationViewModel
    {
        public ICommand GoToMenuPageCommand { get; set; }
        public int Test { get; set; } = 2;
        public ObservableCollection<ThemesModel> list { get; set; } = new ObservableCollection<ThemesModel>();
        public ICommand CheckItemCommand { get; set; }

        public HomePageViewModel()
        { 
            GoToMenuPageCommand = new Command(() => GoToMenu());
            CheckItemCommand = new Command<ThemesModel>(model => CheckItem(model));
            list.Add(new ThemesModel() { DisplayText = "yo", IsSelected = true }) ;
            list.Add(new ThemesModel() { DisplayText = "todelete"});
            list.Add(new ThemesModel() { DisplayText = "yoa"});
            list.Add(new ThemesModel() { DisplayText = "yoa"});
       

        }

        private void GoToMenu()
        {

        }
        public void CheckItem(ThemesModel model)
        {
            list.Add(model);
            //OnPropertyChanged("list");
        }
    }
}
