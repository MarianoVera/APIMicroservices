using AutoMapper;
using TiendaServicio.Api.Autor.Modelo;

namespace Tienda.Servicio.Api.Autor.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            //inicializar el mappeo
            CreateMap<AutorLibro, AutorDto>();
        }
    }
}
