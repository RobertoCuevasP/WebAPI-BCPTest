using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using MVC.Models;

namespace MVC.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
        {
            IEnumerable<mvcCuentaModel> cuentasList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cuenta").Result;
            cuentasList = response.Content.ReadAsAsync<IEnumerable<mvcCuentaModel>>().Result;    
            return View(cuentasList);
        }

        public ActionResult NuevaCuenta()
        {
            return View(new mvcCuentaModel());
        }

        [HttpPost]
        public ActionResult NuevaCuenta(mvcCuentaModel cuenta)
        {
            List<SelectListItem> monedas = new List<SelectListItem>();
            monedas.Add(new SelectListItem { Text = "Bolivianos", Value = "BOL" });
            monedas.Add(new SelectListItem { Text = "Dolares", Value = "DOL" });

            ViewBag.MonedasType = monedas;
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cuenta", cuenta).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Movimientos(string id)
        {
            mvcCuentaDetailModel cuentaDetallada = new mvcCuentaDetailModel();
            
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Movimiento/" + id).Result;
            HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("Cuenta/" + id).Result;
            cuentaDetallada.movimientosList = response.Content.ReadAsAsync<IEnumerable<mvcMovimientoModel>>().Result;
            cuentaDetallada.cuenta = response2.Content.ReadAsAsync<mvcCuentaModel>().Result;
            return View(cuentaDetallada);
        }

        public ActionResult Transaccion()
        {
            List<string> cuentasList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NroCuenta").Result;
            cuentasList = response.Content.ReadAsAsync<List<string>>().Result;
            ViewBag.data = cuentasList;
            return View(new mvcTransactionModel());
        }

        [HttpPost]
        public ActionResult Transaccion(mvcTransactionModel transaccion)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Transaccion", transaccion).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Operacion()
        {
            List<string> cuentasList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NroCuenta").Result;
            cuentasList = response.Content.ReadAsAsync<List<string>>().Result;
            ViewBag.data = cuentasList;
            return View(new mvcAbonoRetiroModel());
        }

        [HttpPost]
        public ActionResult Operacion(mvcAbonoRetiroModel operacion, string submitButton)
        {
            if (submitButton.Equals("Abono"))
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Abono", operacion).Result;
            } else if (submitButton.Equals("Retiro"))
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Retiro", operacion).Result;
            }
            return RedirectToAction("Index");
        }

       
    }
}