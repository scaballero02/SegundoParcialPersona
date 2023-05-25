using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    public class PersonaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Tipo de Documento es requerido")]
        public string Tipo_Documento { get; set; }

        [Required(ErrorMessage = "La Direccion es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        public string mail { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El documento es requerido")]
        public string Documento { get; set; }
        public bool Estado { get; set; }

    }
}
