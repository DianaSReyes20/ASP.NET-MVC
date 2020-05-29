using System;
using System.Collections.Generic;
using System.Linq;
using PAvanzada.Models;
using System.Web;
using System.Web.Mvc;

namespace PAvanzada.Controllers
{
    public class PatrocinadorController : Controller
    {
        // GET: Patrocinador
        [HttpGet]
        public ActionResult Patrocinador()
        {
            Patrocinador patroModel = new Patrocinador();
            return View(patroModel);
        }

        [HttpPost]
        public ActionResult Patrocinador(Patrocinador patroModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Patrocinador.Any(x => x.nombre_patr == patroModel.nombre_patr))
                {
                    ViewBag.DuplicateMessage = "Ya existe un patrocinador con este nombre.";
                    return View("Patrocinador", patroModel);
                }

                dbModel.Patrocinador.Add(patroModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Patrocinador", new Patrocinador());
        }
    }
}