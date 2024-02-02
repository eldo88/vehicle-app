namespace vehicle_app;

public class VehicleModelMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, ref  VehicleModel vehicleModel, ref VehicleMake vehicleMake, ref VehicleType vehicleType, ref MenuChoices menuChoices)
    {
        var modelKey = vehicleMake.VehicleMakeList[menuChoices.MenuChoicesFromUserInput["make"] - 1] + vehicleType.VehicleTypeList[menuChoices.MenuChoicesFromUserInput["vehicle"] - 1];
        var modelValues = vehicleModel.VehicleModelDict[modelKey];
        var modelMenuText = "model";
        menuItemNum = Menus.ShowMenuItems(modelValues, modelMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["model"] = menuChoice;
        menuControl += Menus.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
