using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Personas
    {
        [Key]
        public int Identificador { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public int NumeroIdentificacion { get; set; }

        public string Email { get; set; }

        public string TipoIdentificacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string TipoNumeroIdentificacion { get; set; }

        [NotMapped]
        public string NombresApellidos { get; set; }
    }
}
