using System.Collections.Generic;
using System;
using TiendaServicio.Api.CarritoCompra.Modelos;

namespace TiendaServicio.Api.CarritoCompra.Aplicacion
{
    public class CarritoSesionDto
    {
        public int CarritoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public ICollection<CarritoDetalleDto> ListaDetalle { get; set; }
    }
}
