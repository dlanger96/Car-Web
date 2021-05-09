using Car_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Car_Web.Controllers.Api
{
    public class CarsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllCars()
        {
            List<CarsModel> listCars = new List<CarsModel> { new CarsModel { Id_Car= 1, Make="VW", Model="Golf 8"}, 
                new CarsModel { Id_Car = 2, Make = "BMW", Model = "320d E90" }, 
                new CarsModel { Id_Car = 3, Make = "Audi", Model = "A4" } };
            return Ok(listCars);
        }
    }
}
