using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klitech_Xamarin.Models;

namespace Klitech_Xamarin.Services
{
    public class TodoService
    {
        private Dictionary<int, TodoItem> items = new Dictionary<int, TodoItem>
        {
            {0, new TodoItem {Description = "Be kell vásárolni a hétvégére", Title = "Bevásárlás"}},
            {1, new TodoItem {Description = "Hazmat ruha beszerzése a takarításhoz", Title = "Nagytakarítás"}},
        };
        
        public void AddItem(string title, string description)
        {
            items.Add(items.Keys.Max() + 1, new TodoItem { Title = title, Description = description });
        }

        public TodoItem GetItem(int id)
        {
            return items[id];
        }

        public List<TodoItem> GetAll()
        {
            return items.Values.ToList();
        }
    }
}
