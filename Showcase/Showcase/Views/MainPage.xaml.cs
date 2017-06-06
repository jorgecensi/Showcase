
using Showcase.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showcase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BasePage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new MainViewModel();
        }
        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ShowStoreCommand.Execute(e.SelectedItem);
            }
        }
    }
}