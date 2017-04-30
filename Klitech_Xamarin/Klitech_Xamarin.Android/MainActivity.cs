using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Widget;
using Klitech_Xamarin.Droid.Adapters;
using Klitech_Xamarin.Models;
using Klitech_Xamarin.Services;
using Klitech_Xamarin.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Klitech_Xamarin.Droid
{
    [Activity(Label = "Awesome To-Do app", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        private TodoAdapter adapter;
        public MainViewModel ViewModel { get; private set; }
        public override int Layout => Resource.Layout.Main;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (ViewModel == null)
            {
                ViewModel = new MainViewModel();
            }
            
            adapter = new TodoAdapter(this, ViewModel.Items);
            var list = FindViewById<ListView>(Resource.Id.todoList);
            list.Adapter = adapter;
        }

        protected override void OnResume()
        {
            base.OnResume();
            adapter.Clear();
            adapter.AddAll(ViewModel.Items);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_addtodo)
            {
                ViewModel.AddItemCommand.Execute(null);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return true;
        }
    }
}


