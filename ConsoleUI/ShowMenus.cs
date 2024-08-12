namespace vehicle_app;

public class ShowMenus
{
    public readonly MenuChoices MenuChoices = new();
    private readonly VehicleColor _vehicleColor = new();
    private readonly VehicleEngine _vehicleEngine = new();
    private readonly VehicleMake _vehicleMake = new();
    private readonly VehicleModel _vehicleModel = new();
    private readonly VehicleType _vehicleType = new();
    private readonly MainMenuData _mainMenuData = new();

    private void DisplayBuildVehicleMenus()
    {
        var menuControl = 1;
        var displayMenu = true;

        do
        {
            var menuItemNum = 0;
            var menuChoice = 0;
            switch (menuControl)
            {
                case 0:
                    MenuChoices.MenuChoicesFromUserInput["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    var typeMenu = new MainMenu(_vehicleType.VehicleTypeList, "Select the type of your vehicle");
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
                    var makeMenu = new MainMenu(_vehicleMake.VehicleMakeList, "Select the make of your vehicle");
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
                    var modelMenu = new MainMenu(modelValues, "Select the model of your vehicle");
                    menuItemNum = modelValues.Count;
                    menuChoice = modelMenu.Run();
                    modelValues.RemoveAt(menuItemNum - 1);
                    MenuChoices.MenuChoicesFromUserInput["model"] = menuChoice;
                    Console.WriteLine($"{menuItemNum} {menuChoice}");
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice + 1);
                    break;
                case 4:
                    var engineMenu = new MainMenu(_vehicleEngine.EngineList, "Select the engine/motor for your vehicle");
                    menuItemNum = _vehicleEngine.EngineList.Count;
                    menuChoice = engineMenu.Run();
                    _vehicleEngine.EngineList.RemoveAt(menuItemNum - 1);
                    MenuChoices.MenuChoicesFromUserInput["engine"] = menuChoice;
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice + 1);
                    break;
                case 5:
                    var colorMenu = new MainMenu(_vehicleColor.ColorList, "Select the paint color for your vehicle");
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
            }

        } while (displayMenu);
    }

    public Dictionary<string, string> GetMenuChoiceData()
    {
        Dictionary<string, string> menuChoiceData = new();
        
        menuChoiceData.Add("type", _vehicleType.GetVehicleTypeByIdx(MenuChoices.MenuChoicesFromUserInput["vehicle"]));
        menuChoiceData.Add("make", _vehicleMake.GetVehicleMakeByIdx(MenuChoices.MenuChoicesFromUserInput["make"]));
        var vehicleMakeKey = menuChoiceData["make"] + menuChoiceData["type"];
        menuChoiceData.Add("model", _vehicleModel.GetVehicleModelByIdx(vehicleMakeKey, MenuChoices.MenuChoicesFromUserInput["model"]));
        menuChoiceData.Add("engine", _vehicleEngine.GetEngineTypeByIdx(MenuChoices.MenuChoicesFromUserInput["engine"]));
        menuChoiceData.Add("color", _vehicleColor.GetVehicleColorByIdx(MenuChoices.MenuChoicesFromUserInput["color"]));
        menuChoiceData.Add("year", MenuChoices.MenuChoicesFromUserInput["year"].ToString());
        menuChoiceData.Add("mileage", MenuChoices.MenuChoicesFromUserInput["mileage"].ToString());
        // var MPG = 25; //hardcoded for now
        // var occupantCapacity = 4; // hardcoded for now
        return menuChoiceData;
    }

    public void DisplayMainMenu()
    {
        var menuControl = 1;
        var displayMenu = true;
        do
        {
            switch (menuControl)
            {
                case 0:
                    MenuChoices.MenuChoicesFromUserInput["vehicle"] = 99; // TODO: create key value pair for exiting
                    displayMenu = false;
                    break;
                case 1:
                    var mainMenu = new MainMenu(_mainMenuData.MainMenuDataList,
                        "Please choose from the following options");
                    var menuItemNum = _mainMenuData.MainMenuDataList.Count;
                    var menuChoice = mainMenu.Run();
                    _mainMenuData.MainMenuDataList.RemoveAt(menuItemNum - 1);
                    menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    switch (menuChoice)
                    {
                        case 0:
                            CreatedVehicleSearchScreen.Show();
                            menuControl = 1;
                            break;
                        case 2:
                            menuControl = 0;
                            break;
                    }
                    break;
                case 2:
                    DisplayBuildVehicleMenus();
                    displayMenu = false;
                    break;
            }

        } while (displayMenu);
    }
}