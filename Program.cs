using System.Runtime.CompilerServices;

namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        VehicleColor vehicleColor = new();
        VehicleEngine vehicleEngine = new();
        VehicleMake vehicleMake = new();
        VehicleModel vehicleModel = new();
        VehicleType vehicleType = new();

        ShowMenus showMenus = new(vehicleColor, vehicleEngine, vehicleMake, vehicleModel, vehicleType);
        
        showMenus.DisplayMenus();

        var menuChoices = showMenus.menuChoices.MenuChoicesFromUserInput;

        if (menuChoices["vehicle"] == 99)
        {
            Console.WriteLine("Exiting program.....");
            return;
        }

        Vehicle createdVehicle;

        CreateVehicle createVehicle = new(vehicleColor, vehicleEngine, vehicleMake, vehicleModel, vehicleType, menuChoices);

        try
        {
            createdVehicle = createVehicle.CreateVehicleFromMenuChoices();
            DisplayCreatedVehicle.PrintToConsole(createdVehicle);
            // TODO: implement saving, will need to explicitly cast
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
