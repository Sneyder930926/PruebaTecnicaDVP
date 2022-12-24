using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Usuarios
    {
        [Key]
        public int Identificador { get; set; }

        public string Usuario { get; set; }

        public string Pass { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}