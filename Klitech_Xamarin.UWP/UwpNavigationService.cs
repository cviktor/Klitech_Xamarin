using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Klitech_Xamarin.Services;
using Klitech_Xamarin.UWP.Views;

namespace Klitech_Xamarin.UWP
{
    class UwpNavigationService : INavigationService
    {
        public Frame Frame => Window.Current.Content as Frame;
        public void NavigateToAddItem()
        {
            Frame.Navigate(typeof(AddItemPage));
            SetBackButton();
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                SetBackButton();
            }
        }

        private void SetBackButton()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                Frame.CanGoBack ?
                    AppViewBackButtonVisibility.Visible :
                    AppViewBackButtonVisibility.Collapsed;
        }
    }
}
