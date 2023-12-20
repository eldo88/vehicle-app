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

                    vehicleMakeList.AddRange(values);
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
    readonly Dictionary<string, int> menuChoices = [];
    readonly List<string> vehicleTypeList = [];
    readonly List<string> engineTypeList = [];
    readonly List<string> vehicleMakeList = [];
    readonly Dictionary<string, List<string>> vehicleModelDict = [];

    public Dictionary<string, int> GetMenuChoices()
    {
        return menuChoices;
    }

    public string GetVehicleTypeByIdx(int idx)
    {
        return vehicleTypeList[idx];
    }

    public string GetVehicleMakeByIdx(int idx)
    {
        return vehicleMakeList[idx];
    }

    public string GetVehicleModelByIdx(string vehicleMakeKey, int idx)
    {
        var modelList = vehicleModelDict[vehicleMakeKey];

        return modelList[idx];
    }

    public string GetEngineTypeByIdx(int idx)
    {
        return engineTypeList[idx];
    }

    public void MainMenu()
    {
        var menuChoice = 0;
        bool displayMenu = true;
       
        do 
        {
            Console.WriteLine("\nThe program will allow you to build a vehicle to take on a trip");
            Console.WriteLine("***************************************************************");
            Console.WriteLine($"\n Please choose from the following options:");

            var menuItemNum = 1;
            foreach (var item in vehicleTypeList)
            {
                Console.WriteLine($"\t{menuItemNum}. {item}");
                menuItemNum++;
            }

            Console.WriteLine($"\t{menuItemNum}. Exit Program");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            menuChoice = MenuInput(menuItemNum);
            
            menuChoices["vehicle"] = menuChoice;

            if (menuChoice == menuItemNum)
            {   
                menuChoices.Add("vehicle", 99);
                return;
            }

            var makeChoice = 0;

            if (menuChoice != 0)
            {
                makeChoice = MakeSelectionMenu();
            }

            if (menuChoice != 0 && makeChoice != 4) 
            {
                displayMenu = false;
            }
            else
            {
                menuChoices.Remove("vehicle");
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

            var menuItemNum = 1;
            foreach (var item in vehicleMakeList)
            {
                Console.WriteLine($"\t{menuItemNum}. {item}");
                menuItemNum++;
            }

            Console.WriteLine($"\t{menuItemNum}. Go Back");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            makeSelection = MenuInput(menuItemNum);

            menuChoices["make"] = makeSelection;

            var modelSelection = 0;

            if (makeSelection != menuItemNum && makeSelection != 0)
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
            var modelKey = vehicleMakeList[menuChoices["make"] - 1] + vehicleTypeList[menuChoices["vehicle"] - 1];

            var modelValues = vehicleModelDict[modelKey];

            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
            
            var menuItemNum = 1;
            foreach (var item in modelValues)
            {
                Console.WriteLine($"\t{menuItemNum}. {item}");
                menuItemNum++;
            }

            Console.WriteLine($"\t{menuItemNum}. Go back");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            modelSelection = MenuInput(menuItemNum);

            menuChoices["model"] = modelSelection;

            if (modelSelection == menuItemNum)
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

                engineSelection = MenuInput(menuItemNum);

                if (engineSelection == menuItemNum)
                {
                    engineSelection = 99;
                    return engineSelection;
                }

                menuChoices["engine"] = engineSelection;

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
        var displayMenu = true;

        do
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine($"\nPlease enter the year of your vehicle, if you want to go back enter 1 ");

            var inputStr = Console.ReadLine();
            var validInput = int.TryParse(inputStr, out int result);

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

    public static bool TakeVehicleOnDrive(string vehicleMake, string vehicleModel)
    {
        var drive = false;
        var displayMenu = true;
        do
        {
            Console.WriteLine($"Would you like to take your {vehicleMake} {vehicleModel} on a drive? (enter Y/N)");
        
            var choice = Console.ReadLine();

            var validInput = char.TryParse(choice, out char result);

            if (validInput)
            {
                if (char.ToLower(result) == 'y')
                {
                    drive = true;
                    displayMenu = false;
                }
                else
                {
                    Console.WriteLine($"{choice} is not a valid input");
                }
        }
        } while(displayMenu);

        return drive;
    }

    public static int DriveLength()
    {
        Console.WriteLine("\nHow many miles are you driving?");

        var driveLengthInMiles = Console.ReadLine();
        var validInput = int.TryParse(driveLengthInMiles, out int result);

        if (validInput && result > 0)
        {
            return result;
        }
        else
        {
            Console.WriteLine("Default drive length of 20 miles is being used.");
            result = 20;
        }

        return result;
    }

    private static int MenuInput(int menuItemNum)
    {
        var choiceStr = Console.ReadLine();
        var validInput = int.TryParse(choiceStr, out int result);

        if (validInput && result >= 1 && result <= menuItemNum)
        {
            return result;
        }
        else
        {
            Console.WriteLine($"{choiceStr} is not a valid input");
            result = 0;
        }

        return result;
    }
}