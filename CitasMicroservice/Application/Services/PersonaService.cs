using RestSharp;
using System.Configuration;
using System.Threading.Tasks;
using CitasMicroservice.Application.DTOs;

namespace CitasMicroservice.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly RestClient _client;
        private readonly string _uri;

        public PersonaService()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["PersonasApiUrl"]);
            _uri = "api/Personas";
        }
        public async Task<PersonaDTO> GetByIdentificacion(int tipoPersona, string identificacion)
        {
            // Validación de parámetros
            if (tipoPersona <= 0 || (tipoPersona != 1 && tipoPersona != 2))
            {
                throw new System.ArgumentException("El tipo de persona debe ser 1 (Médico) o 2 (Paciente).");
            }

            if (string.IsNullOrEmpty(identificacion))
            {
                throw new System.ArgumentException("La Identificacion de la persona no puede ser nula o vacia.");
            }

            // Construcción de la URL con los parámetros
            var request = new RestRequest(_uri, Method.Get);
            request.AddParameter("TipoPersona", tipoPersona);
            request.AddParameter("Identificacion", identificacion);

            // Realiza la llamada al servicio de Personas
            var response = await _client.ExecuteAsync<PersonaDTO>(request);

            // Verifica si la respuesta es exitosa
            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            // Manejo de errores o respuestas no exitosas
            return null; // Aquí retornamos null para manejarlo en el controlador
        }
    }
}