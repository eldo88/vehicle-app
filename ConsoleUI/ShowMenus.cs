namespace vehicle_app;

public class ShowMenus
{
    public ShowMenus()
    {
        MenuChoices = MenuDataFactory.CreateMenuChoices();
        _vehicleColor = MenuDataFactory.CreateVehicleColor();
        _vehicleEngine = MenuDataFactory.CreateVehicleEngine();
        _vehicleMake = MenuDataFactory.CreateVehicleMake();
        _vehicleModel = MenuDataFactory.CreateVehicleModel();
        _vehicleType = MenuDataFactory.CreateVehicleType();
        _mainMenuData = MenuDataFactory.CreateMainMenuData();
    }

    public IMenuChoices MenuChoices;
    IVehicleColor _vehicleColor;
    IVehicleEngine _vehicleEngine;
    IVehicleMake _vehicleMake;
    IVehicleModel _vehicleModel;
    IVehicleType _vehicleType;
    IMainMenuData _mainMenuData;

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
                    VehicleTypeMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleType, ref MenuChoices);
                    break;
                case 2:
                    VehicleMakeMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleMake, ref MenuChoices);
                    break;
                case 3:
                    VehicleModelMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleModel, ref _vehicleMake, ref _vehicleType, ref MenuChoices);
                    break;
                case 4:
                    VehicleEngineMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleEngine, ref MenuChoices);
                    break;
                case 5:
                    VehicleColorMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleColor, ref MenuChoices);
                    break;
                case 6:
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
        Dictionary<string, string> MenuChoiceData = [];

        MenuChoiceData.Add("type", _vehicleType.GetVehicleTypeByIdx(MenuChoices.MenuChoicesFromUserInput["vehicle"] - 1));
        MenuChoiceData.Add("make", _vehicleMake.GetVehicleMakeByIdx(MenuChoices.MenuChoicesFromUserInput["make"] - 1));
        var vehicleMakeKey = MenuChoiceData["make"] + MenuChoiceData["type"];
        MenuChoiceData.Add("model", _vehicleModel.GetVehicleModelByIdx(vehicleMakeKey, MenuChoices.MenuChoicesFromUserInput["model"] - 1));
        MenuChoiceData.Add("engine", _vehicleEngine.GetEngineTypeByIdx(MenuChoices.MenuChoicesFromUserInput["engine"] - 1));
        MenuChoiceData.Add("color", _vehicleColor.GetVehicleColorByIdx(MenuChoices.MenuChoicesFromUserInput["color"] - 1));
        MenuChoiceData.Add("year", MenuChoices.MenuChoicesFromUserInput["year"].ToString());
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
                    MainMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _mainMenuData, ref MenuChoices);
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