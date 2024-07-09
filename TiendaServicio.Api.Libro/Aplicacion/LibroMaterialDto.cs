using System;

namespace TiendaServicio.Api.Libro.Aplicacion
{
    public class LibroMaterialDto
    {
        public Guid? LibreariaMaterialId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }
    }
}
