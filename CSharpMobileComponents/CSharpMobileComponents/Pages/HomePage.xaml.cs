using CSharpMobileComponents.Resources.Controls;
using CSharpMobileComponents.Resources.Controls.StackLayoutList;
using CSharpMobileComponents.Resources.Converters;
using CSharpMobileComponents.Resources.CustomViews;
using CSharpMobileComponents.Resources.Util.Tint;
using CSharpMobileComponents.Resources.ViewCells;
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
            PageHashCode = this.GetHashCode();
            InitializeComponent();
           

            BindingContext = _viewModel = new HomePageViewModel();
            list.InitStackList("list" , new StringOnlyView() , null , _viewModel.CheckItemCommand);
            _viewModel.list.CollectionChanged += list.Xx_CollectionChanged;
            //list.SetBinding(StackLayoutList.BindingContextProperty, "list");
            //list.SetValue(StackLayoutList.ItemViewProperty, new StringOnlyView());            
        }

     

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.OnPropertyChanged("Translations");
        }

        private void PrimaryBtnControl_ButtonClicked(object sender, EventArgs e)
        {
            //_viewModel.SwitchColorTheme();
            _viewModel.list.FirstOrDefault().IsSelected = !_viewModel.list.FirstOrDefault().IsSelected;
            _viewModel.list.FirstOrDefault().DisplayText = "changed!";
        }

        private void PrimaryBtnControl_ButtonClicked_2(object sender, EventArgs e)
        {
            _viewModel.list.LastOrDefault().DisplayText = "changed! again";
            //_viewModel.SwitchTranslations(CSharpMobileComponents.Resources.Constants.Languages.English);
        }
    }
}