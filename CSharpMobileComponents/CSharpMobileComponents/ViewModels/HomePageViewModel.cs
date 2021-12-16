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
using CSharpMobileComponents.DataStores;
using System.Collections.Specialized;
using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;

namespace CSharpMobileComponents.ViewModels
{
    public class HomePageViewModel : NavigationViewModel
    {
        public ICommand GoToMenuPageCommand { get; set; }
        public NotifyCollectionChangedEventHandler ListCollectionChangedEvent = null;
        public ObservableCollection<ThemesModel> List
        {
            get
            {

                var retVal = ColorsDataStore.Instance.List;
                if (ListCollectionChangedEvent != null)
                {
                    retVal.CollectionChanged -= ListCollectionChangedEvent;
                    retVal.CollectionChanged += ListCollectionChangedEvent;

                }
                return retVal;
            }

        }

        //public ObservableCollection<ObservableGroupCollection<object, GroupingTestModel>> GroupedList
        //{
        //    get
        //    {

        //        var retVal = TestDataStore.Instance.GroupedList;
        //        //if (ListCollectionChangedEvent != null)
        //        //{
        //        //    retVal.CollectionChanged -= ListCollectionChangedEvent;
        //        //    retVal.CollectionChanged += ListCollectionChangedEvent;

        //        //}
        //        return retVal;
        //    }

        //}

        public ObservableCollection<GroupingTestModel> ListToGroup { get; set; } = new ObservableCollection<GroupingTestModel>(TestDataStore.Instance.ListToGroup.ToList());
        public ICommand CheckItemCommand { get; set; }

        public HomePageViewModel()
        {
            GoToMenuPageCommand = new Command(() => GoToMenu());
            CheckItemCommand = new Command<ISelectableModel>(async (_themesModel) => await RunTaskAndUpdateUI(() => CheckItem(_themesModel)));




        }

        private void GoToMenu()
        {

        }
        private Task CheckItem(ISelectableModel model)
        {
         
            model.IsSelected = !model.IsSelected;
            //OnPropertyChanged("list");
            return Task.CompletedTask;
        }


        public async void ScrollView_OnScrolled(object sender, ScrolledEventArgs e) //Pagination if needed!!
        {
            if (!(sender is ScrollView scrollView))
                return;

            var scrollingSpace = scrollView.ContentSize.Height - scrollView.Height;

            if (scrollingSpace >( e.ScrollY + 5) )
                return;

            await RunTaskAndUpdateUI(async () =>
            {
                await ColorsDataStore.Instance.AddMoreItems();
                OnPropertyChanged("List");
            });
        }

    }
}
