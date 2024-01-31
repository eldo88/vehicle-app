using System.Buffers.Text;
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
        if(ExitProgram.ExitProgramValidator(menuChoices)) return;
        IVehicle createdVehicle;

        try
        {
            createdVehicle = VehicleFactory.BuildFromMenuChoices(vehicleColor, vehicleEngine, vehicleMake, vehicleModel, vehicleType, menuChoices);
            DisplayCreatedVehicle.PrintToConsole(createdVehicle);
            SaveMenu.SaveVehicleMenu(createdVehicle);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
