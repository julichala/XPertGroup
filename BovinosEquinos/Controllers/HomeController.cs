using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BovinosEquinos.Services;
using BovinosEquinos.Services.Interfases;
using BovinosEquinos.Core.Entities;

namespace BovinosEquinos.Controllers
{
    public class HomeController : Controller
    {
        private IAnimalesService animalService;

        public HomeController(IAnimalesService animalService)
        {
            this.animalService = animalService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            //Guardar el archivo en una ruta que podamos leer
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/"), fileName);
                    file.SaveAs(path);
                }
            }

            //Obtener los Animales asignando la especie
            List<Animal> ListaAnimales =  animalService.GetAnimales();

            //Generar los Archivos de las dos especies
            animalService.SaveAnimales(ListaAnimales);

            return RedirectToAction("About");
        }
    }
}