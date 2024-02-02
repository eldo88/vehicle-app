namespace vehicle_app;

public class ShowMenus
{
    public ShowMenus(VehicleColor vehicleColor, VehicleEngine vehicleEngine, VehicleMake vehicleMake, VehicleModel vehicleModel, VehicleType vehicleType)
    {
        VehicleColor = vehicleColor;
        VehicleEngine = vehicleEngine;
        VehicleMake = vehicleMake;
        VehicleModel = vehicleModel;
        VehicleType = vehicleType;
    }

    public MenuChoices menuChoices = new();
    VehicleColor VehicleColor;
    VehicleEngine VehicleEngine;
    VehicleMake VehicleMake;
    VehicleModel VehicleModel;
    VehicleType VehicleType;

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
                    menuChoices.MenuChoicesFromUserInput["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    VehicleTypeMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref VehicleType, ref menuChoices);
                    break;
                case 2:
                    VehicleMakeMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref VehicleMake, ref menuChoices);
                    break;
                case 3:
                    VehicleModelMenu.Show(ref menuItemNum, ref menuChoice, ref menuControl, ref VehicleModel, ref VehicleMake, ref VehicleType, ref menuChoices);
                    break;
                case 4:
                    var engineMenuText = "engine";
                    menuItemNum = Menus.ShowMenuItems(VehicleEngine.EngineList, engineMenuText);
                    menuChoice = Input.MenuInput(menuItemNum);
                    menuChoices.MenuChoicesFromUserInput["engine"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 5:
                    var colorMenuText = "color";
                    menuItemNum = Menus.ShowMenuItems(VehicleColor.ColorList, colorMenuText);
                    menuChoice = Input.MenuInput(menuItemNum);
                    menuChoices.MenuChoicesFromUserInput["color"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 6:
                    var year = Menus.VehicleYearSelectionMenu();
                    menuChoices.MenuChoicesFromUserInput["year"] = year;

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