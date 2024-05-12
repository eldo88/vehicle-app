namespace vehicle_app;

public class ShowMenus
{
    public ShowMenus()
    {
        MenuChoices = new();
        _vehicleColor = new();
        _vehicleEngine = new();
        _vehicleMake = new();
        _vehicleModel = new();
        _vehicleType = new();
        _mainMenuData = new();
    }

    public MenuChoices MenuChoices;
    readonly VehicleColor _vehicleColor;
    readonly VehicleEngine _vehicleEngine;
    readonly VehicleMake _vehicleMake;
    readonly VehicleModel _vehicleModel;
    readonly VehicleType _vehicleType;
    readonly MainMenuData _mainMenuData;

    public void DisplayBuildVehicleMenus()
    {
        var menuControl = 1;
        var displayMenu = true;

        do
        {
            int menuItemNum = 0;
            int menuChoice = 0;
            switch (menuControl)
            {
                case 0:
                    MenuChoices.MenuChoicesFromUserInput["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    MainMenu typeMenu = new MainMenu(_vehicleType.VehicleTypeList, "Select the type of your vehicle");
                    //PrintMessages printMessages = StandardUiMessages.BuildAVehicleBanner; 
                    //printMessages += StandardUiMessages.MenuSeparator;
                    menuItemNum = _vehicleType.VehicleTypeList.Count;
                    menuChoice = typeMenu.Run();
                    _vehicleType.VehicleTypeList.RemoveAt(menuItemNum - 1);
                    MenuChoices.MenuChoicesFromUserInput["vehicle"] = menuChoice;
                    Console.WriteLine($"{menuItemNum} {menuChoice}");
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice + 1);
                    break;
                case 2:
                    MainMenu makeMenu = new MainMenu(_vehicleMake.VehicleMakeList, "Select the make of your vehicle");
                    menuItemNum = _vehicleMake.VehicleMakeList.Count;
                    menuChoice = makeMenu.Run();
                    _vehicleMake.VehicleMakeList.RemoveAt(menuItemNum - 1);
                    MenuChoices.MenuChoicesFromUserInput["make"] = menuChoice;
                    Console.Write($"{menuItemNum} {menuChoice}");
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice + 1);
                    break;
                case 3:
                    var modelKey = _vehicleMake.VehicleMakeList[MenuChoices.MenuChoicesFromUserInput["make"]] + _vehicleType.VehicleTypeList[MenuChoices.MenuChoicesFromUserInput["vehicle"]];
                    var modelValues = _vehicleModel.VehicleModelDict[modelKey];
                    MainMenu modelMenu = new MainMenu(modelValues, "Select the model of your vehicle");
                    menuItemNum = modelValues.Count;
                    menuChoice = modelMenu.Run();
                    modelValues.RemoveAt(menuItemNum - 1);
                    MenuChoices.MenuChoicesFromUserInput["model"] = menuChoice;
                    Console.WriteLine($"{menuItemNum} {menuChoice}");
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice + 1);
                    break;
                case 4:
                    MainMenu engineMenu = new MainMenu(_vehicleEngine.EngineList, "Select the engine/motor for your vehicle");
                    menuItemNum = _vehicleEngine.EngineList.Count;
                    menuChoice = engineMenu.Run();
                    _vehicleEngine.EngineList.RemoveAt(menuItemNum - 1);
                    MenuChoices.MenuChoicesFromUserInput["engine"] = menuChoice;
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice + 1);
                    break;
                case 5:
                    MainMenu colorMenu = new MainMenu(_vehicleColor.ColorList, "Select the paint color for your vehicle");
                    menuItemNum = _vehicleColor.ColorList.Count;
                    menuChoice = colorMenu.Run();
                    _vehicleColor.ColorList.RemoveAt(menuItemNum - 1);
                    MenuChoices.MenuChoicesFromUserInput["color"] = menuChoice;
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice + 1);
                    break;
                case 6:
                    VehicleMileageMenu.Show(ref menuControl, MenuChoices);
                    break;
                case 7:
                    var year = VehicleYearMenu.Show();
                    MenuChoices.MenuChoicesFromUserInput["year"] = year;

                    if (year == 1)
                    {
                        menuControl -= 1;
                    }
                    else
                    {
                        displayMenu = false;
                    }

                    break;
                default:
                    break;
            }

        } while (displayMenu);
    }

    public Dictionary<string, string> GetMenuChoiceData()
    {
        Dictionary<string, string> MenuChoiceData = new();

        MenuChoiceData.Add("type", _vehicleType.GetVehicleTypeByIdx(MenuChoices.MenuChoicesFromUserInput["vehicle"]));
        MenuChoiceData.Add("make", _vehicleMake.GetVehicleMakeByIdx(MenuChoices.MenuChoicesFromUserInput["make"]));
        var vehicleMakeKey = MenuChoiceData["make"] + MenuChoiceData["type"];
        MenuChoiceData.Add("model", _vehicleModel.GetVehicleModelByIdx(vehicleMakeKey, MenuChoices.MenuChoicesFromUserInput["model"]));
        MenuChoiceData.Add("engine", _vehicleEngine.GetEngineTypeByIdx(MenuChoices.MenuChoicesFromUserInput["engine"]));
        MenuChoiceData.Add("color", _vehicleColor.GetVehicleColorByIdx(MenuChoices.MenuChoicesFromUserInput["color"]));
        MenuChoiceData.Add("year", MenuChoices.MenuChoicesFromUserInput["year"].ToString());
        MenuChoiceData.Add("mileage", MenuChoices.MenuChoicesFromUserInput["mileage"].ToString());
        // var MPG = 25; //hardcoded for now
        // var occupantCapacity = 4; // hardcoded for now
        return MenuChoiceData;
    }

    public void DisplayMainMenu()
    {
        var menuControl = 1;
        var displayMenu = true;
        do
        {
            int menuItemNum = 0;
            int menuChoice = 0;
            switch (menuControl)
            {
                case 0:
                    MenuChoices.MenuChoicesFromUserInput["vehicle"] = 99; // TODO: create key value pair for exiting
                    displayMenu = false;
                    break;
                case 1:
                    MainMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, _mainMenuData, MenuChoices);
                    if (menuChoice == 1)
                    {
                        CreatedVehicleSearchScreen.Show();
                        menuControl = 1;
                    }
                    break;
                case 2:
                    DisplayBuildVehicleMenus();
                    displayMenu = false;
                    break;
                default:
                    break;
            }

        } while (displayMenu);
    }
}