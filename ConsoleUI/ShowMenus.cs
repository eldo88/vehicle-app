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
    }

    public IMenuChoices _menuChoices;
    IVehicleColor _vehicleColor;
    IVehicleEngine _vehicleEngine;
    IVehicleMake _vehicleMake;
    IVehicleModel _vehicleModel;
    IVehicleType _vehicleType;

    public void DisplayMenus()
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
}