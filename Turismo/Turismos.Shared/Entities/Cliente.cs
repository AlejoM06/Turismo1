using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismos.Shared.Entities
{
    public class Cliente
    {

        public int Id { get; set; }
        [Display(Name = "Nombre Ciudad")] // Etiquetas nombre campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener unicamente 100 caracteres")] //Es la longitud de caracteres del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        public string? NomUsuario { get; set; }
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        [Display(Name = "Documento de Identidad")]
        public string? Cedula { get; set; }
        [Required(ErrorMessage = "El campo {2} es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo {3} es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El campo {4} es obligatorio")]
        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        public Factura? Factura { get; set; }
        public int FacturaId { get; set; }

        public Comentario? Comentario { get; set; }
        public int ComentarioId { get; set; }

        public Viaje? Viajes { get; set; }
        public int ViajeId { get; set; }
    }
}
