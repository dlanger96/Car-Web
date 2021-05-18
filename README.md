# Car-Web

Web app for cars

## Main

<img align="center" alt="main" width="1000%" src="https://raw.githubusercontent.com/dlanger96/Car-Web/main/App%20photos/Main.png"/>

---

## Modal

<img align="center" alt="modal" width="1000%" src="https://raw.githubusercontent.com/dlanger96/Car-Web/main/App%20photos/Modal.png"/>

<br>

</br>

## ActionResult for Cars

```csharp
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
```

## Get all the cars from DB

API side

```csharp
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
```

## Generating table

```javascript
$(function () {
  $("#btn-Car").click(function () {
    var zapis = $("#txt-Car").val();
    $.ajax({
      type: "GET",
      url: "https://localhost:44352/api/cars/GetAllCars",
      data: { keyword: zapis },
      dataType: "json",
      contentType: "application/json; charset=utf-8",
      success: function (msg) {
        $("#car-table thead").empty();
        $("#car-table thead").append(
          "<tr> <th>#</th> <th>Make</th> <th>Model</th> <th>Fuel</th> <th>Power</th> <th>Production Year</th> <th>Quantity</th> <th>Select</th> </tr>"
        );
        console.log(msg);
        $("#car-table tbody").empty();
        for (var i = 0; i < msg.length; i++) {
          var number = i + 1;
          $("#car-table tbody").append(
            "<tr> <td>" +
              number +
              "</td> <td>" +
              msg[i].Make +
              "</td> <td>" +
              msg[i].Model +
              "</td> <td>" +
              msg[i].Fuel +
              "</td> <td>" +
              msg[i].Power +
              "</td> <td>" +
              msg[i].ProductionYear +
              "</td> <td>" +
              msg[i].Quantity +
              '</td> <td><button type="button" class="btn btn-warning" onclick="EditCarRecord(' +
              msg[i].Id_Car +
              ')">Select Car</button></td> </tr>'
          );
        }
      },
      error: function () {
        alert("Error while inserting data");
      },
    });
    return false;
  });
});
```

## Edit selected car

```javascript
function EditCarRecord(Selectedid) {
  $("#form")[0].reset();
  $("#ModalTitle").html("Edit selected Car: " + Selectedid + " ");
  $("#MyModal").modal();
  $.ajax({
    type: "GET",
    url: "https://localhost:44352/api/cars/GetSelectedCar",
    data: { selectedId: Selectedid },
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (car) {
      console.log(car);
      for (var i = 0; i < car.length; i++) {
        $("#IdCar").val(car[i].Id_Car);
        $("#CarModel").val(car[i].Model);
        $("#CarPower").val(car[i].Power);
        $("#CarQuantity").val(car[i].Quantity);
        $("#CarProductionYear").val(car[i].ProductionYear);
        $("#fuel-DropDown").val(car[i].Fuel);
        $("#make-DropDown").val(car[i].Make);
      }
    },
    error: function () {
      alert("Error while showing data");
    },
  });
}
```

## Saving data

Client

```javascript
$("#SaveCarRecord").click(function () {
  var data = $("#SubmitForm").serialize();
  $.ajax({
    type: "Post",
    url: "https://localhost:44352/api/cars/SaveCar",
    data: data,
    dataType: "json",
    success: function (result) {
      alert(result);
    },
    error: function (result) {
      alert("Error");
    },
  });
});
```

API

```csharp
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
                        string selectedFuel = selectedCar.Fuel.ToString();
                        string selectedMake = selectedCar.Make.ToString();
                        int selectedModel = int.Parse(selectedCar.Model);
                        Car currentCar = new Car();
                        currentCar.Fuel = entities.Fuels.Where(c => selectedFuel == c.Name).Select(c => c.Id_Fuel).FirstOrDefault();
                        currentCar.Make = entities.Makes.Where(c => selectedMake == c.Name).Select(c => c.Id_Make).FirstOrDefault();
                        currentCar.Model = entities.Models.Where(c => selectedModel == c.Id_Model).Select(c => c.Id_Model).FirstOrDefault();
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
            return Ok("Data Saved");

        }
```
