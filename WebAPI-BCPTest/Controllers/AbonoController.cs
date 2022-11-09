using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_BCPTest.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPI_BCPTest.Controllers
{
    public class AbonoController : ApiController
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_connection"].ConnectionString);

        // POST: api/Abono
        public string Post(Operacion operacion)
        {
            string msg = "Error";
            if (operacion != null)
            {
                SqlCommand cmd = new SqlCommand("SP_Abono", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroCuenta", operacion.NroCuenta);
                cmd.Parameters.AddWithValue("@Monto", operacion.Monto);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Abono Realizado";
                }
            }
            return msg;
        }
    }
}
