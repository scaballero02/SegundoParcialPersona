
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.Services
{
    public class PersonaService
    {
        private PersonaRepository repositoryPersona;

        public PersonaService(string connectionString)
        {
            this.repositoryPersona = new PersonaRepository(connectionString);
        }

        public string insertarPersona(PersonaModel Persona)
        {
            return validarDatosPersona(Persona) ? repositoryPersona.insertarPersona(Persona) : throw new Exception("Error en la validacion");
        }

        public string modificarPersona(PersonaModel Persona, int id)
        {
            return validarDatosPersona(Persona) ? repositoryPersona.modificarPersona(Persona, id) : throw new Exception("Error en la validacion");
        }

        public string eliminarPersona(int id)
        {
            return repositoryPersona.eliminarPersona(id);
        }

        public PersonaModel consultarPersona(int id)
        {
            return repositoryPersona.consultarPersona(id);
        }

        public IEnumerable<PersonaModel> listarPersona()
        {
            return repositoryPersona.listarPersona();
        }

        private bool validarDatosPersona(PersonaModel Persona)
        {
            /*if (Persona.Nombre.Trim().Length > 2)
            {
                return false;
            }*/

            return true;
        }
    }
}