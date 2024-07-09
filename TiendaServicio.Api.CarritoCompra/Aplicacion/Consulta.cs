using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TiendaServicio.Api.CarritoCompra.Persistencia;
using Microsoft.EntityFrameworkCore;
using TiendaServicio.Api.CarritoCompra.InterfazRemota;
using System.Linq;

namespace TiendaServicio.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoSesionDto>
        {
            public int CarritoSesionId { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, CarritoSesionDto>
        {
            public readonly CarritoContexto _contexto;
            private readonly ILibrosService _librosService;
            public Manejador(CarritoContexto contexto, ILibrosService librosService)
            {
                _contexto = contexto;
                _librosService = librosService;
            }
            public async Task<CarritoSesionDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _contexto.CarritoSesiones.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);

                if (carritoSesion == null) return null;

                var carritoSesionDetalle = await _contexto.CarritoSesionDetalle.Where(x => x.CarritoSesionId == request.CarritoSesionId).ToListAsync();

                var listaCarritoDto = new List<CarritoDetalleDto>();

                foreach(var libro in carritoSesionDetalle)
                {
                    var response = await _librosService.GetLibro(new System.Guid(libro.ProductoSeleccionado));
                    if(response.resultado)
                    {
                        var objetoLibro = response.Libro;
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            TituloLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId,
                            AutorLibro = objetoLibro.AutorLibro.ToString(),
                        };

                        listaCarritoDto.Add(carritoDetalle);
                    }
                }
                var carritoDto = new CarritoSesionDto
                {
                    CarritoSesionId = carritoSesion.CarritoSesionId,
                    FechaCreacion = carritoSesion.FechaCreacion,
                    ListaDetalle = listaCarritoDto
                };

                return carritoDto;

            }
        }
    }
}
