using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndManufacturers.Logic
{
    public static class API
    {
        public static IEnumerable<Manufacturer> getAllManufacturers()
        {
            var AllManufacturers = DataReader.GetAllManufacturers().
                OrderBy(m => m.Division);

            return AllManufacturers;
        }

        public static IEnumerable<Car> getAllVehiclesOfManufacturer(string division)
        {
            var cars = DataReader.GetAllCars().
                Where(car => car.Division == division)
                .OrderBy(c => c.CarLine)
                .ThenBy(c => c.Cylinders);

            return cars;
        }

        public static IEnumerable<(string manufacturer, int numberOfCars)> getNumberOfCarsPerMFG()
        {
            var allMFGs = DataReader.GetAllCars()
                .GroupBy(car => car.Division)
                .Select(group => (manufacturer: group.Key, numberOfCars: group.Count()));

            return allMFGs;
        }

        public static IEnumerable<string> getAllCountries()
        {
            var allCountries = DataReader.GetAllManufacturers()
                .Select(m => m.Country)
                .Distinct();

            return allCountries;
        }

        public static IEnumerable<(string division, IEnumerable<Car> cars)> getBestCarsOfManufacturersFrom(string country)
        {
            var manufacturers = DataReader.GetAllManufacturers()
                .Where(m => m.Country == country)
                .Select(m => m.Division)
                .ToHashSet();

            var bestThreeCars = DataReader.GetAllCars()
                .Where(c => manufacturers.Contains(c.Division))
                .GroupBy(c => c.Division)
                .Select(group => (
                    division: group.Key,
                    cars: group.OrderByDescending(car => car.CombinedGasEfficiency)
                               .Take(3))
                    );
            
            return bestThreeCars;
        }

        public static Car getCarWithLowestCombinedEfficiency()
        {
            var LowestCombinedEfficiencyCar = DataReader.GetAllCars()
                .OrderBy(c => c.CombinedGasEfficiency)
                .First();

            return LowestCombinedEfficiencyCar;
        }

        public static double getAvarageCityEfficiency()
        {
            var avarageCityEfficiency = DataReader.GetAllCars()
                .Average(c => c.CityGasEfficiency);
                
            return avarageCityEfficiency;
        }

        public static int getNumberOfCountries()
        {
            var numOfCountries = getAllCountries().Count();

            return numOfCountries;
        }

        public static (string name, double avg) getMFGWithHighestAVGCombinedEfficiency()
        {
            var MFGWithHighestAVGCombinedEfficiency = DataReader.GetAllCars()
                .GroupBy(c => c.Division)
                .Select(group => (name: group.Key, avg: group.Average(c => c.CombinedGasEfficiency)))
                .OrderByDescending(tuple => tuple.avg)
                .First();
                

            return MFGWithHighestAVGCombinedEfficiency;
        }
    }
}
