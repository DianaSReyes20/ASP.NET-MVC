using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAvanzada.Models;
using System.Web.Mvc;

namespace PAvanzada.Controllers
{
    public class ConvenioController : Controller
    {
        // GET: Convenio
        [HttpGet]
        public ActionResult Convenio()
        {
            Convenio convModel = new Convenio();
            return View(convModel);
        }

        [HttpPost]
        public ActionResult Convenio(Convenio convModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Convenio.Any(x => x.codigo_c == convModel.codigo_c))
                {
                    ViewBag.DuplicateMessage = "Ya existe un convenio con este código.";
                    return View("Convenio", convModel);
                }

                dbModel.Convenio.Add(convModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Convenio", new Convenio());
        }

        // GET: Juego
        [HttpGet]
        public ActionResult List()
        {
            using (DbModels dbModel = new DbModels())
                return View(dbModel.Convenio.ToList());
        }
    }
}