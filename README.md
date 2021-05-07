# Cars And Manufacturers

Using a menu, we present data from CSV files which contains data about Cars and manufacturers.
The user can choose:
* List of all manufacturers
* List of all vehicles of a specific manufacturer
* Number of cars per MFG
* Best cars of each MFG per countery
* List General highlights

The project above demonstrate:
* working with database in the form of two csv files: Cars.csv and Manufacturers.csv
* The work and implemintation of Extension Methods in C#:



The project contains the following:
* [Data:](https://github.com/itay-adi/CarsAndManufacturers/tree/main/CarsAndManufacturers/CarsAndManufacturers/Data) 
	A folder containing the two CSV files
	
* [Entities:](https://github.com/itay-adi/CarsAndManufacturers/tree/main/CarsAndManufacturers/CarsAndManufacturers/Entities)
	A folder containing the entities: Car and Manufacturer with getters and setters
	
* [Logic:](https://github.com/itay-adi/CarsAndManufacturers/tree/main/CarsAndManufacturers/CarsAndManufacturers/Logic)
	A folder containing 3 classes:
	* API.cs- a public static Class which contains the core functions(https://github.com/itay-adi/CarsAndManufacturers/blob/main/CarsAndManufacturers/CarsAndManufacturers/Logic/API.cs)
	* ConsoleHelper.cs- a public static Class which contains the differnet print methods(https://github.com/itay-adi/CarsAndManufacturers/blob/main/CarsAndManufacturers/CarsAndManufacturers/Logic/ConsoleHelper.cs)
	* DataReader.cs- a public static Class which contains a methods which turn strings to entities(https://github.com/itay-adi/CarsAndManufacturers/blob/main/CarsAndManufacturers/CarsAndManufacturers/Logic/DataReader.cs)
		
* [Program.cs](https://github.com/itay-adi/CarsAndManufacturers/blob/main/CarsAndManufacturers/CarsAndManufacturers/Program.cs)
	A file which contains the main and wrapper functions
