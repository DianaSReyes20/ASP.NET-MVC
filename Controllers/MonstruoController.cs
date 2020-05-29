using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAvanzada.Models;
using System.Web.Mvc;

namespace PAvanzada.Controllers
{
    public class MonstruoController : Controller
    {
        // GET: Monstruo
        [HttpGet]
        public ActionResult Monstruo()
        {
            Monstruo monsModel = new Monstruo();
            return View(monsModel);
        }

        [HttpPost]
        public ActionResult Monstruo(Monstruo monsModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Monstruo.Any(x => x.nombre_monstruo == monsModel.nombre_monstruo))
                {
                    ViewBag.DuplicateMessage = "Ya existe un monstruo con este nombre.";
                    return View("Monstruo", monsModel);
                }

                dbModel.Monstruo.Add(monsModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Monstruo", new Monstruo());
        }
    }
}