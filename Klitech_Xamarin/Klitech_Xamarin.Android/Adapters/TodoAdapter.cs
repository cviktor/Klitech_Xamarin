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
using Klitech_Xamarin.Models;
using Klitech_Xamarin.Services;

namespace Klitech_Xamarin.Droid.Adapters
{
    public class TodoAdapter : ArrayAdapter<TodoItem>
    {
        
        public TodoAdapter(Context context, IList<TodoItem> objects) : base(context, 0, objects)
        {
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this.GetItem(position);
            if (convertView == null)
            {
                convertView = LayoutInflater.From(Context).Inflate(Resource.Layout.item_todo, parent, false);
            }

            TextView todoName = convertView.FindViewById<TextView>(Resource.Id.todoName);
            TextView todoDescription = convertView.FindViewById<TextView>(Resource.Id.todoDescription);

            todoName.Text = item.Title;
            todoDescription.Text = item.Description;

            return convertView;
        }
    }
}