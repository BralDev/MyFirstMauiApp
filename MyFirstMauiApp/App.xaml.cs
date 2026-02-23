namespace MyFirstMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MyFirstMauiApp.Views.AddProductPage());
        }
    }
}
