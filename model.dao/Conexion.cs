using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.dao
{
  public class Conexion
    {
        private static Conexion objConexion = null;
        private SqlConnection con;

        public Conexion()
        {
            con = new SqlConnection("Data Source=DESKTOP-BNPH7ME;Initial Catalog=BDlogin;Integrated Security=True");
        }
        public static Conexion estado()
        {
            if (objConexion == null)
            {
                objConexion = new Conexion();
            }
            return objConexion;
        }

        public SqlConnection getCon()
        {
            return con;
        }
        public void cerrarConexion()
        {
            objConexion = null;
        }

    }
}
