namespace vehicle_app;

public class VehicleMakeMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref  VehicleMake vehicleMake, ref MenuChoices menuChoices)
    {
        var makeMenuText = "make";
        menuItemNum = Menus.ShowMenuItems(vehicleMake.VehicleMakeList, makeMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["make"] = menuChoice;
        menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
