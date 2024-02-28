namespace vehicle_app;

public class VehicleColorMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, VehicleColor vehicleColor, MenuChoices menuChoices)
    {
        var colorMenuText = "the color";
        menuItemNum = MenuActions.ShowMenuItems(vehicleColor.ColorList, colorMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["color"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
