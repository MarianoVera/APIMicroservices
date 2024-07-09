using AutoMapper;
using TiendaServicio.Api.Libro.Modelo;

namespace TiendaServicio.Api.Libro.Aplicacion
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //inicializar el mappeo
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }
    }
}
