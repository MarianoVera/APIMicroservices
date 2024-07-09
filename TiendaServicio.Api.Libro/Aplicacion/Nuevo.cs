using MediatR;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Modelo;
using TiendaServicio.Api.Libro.Persistencia;

namespace TiendaServicio.Api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta:IRequest
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }

        }
            public class Manejador : IRequestHandler<Ejecuta>
            {
                public readonly ContextoLibreria _contexto;
                public Manejador(ContextoLibreria contexto)
                {
                    _contexto = contexto;
                }
                public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
                {
                var libroMaterial = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibro = (Guid.NewGuid())
                };

                _contexto.LibreriaMateriales.Add(libroMaterial);

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
