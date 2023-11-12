using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Turismos.Shared.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DataType Fecha { get; set; }
        [Required]
        [Display(Name = "Total")]
        public double Total { get; set; }
        [Required]
        [Display(Name = "Detalle")]
        [DataType(DataType.MultilineText)]
        public string Detalle { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        [JsonIgnore]
        public TipoPago TipoPago { get; set; }
        public int TipoPagoId { get; set; }

    }
}
