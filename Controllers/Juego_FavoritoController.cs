using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAvanzada.Models;
using System.Web.Mvc;

namespace PAvanzada.Controllers
{
    public class Juego_FavoritoController : Controller
    {
        // GET: Juego
        [HttpGet]
        public ActionResult Juego_Favorito()
        {
            Juego_Favorito juegoModel = new Juego_Favorito();
            return View(juegoModel);
        }

        [HttpPost]
        public ActionResult Juego_Favorito(Juego_Favorito juegoModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Juego_Favorito.Any(x => x.codigo_juego == juegoModel.codigo_juego))
                {
                    ViewBag.DuplicateMessage = "Ya existe un juego con este codigo.";
                    return View("Juego_Favorito", juegoModel);
                }

                dbModel.Juego_Favorito.Add(juegoModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso.";
            return View("Juego_Favorito", new Juego_Favorito());
        }

        // GET: Juego
        [HttpGet]
        public ActionResult List()
        {
            using (DbModels dbModel = new DbModels())
                return View(dbModel.Juego_Favorito.ToList());
        }

        // GET: Juego
        public ActionResult Editar(String codigo_juego)
        {
            using (DbModels dbModel = new DbModels())
                return View(dbModel.Juego_Favorito.Where(x => x.codigo_juego == codigo_juego).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Editar(String codigo_juego, Juego_Favorito juego_Favorito)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.Entry(juego_Favorito).State = System.Data.Entity.EntityState.Modified;
                dbModel.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult Eliminar(String codigo_juego)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Juego_Favorito.Where(x => x.codigo_juego == codigo_juego).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Eliminar(String codigo_juego, FormCollection collection)
        {
            using (DbModels dbModel = new DbModels())
            {
                Juego_Favorito juego_Favorito = dbModel.Juego_Favorito.Where(x => x.codigo_juego == codigo_juego).FirstOrDefault();
                dbModel.Juego_Favorito.Remove(juego_Favorito);
                dbModel.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}