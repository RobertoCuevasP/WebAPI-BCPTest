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
    public class MovimientoController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_connection"].ConnectionString);

        // GET: api/Movimiento/1
        public List<Movimiento> Get(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GetMovimientos", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@NroCuenta", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Movimiento> movimientosList = new List<Movimiento>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Movimiento mov = new Movimiento();
                    mov.NroCuenta = dt.Rows[i]["Nro_Cuenta"].ToString();
                    mov.Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"]);
                    mov.Tipo = Convert.ToChar(dt.Rows[i]["Tipo"]);
                    mov.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"]);
                    movimientosList.Add(mov);
                }
            }
            return dt.Rows.Count > 0 ? movimientosList : null;
        }

    }
}
