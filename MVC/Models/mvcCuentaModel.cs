using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcCuentaModel
    {
        [Required (ErrorMessage = "Debe llenarse el campo")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "El número de cuenta no es válido")]
        public string NroCuenta { get; set; }
        public string Tipo { get; set; }
        public Moneda Moneda { get; set; }

        [Required (ErrorMessage ="Debe llenarse el campo")]
        [StringLength(40, ErrorMessage ="El campo no puede exceder de 40 caracteres")]
        public string Nombre { get; set; }

        public decimal Saldo { get; set; }
    }
    
    public enum Moneda
    {
        BOL,
        DOL
    }
}