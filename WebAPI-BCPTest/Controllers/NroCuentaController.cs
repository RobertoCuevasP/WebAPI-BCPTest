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
    public class NroCuentaController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_connection"].ConnectionString);
        // GET: api/NroCuenta
        public List<string> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GetNumerosCuenta", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> cuentasList = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cuentasList.Add(dt.Rows[i]["Nro_Cuenta"].ToString());
                }
            }
            return dt.Rows.Count > 0 ? cuentasList : null;
        }
    }
}
