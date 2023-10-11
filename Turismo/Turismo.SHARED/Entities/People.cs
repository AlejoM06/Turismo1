using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.SHARED.Entities
{
    public class People
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Ciudad")] // Etiquetas nombre campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener unicamente 100 caracteres")] //Es la longitud de caracteres del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        public string? NomUsuario { get; set; }

        public string? Edad { get; set; }
        public string? Contacto { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
    }
}
