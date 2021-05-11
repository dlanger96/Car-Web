using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Web.Models
{
    public class CarsModel
    {
        public int Id_Car { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Fuel { get; set; }
        public string Power { get; set; }
        public int ProductionYear { get; set; }
        public int Quantity { get; set; }

    }
}