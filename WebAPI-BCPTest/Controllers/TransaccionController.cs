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
    public class TransaccionController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_connection"].ConnectionString);

        // POST: api/Movimiento
        public string PostTransaccion(Transaccion transaccion)
        {
            string msg = "Error";
            if (transaccion != null)
            {
                SqlCommand cmd = new SqlCommand("SP_Transaccion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CuentaOrigen", transaccion.CuentaOrigen);
                cmd.Parameters.AddWithValue("@CuentaDestino", transaccion.CuentaDestino);
                cmd.Parameters.AddWithValue("@Monto", transaccion.Monto);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Transacction has been completed";
                }
            }
            return msg;
        }

    }
}
