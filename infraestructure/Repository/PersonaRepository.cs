using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public class PersonaRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public PersonaRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insertarPersona(PersonaModel Persona)
        {
            try // Aca tambien, por ejemplo: ciudad no esta en la base de datos, le vas a cambiar por direccion umia wayorar
            {
                String query = "insert into Persona(nombre, apellido, direccion, tipo_documento, documento, mail, telefono, estado) " +
                    " values(@nombre, @apellido, @direccion, @tipo_documento, @documento, @mail, @telefono, @estado)";
                connection.Open();
                connection.Execute(query, Persona);
                connection.Close();
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modificarPersona(PersonaModel Persona, int id)
        {
            try
            {
                connection.Execute($"UPDATE Persona SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "mail = @mail, " +
                    "telefono = @telefono, " +
                    "direccion = @direccion, " +
                    "tipo_documento = @tipo_documento, " +
                    "estado = @estado, " +
                    "documento = @documento " +
                    $"WHERE id = {id}", Persona);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string eliminarPersona(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM Persona WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PersonaModel consultarPersona(int id)
        {
            try
            {
                return connection.QueryFirst<PersonaModel>($"SELECT * FROM Persona WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PersonaModel> listarPersona()
        {
            try
            {
                return connection.Query<PersonaModel>($"SELECT * FROM Persona order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}