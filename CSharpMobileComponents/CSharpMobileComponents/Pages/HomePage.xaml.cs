using CSharpMobileComponents.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.OnPropertyChanged("Translations");
        }

        private void PrimaryBtnControl_ButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void PrimaryBtnControl_ButtonClicked_2(object sender, EventArgs e)
        {

        }
    }
}