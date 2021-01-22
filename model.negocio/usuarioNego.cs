using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.entity;
using model.dao;
namespace model.negocio
{
   public class usuarioNego
    {
        private usuarioDao objUsuarioDao;

        public usuarioNego()
        {
            objUsuarioDao = new usuarioDao();
        }
        public void create(usuario objUsuario)
        {
            //validaciones

            //validar id_usuario  estado=1
            string codigo = objUsuario.Id_user.ToString();
            int idUsuario = 0;
            bool verificacion;
            if(codigo ==null)
            {
                objUsuario.Estado = 10;
                return;
            }else
            {
                try
                {
                    idUsuario = Convert.ToInt32(objUsuario.Id_user);
                    verificacion = idUsuario >= 1 && idUsuario <= 99;
                    if (!verificacion)
                    {
                        objUsuario.Estado = 1;
                        return;
                    }
                }catch(Exception e)
                {
                    objUsuario.Estado = 100;
                    return;
                }
            }

            //validar nombre del usuario  estado =2
            string nombre = objUsuario.Nombre;

            if(nombre == null)
            {
                objUsuario.Estado = 20;
                return;
            }
            else
            {
                nombre = objUsuario.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;

                if(!verificacion)
                {
                    objUsuario.Estado = 2;
                    return;
                }
            }
            //validar el apellido del usuario  estado=3
            string apellido = objUsuario.Apellido ;

            if (apellido == null)
            {
                objUsuario.Estado = 30;
                return;
            }
            else
            {
                apellido = objUsuario.Apellido.Trim();
                verificacion = apellido.Length > 0 && apellido.Length <= 50;

                if (!verificacion)
                {
                    objUsuario.Estado = 3;
                    return;
                }
               
            }
            //validar el telefono del usuario  estado =4
            string telefono = objUsuario.Telefono;

            if (telefono == null)
            {
                objUsuario.Estado = 40;
                return;
            }
            else
            {
                telefono = objUsuario.Telefono.Trim();
                verificacion = telefono.Length > 0 && telefono.Length <= 12;

                if (!verificacion)
                {
                    objUsuario.Estado = 4;
                    return;
                }

            }
            //validar duplicidad =estado=5
            usuario objUsuarioaux = new usuario();
            objUsuarioaux.Id_user = objUsuario.Id_user;
            verificacion = !objUsuarioDao.find(objUsuarioaux);
            if (!verificacion)
            {
                objUsuario.Estado = 5;
                return;
            }
            objUsuario.Estado = 99;
            objUsuarioDao.create(objUsuario);
        }

        public void update(usuario objUsuario)
        {
            //validaciones

            //validar id_usuario  estado=1
            bool verificacion;
          
            //validar nombre del usuario  estado =2
            string nombre = objUsuario.Nombre;

            if (nombre == null)
            {
                objUsuario.Estado = 20;
                return;
            }
            else
            {
                nombre = objUsuario.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;

                if (!verificacion)
                {
                    objUsuario.Estado = 2;
                    return;
                }
            }
            //validar el apellido del usuario  estado=3
            string apellido = objUsuario.Apellido;

            if (apellido == null)
            {
                objUsuario.Estado = 30;
                return;
            }
            else
            {
                apellido = objUsuario.Apellido.Trim();
                verificacion = apellido.Length > 0 && apellido.Length <= 50;

                if (!verificacion)
                {
                    objUsuario.Estado = 3;
                    return;
                }

            }
            //validar el telefono del usuario  estado =4
            string telefono = objUsuario.Telefono;

            if (telefono == null)
            {
                objUsuario.Estado = 40;
                return;
            }
            else
            {
                telefono = objUsuario.Telefono.Trim();
                verificacion = telefono.Length > 0 && telefono.Length <= 12;

                if (!verificacion)
                {
                    objUsuario.Estado = 4;
                    return;
                }

            }
    
            objUsuario.Estado = 99;
            objUsuarioDao.update(objUsuario);
        }
        public void delete(usuario objUsuario)
        {
            //validaciones

         
            bool verificacion;

            usuario objUsuarioAux = new usuario();
            objUsuarioAux.Id_user = objUsuario.Id_user;
            verificacion = objUsuarioDao.find(objUsuarioAux);

     
            if (!verificacion)
            {
                objUsuario.Estado = 33;
                return;
            }
            objUsuario.Estado = 99;
            objUsuarioDao.delete(objUsuario);
        }

        public bool find(usuario objUsuario)
        {
            return objUsuarioDao.find(objUsuario);
        } 
        public List<usuario> findAll()
        {
            return objUsuarioDao.findAll();
        }
    }
}
