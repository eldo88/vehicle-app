using vehicle_app.Driver;

namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        ShowMenus showMenus = new();
        showMenus.DisplayMainMenu();

        var menuChoices = showMenus.MenuChoices.MenuChoicesFromUserInput;
        if(ExitProgram.ExitProgramValidator(menuChoices)) return;
        var data = showMenus.GetMenuChoiceData();

        try
        {
            var createdVehicle = BuildVehicle.BuildFromMenuChoices(data);
            DisplayCreatedVehicle.PrintToConsole(createdVehicle);
            var vehicleService = VehicleServiceFactory.CreateVehicleService();
            SaveMenu saveMenu = new();
            saveMenu.SaveVehicleEvent += vehicleService.OnVehicleSaved;
            saveMenu.SaveVehicleMenu(createdVehicle);

            if (!TakeVehicleOnDriveMenu.GoOnDrive(createdVehicle.GetVehicleMakeAndModel())) return;
            var driveLength = DriveLengthScreen.EnterDriveLength();
            var driver = new Driver.Driver(new Person("Lee", "Jones"), createdVehicle);
            DisplayCreatedVehicle.PrintDriveDetails(driver, driveLength);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.DetailedMessage());
        }
        
    }
}
