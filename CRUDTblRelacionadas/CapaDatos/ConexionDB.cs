using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CRUDTblRelacionadas.CapaDatos
{
    class ConexionDB
    {
        static private string CadenaConexion = "Server=DESKTOP-D7N6USO\\SQLEXPRESS; DataBase=PRACTICA_TABLAS; Integrated Security= true";
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
                
            }
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();

            }
            return Conexion;
        }
    }
}
