namespace vehicle_app;

public class VehicleModelMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, VehicleModel vehicleModel, VehicleMake vehicleMake, VehicleType vehicleType, MenuChoices menuChoices)
    {
        var modelKey = vehicleMake.VehicleMakeList[menuChoices.MenuChoicesFromUserInput["make"]] + vehicleType.VehicleTypeList[menuChoices.MenuChoicesFromUserInput["vehicle"]];
        var modelValues = vehicleModel.VehicleModelDict[modelKey];
        var modelMenuText = "the model";
        menuItemNum = MenuActions.ShowMenuItems(modelValues, modelMenuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["model"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
