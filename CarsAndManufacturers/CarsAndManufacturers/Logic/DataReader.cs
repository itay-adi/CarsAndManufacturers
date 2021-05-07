using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndManufacturers
{
    public static class DataReader
    {
        // TODO: This should be moved to an external config file
        private const string _basePath = "Data";
        private const string _carsFile = "Cars.csv";
        private const string _mfgFile = "Manufacturers.csv";

        public static string[] toColumns(this string source)
        {
            return source.Split(',')
                .Select(s => s.Trim())
                .ToArray();
        }

        private static Car ToCar(this string source)
        {
            var carString = source.toColumns();
            Car car = new Car();

            if (carString.Length > 0)
            {
                car.ModelYear = int.Parse(carString[0]);
                car.Division = carString[1];
                car.CarLine = carString[2];
                car.EngineDisplacement = Double.Parse(carString[3]);
                car.Cylinders = int.Parse(carString[4]);
                car.CityGasEfficiency = int.Parse(carString[5]);
                car.HighWayGasEfficiency = int.Parse(carString[6]);
                car.CombinedGasEfficiency = int.Parse(carString[7]);

                return car;
            }

            return null;
        }

        private static Manufacturer ToManufacturer(this string source)
        {
            var manufacturerString = source.toColumns();
            Manufacturer manufacturer = new Manufacturer();

            if (manufacturerString.Length > 0)
            {
                manufacturer.Division = manufacturerString[0];
                manufacturer.Country = manufacturerString[1];
                manufacturer.Year = int.Parse(manufacturerString[2]);

                return manufacturer;
            }

            return null;
        }

        public static IEnumerable<Car> GetAllCars()
        {
            var carList = File.ReadAllLines($"{_basePath}/{_carsFile}")
                .Skip(1)
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToCar());

            return carList;
        }

        public static IEnumerable<Manufacturer> GetAllManufacturers()
        {
            var ManufacturerList = File.ReadAllLines($"{_basePath}/{_mfgFile}")
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToManufacturer());

            return ManufacturerList;
        }
    }
}
