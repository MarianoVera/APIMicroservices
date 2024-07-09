using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Modelo;
using TiendaServicio.Api.Libro.Persistencia;

namespace TiendaServicio.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDto> 
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            public readonly ContextoLibreria _contexto;
            public readonly IMapper _mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.LibreriaMateriales.Where(x => x.AutorLibro.ToString() == request.AutorGuid.ToString()).FirstOrDefaultAsync();
                var libroDto = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(libro);

                return libroDto;

                throw new System.NotImplementedException();
            }
        }
    }
}
