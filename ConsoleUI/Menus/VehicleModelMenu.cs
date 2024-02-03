namespace vehicle_app;

public class VehicleModelMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref  IVehicleModel vehicleModel, ref IVehicleMake vehicleMake, ref IVehicleType vehicleType, ref IMenuChoices menuChoices)
    {
        var modelKey = vehicleMake.VehicleMakeList[menuChoices.MenuChoicesFromUserInput["make"] - 1] + vehicleType.VehicleTypeList[menuChoices.MenuChoicesFromUserInput["vehicle"] - 1];
        var modelValues = vehicleModel.VehicleModelDict[modelKey];
        var modelMenuText = "model";
        menuItemNum = MenuActions.ShowMenuItems(modelValues, modelMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["model"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
