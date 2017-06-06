using Showcase.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Showcase.ViewModels
{
    public class StoreViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; }

        public StoreViewModel(Store store)
        {
            Products = new ObservableCollection<Product>();
        }

        public override async Task LoadAsync()
        {
            Products.Clear();
            Products.Add(new Product() { Name = "Cerveja", Description = "R$2,50" });
            OnPropertyChanged(nameof(Products));
        }
    }
}
