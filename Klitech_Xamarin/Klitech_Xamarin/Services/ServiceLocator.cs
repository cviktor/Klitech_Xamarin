namespace Klitech_Xamarin.Services
{
    public class ServiceLocator
    {
        public static INavigationService NavigationService { get; set; }
        public static TodoService TodoService { get; set; }

        public static bool IsInitialized { get; private set; }

        public static void InitializeApp(INavigationService navigationService)
        {
            if(IsInitialized) return;

            TodoService = new TodoService();
            NavigationService = navigationService;
            IsInitialized = true;
        }
    }
}