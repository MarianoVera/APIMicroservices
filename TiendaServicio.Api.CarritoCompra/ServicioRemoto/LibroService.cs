using Microsoft.Extensions.Logging;
using NLog.Targets;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.InterfazRemota;
using TiendaServicio.Api.CarritoCompra.ModeloRemoto;

namespace TiendaServicio.Api.CarritoCompra.ServicioRemoto
{
    public class LibroService : ILibrosService
    {
        //httpclient
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibroService> _logger;

        public LibroService(IHttpClientFactory httpClient, ILogger<LibroService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LibroRemoto Libro, string ErrorMessage)> GetLibro(Guid LibroId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Libros");
                var response = await cliente.GetAsync($"api/LibroMaterial/{LibroId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    var resultado = JsonSerializer.Deserialize<LibroRemoto>(contenido, options);

                    return (true, resultado, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
            
        }
    }
}
