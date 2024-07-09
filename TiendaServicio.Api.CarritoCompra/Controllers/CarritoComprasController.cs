using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompra.Aplicacion;
using TiendaServicio.Api.CarritoCompra.Modelos;

namespace TiendaServicio.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarritoComprasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<CarritoSesionDto>> GetLibros()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }
    }
}
