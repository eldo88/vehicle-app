using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        ShowMenus showMenus = new();
        showMenus.DisplayMenus();

        var menuChoices = showMenus._menuChoices.MenuChoicesFromUserInput;
        if(ExitProgram.ExitProgramValidator(menuChoices)) return;
        IMotorizedVehicle createdVehicle;
        var data = showMenus.GetMenuChoiceData();

        try
        {
            createdVehicle = VehicleFactory.BuildFromMenuChoices(data);
            DisplayCreatedVehicle.PrintToConsole(createdVehicle);
            SaveMenu.SaveVehicleMenu(createdVehicle);

            if (TakeVehicleOnDriveMenu.GoOnDrive(createdVehicle.Make, createdVehicle.Model))
            {
                var driveLength = DriveLengthScreen.EnterDriveLength();
                MotorizedVehicle.PrintDriveDetails(createdVehicle.Drive(driveLength));
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
