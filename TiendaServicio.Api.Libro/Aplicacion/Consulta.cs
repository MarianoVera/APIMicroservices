using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Persistencia;

namespace TiendaServicio.Api.Libro.Aplicacion
{
    public class Consulta
    {
        public class ListaLibro : IRequest<List<LibroMaterialDto>>
        {

        }
        public class Manejador : IRequestHandler<ListaLibro, List<LibroMaterialDto>>
        {
            public readonly ContextoLibreria _contexto;
            public readonly IMapper _mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<LibroMaterialDto>> Handle(ListaLibro request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.LibreriaMateriales.ToListAsync();
                var librosDto = _mapper.Map<List<LibroMaterialDto>>(libros);

                return librosDto;
            }
        }
    }
}
