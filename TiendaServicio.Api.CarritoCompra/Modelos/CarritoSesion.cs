using System;
using System.Collections;
using System.Collections.Generic;

namespace TiendaServicio.Api.CarritoCompra.Modelos
{
    public class CarritoSesion
    {
        public int CarritoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public ICollection<CarritoSesionDetalle> ListaDetalle { get; set; }
    }
}
