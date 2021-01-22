using model.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.dao
{
   public  class usuarioDao:IntUsuario<usuario>
    {
        private Conexion objConexion;
        private SqlCommand comando;
        public usuarioDao()
        {
            objConexion = Conexion.estado();
        }

        public void create(usuario objUsuario)
        {
            string create = "insert into usuario(id_user,nombre,apellido,telefono) values('" + objUsuario.Id_user + "','" + objUsuario.Nombre + "','" + objUsuario.Apellido + "','" + objUsuario.Telefono + "') ";
            try
            {
                comando = new SqlCommand(create, objConexion.getCon());
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void update(usuario objUsuario)
        {
            string update = "update usuario  set nombre='"+objUsuario.Nombre+"', apellido='"+objUsuario.Apellido+"', telefono='"+objUsuario.Telefono+"' where id_user='"+objUsuario.Id_user+"' ";
            try
            {
                comando = new SqlCommand(update, objConexion.getCon());
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void delete(usuario objUsuario)
        {
            string delete = "delete from usuario where id_user='" + objUsuario.Id_user + "' ";
            try
            {
                comando = new SqlCommand(delete, objConexion.getCon());
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public bool find(usuario objUsuario)
        {
            bool  hayregistros;
            string find = "select * from usuario where id_user='"+objUsuario.Id_user+"' ";
            try
            {
                comando = new SqlCommand(find, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                hayregistros = read.Read();

                if (hayregistros)
                {
                    objUsuario.Id_user = Convert.ToInt32(read[0].ToString());
                    objUsuario.Nombre = read[1].ToString();
                    objUsuario.Apellido = read[2].ToString();
                    objUsuario.Telefono = read[3].ToString();

                    objUsuario.Estado = 99;

                }else
                {
                    objUsuario.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
            return hayregistros;
        }

        public List<usuario> findAll()
        {
            List<usuario> listaUsuario = new List<usuario>();
            string findAll = "select * from usuario ";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();

                while (read.Read())
                {
                    usuario objUsuario = new usuario();
                    objUsuario.Id_user = Convert.ToInt32(read[0].ToString());
                    objUsuario.Nombre = read[1].ToString();
                    objUsuario.Apellido = read[2].ToString();
                    objUsuario.Telefono = read[3].ToString();

                    listaUsuario.Add(objUsuario);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally{
                    objConexion.getCon().Close();
                    objConexion.cerrarConexion();
                }
            
            return listaUsuario;
        }
    }
}
