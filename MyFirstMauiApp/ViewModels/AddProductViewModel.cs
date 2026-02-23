using MyFirstMauiApp.Models;
using MyFirstMauiApp.Services;
using System.Windows.Input;

namespace MyFirstMauiApp.ViewModels
{
    public class AddProductViewModel : BindableObject
    {
        private readonly ProductService _productService;

        // Campos privados para almacenar los valores de las propiedades
        private string _name = string.Empty;
        // Propiedad con notificación de cambio para el nombre del producto
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

        private string? _description;
        public string? Description { get => _description; set { _description = value; OnPropertyChanged(); } }

        private decimal _price;
        public decimal Price { get => _price; set { _price = value; OnPropertyChanged(); } }

        private int _stock;
        public int Stock { get => _stock; set { _stock = value; OnPropertyChanged(); } }

        // Comando para guardar el producto, se vincula a un botón en la vista
        public ICommand SaveCommand { get; }

        public AddProductViewModel()
        {
            _productService = new ProductService();
            // Inicializa el comando con la función que se ejecutará al hacer clic
            SaveCommand = new Command(async () => await ExecuteSave());
        }

        // Función que se ejecuta al hacer clic en el botón de guardar
        private async Task ExecuteSave()
        {
            // Usamos una variable local para no escribir Application.Current.MainPage mil veces
            var mainPage = Application.Current?.MainPage;

            // 1. Validación
            if (string.IsNullOrWhiteSpace(Name) || Price <= 0)
            {
                if (mainPage != null)
                    await mainPage.DisplayAlert("Validación", "Nombre y precio son obligatorios", "OK");
                return;
            }

            var product = new Product
            {
                Name = Name!,
                Description = Description,
                Price = Price,
                Stock = Stock
            };

            bool success = await _productService.CreateProductAsync(product);

            // 2. Respuesta del servidor
            if (success)
            {
                if (mainPage != null)
                {
                    await mainPage.DisplayAlert("Éxito", "¡Producto guardado correctamente!", "Continuar");
                    // 3. Navegación de regreso a la anterior página                
                    await mainPage.Navigation.PopAsync();
                }                    
            }
            else
            {
                if (mainPage != null)
                    await mainPage.DisplayAlert("Error", "No se pudo conectar con la API", "Reintentar");
            }
        }
    }
}