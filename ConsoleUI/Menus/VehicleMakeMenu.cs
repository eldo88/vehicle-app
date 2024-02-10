namespace vehicle_app;

public class VehicleMakeMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, VehicleMake vehicleMake, MenuChoices menuChoices)
    {
        var makeMenuText = "make";
        menuItemNum = MenuActions.ShowMenuItems(vehicleMake.VehicleMakeList, makeMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["make"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
