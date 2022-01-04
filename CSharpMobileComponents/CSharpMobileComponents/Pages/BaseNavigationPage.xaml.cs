using CSharpMobileComponents.Models;
using CSharpMobileComponents.Resources.Controls.Alerts;
using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CSharpMobileComponents.Resources.Constants;

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
        /// <summary>
        /// Modals
        /// </summary>
        public bool IsModalBeingUsed { get; set; } = false;
        public Frame ModalFrame { get; set; }
        public Frame ModalBorderFrame { get; set; }
        public Frame OverlayFrame { get; set; }

        /// <summary>
        /// Alerts
        /// </summary>
        public bool IsAlertModalBeingUsed { get; set; } = false;
        public Frame AlertModalFrame { get; set; }
        public Frame AlertModalBorderFrame { get; set; }
        public Frame AlertOverlayFrame { get; set; }


        public int PageHashCode { get; set; }
        public List<ICustomControl> PageCustomControls { get; set; } = new List<ICustomControl>();
        public BaseNavigationPage()
        {
            InitializeComponent();
            PageHashCode = this.GetHashCode();
            AssignFrames();
            ResetToolbar();
            MessagingCenter.Subscribe<ICustomControl, int>(this, CustomControlsMessagesNames.Register.ToString(), (sender, controlPageHashcode) =>
            {
                if (controlPageHashcode == this.PageHashCode)
                    RegisterControl(sender);
            });
        }

        private void AssignFrames()
        {
            OverlayFrame = overlayFrame;
            ModalBorderFrame = modalBorderFrame;
            ModalFrame = modalFrame;
            AlertOverlayFrame = alertOverlayFrame;
            AlertModalBorderFrame = alertModalBorderFrame;
            AlertModalFrame = alertModalFrame;
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

        public void ToogleModalAlertVisibility(bool isVisible, View alertModalView = null) // order matters
        {
            if (isVisible)
            {
                if (IsAlertModalBeingUsed)
                    return;

                AlertOverlayFrame.IsVisible = isVisible;
                AlertModalBorderFrame.IsVisible = isVisible;
                AlertModalFrame.IsVisible = isVisible;
                AlertModalFrame.Content = alertModalView;
                IsAlertModalBeingUsed = true;
                return;

            }

            AlertModalFrame.IsVisible = isVisible;
            AlertModalBorderFrame.IsVisible = isVisible;
            AlertOverlayFrame.IsVisible = isVisible;
            AlertModalFrame.Content = null;
            IsAlertModalBeingUsed = false;
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

        public void RegisterControl(object customControl)
        {
            var control = (ICustomControl)customControl;
            if (control == null)
                return;
            if (PageCustomControls.Any(_pageCustomcontrol => _pageCustomcontrol.ControlHashCode == control.ControlHashCode))
                return;
            PageCustomControls.Add(control);
        }


        private void SubscribeToMessagesOnAppearing()
        {
            MessagingCenter.Subscribe<object>(this, CustomControlsMessagesNames.CloseAlertModal.ToString(), (sender) =>
            {
                ToogleModalAlertVisibility(false);
            });
            MessagingCenter.Subscribe<object, AlertModel>(this, CustomControlsMessagesNames.OpenAlertModal.ToString(), (sender, alertModel) =>
            {
                var alert = new SimpleAlert(alertModel);
                ToogleModalAlertVisibility(true, alert);
            });
        }
        private void UnsubscribeToMessagesOnDisappearing()
        {
            MessagingCenter.Unsubscribe<ICustomControl, int>(this, CustomControlsMessagesNames.Register.ToString());
            MessagingCenter.Unsubscribe<object>(this, CustomControlsMessagesNames.OpenAlertModal.ToString());
            MessagingCenter.Unsubscribe<object>(this, CustomControlsMessagesNames.CloseAlertModal.ToString());

        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            SubscribeToMessagesOnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            UnsubscribeToMessagesOnDisappearing();
        }
    }
}