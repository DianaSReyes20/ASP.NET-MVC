using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAvanzada.Models;
using System.Web.Mvc;

namespace PAvanzada.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult Usuario()
        {
            Usuario userModel = new Usuario();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Usuario(Usuario userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Usuario.Any(x => x.nombre_usuario == userModel.nombre_usuario))
                {
                    ViewBag.DuplicateMessage = "Ya existe un usuario con este nombre.";
                    return View("Usuario", userModel);
                }

                dbModel.Usuario.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Usuario", new Usuario());
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Usuario userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                var usr = dbModel.Usuario.Single(x => x.nombre_usuario == userModel.nombre_usuario && x.contraseña == userModel.contraseña);
                if (usr != null)
                {
                    Session["nombre_usuario"] = usr.nombre_usuario.ToString();
                    Session["contraseña"] = usr.contraseña.ToString();
                    if (usr.nombre_usuario.ToString()!="Saitama")
                        return RedirectToAction("LoggedIn");
                } else
                {
                    ModelState.AddModelError("", "El usuario o la contraseña son incorrectos");
                }

                if (usr != null)
                {
                    Session["nombre_usuario"] = usr.nombre_usuario.ToString();
                    Session["contraseña"] = usr.contraseña.ToString();
                    if (usr.nombre_usuario.ToString() == "Saitama")
                        return RedirectToAction("LoggedIn_S");
                }
                else
                {
                    ModelState.AddModelError("", "El usuario o la contraseña son incorrectos");
                }
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (Session["nombre_usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult LoggedIn_S()
        {
            if (Session["nombre_usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }


    }
}