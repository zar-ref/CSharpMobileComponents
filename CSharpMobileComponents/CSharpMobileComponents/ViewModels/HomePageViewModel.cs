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
using static CSharpMobileComponents.Resources.Constants;
using CSharpMobileComponents.Resources;

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


        public NotifyCollectionChangedEventHandler GroupedListCollectionChangedEvent = null;
        public ObservableCollection<GroupingTestModel> ListToGroup
        {
            get
            {
                var retVal = TestDataStore.Instance.ListToGroup;
                if (GroupedListCollectionChangedEvent != null)
                {
                    retVal.CollectionChanged -= GroupedListCollectionChangedEvent;
                    retVal.CollectionChanged += GroupedListCollectionChangedEvent;
                }
                return retVal;
            }
        }
        public NotifyCollectionChangedEventHandler GroupedListCollectionChangedEvent2 = null;
        public ObservableCollection<GroupingTestModel> ListToGroup2
        {
            get
            {
                var retVal = TestDataStore.Instance.ListToGroup2;
                if (GroupedListCollectionChangedEvent2 != null)
                {
                    retVal.CollectionChanged -= GroupedListCollectionChangedEvent2;
                    retVal.CollectionChanged += GroupedListCollectionChangedEvent2;
                }
                return retVal;
            }
        }


        public ICommand CheckItemCommand { get; set; }
        public ICommand CheckItemInAlertCommand { get; set; }
        public ICommand CheckItemInAlertYesOrNoCommand { get; set; }
        public ICommand SelectItemCommand { get; set; }
        public ICommand SelectItemYesOrNoCommand { get; set; }

        public HomePageViewModel()
        {
            GoToMenuPageCommand = new Command(() => GoToMenu());
            CheckItemCommand = new Command<ISelectableModel>(async (_selectableModel) => await RunTaskAndUpdateUI(() => CheckItem(_selectableModel)));
            CheckItemInAlertCommand = new Command<ISelectableModel>(async (_selectableModel) => await RunTaskAndUpdateUI(() => CheckItemInAlert(_selectableModel)));
            SelectItemCommand = new Command<ISelectableModel>(async (_selectableModel) => await RunTaskAndUpdateUI(() => SelectItem(_selectableModel)));
            //Yes or no selection
            CheckItemInAlertYesOrNoCommand = new Command<AlertYesOrNoChoiceCommandParameterModel>(async (_selectableModel) => await RunTaskAndUpdateUI(() => CheckItemInAlertYesOrNo(_selectableModel)));
            SelectItemYesOrNoCommand = new Command<object>(async (_selectableModel) => await RunTaskAndUpdateUI(() => SelectItemYesOrNo(_selectableModel)));




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
        private Task CheckItemInAlert(ISelectableModel model)
        {

            model.IsSelected = !model.IsSelected;
            //OnPropertyChanged("list");
            MessagingCenter.Send<object>(this, Constants.CustomControlsMessagesNames.CloseAlertModal.ToString());
            return Task.CompletedTask;
        }
        private Task CheckItemInAlertYesOrNo(AlertYesOrNoChoiceCommandParameterModel model)
        {
            var selectable = model.CommandParameter as ISelectableModel;
            selectable.IsSelected = model.Choice;
            //OnPropertyChanged("list");
            //MessagingCenter.Send<object>(this, Constants.CustomControlsMessagesNames.CloseAlertModal.ToString());
            return Task.CompletedTask;
        }

        private Task SelectItem(ISelectableModel model)
        {
            AlertModel newAlert = new AlertModel(Resources.Constants.AlertTypes.Info, "Selecting Item?", "Do you wish to select the item Yes Or no?", null, CheckItemCommand, model);

            MessagingCenter.Send<object, AlertModel>(this, CustomControlsMessagesNames.OpenAlertModal.ToString(), newAlert);

            return Task.CompletedTask;
        }
        private Task SelectItemYesOrNo(object model)
        {
            AlertModel newAlert = new AlertModel(
                 Resources.Constants.AlertTypes.Info,
                 "Selecting Item?",
                 "Do you wish to select the item?",
                 CheckItemInAlertYesOrNoCommand,
                 null,
                 new AlertYesOrNoChoiceCommandParameterModel() { Choice = true, CommandParameter = model },
                 CheckItemInAlertYesOrNoCommand,
                 null,
                 new AlertYesOrNoChoiceCommandParameterModel() { Choice = false, CommandParameter = model });

            MessagingCenter.Send<object, AlertModel>(this, CustomControlsMessagesNames.OpenAlertModal.ToString(), newAlert);

            return Task.CompletedTask;
        }

        public async void ScrollView_OnScrolled(object sender, ScrolledEventArgs e) //Pagination if needed!!
        {
            if (!(sender is ScrollView scrollView))
                return;

            var scrollingSpace = scrollView.ContentSize.Height - scrollView.Height;

            if (scrollingSpace > (e.ScrollY + 5))
                return;

            await RunTaskAndUpdateUI(async () =>
            {
                await ColorsDataStore.Instance.AddMoreItems();
                OnPropertyChanged("List");
            });
        }

    }
}
