﻿using PersonasMicroservice.Api.DTOs;
using PersonasMicroservice.Application.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace PersonasMicroservice.Api.Controllers
{
    [RoutePrefix("api/Personas")]
    public class PersonasController : ApiController
    {
        private readonly IPersonaService _personaService;

        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var personas = await _personaService.GetAll();
            return Ok(personas);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var persona = await _personaService.GetById(id);
            return Ok(persona);
        }

        [HttpPost]
        [Route("{idTipoPersona}")]
        public async Task<IHttpActionResult> Create(int idTipoPersona, [FromBody] PersonaDTO personaDto)
        {
            string msj = await _personaService.Create(idTipoPersona, personaDto);
            return Ok(msj);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] PersonaDTO personaDto)
        {
            string msj = await _personaService.Update(id, personaDto);
            return Ok(msj);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            string msj = await _personaService.Delete(id);
            return Ok(msj);
        }


    }
}