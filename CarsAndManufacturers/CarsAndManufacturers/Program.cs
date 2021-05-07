using CarsAndManufacturers.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsAndManufacturers
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var choice = menuOptions.GetUserSelection(false);
                menuChoices(choice.index);
                Console.WriteLine();
            }
        }

        static List<string> menuOptions = new List<string>
        {
             "Option 1: List of all manufacturers",
             "Option 2: List of all vehicles of a specific manufacturer",
             "Option 3: Number of cars per MFG",
             "Option 4: Best cars of each MFG per countery",
             "Option 5: List General highlights"
        };

        private static void menuChoices(int choice)
        {
            switch (choice)
            {
                case 1:
                    ListAllManufacturers();
                    break;

                case 2:
                    ListCarsOfManufacturer();
                    break;

                case 3:
                    ListNumberOfCarsPErManufacturer();
                    break;

                case 4:
                    ListBestCarsOfManufacturers();
                    break;

                case 5:
                    ListGeneralHighlights();
                    break;

                default:
                    "Invalid input, please try again".Print(ConsoleColor.Red); ;
                    break;
            }
        }

        private static void ListAllManufacturers() 
        {
            var allManufacturers = API.getAllManufacturers();

            "\nOption 1: List of all manufacturers:\n".Print(ConsoleColor.Yellow);

            foreach (var manufacturer in allManufacturers)
            {
                $"{manufacturer.Division,-35} {manufacturer.Year,-5} {manufacturer.Country}".Print(ConsoleColor.Cyan);
            }
        }

        private static void ListCarsOfManufacturer()
        {
            var manfuacturers = API
                .getAllManufacturers()
                .Select(m => m.Division);

            "\nOption 2: List of all vehicles of a specific manufacturer:\n".Print(ConsoleColor.Yellow);
            
            var selected = manfuacturers.GetUserSelection();

            var cars = API.getAllVehiclesOfManufacturer(selected.option);

            foreach (var car in cars)
            {
                $"{car.Division,-30} {car.ModelYear,-30} {car.Cylinders}".Print(ConsoleColor.Cyan);
            }
        }

        private static void ListNumberOfCarsPErManufacturer()
        {
            var res = API.getNumberOfCarsPerMFG();

            "\nOption 3: Number of cars per MFG:\n".Print(ConsoleColor.Yellow);

            foreach (var item in res)
            {
                $"{item.manufacturer,-35} {item.numberOfCars}".Print(ConsoleColor.Cyan);
            }
        }

        private static void ListBestCarsOfManufacturers()
        {
            var countries = API.getAllCountries();

            "\nOption 4: Best cars of each MFG per countery:\n".Print(ConsoleColor.Yellow);

            var SelectedCountry = countries.GetUserSelection();

            var carGroup = API.getBestCarsOfManufacturersFrom(SelectedCountry.option);

            foreach (var group in carGroup)
            {
                group.division.Print(ConsoleColor.Cyan);

                foreach (var car in group.cars)
                {
                    $"{car.CarLine,-30} {car.ModelYear,-5}, {car.CombinedGasEfficiency}".Print();
                }
            }         
        }

        private static void ListGeneralHighlights()
        {
            "\nOption 5: General \"Most\"s:\n".Print(ConsoleColor.Yellow);

            $"Car with lowest combined FE: {API.getCarWithLowestCombinedEfficiency().Division}".Print(ConsoleColor.Cyan);
            $"Average City Efficiency: {API.getAvarageCityEfficiency():0.00}".Print(ConsoleColor.Cyan);
            $"Number of different countries: {API.getNumberOfCountries()}".Print(ConsoleColor.Cyan);

            var mfgWithHighAvg = API.getMFGWithHighestAVGCombinedEfficiency();
            $"Manufacturer with highest average combined FE is: {mfgWithHighAvg.name} {mfgWithHighAvg.avg:0.00}".Print(ConsoleColor.Cyan);
        }
    }
}
