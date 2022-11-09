using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcCuentaDetailModel
    {
        public mvcCuentaModel cuenta { get; set; }
        public IEnumerable<mvcMovimientoModel> movimientosList { get; set; }
    }
}