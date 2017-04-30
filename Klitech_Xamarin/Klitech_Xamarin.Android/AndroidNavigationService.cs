using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Klitech_Xamarin.Services;

namespace Klitech_Xamarin.Droid
{
    public class AndroidNavigationService : INavigationService
    {
        public Activity CurrentActivity { get; set; }

        public void NavigateToAddItem()
        {
            CurrentActivity.StartActivity(typeof(AddItemActivity));
        }

        public void GoBack()
        {
            CurrentActivity.Finish();
        }
    }
}