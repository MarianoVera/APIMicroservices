using System;

namespace TiendaServicio.Api.CarritoCompra.Aplicacion
{
    public class CarritoDetalleDto
    {
        public string TituloLibro { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? LibroId { get; set; }
        public string AutorLibro { get; set; }
    }
}
