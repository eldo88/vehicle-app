namespace vehicle_app;

public class DisplayMenus
{
    public DisplayMenus(){}
    readonly Dictionary<string, int> menuChoices = [];
    List<string> vehicleTypeList = [];
    List<string> engineTypeList = [];
    List<string> vehicleMakeList = [];
    List<string> vehicleColorList = [];
    readonly Dictionary<string, List<string>> vehicleModelDict = [];

    private void ReadDataFromFile(string filePath, List<string> targetList)
    {
        if (File.Exists(filePath))
        {
            using StreamReader fileReader = new StreamReader(File.OpenRead(filePath));
            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(',');
                    targetList.AddRange(values);
                }
            }
        }
    }

    private void ReadModelData(string filePath, Dictionary<string, List<string>> targetDict)
    {
        if (File.Exists(filePath))
        {
            using StreamReader fileReader = new StreamReader(File.OpenRead(filePath));
            while (!fileReader.EndOfStream)
            {
                var makeVehicleTypeKey = fileReader.ReadLine();
                var line = fileReader.ReadLine();

                if (makeVehicleTypeKey != null && line != null)
                {
                    var values = line.Split(',');
                    var modelList = new List<string>(values);
                    targetDict.Add(makeVehicleTypeKey, modelList);
                }
            }
        }
    }

    // private void LoadHardCodedData()
    // {
    //     List<string> chevyCar = ["Corvette","Camaro","Bolt"];
    //     vehicleModelDict.Add("ChevroletCar", chevyCar);

    //     List<string> chevyTruck = ["Silverado 1500","Silverado 2500","Colorado"];
    //     vehicleModelDict.Add("ChevroletTruck", chevyTruck);

    //     List<string> chevySuv = ["Tahoe","Suburban","Blazer"];
    //     vehicleModelDict.Add("ChevroletSUV", chevySuv);

    //     List<string> toyotaCar = ["Corrolla","Camry","Prius"];
    //     vehicleModelDict.Add("ToyotaCar", toyotaCar);

    //     List<string> toyotaTruck = ["Tacoma","Tundra"];
    //     vehicleModelDict.Add("ToyotaTruck", toyotaTruck);

    //     List<string> toyotaSuv = ["4Runner","Land Cruiser","Sequoia"];
    //     vehicleModelDict.Add("ToyotaSUV", toyotaSuv);

    //     List<string> fordCar = ["Focus","Escort","Fusion"];
    //     vehicleModelDict.Add("FordCar", fordCar);

    //     List<string> fordTruck = ["F-150","F-250","F-350","Ranger","Maverick"];
    //     vehicleModelDict.Add("FordTruck", fordTruck);

    //     List<string> fordSuv = ["Explorer","Bronco 2 Door","Bronco 4 Door","Escape"];
    //     vehicleModelDict.Add("FordSUV", fordSuv);


    //     vehicleTypeList = ["Car","Truck","SUV"];

    //     engineTypeList = ["V4","V6","V8","V6 Hybrid","Electric","Turbo Diesel"];

    //     vehicleMakeList = ["Toyota","Ford","Chevrolet"];

    //     vehicleColorList = ["White","Black","Silver","Blue","Red","Grey"];
    // }

    private void LoadData()
    {
        string[] modelDataFilePaths = {
            "./data/vehicle-data/toyota-car-data.csv",
            "./data/vehicle-data/toyota-truck-data.csv",
            "./data/vehicle-data/toyota-suv-data.csv",
            "./data/vehicle-data/ford-car-data.csv",
            "./data/vehicle-data/ford-truck-data.csv",
            "./data/vehicle-data/ford-suv-data.csv",
            "./data/vehicle-data/chevrolet-car-data.csv",
            "./data/vehicle-data/chevrolet-truck-data.csv",
            "./data/vehicle-data/chevrolet-suv-data.csv"
        };

        foreach (var filePath in modelDataFilePaths)
        {
            ReadModelData(filePath, vehicleModelDict);
        }

        ReadDataFromFile("./data/vehicle-data/vehicle-type-data.csv", vehicleTypeList);
        ReadDataFromFile("./data/vehicle-data/vehicle-make-data.csv", vehicleMakeList);
        ReadDataFromFile("./data/vehicle-data/engine-data.csv", engineTypeList);
        ReadDataFromFile("./data/vehicle-data/vehicle-color-data.csv", vehicleColorList);
    }

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

    public string GetVehicleColorByIdx(int idx)
    {
        return vehicleColorList[idx];
    }

    public void MainMenu()
    {
        LoadData();
        // LoadHardCodedData();

        var menuChoice = 0;
        bool displayMenu = true;
       
        do 
        {
            Console.WriteLine("\nThis program will allow you to build a vehicle");

            const string menuText = "the type";
            var menuItemNum = ShowMenuItems(vehicleTypeList, menuText);

            menuChoice = MenuInput(menuItemNum);
            
            menuChoices["vehicle"] = menuChoice;

            if (menuChoice == menuItemNum)
            {   
                menuChoices["vehicle"] = 99;
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

        } while(displayMenu);
    }

    private int MakeSelectionMenu()
    {
        var makeSelection = 0;
        var displayMenu = true;

        do
        {
            const string menuText = "make";
            var menuItemNum = ShowMenuItems(vehicleMakeList, menuText);

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

    private int ModelSelectionMenu()
    {
        var modelSelection = 0;
        var displayMenu = true;

        do
        {
            var modelKey = vehicleMakeList[menuChoices["make"] - 1] + vehicleTypeList[menuChoices["vehicle"] - 1];

            var modelValues = vehicleModelDict[modelKey];

            const string menuText = "model";
            var menuItemNum = ShowMenuItems(modelValues, menuText);

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
                engineSelection = EngineSelectionMenu();
            }

            if (modelSelection != 0 && engineSelection != 99)
            {
                displayMenu = false;
            }

        } while (displayMenu);

        return modelSelection;
    }

    private int EngineSelectionMenu()
    {
        var engineSelection = 0;
        var displayMenu = true;

        do
        {
            const string menuText = "engine";
            var menuItemNum = ShowMenuItems(engineTypeList, menuText);

            engineSelection = MenuInput(menuItemNum);

            if (engineSelection == menuItemNum)
            {
                engineSelection = 99;
                return engineSelection;
            }

            menuChoices["engine"] = engineSelection;

            var vehicleColor = 0;
            if (engineSelection != 0 && engineSelection != menuItemNum)
            {
                vehicleColor = VehicleColorSelectionMenu();
            }

            if (engineSelection != 0 && vehicleColor != 99)
            {
                displayMenu = false;
            }
        } while (displayMenu);

        return engineSelection;
    }

    private int VehicleColorSelectionMenu()
    {
        var colorSelection = 0;
        var displayMenu = true;

        do
        {
            const string menuText = "color";
            var menuItemNum = ShowMenuItems(vehicleColorList, menuText);

            colorSelection = MenuInput(menuItemNum);

            if (colorSelection == menuItemNum)
            {
                colorSelection = 99;
                return colorSelection;
            }

            menuChoices["color"] = colorSelection;

            var vehicleYear = 0;
            if (colorSelection != 0 && colorSelection != menuItemNum)
            {
                vehicleYear = VehicleYearSelectionMenu();
            }

            if (colorSelection != 0 && vehicleYear != 1)
            {
                displayMenu = false;
            }
        } while (displayMenu);

        return colorSelection;
    }

    private int VehicleYearSelectionMenu()
    {
        var vehicleYear = 0;
        var displayMenu = true;

        do
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine($"\nPlease enter the year of your vehicle (must be newer than 1990), if you want to go back enter 1 ");

            var inputStr = Console.ReadLine();
            var validInput = int.TryParse(inputStr, out int result);

            if (validInput && result >= 1990 && result <= 2025)
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

    public static bool TakeVehicleOnDriveMenu(string vehicleMake, string vehicleModel)
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
                else if (char.ToLower(result) == 'n')
                {
                    drive = false;
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

    public static int DriveLengthMenu()
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

    private int ShowMenuItems(List<string> menuItems, string menuText)
    {
        Console.WriteLine("***************************************************************");
        Console.WriteLine($"\n Please choose the {menuText} of your vehicle from the following options:");

        var menuItemNum = 1;
        foreach (var item in menuItems)
        {
            Console.WriteLine($"\t{menuItemNum}. {item}");
            menuItemNum++;
        }

        Console.WriteLine($"\t{menuItemNum}. Go Back");
        Console.WriteLine("\n****************************************************************\n");
        Console.Write("Enter an integer value of your choice: ");

        return menuItemNum;
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