using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;

namespace DAO
{
    public class OracleBaseDAO
    {

        /// <summary>
        /// cadena de conexion a la base datos.
        /// </summary>
        private string conexion;



        /// <summary>
        /// permite la conexion a la base de datos.
        /// </summary>
        private OracleConnection con;

        protected OracleBaseDAO()
        {
            conexion = ConfigurationManager.AppSettings["ConexionOracle"].ToString();

            con = new OracleConnection();
        }


        /// <summary>
        /// realiza consultas en la base de datos a partir  de un query
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="query"></param>
        /// <returns>Retorna los datos generados por el query</returns>
        protected DataTable Consultar(OracleParameter [] parametros, String query )
        {
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            con.ConnectionString = conexion;
            OracleCommand cmd = new OracleCommand();
            DataSet set = new DataSet();
            cmd.Connection = con;
            try
            {
                con.Open();

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                

                if (parametros != null)
                {
                    foreach (var parametro in parametros )
                    {
                        cmd.Parameters.Add(parametro);
                    }
                }
                //cmd.ExecuteNonQuery();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(set);
                return set.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// realiza consultas en la base de datos a partir  de un sp
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="nameSP"></param>
        /// <returns>Retorna los datos generados por el query</returns>
        protected DataTable ConsultarSP(OracleParameter[] parametros, String nameSP)
        {
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            con.ConnectionString = conexion;
            OracleCommand cmd = new OracleCommand();
            DataSet set = new DataSet();
            cmd.Connection = con;
            try
            {
                con.Open();

                cmd.CommandText = nameSP;
                cmd.CommandType = CommandType.StoredProcedure;


                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.Add(parametro);
                    }
                }


                cmd.Parameters.Add("pcursor", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(set);
     
                
                return set.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Ejecuta un query en una bd de oracle
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="query"></param>
        protected void ejecutar(OracleParameter[] parametros, String query)
        {
            con.ConnectionString = conexion;
            OracleCommand cmd = new OracleCommand();
            DataSet set = new DataSet();
            cmd.Connection = con;
            try
            {
                con.Open();

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.Add(parametro);
                    }
                }
                int res = cmd.ExecuteNonQuery();

                if (res <= 0)
                {
                    throw new Exception("No se insertaron los datos.");
                }

            }
             catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
