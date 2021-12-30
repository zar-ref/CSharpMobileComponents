using CSharpMobileComponents.DataStores;
using CSharpMobileComponents.Models.Lists;
using CSharpMobileComponents.Resources.Controls;
using CSharpMobileComponents.Resources.Controls.StackLayoutList;
using CSharpMobileComponents.Resources.Converters;
using CSharpMobileComponents.Resources.CustomViews;
using CSharpMobileComponents.Resources.Util.Tint;
using CSharpMobileComponents.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : BaseNavigationPage
    {
        public HomePageViewModel _viewModel;
        public HomePage()
        {

            InitializeComponent();
            BindingContext = _viewModel = new HomePageViewModel();
            _ = _viewModel.RunTaskAndUpdateUI(async () => await InitPage());
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

            //_viewModel.OnPropertyChanged("Translations");
        }

        private void PrimaryBtnControl_ButtonClicked(object sender, EventArgs e)
        {
            //_viewModel.List.RemoveAt(0);
            //_viewModel.SwitchColorTheme(); 
            //_viewModel.ListToGroup.RemoveAt(0);
            //_viewModel.OnPropertyChanged("ListToGroup");
            TestDataStore.Instance.ListToGroup.Add(new GroupingTestModel("ne2222www_0"));
        }

        private void PrimaryBtnControl_ButtonClicked_2(object sender, EventArgs e)
        {
            //ColorsDataStore.Instance.List.Add(new Models.Lists.ThemesModel() { DisplayText = "neww" });
            //ColorsDataStore.Instance.List.LastOrDefault().IsSelected = !ColorsDataStore.Instance.List.LastOrDefault().IsSelected;

            //TestDataStore.Instance.ListToGroup.LastOrDefault().IsSelected = true; //= !TestDataStore.Instance.ListToGroup.LastOrDefault().IsSelected;
            //var x = TestDataStore.Instance.ListToGroup.LastOrDefault();
            TestDataStore.Instance.ListToGroup2.Add(new GroupingTestModel("newww1_1"));

            //_ = _viewModel.ListToGroup;c
            //_viewModel.OnPropertyChanged("ListToGroup");
            //_ = _viewModel.List; 
            //_viewModel.list.LastOrDefault().DisplayText = "changed! again";
            //_viewModel.SwitchTranslations(CSharpMobileComponents.Resources.Constants.Languages.English);
        }

        private async Task InitPage()
        {
            //_viewModel.ListCollectionChangedEvent = list.StackLayoutCollectionChanged;
            //list.InitStackList("List", new StringOnlyView(), null, _viewModel.CheckItemCommand);
            _viewModel.GroupedListCollectionChangedEvent = groupedlist.StackLayoutGroupedCollectionChanged;
            groupedlist.InitGroupedStackList("ListToGroup", "GroupText", new GroupKeyStringOnlyView(), new StringOnlyView(), null, null);

            _viewModel.GroupedListCollectionChangedEvent2 = groupedlist2.StackLayoutGroupedCollectionChanged;
            groupedlist2.InitGroupedStackList("ListToGroup2", "GroupText", new GroupKeyStringOnlyView(), new StringOnlyView2(), null, null);
            return;
        }
    }
}