using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba2.Models
{
    public class Banco
    {
        public int BancoId { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Direccion")]
        public string Direccion { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
