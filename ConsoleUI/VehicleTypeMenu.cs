namespace vehicle_app;

public class VehicleTypeMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref VehicleType vehicleType, ref MenuChoices menuChoices)
    {
        Console.WriteLine("\nThis program will allow you to build a vehicle");
        var mainMenuText = "the type";
        menuItemNum = Menus.ShowMenuItems(vehicleType.VehicleTypeList, mainMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["vehicle"] = menuChoice;
        menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
