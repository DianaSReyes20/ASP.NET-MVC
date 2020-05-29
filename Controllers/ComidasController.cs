using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAvanzada.Models;

namespace PAvanzada.Controllers
{
    public class ComidasController : Controller
    {
        // GET: Comidas
        [HttpGet]
        public ActionResult Comidas()
        {
            Comidas comidaModel = new Comidas();
            return View(comidaModel);
        }

        [HttpPost]
        public ActionResult Comidas(Comidas comidaModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Comidas.Any(x => x.fecha == comidaModel.fecha))
                {
                    ViewBag.DuplicateMessage = "Ya existe una comida con esta fecha.";
                    return View("Comidas", comidaModel);
                }

                dbModel.Comidas.Add(comidaModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Comidas", new Comidas());
        }

        // GET: Juego
        [HttpGet]
        public ActionResult List()
        {
            using (DbModels dbModel = new DbModels())
                return View(dbModel.Comidas.ToList());
        }
    }
}