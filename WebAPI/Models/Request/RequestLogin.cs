using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Request
{
    public class RequestLogin
    {
        public string Usuario { get; set; }

        public string Pass { get; set; }
    }
}
