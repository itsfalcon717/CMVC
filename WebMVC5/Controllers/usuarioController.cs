using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.entity;
using model.negocio;

namespace WebMVC5.Controllers
{
    public class usuarioController : Controller
    {
        private usuarioNego objUsuarioNeg;
        public usuarioController()
        {
            objUsuarioNeg = new usuarioNego();
        }
        // GET: usuario
        public ActionResult Inicio()
        {
            List<usuario> lista=objUsuarioNeg.findAll();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(usuario objUsuario)
        {
            mensajeInicio();
            objUsuarioNeg.create(objUsuario);
            mensajeErrorRegistro(objUsuario);
            return View();
        }
        //metodo edit
        [HttpPost]
        public ActionResult Update(usuario objUsuario)
        {
            objUsuarioNeg.update(objUsuario);
            mensajeErrorRegistro(objUsuario);
            return View();
        }
        public void mensajeInicio()
        {
            ViewBag.mensajeInicio = "Formulario de Registro de Usuarios";
        }
        public void mensajeErrorRegistro(usuario objUsuario)
        {
            switch (objUsuario.Estado)
            {
                case 10:
                    ViewBag.mensajeError = "Campo codigo esta vacio";
                    break;
                case 1:
                    ViewBag.mensajeError = "Excedio la longitud de la cadena,caracteres de tipo numero";
                    break;
                case 100:
                    ViewBag.mensajeError = "solo se permiten numeros";
                    break;
                case 20:
                    ViewBag.mensajeError = "Campo nombre esta vacio";
                    break;
                case 2:
                    ViewBag.mensajeError = "longitud de la cadena excedio,solo se permite menor o igual que 50";
                    break;
                case 30:
                    ViewBag.mensajeError = "Campo apellido esta vacio";
                    break;
                case 3:
                    ViewBag.mensajeError = "campo apellido longitud de la cadena excedio,solo se permite menor o igual que 50";
                    break;
                case 40:
                    ViewBag.mensajeError = "Campo telefono esta vacio";
                    break;
                case 4:
                    ViewBag.mensajeError = "campo telefono longitud de la cadena excedio,solo se permite menor o igual que 12";
                    break;
                case 5:
                    ViewBag.mensajeError = "Usuario ["+objUsuario.Id_user +"] ya esta registrado";
                    break;
                case 99:
                    ViewBag.mensajeExito = "Usuario [" + objUsuario.Id_user + "] se registro correctamente";
                    break;
            }
        
        }
    }
}