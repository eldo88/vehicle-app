namespace vehicle_app;

public class DisplayMenus
{
    public DisplayMenus()
    {
        string vehicleTypeDataFilePath = @"./data/vehicle-data/vehicle-type-data.csv";

        if (File.Exists(vehicleTypeDataFilePath))
        {
            StreamReader fileReader;
            fileReader = new StreamReader(File.OpenRead(vehicleTypeDataFilePath));

            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();

                if (line != null)
                {
                    var values = line.Split(',');

                    vehicleTypeList.AddRange(values);
                }
            }
        }

        string vehicleMakeDataFilePath = @"./data/vehicle-data/vehicle-make-data.csv";

        if (File.Exists(vehicleMakeDataFilePath))
        {
            StreamReader fileReader;
            fileReader = new StreamReader(File.OpenRead(vehicleMakeDataFilePath));

            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();

                if (line != null)
                {
                    var values = line.Split(',');

                    vehicleMakeTypeList.AddRange(values);
                }
            }
        }

        string toyotaCarDataFilePath = @"./data/vehicle-data/toyota-car-data.csv";
        string toyotaTruckDataFilePath = @"./data/vehicle-data/toyota-truck-data.csv";
        string toyotaSuvDataFilePath = @"./data/vehicle-data/toyota-suv-data.csv";
        string fordCarDataFilePath = @"./data/vehicle-data/ford-car-data.csv";
        string fordTruckDataFilePath = @"./data/vehicle-data/ford-truck-data.csv";
        string fordSuvDataFilePath = @"./data/vehicle-data/ford-suv-data.csv";
        string chevroletCarDataFilePath = @"./data/vehicle-data/chevrolet-car-data.csv";
        string chevroletTruckDataFilePath = @"./data/vehicle-data/chevrolet-truck-data.csv";
        string chevroletSuvDataFilePath = @"./data/vehicle-data/chevrolet-suv-data.csv";

        var modelDataFilePaths = new List<string>
        {
            toyotaCarDataFilePath, toyotaTruckDataFilePath, toyotaSuvDataFilePath, fordCarDataFilePath, 
            fordTruckDataFilePath, fordSuvDataFilePath, chevroletCarDataFilePath, chevroletTruckDataFilePath,
            chevroletSuvDataFilePath
        };

        foreach (var filePath in modelDataFilePaths)
        {
            if (File.Exists(filePath))
            {
                StreamReader fileReader;
                fileReader = new StreamReader(File.OpenRead(filePath));

                while (!fileReader.EndOfStream)
                {
                    var makeVehicleTypeKey = fileReader.ReadLine();
                    var line = fileReader.ReadLine();

                    if (makeVehicleTypeKey != null && line != null)
                    {
                        var values = line.Split(',');

                        var modelList = new List<string>();

                        modelList.AddRange(values);

                        vehicleModelDict.Add(makeVehicleTypeKey, modelList);
                    }
                }
            }
        }

        string engineDataFilePath = @"./data/vehicle-data/engine-data.csv";

        if (File.Exists(engineDataFilePath))
        {
            StreamReader fileReader;
            fileReader = new StreamReader(File.OpenRead(engineDataFilePath));

            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();

                if (line != null)
                {
                    var values = line.Split(',');

                    engineTypeList.AddRange(values);
                }
            }
        }
    }
    Dictionary<string, int> menuChoices = new Dictionary<string, int>();
    List<string> vehicleTypeList = new List<string>();
    List<string> engineTypeList = new List<string>();
    List<string> vehicleMakeTypeList = new List<string>();
    Dictionary<string, List<string>> vehicleModelDict = new Dictionary<string, List<string>>();

    public Dictionary<string, int> GetMenuChoices()
    {
        return menuChoices;
    }

    public string GetEngineTypeByIdx(int idx)
    {
        return engineTypeList[idx];
    }

    public void MainMenu()
    {
        var choice = 0;
        bool displayMenu = true;
       
        do 
        {
            Console.WriteLine("\nThe program will allow you to build a vehicle to take on a trip");
            Console.WriteLine("***************************************************************");
            Console.WriteLine($"\n Please choose from the following options:");

            var itemMenuNum = 1;
            foreach (var item in vehicleTypeList)
            {
                Console.WriteLine($"\t{itemMenuNum}. {item}");
                itemMenuNum++;
            }

            Console.WriteLine($"\t{itemMenuNum}. Exit Program");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            var result = 0;
            var choiceStr = Console.ReadLine();
            var validInput = int.TryParse(choiceStr, out result);


            if (validInput && result >= 1 && result <= 4)
            {
                choice = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
            }
            menuChoices["vehicle"] = choice;

            if (choice == itemMenuNum)
            {
                return;
            }

            var makeChoice = 0;

            if (choice != 0)
            {
                makeChoice = MakeSelectionMenu();
            }

            if (choice != 0 && makeChoice != 4) 
            {
                displayMenu = false;
            }

        } while(displayMenu);
    }

    public int MakeSelectionMenu()
    {
        var makeSelection = 0;
        var displayMenu = true;

        do
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n Please choose the make of your vehicle from the following options:");

            var itemMenuNum = 1;
            foreach (var item in vehicleMakeTypeList)
            {
                Console.WriteLine($"\t{itemMenuNum}. {item}");
                itemMenuNum++;
            }

            Console.WriteLine($"\t{itemMenuNum}. Go Back");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            var result = 0;
            var choiceStr = Console.ReadLine();
            var validInput = int.TryParse(choiceStr, out result);

            if (validInput && result >= 1 && result <= itemMenuNum)
            {
                makeSelection = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
                makeSelection = 0;
            }

            menuChoices["make"] = makeSelection;

            var modelSelection = 0;

            if (makeSelection != itemMenuNum && makeSelection != 0)
            {
                modelSelection = ModelSelectionMenu();
            }

            if (makeSelection != 0 && modelSelection != 99)
            {
                displayMenu = false;
            }

        } while (displayMenu);

        return makeSelection;
    }

    public int ModelSelectionMenu()
    {
        var modelSelection = 0;
        var displayMenu = true;

        do
        {
            var modelKey = vehicleMakeTypeList[menuChoices["make"] - 1] + vehicleTypeList[menuChoices["vehicle"] - 1];

            var modelValues = vehicleModelDict[modelKey];

            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
            
            var itemMenuNum = 1;
            foreach (var item in modelValues)
            {
                Console.WriteLine($"\t{itemMenuNum}. {item}");
                itemMenuNum++;
            }

            Console.WriteLine($"\t{itemMenuNum}. Go back");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            var result = 0;
            var choiceStr = Console.ReadLine();
            var validInput = int.TryParse(choiceStr, out result);

            if (validInput && result >= 1 && result <= itemMenuNum)
            {
                modelSelection = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
                modelSelection = 0;
            }

            menuChoices["model"] = modelSelection;

            if (modelSelection == itemMenuNum)
            {
                modelSelection = 99;
                return modelSelection;
            }

            var engineSelection = 0;

            if (modelSelection != 99 && modelSelection != 0)
            {
                //need to have separate menu for electric vehicles
                var mainMenuChoice = 1;
                engineSelection = EngineSelectionMenu(mainMenuChoice);
            }

            if (modelSelection != 0 && engineSelection != 99)
            {
                displayMenu = false;
            }

        } while (displayMenu);

        return modelSelection;
    }

    public int EngineSelectionMenu(int mainMenuChoice)
    {
        var engineSelection = 0;
        var displayMenu = true;

        do
        {
            if (mainMenuChoice == 1 || mainMenuChoice == 2 || mainMenuChoice == 3)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine($"\n Please choose from the following options for your engine type:");
                var menuItemNum = 1;
                foreach (var item in engineTypeList)
                {
                    Console.WriteLine($"\t{menuItemNum}. {item}");
                    menuItemNum++;
                }

                Console.WriteLine($"\t{menuItemNum}. Go back");
                Console.WriteLine("\n***************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");

                var result = 0;
                var choiceStr = Console.ReadLine();
                var validInput = int.TryParse(choiceStr, out result);

                if (validInput && result >= 1 && result <= menuItemNum)
                {
                    engineSelection = result;
                }
                else
                {
                    Console.WriteLine($"{choiceStr} is not a valid input");
                    engineSelection = 0;
                }

                menuChoices["engine"] = engineSelection;

                if (engineSelection == menuItemNum)
                {
                    engineSelection = 99;
                    return engineSelection;
                }

                var vehicleYear = 0;
                if (engineSelection != 0 && engineSelection != menuItemNum)
                {
                    vehicleYear = VehicleYearSelectionMenu();
                }

                if (engineSelection != 0 && vehicleYear != 1)
                {
                    displayMenu = false;
                }
            }
        } while (displayMenu);

        return engineSelection;
    }

    public int VehicleYearSelectionMenu()
    {
        var vehicleYear = 0;
        var inputStr = "";
        var displayMenu = true;

        do
        {
            Console.WriteLine("***************************************************************");
            Console.Write($"\n Please enter the year of your vehicle, if you want to exit enter 1: ");
            inputStr = Console.ReadLine();
            Console.WriteLine("\n***************************************************************\n");

            var result = 0;
            var validInput = int.TryParse(inputStr, out result);

            if (validInput && result <= 2025)
            {
                vehicleYear = result;
                menuChoices["year"] = vehicleYear;
                displayMenu = false;
            }
            else
            {
                Console.WriteLine("Year entered not valid, please enter another year");
            }

        } while(displayMenu);

        return vehicleYear;
    }
}