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
    public class CuentaController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_connection"].ConnectionString);
        // GET: api/Cuenta
        public List<Cuenta> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GetCuentas", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Cuenta> cuentasList = new List<Cuenta>();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Cuenta acc = new Cuenta();
                    acc.NroCuenta = dt.Rows[i]["Nro_Cuenta"].ToString();
                    acc.Tipo = dt.Rows[i]["Tipo"].ToString();
                    acc.Moneda = dt.Rows[i]["Moneda"].ToString();
                    acc.Nombre = dt.Rows[i]["Nombre"].ToString();
                    acc.Saldo = Convert.ToDecimal(dt.Rows[i]["Saldo"]);
                    cuentasList.Add(acc);
                }
            }
            return dt.Rows.Count > 0 ? cuentasList : null;
        }

        // GET: api/Cuenta/5
        public Cuenta Get(string id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GetCuentaByNro", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@NroCuenta", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Cuenta acc = new Cuenta();
            if (dt.Rows.Count > 0)
            {        
                acc.NroCuenta = dt.Rows[0]["Nro_Cuenta"].ToString();
                acc.Tipo = dt.Rows[0]["Tipo"].ToString();
                acc.Moneda = dt.Rows[0]["Moneda"].ToString();
                acc.Nombre = dt.Rows[0]["Nombre"].ToString();
                acc.Saldo = Convert.ToDecimal(dt.Rows[0]["Saldo"]);
                
            }
            return dt.Rows.Count > 0 ? acc : null;
        }

        // POST: api/Cuenta
        public string Post(Cuenta cuenta)
        {
            string msg = "Error";
            if(cuenta != null)
            {
                SqlCommand cmd = new SqlCommand("SP_CreateCuentaAux", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroCuenta", cuenta.NroCuenta);
                cmd.Parameters.AddWithValue("@Moneda", cuenta.Moneda);
                cmd.Parameters.AddWithValue("@Nombre", cuenta.Nombre);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Account has been created";
                }
            }
            return msg;
        }

        // PUT: api/Cuenta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        

        // DELETE: api/Cuenta/5
        public void Delete(int id)
        {
        }
    }
}
