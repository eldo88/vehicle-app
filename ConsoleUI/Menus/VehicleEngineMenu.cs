namespace vehicle_app;

public class VehicleEngineMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref  IVehicleEngine vehicleEngine, ref IMenuChoices menuChoices)
    {
        var engineMenuText = "engine";
        menuItemNum = MenuActions.ShowMenuItems(vehicleEngine.EngineList, engineMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["engine"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
