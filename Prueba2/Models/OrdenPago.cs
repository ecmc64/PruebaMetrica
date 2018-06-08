using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba2.Models
{
    public class OrdenPago
    {
        public int OrdenPagoId { get; set; }

        [Display(Name = "Importe de Pago")]
        public double Monto { get; set; }

        [Display(Name = "Moneda")]
        public int MonedaId { get; set; }

        public int EstadoId { get; set; }
        public int SucursalId { get; set; }

        [Display(Name = "Fecha de Pago")]
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }

        

        
        public Sucursal SucursalPago { get; set; }
        public Estado EstadoPago { get; set; }
        public Moneda MonedaPago { get; set; }
    }
}
