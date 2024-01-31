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
            int menuItemNum;
            int menuChoice;
            switch (menuControl)
            {
                case 0:
                    menuChoices.MenuChoicesFromUserInput["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    Console.WriteLine("\nThis program will allow you to build a vehicle");
                    var mainMenuText = "the type";
                    menuItemNum = Menus.ShowMenuItems(VehicleType.VehicleTypeList, mainMenuText);
                    menuChoice = Input.MenuInput(menuItemNum);
                    menuChoices.MenuChoicesFromUserInput["vehicle"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 2:
                    var makeMenuText = "make";
                    menuItemNum = Menus.ShowMenuItems(VehicleMake.VehicleMakeList, makeMenuText);
                    menuChoice = Input.MenuInput(menuItemNum);
                    menuChoices.MenuChoicesFromUserInput["make"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 3:
                    var modelKey = VehicleMake.VehicleMakeList[menuChoices.MenuChoicesFromUserInput["make"] - 1] + VehicleType.VehicleTypeList[menuChoices.MenuChoicesFromUserInput["vehicle"] - 1];
                    var modelValues = VehicleModel.VehicleModelDict[modelKey];
                    var modelMenuText = "model";
                    menuItemNum = Menus.ShowMenuItems(modelValues, modelMenuText);
                    menuChoice = Input.MenuInput(menuItemNum);
                    menuChoices.MenuChoicesFromUserInput["model"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
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