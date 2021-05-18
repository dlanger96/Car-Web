using Car_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Web.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Cars()
        {
            CarsModel carsModel = new CarsModel();
            using (CarsEntities entities = new CarsEntities())
            {
                carsModel.ListOfFuels = entities.Fuels.ToList();
                carsModel.ListOfMakes = entities.Makes.ToList();
                carsModel.ListOfModels = entities.Models.ToList();
            }
            return View(carsModel);
        }
        public ActionResult CreateCars()
        {
            return View();
        }
    }
}