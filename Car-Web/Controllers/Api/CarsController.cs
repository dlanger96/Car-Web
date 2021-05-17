using Car_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

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
                    //carsModel.ListOfFuels = (from p in entities.Fuels.AsEnumerable() select new SelectListItem { Text = p.Name, Value = p.Id_Fuel.ToString() }).ToList();
                    listOfCars.Add(carsModel);
                }



            }
            return Ok(listOfCars);
        }

        [HttpPost]
        public IHttpActionResult SaveCar(CarsModel selectedCar)
        {
                try
                {
                
                using (CarsEntities entities = new CarsEntities())
                {
                    if (selectedCar.Id_Car > 0)
                    {
                        Car carForEdit = entities.Cars.Where(c => selectedCar.Id_Car == c.Id_Car).FirstOrDefault();

                        carForEdit.Id_Car = int.Parse(entities.Cars.Where(c => selectedCar.Id_Car == c.Id_Car).Select(c => c.Id_Car).FirstOrDefault().ToString());
                        carForEdit.Fuel = int.Parse(entities.Fuels.Where(c => selectedCar.Fuel == c.Name).Select(c => c.Id_Fuel).FirstOrDefault().ToString());
                        carForEdit.Make = entities.Makes.Where(c => selectedCar.Make == c.Name).Select(c => c.Id_Make).FirstOrDefault();
                        carForEdit.Model = entities.Models.Where(c => selectedCar.Model == c.Name).Select(c => c.Id_Model).FirstOrDefault();
                        carForEdit.Power = selectedCar.Power;
                        carForEdit.Production_Year = selectedCar.ProductionYear;
                        carForEdit.Quantity = selectedCar.Quantity;
                        entities.SaveChanges();

                    }
                    else
                    {
                        Car currentCar = new Car();
                        //currentCar.Id_Car = int.Parse(entities.Cars.Where(c => selectedCar.Id_Car == c.Id_Car).Select(c => c.Id_Car).FirstOrDefault().ToString());
                        currentCar.Fuel = int.Parse(entities.Fuels.Where(c => selectedCar.Fuel == c.Name).Select(c => c.Id_Fuel).FirstOrDefault().ToString());
                        currentCar.Make = entities.Makes.Where(c => selectedCar.Make == c.Name).Select(c => c.Id_Make).FirstOrDefault();
                        currentCar.Model = entities.Models.Where(c => selectedCar.Model == c.Name).Select(c => c.Id_Model).FirstOrDefault();
                        currentCar.Power = selectedCar.Power;
                        currentCar.Production_Year = selectedCar.ProductionYear;
                        currentCar.Quantity = selectedCar.Quantity;
                        entities.Cars.Add(currentCar);
                        entities.SaveChanges();
                    }
                }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            return Ok();

        }

    }
}
