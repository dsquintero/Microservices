using CitasMicroservice.Application.DTOs;
using CitasMicroservice.Application.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CitasMicroservice.Api.Controllers
{
    [RoutePrefix("api/Citas")]
    public class CitasController : ApiController
    {
        private readonly ICitaService _citaService;

        public CitasController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        /// <summary>
        /// Obtiene una cita por su ID.
        /// </summary>
        /// <param name="id">ID de la cita.</param>
        /// <returns>La cita si es encontrada, de lo contrario, NotFound.</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID de la cita debe ser un número positivo.");
            }

            try
            {
                var cita = await _citaService.GetById(id);
                if (cita == null)
                {
                    return NotFound();
                }

                return Ok(cita);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Crea una nueva cita.
        /// </summary>
        /// <param name="citaDto">Datos de la cita a crear.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] CitaDTO citaDto)
        {
            if (citaDto == null)
            {
                return BadRequest("La información de la cita no puede ser nula.");
            }

            try
            {
                string msj = await _citaService.Create(citaDto);
                return Ok(msj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Actualiza una cita existente.
        /// </summary>
        /// <param name="id">ID de la cita a actualizar.</param>
        /// <param name="citaDto">Nuevos datos de la cita.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] CitaDTO citaDto)
        {
            if (id <= 0)
            {
                return BadRequest("El ID de la cita debe ser un número positivo.");
            }

            if (citaDto == null)
            {
                return BadRequest("La información de la cita no puede ser nula.");
            }

            try
            {
                string msj = await _citaService.Update(id, citaDto);
                return Ok(msj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Elimina una cita por su ID.
        /// </summary>
        /// <param name="id">ID de la cita a eliminar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID de la cita debe ser un número positivo.");
            }

            try
            {
                string msj = await _citaService.Delete(id);
                return Ok(msj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
