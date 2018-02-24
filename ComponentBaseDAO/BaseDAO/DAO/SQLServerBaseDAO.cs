using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAO
{
    /// <summary>
    /// Clase que permite manejar todo lo referente de acceso a datos para el motor SqlServer.
    /// </summary>
   public class SQLServerBaseDAO
    {
                
        /// <summary>
        /// Cadena de conexion
        /// </summary>
        private string Conexion;
        /// <summary>
        /// Permite la conexion  a la base datos
        /// </summary>
        private static SqlConnection Cone;



        /// <summary>
        /// establece la conexion al motor de base datos con una conexión por defecto "conexionSqlServer" del .config 
        /// </summary>
        public SQLServerBaseDAO ()
        {            //Cadena de Conexion
            Conexion = ConfigurationManager.ConnectionStrings["conexionSqlServer"].ConnectionString;
            Cone = new SqlConnection(Conexion);
        }

        /// <summary>
        /// establece la conexion al motor de base datos 
        /// </summary>
        /// <param name="cadenaConexion">recibe el nombre de la cadena de conexión del .config</param>
        public SQLServerBaseDAO(string cadenaConexion)
        {            //Cadena de Conexion
            Conexion = ConfigurationManager.ConnectionStrings[cadenaConexion].ConnectionString;
            Cone = new SqlConnection(Conexion);
        }


        /// <summary>
        /// abre la conexion Sql
        /// </summary>
        public void abrirConexion()
        {
            Cone.Open();
        }
    
        /// <summary>
        /// cierra la conexion sql
        /// </summary>
        public void CerrarConexion()
        {
            Cone.Close();
        }



        /// <summary>
        /// permite realizar consultas de información a traves de procedures recibe una lista de parametros.
        /// </summary>
        /// <param name="nombreSP"></param>
        /// <param name="parametros"></param>
        /// <returns>retorna DataTable como resultado del procedure </returns>
        protected DataTable Consultar(string nombreSP, List<SqlParameter> parametros)
        {
            DataTable DtCompraul = new DataTable();
            try
            {
                SqlCommand SqlComando = new SqlCommand(nombreSP, Cone);
                SqlDataAdapter SqlDA = new SqlDataAdapter();

                SqlComando.Parameters.Clear();
                SqlComando.CommandType = CommandType.StoredProcedure;

                foreach (var IDP in parametros)
                {
                    SqlComando.Parameters.Add(IDP);
                }
                
                SqlDA.SelectCommand = SqlComando;

                SqlDA.Fill(DtCompraul);
                
                return DtCompraul;
            }

            catch (Exception e)
            {
                 throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// permite realizar consultas de información a traves de stored procedures recibe un array de parametros.
        /// </summary>
        /// <param name="nombreSP"></param>
        /// <param name="parametros"></param>
        /// <returns>retorna DataTable como resultado del SP </returns>
        public DataTable Consultar(string nombreSP, SqlParameter [] parametros)
        {
            DataTable DtCompraul = new DataTable();
            try
            {
                SqlCommand SqlComando = new SqlCommand(nombreSP, Cone);
                SqlDataAdapter SqlDA = new SqlDataAdapter();

                SqlComando.Parameters.Clear();
                SqlComando.CommandType = CommandType.StoredProcedure;

                if(parametros != null)
                foreach (var IDP in parametros)
                {
                    SqlComando.Parameters.Add(IDP);
                }

                SqlDA.SelectCommand = SqlComando;

                SqlDA.Fill(DtCompraul);

                return DtCompraul;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        /// <summary>
        /// permite realizar la ejecucion de información a traves de procedures util para insertar, eliminar, actulizar  recibe una lista de parametros.
        /// </summary>
        /// <param name="nombreSP"></param>
        /// <param name="parametros"></param>
        protected void ejecutar(string nombreSP, List<SqlParameter> parametros)
        {
            DataTable DtCompraul = new DataTable();
            try
            {
                SqlCommand SqlComando = new SqlCommand(nombreSP, Cone);
                SqlDataAdapter SqlDA = new SqlDataAdapter();

                SqlComando.Parameters.Clear();
                SqlComando.CommandType = CommandType.StoredProcedure;

                foreach (var IDP in parametros)
                {
                    SqlComando.Parameters.Add(IDP);
                }

                SqlComando.ExecuteNonQuery();

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// permite realizar la ejecucion de información a traves de procedures util para insertar, eliminar, actulizar  recibe un array de parametros.
        /// </summary>
        /// <param name="nombreSP"></param>
        /// <param name="parametros"></param>
        public void ejecutar (string nombreSP, SqlParameter [] parametros )
        {
            DataTable DtCompraul = new DataTable();
            try
            {
                SqlCommand SqlComando = new SqlCommand(nombreSP, Cone);
                SqlDataAdapter SqlDA = new SqlDataAdapter();

                SqlComando.Parameters.Clear();
                SqlComando.CommandType = CommandType.StoredProcedure;

                foreach (var IDP in parametros)
                {
                    SqlComando.Parameters.Add(IDP);
                }

                SqlComando.ExecuteNonQuery();

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
