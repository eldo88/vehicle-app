namespace vehicle_app;

public class ShowMenus
{
    Menus menus = new();

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
                    menus.menuChoices["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    Console.WriteLine("\nThis program will allow you to build a vehicle");
                    var mainMenuText = "the type";
                    menuItemNum = Menus.ShowMenuItems(menus.vehicleTypeList, mainMenuText);
                    menuChoice = Menus.MenuInput(menuItemNum);
                    menus.menuChoices["vehicle"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 2:
                    var makeMenuText = "make";
                    menuItemNum = Menus.ShowMenuItems(menus.vehicleMakeList, makeMenuText);
                    menuChoice = Menus.MenuInput(menuItemNum);
                    menus.menuChoices["make"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 3:
                    var modelKey = menus.vehicleMakeList[menus.menuChoices["make"] - 1] + menus.vehicleTypeList[menus.menuChoices["vehicle"] - 1];
                    var modelValues = menus.vehicleModelDict[modelKey];
                    var modelMenuText = "model";
                    menuItemNum = Menus.ShowMenuItems(modelValues, modelMenuText);
                    menuChoice = Menus.MenuInput(menuItemNum);
                    menus.menuChoices["model"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 4:
                    var engineMenuText = "engine";
                    menuItemNum = Menus.ShowMenuItems(menus.engineTypeList, engineMenuText);
                    menuChoice = Menus.MenuInput(menuItemNum);
                    menus.menuChoices["engine"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 5:
                    var colorMenuText = "color";
                    menuItemNum = Menus.ShowMenuItems(menus.vehicleColorList, colorMenuText);
                    menuChoice = Menus.MenuInput(menuItemNum);
                    menus.menuChoices["color"] = menuChoice;
                    menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 6:
                    var year = menus.VehicleYearSelectionMenu();

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