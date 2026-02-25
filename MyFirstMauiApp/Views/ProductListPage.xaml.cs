using MyFirstMauiApp.ViewModels;

namespace MyFirstMauiApp.Views;

public partial class ProductListPage : ContentPage
{
    public ProductListPage()
    {
        InitializeComponent();
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        // Navegamos a la página agregar producto
        await Navigation.PushAsync(new AddProductPage());
    }

    // Método que se llama cada vez que la página aparece en pantalla
    protected override async void OnAppearing()
    {
        // Llamamos al método base para asegurarnos de que cualquier lógica de la clase base se ejecute
        base.OnAppearing();

        // Verificamos si el BindingContext es del tipo ProductListViewModel        
        if (BindingContext is ProductListViewModel viewModel)
        {
            // Llamamos al método que carga los productos
            await viewModel.LoadProducts();
        }
    }

    private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        // 1. Identificamos el registro seleccionado
        var selectedProduct = e.CurrentSelection.FirstOrDefault() as MyFirstMauiApp.Models.Product;

        if (selectedProduct != null)
        {
            // 2. Navegamos pasando el producto al constructor
            // Nota: Crearemos este constructor en el siguiente paso
            await Navigation.PushAsync(new AddProductPage(selectedProduct));

            // 3. Limpiamos la selección para que pueda volver a tocarlo después
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}