using CSharpMobileComponents.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseNavigationPage : ContentPage
    {
        public View ChildContent
        {
            get { return this.ChildContentContainer.Content; }
            set { this.ChildContentContainer.Content = value; }
        }
        public bool IsModalBeingUsed { get; set; } = false;
        public Frame ModalFrame { get; set; }
        public Frame ModalBorderFrame { get; set; }
        public Frame OverlayFrame { get; set; }

        public BaseNavigationPage()
        {
            InitializeComponent();
            OverlayFrame = overlayFrame;
            ModalBorderFrame = modalBorderFrame;
            ModalFrame = modalFrame;
            ResetToolbar();
        }
        public void OnCloseModal(System.Object sender, System.EventArgs e)
        {
            ToogleModalVisibility(false);
        }

        public void ToogleModalVisibility(bool isVisible, View modalView = null) // order matters
        {
            if (isVisible)
            {
                if (IsModalBeingUsed)
                    return;

                OverlayFrame.IsVisible = isVisible;
                ModalBorderFrame.IsVisible = isVisible;
                ModalFrame.IsVisible = isVisible;
                ModalFrame.Content = modalView;
                IsModalBeingUsed = true;
                return;

            }

            ModalFrame.IsVisible = isVisible;
            ModalBorderFrame.IsVisible = isVisible;
            OverlayFrame.IsVisible = isVisible;
            ModalFrame.Content = null;
            IsModalBeingUsed = false;
        }

        private void ResetToolbar()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.ToolbarItems.Clear(); 

                ToolbarItem changeThemeToolbarItem = new ToolbarItem() { IconImageSource = "icon_sun", Priority = 0, Order = ToolbarItemOrder.Primary };
                changeThemeToolbarItem.Clicked += OnChangeTheme;
                Application.Current.MainPage.ToolbarItems.Add(changeThemeToolbarItem);
            });
        }

        private void OnChangeTheme(object sender, EventArgs e)
        {
            var vm = (BaseViewModel)this.BindingContext;
            if (vm == null)
                return;
            vm.SwitchColorTheme(); 
        }
    }
}