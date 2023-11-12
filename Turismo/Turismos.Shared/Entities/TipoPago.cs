using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Turismos.Shared.Entities
{
    public class TipoPago
    {
        public int Id { get; set; }
        [DataType(DataType.CreditCard)]
        public string TCredito { get; set; }
        [DataType(DataType.CreditCard)]
        public string TDebito { get; set; }
        public double Efectivo { get; set; }
        public string PSE { get; set; }

        [JsonIgnore]
        public ICollection<Factura> Facturas { get; set; }
    }
}
