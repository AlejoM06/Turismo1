using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Shared.Entities
{
    public class Celebracion
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Celebracion")] // Etiquetas nombre campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener unicamente 100 caracteres")] //Es la longitud de caracteres del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        public string? NomCelebracion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Ubicacion { get; set; }
        public string? Contacto { get; set; }
    }
}