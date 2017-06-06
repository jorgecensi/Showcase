
using Showcase.ViewModels;
using Xamarin.Forms.Xaml;

namespace Showcase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();

        }
    }
}