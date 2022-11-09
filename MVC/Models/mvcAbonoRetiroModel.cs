using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MVC.Models
{
    public class mvcAbonoRetiroModel
    {   
        [Required]
        public string NroCuenta { get; set; }
        [Required]
        public decimal Monto { get; set; }
    }
}