using MediatR;
using Microsoft.AspNetCore.Authentication;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Autor.Modelo;
using TiendaServicio.Api.Autor.Persistencia;

namespace Tienda.Servicio.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            //parametros que envia controller para crear nuevo autor libro
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class Manejador: IRequestHandler<Ejecuta>
        {
            //1. necesitamos el contexto para inyectarlo
            public readonly ContextoAutor _contexto;
            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,    
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid= Convert.ToString(Guid.NewGuid()),
                };

                _contexto.AutorLibros.Add(autorLibro);

                var valor = await _contexto.SaveChangesAsync();

                if(valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar autor libro");
            }
        }
    }
}
