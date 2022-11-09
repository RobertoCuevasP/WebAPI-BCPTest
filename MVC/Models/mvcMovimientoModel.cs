using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcMovimientoModel
    {
        public string NroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public char Tipo { get; set; }
        public decimal Importe { get; set; }
    }
}