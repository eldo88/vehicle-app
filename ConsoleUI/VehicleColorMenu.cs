namespace vehicle_app;

public class VehicleColorMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref  IVehicleColor vehicleColor, ref IMenuChoices menuChoices)
    {
        var colorMenuText = "color";
        menuItemNum = MenuActions.ShowMenuItems(vehicleColor.ColorList, colorMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["color"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
