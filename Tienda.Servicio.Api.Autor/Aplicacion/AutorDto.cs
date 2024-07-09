using System.Collections.Generic;
using System;
using TiendaServicio.Api.Autor.Modelo;

namespace Tienda.Servicio.Api.Autor.Aplicacion
{
    public class AutorDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
