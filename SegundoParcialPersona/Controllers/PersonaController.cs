using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace SegundoParcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        // GET: PersonaController
        private PersonaService PersonaService;
        private IConfiguration configuration;

        public PersonaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.PersonaService = new PersonaService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("ListarPersona")]
        public ActionResult<List<PersonaModel>> ListarPersona()
        {
            var resultado = PersonaService.listarPersona();
            return Ok(resultado);
        }

        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<PersonaModel> ConsultarPersona(int id)
        {
            var result = this.PersonaService.consultarPersona(id);
            return Ok(result);
        }


        [HttpPost("InsertarPersona")]
        public ActionResult<string> insert(PersonaModel models)
        {
            var result = this.PersonaService.insertarPersona(new Infraestructure.Models.PersonaModel
            {
                Nombre = models.Nombre,
                Apellido = models.Apellido,
                mail = models.mail,
                Telefono = models.Telefono,
                Documento = models.Documento,
                Tipo_Documento = models.Tipo_Documento,
                Direccion = models.Direccion,
                Estado = models.Estado
            });
            return Ok(result);
        }
        // endpoint for Persona modify
        [HttpPut("ModificarPersona/{id}")]
        public ActionResult<string> modificarPersona(PersonaModel models, int id)
        {

            var result = this.PersonaService.modificarPersona(new Infraestructure.Models.PersonaModel
            {
                Nombre = models.Nombre,
                Apellido = models.Apellido,
                mail = models.mail,
                Telefono = models.Telefono,
                Tipo_Documento = models.Tipo_Documento,
                Documento = models.Documento,
                Direccion = models.Direccion,
                Estado = models.Estado
            }, id);
            return Ok(result);
        }

        // endpoint for Persona delete
        [HttpDelete("EliminarPersona/{id}")]
        public ActionResult<string> eliminar(int id)
        {
            var result = this.PersonaService.eliminarPersona(id);
            return Ok(result);
        }
    }
}