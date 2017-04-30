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
using Klitech_Xamarin.ViewModels;

namespace Klitech_Xamarin.Droid
{
    [Activity(Label = "Új elem hozzáadása")]
    public class AddItemActivity : BaseActivity
    {
        private EditText title;
        private EditText description;
        public override int Layout => Resource.Layout.AddItem;

        public AddItemViewModel ViewModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (ViewModel == null)
            {
                ViewModel = new AddItemViewModel();
            }

            title = FindViewById<EditText>(Resource.Id.title);
            description = FindViewById<EditText>(Resource.Id.description);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_save)
            {
                ViewModel.Title = title.Text;
                ViewModel.Description = description.Text;
                ViewModel.SaveItemCommand.Execute(null);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.add_menu, menu);
            return true;
        }
    }
}