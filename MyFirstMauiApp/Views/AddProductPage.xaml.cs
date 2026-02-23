using MyFirstMauiApp.ViewModels;

namespace MyFirstMauiApp.Views;

public partial class AddProductPage : ContentPage
{
    public AddProductPage()
    {
        InitializeComponent();

        // Vinculamos la vista con su modelo de vista
        BindingContext = new AddProductViewModel();
    }
}