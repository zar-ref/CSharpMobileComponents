using CSharpMobileComponents.Resources.Controls;
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
            InitializeComponent();

            BindingContext = _viewModel = new HomePageViewModel();


            list.SetBinding(ListView.ItemsSourceProperty, "list");
            list.SetValue(SelectableListView.ChildViewProperty, new StringOnlyView());
            //var dataTemplate = new DataTemplate(() =>
            //{


            //    var selectableCell = new SelectableRadioViewCell();
            //    //var x = new Label();
            //    //x.SetBinding(Label.TextProperty, "DisplayText");
            //    //selectableCell.ChildView = x;
            //    //return new ViewCell { View = x };
            //    //return selectableCell;

            //    var stringOnlyLabel = new StringOnlyView();
            //    stringOnlyLabel.SetViewBindings();
            //    return new ViewCell { View = stringOnlyLabel };
            //});
            //list.ItemTemplate = dataTemplate;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.OnPropertyChanged("Translations");
        }

        private void PrimaryBtnControl_ButtonClicked(object sender, EventArgs e)
        {
            //_viewModel.SwitchColorTheme();
            //_viewModel.list.FirstOrDefault().IsSelected = !_viewModel.list.FirstOrDefault().IsSelected;
        }

        private void PrimaryBtnControl_ButtonClicked_2(object sender, EventArgs e)
        {
            _viewModel.SwitchTranslations(CSharpMobileComponents.Resources.Constants.Languages.English);
        }
    }
}