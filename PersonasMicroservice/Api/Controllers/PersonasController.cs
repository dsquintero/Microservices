using PersonasMicroservice.Application.Services;
using System.Threading.Tasks;
using System.Web.Http;
using PersonasMicroservice.Application.DTOs;

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

        /// <summary>
        /// Obtiene todas las personas.
        /// </summary>
        /// <returns>Lista de personas.</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var personas = await _personaService.GetAll();
            if (personas == null || personas.Count == 0)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        /// <summary>
        /// Obtiene una persona por su ID.
        /// </summary>
        /// <param name="id">ID de la persona.</param>
        /// <returns>Persona si es encontrada, de lo contrario NotFound.</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un número positivo.");
            }

            var persona = await _personaService.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }


        /// <summary>
        /// Obtiene una persona por su TipoPersona e Identificacion
        /// </summary>
        /// <param name="TipoPersona">Tipo de la persona</param>
        /// <param name="Identificacion">Indentificacion de la persona</param>
        /// <returns>Persona si es encontrada, de lo contrario NotFound.</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetByIdentificacion(int TipoPersona, string Identificacion)
        {
            if (TipoPersona <= 0 || (TipoPersona != 1 && TipoPersona != 2))
            {
                return BadRequest("El tipo de persona debe ser 1 (Médico) o 2 (Paciente).");
            }

            if (string.IsNullOrEmpty(Identificacion))
            {
                return BadRequest("La Identificacion de la persona no puede ser nula o vacia.");
            }

            var persona = await _personaService.GetByIdentificacion(TipoPersona, Identificacion);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        /// <summary>
        /// Crea una nueva persona.
        /// </summary>
        /// <param name="idTipoPersona">ID del tipo de persona (1 para Médico, 2 para Paciente).</param>
        /// <param name="personaDto">Datos de la persona a crear.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost]
        [Route("{idTipoPersona}")]
        public async Task<IHttpActionResult> Create(int idTipoPersona, [FromBody] PersonaDTO personaDto)
        {
            if (idTipoPersona <= 0 || (idTipoPersona != 1 && idTipoPersona != 2))
            {
                return BadRequest("El tipo de persona debe ser 1 (Médico) o 2 (Paciente).");
            }

            if (personaDto == null)
            {
                return BadRequest("La información de la persona no puede ser nula.");
            }

            string msj = await _personaService.Create(idTipoPersona, personaDto);
            return Created("api/Personas", msj);
        }

        /// <summary>
        /// Actualiza una persona existente.
        /// </summary>
        /// <param name="id">ID de la persona a actualizar.</param>
        /// <param name="personaDto">Nuevos datos de la persona.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] PersonaDTO personaDto)
        {
            if (id <= 0)
            {
                return BadRequest("El ID de la persona debe ser un número positivo.");
            }

            if (personaDto == null)
            {
                return BadRequest("La información de la persona no puede ser nula.");
            }

            string msj = await _personaService.Update(id, personaDto);
            return Ok(msj);
        }

        /// <summary>
        /// Elimina una persona por su ID.
        /// </summary>
        /// <param name="id">ID de la persona a eliminar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID de la persona debe ser un número positivo.");
            }

            string msj = await _personaService.Delete(id);
            return Ok(msj);
        }
    }
}
