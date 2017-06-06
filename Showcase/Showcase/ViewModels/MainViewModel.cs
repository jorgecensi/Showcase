using Showcase.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Showcase.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command AboutCommand { get; }
        public Command AtualizarCommand { get; }
        public ObservableCollection<Store> Stores { get; }
        public Command<Store> ShowStoreCommand { get; }

        public MainViewModel()
        {
            Title = "Showcase";
            Stores = new ObservableCollection<Store>();
            AboutCommand = new Command(ExecuteAboutCommand);
            AtualizarCommand = new Command(ExecuteAtualizarCommand);
            ShowStoreCommand = new Command<Store>(ExecuteShowStoreCommand);
        }

        private async void ExecuteShowStoreCommand(Store store)
        {
            await PushAsync<StoreViewModel>(store);
        }

        private void ExecuteAtualizarCommand()
        {

            Stores.Add(new Store() { Id = "3", Description = "Descrição da Loja A", Name = "Loja A" });
            Stores.Add(new Store() { Id = "4", Description = "Descrição da Loja B", Name = "Loja B" });


            OnPropertyChanged(nameof(Stores));
        }
        private async void ExecuteAboutCommand()
        {
            await PushAsync<AboutViewModel>();
        }
        public override async Task LoadAsync()
        {
            if (Stores.Count == 0)
            {
                Stores.Add(new Store() { Id = "1", Description = "Descrição da Loja X", Name = "Loja X" });
                Stores.Add(new Store() { Id = "2", Description = "Descrição da Loja Z", Name = "Loja Z" });
                Stores.Add(new Store() { Id = "2", Description = "Descrição da Loja Y", Name = "Loja Y" });

                OnPropertyChanged(nameof(Stores));
            }

        }
    }
}
