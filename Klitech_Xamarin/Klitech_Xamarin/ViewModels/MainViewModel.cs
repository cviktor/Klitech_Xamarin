using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Klitech_Xamarin.Models;
using Klitech_Xamarin.Services;
using MvvmCross.Core.ViewModels;

namespace Klitech_Xamarin.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public List<TodoItem> Items => ServiceLocator.TodoService.GetAll();

        public ICommand AddItemCommand { get; }

        public MainViewModel()
        {
            AddItemCommand = new MvxCommand(AddItemCommandExecute);
        }

        private void AddItemCommandExecute()
        {
            ServiceLocator.NavigationService.NavigateToAddItem();
        }
    }
}
