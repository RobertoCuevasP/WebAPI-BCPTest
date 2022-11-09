using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_BCPTest.Models
{
    public class Movimiento
    {
        public string NroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public char Tipo { get; set; }
        public decimal Importe { get; set; }
    }
}