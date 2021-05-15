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
            List<CarsModel> listOfCars = new List<CarsModel>();
            
            List<Car> listCar = new List<Car>();
            using (CarsEntities entities = new CarsEntities())
            {
                listCar = new List<Car>(entities.Cars.ToList());
                foreach (var item in listCar)
                {
                    CarsModel carsModel = new CarsModel();
                    carsModel.Id_Car = item.Id_Car;
                    carsModel.Fuel = entities.Fuels.Where(c => item.Fuel == c.Id_Fuel).Select(c => c.Name).FirstOrDefault().ToString();
                    carsModel.Make = entities.Makes.Where(c => c.Id_Make == item.Make).Select(c => c.Name).FirstOrDefault().ToString();
                    carsModel.Model = entities.Models.Where(c => c.Id_Model == item.Model).Select(c => c.Name).FirstOrDefault().ToString();
                    carsModel.Power = item.Power;
                    carsModel.ProductionYear = int.Parse(item.Production_Year.ToString());
                    carsModel.Quantity = int.Parse(item.Quantity.ToString());
                    listOfCars.Add(carsModel);
                }
               
                
                
            }
            return Ok(listOfCars);
        }
        [HttpGet]
        public IHttpActionResult GetSelectedCar(int selectedId)
        {
            List<CarsModel> listOfCars = new List<CarsModel>();

            List<Car> listCar = new List<Car>();
            using (CarsEntities entities = new CarsEntities())
            {
                listCar = new List<Car>(entities.Cars.Where(c => selectedId == c.Id_Car));
                foreach (var item in listCar)
                {
                    CarsModel carsModel = new CarsModel();
                    carsModel.Id_Car = item.Id_Car;
                    carsModel.Fuel = entities.Fuels.Where(c => item.Fuel == c.Id_Fuel).Select(c => c.Name).FirstOrDefault().ToString();
                    carsModel.Make = entities.Makes.Where(c => c.Id_Make == item.Make).Select(c => c.Name).FirstOrDefault().ToString();
                    carsModel.Model = entities.Models.Where(c => c.Id_Model == item.Model).Select(c => c.Name).FirstOrDefault().ToString();
                    carsModel.Power = item.Power;
                    carsModel.ProductionYear = int.Parse(item.Production_Year.ToString());
                    carsModel.Quantity = int.Parse(item.Quantity.ToString());
                    listOfCars.Add(carsModel);
                }



            }
            return Ok(listOfCars);
        }





    }
}
