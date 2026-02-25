using MyFirstMauiApp.Models;
using MyFirstMauiApp.ViewModels;

namespace MyFirstMauiApp.Views;

public partial class AddProductPage : ContentPage
{
    public AddProductPage()
    {
        InitializeComponent();

        // Vinculamos la vista con su modelo de vista
        var vm = new AddProductViewModel();
        vm.Id = 0; // Indica que es un nuevo producto
        vm.Title = "Nuevo Producto";

        BindingContext = vm;
    }

    public AddProductPage(Product productToEdit) // Constructor para EDITAR
    {
        InitializeComponent();
        var vm = new AddProductViewModel();

        // Cargamos los datos del producto seleccionado en el ViewModel
        vm.Id = productToEdit.Id;
        vm.Name = productToEdit.Name;
        vm.Description = productToEdit.Description;
        vm.Price = productToEdit.Price;
        vm.Stock = productToEdit.Stock;
        vm.Title = "Editar Producto";

        BindingContext = vm;
    }
}