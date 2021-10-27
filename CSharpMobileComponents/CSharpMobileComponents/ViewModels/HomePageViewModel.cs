using CSharpMobileComponents.Models.Lists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using CSharpMobileComponents.Resources.Util;
using System.Threading.Tasks;

namespace CSharpMobileComponents.ViewModels
{
    public class HomePageViewModel : NavigationViewModel
    {
        public ICommand GoToMenuPageCommand { get; set; }
        public int Test { get; set; } = 2;
        public ObservableCollection<ThemesModel> list { get; set; } = new ObservableCollection<ThemesModel>();
        public ICommand CheckItemCommand { get; set; }

        public   HomePageViewModel()
        {
            GoToMenuPageCommand = new Command(() => GoToMenu());
            CheckItemCommand = new Command<ThemesModel>(async (model) =>
            {
              await RunTaskAndUpdateUI(() => CheckItem(model));
             
             
            });

            list.Add(new ThemesModel() { DisplayText = "2", IsSelected = true });
            list.Add(new ThemesModel() { DisplayText = "3" });
            list.Add(new ThemesModel() { DisplayText = "1" });
            list.Add(new ThemesModel() { DisplayText = "5" });
            list.Add(new ThemesModel() { DisplayText = "4" });
            list.Add(new ThemesModel() { DisplayText = "44" });
            list.Add(new ThemesModel() { DisplayText = "94" });
            list.Add(new ThemesModel() { DisplayText = "74" });
            list.Add(new ThemesModel() { DisplayText = "34" });
            list.Add(new ThemesModel() { DisplayText = "14" });
            list.Add(new ThemesModel() { DisplayText = "24" });


        }

        private void GoToMenu()
        {

        }
        private Task CheckItem(ThemesModel model)
        {
            list.SortAscending(s => s.DisplayText);
            //list.Add(model);
            OnPropertyChanged("list");
            return Task.CompletedTask;
        }

        private Task<int> CheckItem2(ThemesModel model)
        {
            return Task.FromResult(2);
        }

    }
}
