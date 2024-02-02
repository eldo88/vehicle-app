namespace vehicle_app;

public class VehicleEngineMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref  VehicleEngine vehicleEngine, ref MenuChoices menuChoices)
    {
        var engineMenuText = "engine";
        menuItemNum = Menus.ShowMenuItems(vehicleEngine.EngineList, engineMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["engine"] = menuChoice;
        menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
