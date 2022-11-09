using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_BCPTest.Models
{
    public class Transaccion
    {
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }

        public decimal Monto { get; set; }
    }
}