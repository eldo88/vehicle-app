using System.Collections;

namespace vehicle_app;

public sealed class SaveMenu
{
    
    public event EventHandler<VehicleEvent>? SaveVehicleEvent;
    public void SaveVehicleMenu(IVehicle vehicle)
    {
        var displayMenu = true;
        do
        {
            StandardUiMessages.MenuSeparator();
            StandardUiMessages.SaveVehicleMessage(vehicle);
            var choice = Console.ReadLine();

            if (!char.TryParse(choice, out var result)) continue;
            switch (char.ToLower(result))
            {
                case 'y':
                    OnSaveVehicle(vehicle);
                    displayMenu = false;
                    break;
                case 'n':
                    displayMenu = false;
                    break;
                default:
                {
                    StandardUiMessages.InvalidInputMessage(choice);

                    break;
                }
            }
        }while(displayMenu);
    }

    private void OnSaveVehicle(IVehicle vehicle)
    {
        SaveVehicleEvent?.Invoke(this, new VehicleEvent(vehicle));
    }
}