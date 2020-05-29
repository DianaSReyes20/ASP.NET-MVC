using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAvanzada.Models;
using System.Web.Mvc;

namespace PAvanzada.Controllers
{
    public class LuchaController : Controller
    {
        // GET: Lucha
        [HttpGet]
        public ActionResult Lucha()
        {
            Lucha luchaModel = new Lucha();
            return View(luchaModel);
        }

        [HttpPost]
        public ActionResult Lucha(Lucha luchaModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Lucha.Any(x => x.codigo_l == luchaModel.codigo_l))
                {
                    ViewBag.DuplicateMessage = "Ya existe un combate con este codigo.";
                    return View("Lucha", luchaModel);
                }

                dbModel.Lucha.Add(luchaModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Lucha", new Lucha());
        }

        // GET: Juego
        [HttpGet]
        public ActionResult List()
        {
            using (DbModels dbModel = new DbModels())
                return View(dbModel.Lucha.ToList());
        }
    }
}