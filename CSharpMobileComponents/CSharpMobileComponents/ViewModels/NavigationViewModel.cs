using CSharpMobileComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CSharpMobileComponents.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {

        public ICommand NavigateToPageCommand { get; set; } 
        public ICommand PopPageCommand { get; set; } 

        public ICommand CleanAllPagesCommand { get; set; }
        public ICommand CleanAllPagesUpUntilStartScreenCommand { get; set; } 

        public static bool IsNavigating { get; set; }

        public NavigationViewModel()
        {
            IsLoading = false;
            NavigateToPageCommand = new Command<NavigationModel>(async (navPage) => await NavigateToPage(navPage));
            PopPageCommand = new Command(async () => await PopPage());
            CleanAllPagesCommand = new Command(() => CleanAllPages());
            CleanAllPagesUpUntilStartScreenCommand = new Command<Page>((startscreenPage) => CleanAllPagesUpUntilStartScreen(startscreenPage));
        }



        public async Task NavigateIsBusyTaskAsync(Func<Task> awaitableTask)
        {
            IsLoading = true;
            if (IsNavigating)
            {
                // prevent accidental double-tap calls
                return;
            }
            IsNavigating = true;
            try
            {
                await awaitableTask();
            }
            finally
            {
                IsNavigating = false;
                IsLoading = false;
            }
        }
        public async Task NavigateToPage(NavigationModel navigationModel)
        {

            IsLoading = true;
            if (string.IsNullOrEmpty(navigationModel.PageName))
                return;

            Type pageType = Type.GetType(navigationModel.PageName);

            Page page = GetPageFromNavigationModel(navigationModel);
            if (page == null)
                return;

            //await NavigateIsBusyTaskAsync(async () => await Application.Current.MainPage.Navigation.PushAsync(page));
            await NavigateIsBusyTaskAsync(async () => await NavigateToPage(navigationModel)); // to try and improve....

        }

        private Page GetPageFromNavigationModel(NavigationModel navigationPage)
        {
            Page pageToNavigate = null;

            if (navigationPage.PageParameters == null && navigationPage.PageViewModel == null)
                pageToNavigate = (Page)Activator.CreateInstance(Type.GetType(navigationPage.PageName));

            else if (navigationPage.PageParameters != null && navigationPage.PageViewModel == null)
                pageToNavigate = (Page)Activator.CreateInstance(Type.GetType(navigationPage.PageName), navigationPage.PageParameters);

            else if (navigationPage.PageParameters == null && navigationPage.PageViewModel != null)
            {
                object pageViewModel = GetPageViewModelFromType(navigationPage.PageViewModel, navigationPage.PageViewModelParameters);
                pageToNavigate = (Page)Activator.CreateInstance(Type.GetType(navigationPage.PageName), pageViewModel);
            }

            else if (navigationPage.PageParameters != null && navigationPage.PageViewModel != null)
            {
                object pageViewModel = GetPageViewModelFromType(navigationPage.PageViewModel, navigationPage.PageViewModelParameters);
                pageToNavigate = (Page)Activator.CreateInstance(Type.GetType(navigationPage.PageName), pageViewModel, navigationPage.PageParameters);
            }

            return pageToNavigate;

        }

        private object GetPageViewModelFromType(Type viewModel, object viewModelParameters = null)
        {
            if (viewModelParameters == null)
                return Activator.CreateInstance(viewModel);
            else
                return Activator.CreateInstance(viewModel, viewModelParameters);
        }


        public async Task PopPage()
        {
            IsLoading = true;
            await Application.Current.MainPage.Navigation.PopAsync();
            IsLoading = false;
        }
        public void CleanAllPages()
        {
            var existingPages = Application.Current.MainPage.Navigation.NavigationStack.ToList();
            for (int i = 0; i < existingPages.Count - 1; i++)
            {

                Application.Current.MainPage.Navigation.RemovePage(existingPages[i]);
            }
        }


        public void CleanAllPagesUpUntilStartScreen(Page startScreenPage)
        {
            //var existingPages = Application.Current.MainPage.Navigation.NavigationStack.ToList();
            //for (int i = 0; i < existingPages.Count; i++)
            //{
            //    if (existingPages[i] != startScreenPage)
            //        Application.Current.MainPage.Navigation.RemovePage(existingPages[i]);
            //    else
            //    {
            //        var menuPage = (MenuScreenPage)existingPages[i];
            //        if (!menuPage._viewModel.IsStartScreen)
            //            Application.Current.MainPage.Navigation.RemovePage(existingPages[i]);
            //    }
            //}
            //var x = Application.Current.MainPage.Navigation.NavigationStack.ToList().Count;
        }
    }
}
