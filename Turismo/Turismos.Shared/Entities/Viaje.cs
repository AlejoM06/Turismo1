using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Turismos.Shared.Entities
{
    public class Viaje
    {
        public int Id { get; set; }
        [Display(Name = "Origen")] // Etiquetas nombre campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener unicamente 100 caracteres")] //Es la longitud de caracteres del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Indica que hace un salto de nulos)
        public string Origen { get; set; }
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        [Display(Name = "Destino")]
        public string Destino { get; set; }
        [Required(ErrorMessage = "El campo {2} es obligatorio")]
        [Display(Name = "Fecha de inicio")]
        [DataType(DataType.Date)]
        public string FechaInicio { get; set; }
        [Required(ErrorMessage = "El campo {3} es obligatorio")]
        [Display(Name = "Fecha final")]
        [DataType(DataType.Date)]
        public string FechaFin { get; set; }
        [Required(ErrorMessage = "El campo {4} es obligatorio")]
        [Display(Name = "Cantidad de puestos")]
        [DataType(DataType.PhoneNumber)]
        public string Puestos { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        [JsonIgnore]
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }

        [JsonIgnore]
        public Transporte Transporte { get; set; }
        public int TransporteId { get; set; }

    }
}
