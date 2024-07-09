using MediatR;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Modelos;
using TiendaServicio.Api.CarritoCompra.Persistencia;

namespace TiendaServicio.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime? FechaCreacion { get; set; }
            public ICollection<CarritoSesionDetalle> ListaDetalle { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly CarritoContexto _contexto;
            public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carrito = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacion,
                    ListaDetalle = request.ListaDetalle
                };

                _contexto.CarritoSesiones.Add(carrito);

                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new System.NotImplementedException();
            }
        }
    }
}
