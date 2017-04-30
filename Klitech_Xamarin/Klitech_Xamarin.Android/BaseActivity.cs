using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Klitech_Xamarin.Services;

namespace Klitech_Xamarin.Droid
{
    public abstract class BaseActivity : AppCompatActivity
    {
        public abstract int Layout { get; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Platform specifikus service létrehozása
            if (!ServiceLocator.IsInitialized)
            {
                ServiceLocator.InitializeApp(new AndroidNavigationService());
            }

            // Set our view from the "main" layout resource
            SetContentView(Layout);

            Toolbar toolbar = (Toolbar)FindViewById(Resource.Id.mainToolbar);
            SetSupportActionBar(toolbar);
        }

        protected override void OnResume()
        {
            base.OnResume();
            (ServiceLocator.NavigationService as AndroidNavigationService).CurrentActivity = this;
        }
    }
}