using Showcase.Helpers;
using Showcase.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Showcase.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AzureServices azureService;
        // INavigation navigation;


        ICommand loginCommand;




        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        //public LoginViewModel(INavigation nav)
        public LoginViewModel()
        {
            azureService = DependencyService.Get<AzureServices>();
            //navigation = nav;

            //Title = "Social Login";
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync()))
                return;
            else
            {
                // var mainViewModel = new MainViewModel();
                //await navigation.PushAsync(mainPage);                
                await PushAsync<MainViewModel>();


                //RemovePageFromStack();
            }
        }

        //private void RemovePageFromStack()
        //{
        //    var existingPages = navigation.NavigationStack.ToList();
        //    foreach (var page in existingPages)
        //    {
        //        if (page.GetType() == typeof(LoginPage))
        //            navigation.RemovePage(page);
        //    }
        //}


        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
            {
                return Task.FromResult(true);
            }

            return azureService.LoginAsync();
        }

    }
}
