namespace vehicle_app;

public class ShowMenus
{
    public ShowMenus()
    {
        _menuChoices = MenuDataFactory.CreateMenuChoices();
        _vehicleColor = MenuDataFactory.CreateVehicleColor();
        _vehicleEngine = MenuDataFactory.CreateVehicleEngine();
        _vehicleMake = MenuDataFactory.CreateVehicleMake();
        _vehicleModel = MenuDataFactory.CreateVehicleModel();
        _vehicleType = MenuDataFactory.CreateVehicleType();
        _mainMenuData = MenuDataFactory.CreateMainMenuData();
    }

    public IMenuChoices _menuChoices;
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
                    _menuChoices.MenuChoicesFromUserInput["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    VehicleTypeMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleType, ref _menuChoices);
                    break;
                case 2:
                    VehicleMakeMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleMake, ref _menuChoices);
                    break;
                case 3:
                    VehicleModelMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleModel, ref _vehicleMake, ref _vehicleType, ref _menuChoices);
                    break;
                case 4:
                    VehicleEngineMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleEngine, ref _menuChoices);
                    break;
                case 5:
                    VehicleColorMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _vehicleColor, ref _menuChoices);
                    break;
                case 6:
                    var year = VehicleYearMenu.Show();
                    _menuChoices.MenuChoicesFromUserInput["year"] = year;

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

        MenuChoiceData.Add("type", _vehicleType.GetVehicleTypeByIdx(_menuChoices.MenuChoicesFromUserInput["vehicle"] - 1));
        MenuChoiceData.Add("make", _vehicleMake.GetVehicleMakeByIdx(_menuChoices.MenuChoicesFromUserInput["make"] - 1));
        var vehicleMakeKey = MenuChoiceData["make"] + MenuChoiceData["type"];
        MenuChoiceData.Add("model", _vehicleModel.GetVehicleModelByIdx(vehicleMakeKey, _menuChoices.MenuChoicesFromUserInput["model"] - 1));
        MenuChoiceData.Add("engine", _vehicleEngine.GetEngineTypeByIdx(_menuChoices.MenuChoicesFromUserInput["engine"] - 1));
        MenuChoiceData.Add("color", _vehicleColor.GetVehicleColorByIdx(_menuChoices.MenuChoicesFromUserInput["color"] - 1));
        MenuChoiceData.Add("year", _menuChoices.MenuChoicesFromUserInput["year"].ToString());
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
                    _menuChoices.MenuChoicesFromUserInput["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    MainMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref _mainMenuData, ref _menuChoices);
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