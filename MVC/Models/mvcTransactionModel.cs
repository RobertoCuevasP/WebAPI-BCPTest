using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcTransactionModel
    {
        [Required]
        public string CuentaOrigen { get; set; }
        [Required]
        public string CuentaDestino { get; set; }

        [Required]
        public decimal Monto { get; set; }
    }
}