using System.Threading.Tasks;
using System.Web.Http;
using RecetasMicroservice.Api.DTOs;
using RecetasMicroservice.Application.Services;

namespace RecetasMicroservice.Api.Controllers
{
    [RoutePrefix("api/Personas")]
    public class RecetaController : ApiController
    {
        private readonly IRecetaService _personaService;

        public RecetaController(IRecetaService personaService)
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
        public async Task<IHttpActionResult> Create(int idTipoPersona, [FromBody] RecetaDTO personaDto)
        {
            string msj = await _personaService.Create(idTipoPersona, personaDto);
            return Ok(msj);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] RecetaDTO personaDto)
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