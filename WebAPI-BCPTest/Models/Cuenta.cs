using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_BCPTest.Models
{
    public class Cuenta
    {
        public string NroCuenta { get; set; }
        public string Tipo { get; set; }
        public string Moneda { get; set; }
        public string Nombre { get; set; }

        public decimal Saldo { get; set; }
    }
}