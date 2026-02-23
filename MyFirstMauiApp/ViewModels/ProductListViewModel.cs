using MyFirstMauiApp.Models;
using MyFirstMauiApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyFirstMauiApp.ViewModels
{
    public class ProductListViewModel : BindableObject
    {
        private readonly ProductService _productService;

        // Esta colección está vinculada al CollectionView del XAML
        public ObservableCollection<Product> Products { get; set; } = new();

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { _isRefreshing = value; OnPropertyChanged(); }
        }

        public ICommand LoadProductsCommand { get; }

        public ProductListViewModel()
        {
            _productService = new ProductService();
            LoadProductsCommand = new Command(async () => await LoadProducts());

            // Cargamos los productos al iniciar
            Task.Run(async () => await LoadProducts());
        }

        public async Task LoadProducts()
        {
            IsRefreshing = true;
            Products.Clear();

            var result = await _productService.GetAllProductsAsync();

            foreach (var product in result)
            {
                Products.Add(product);
            }

            IsRefreshing = false;
        }
    }
}