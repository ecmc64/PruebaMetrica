using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba2.Models
{
    public class Sucursal
    {
        public int SucursalId { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Direccion")]
        public string Direccion { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Banco")]
        public int BancoId { get; set; }

        public Banco BancoAsignado { get; set; }
    }
}
