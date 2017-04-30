using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Klitech_Xamarin.Services;
using MvvmCross.Core.ViewModels;

namespace Klitech_Xamarin.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveItemCommand { get; }
        public AddItemViewModel()
        {
            SaveItemCommand = new MvxCommand(AddItemCommandExecute);
        }

        private void AddItemCommandExecute()
        {
            ServiceLocator.TodoService.AddItem(title, description);
            ServiceLocator.NavigationService.GoBack();
        }
    }
}
