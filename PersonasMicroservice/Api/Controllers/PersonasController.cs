using PersonasMicroservice.Api.DTOs;
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
        // GET
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(PersonaDTO personaDto)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update(string id, [FromBody] PersonaDTO personaDto)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            return Ok();
        }


    }
}