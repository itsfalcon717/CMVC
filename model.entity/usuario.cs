using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.entity
{
   public class usuario
    {
        private int id_user;
        private string nombre;
        private string apellido;
        private string telefono;

        private int estado;
        //generamos contructor por defecto
        public usuario()
        {

        }
        public usuario(int id_user)
        {
            this.id_user = id_user;
        }

        public  usuario(int id_user,string nombre,string apellido,string telefono)
        {
            this.id_user = id_user;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }

        //metodos get y  set
        public int Id_user
        {
            get
            {
                return id_user;
            }

            set
            {
                id_user = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
