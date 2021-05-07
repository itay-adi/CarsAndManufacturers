using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndManufacturers
{
    public class Car
    {
        public int ModelYear { get; set; }
        public String Division { get; set; }
        public String CarLine { get; set; }
        public Double EngineDisplacement { get; set; }
        public int Cylinders { get; set; }
        public int CityGasEfficiency { get; set; }
        public int HighWayGasEfficiency { get; set; }
        public int CombinedGasEfficiency { get; set; }
    }
}
