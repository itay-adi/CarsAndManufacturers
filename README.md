# CarsAndManufacturers

Using a menu, we present data from CSV files which contains data about Cars and manufacturers.
The user can choose:
* List of all manufacturers
* List of all vehicles of a specific manufacturer
* Number of cars per MFG
* Best cars of each MFG per countery
* List General highlights

The project above demonstrate:
1. working with database in the form of two csv files: Cars.csv and Manufacturers.csv
2. The work and implemintation of Extension Methods in C#:



The project contains the following:
1. [Data:](https://github.com/itay-adi/CarsAndManufacturers/tree/main/CarsAndManufacturers/CarsAndManufacturers/Data) 
	A folder containing the two CSV files
	
2. [Entities:](https://github.com/itay-adi/CarsAndManufacturers/tree/main/CarsAndManufacturers/CarsAndManufacturers/Entities)
	A folder containing the entities: Car and Manufacturer with getters and setters
	
3. [Logic:](https://github.com/itay-adi/CarsAndManufacturers/tree/main/CarsAndManufacturers/CarsAndManufacturers/Logic)
	A folder containing 3 classes:
		* API.cs- a public static Class which contains the core functions
		* ConsoleHelper.cs- a public static Class which contains the differnet print methods
		* DataReader.cs- a public static Class which contains a methods which turn strings to entities
		
4. [Program.cs](https://github.com/itay-adi/CarsAndManufacturers/tree/main/CarsAndManufacturers/CarsAndManufacturers)
	A file which contains the main and wrapper functions
