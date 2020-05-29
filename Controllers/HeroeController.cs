using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAvanzada.Models;
using System.Web.Mvc;

namespace PAvanzada.Controllers
{
    public class HeroeController : Controller
    {
        // GET: Heroe
        [HttpGet]
        public ActionResult Heroe()
        {
            Heroe heroModel = new Heroe();
            return View(heroModel);
        }

        [HttpPost]
        public ActionResult Heroe(Heroe heroModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Heroe.Any(x => x.nombre_heroe == heroModel.nombre_heroe))
                {
                    ViewBag.DuplicateMessage = "Ya existe un Héroe con este nombre.";
                    return View("Heroe", heroModel);
                }

                dbModel.Heroe.Add(heroModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Heroe", new Heroe());
        }
    }
}