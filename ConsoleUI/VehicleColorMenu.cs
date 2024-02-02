﻿namespace vehicle_app;

public class VehicleColorMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref  VehicleColor vehicleColor, ref MenuChoices menuChoices)
    {
        var colorMenuText = "color";
        menuItemNum = Menus.ShowMenuItems(vehicleColor.ColorList, colorMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["color"] = menuChoice;
        menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
