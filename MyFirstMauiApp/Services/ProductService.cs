using System.Net.Http.Json; // Importado para usar PostAsJsonAsync
using MyFirstMauiApp.Models;

namespace MyFirstMauiApp.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        // URL del endpoint de la API para productos
        private const string Url = "https://localhost:7030/api/products";

        public ProductService()
        {
            // Esto permite conectar a HTTPS local en desarrollo (ignora error de certificado)
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
        }

        // Método para crear un nuevo producto enviando una solicitud POST a la API
        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                // Convierte el objeto a JSON y lo envía automáticamente
                var response = await _httpClient.PostAsJsonAsync(Url, product);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Imprime el error en consola para debuggear
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}