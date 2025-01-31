﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Aplicacion;

namespace TiendaServicio.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibreriaMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroMaterialDto>>> GetLibros()
        {
            return await _mediator.Send( new Consulta.ListaLibro());
        }
    }
}
