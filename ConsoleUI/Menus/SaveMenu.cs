using System.Collections;

namespace vehicle_app;

public class SaveMenu
{
    
    public event EventHandler<VehicleEvent>? SaveVehicleEvent;
    public void SaveVehicleMenu(IVehicle vehicle)
    {
        bool displayMenu = true;
        do
        {
            StandardUiMessages.MenuSeparator();
            StandardUiMessages.SaveVehicleMessage(vehicle);
            var choice = Console.ReadLine();

            if (char.TryParse(choice, out char result))
            {
                if (char.ToLower(result) == 'y')
                {
                    OnSaveVehicle(vehicle);
                    displayMenu = false;
                }
                else if (char.ToLower(result) == 'n')
                {
                    displayMenu = false;
                }
                else if (choice is not null)
                {
                    StandardUiMessages.InvalidInputMessage(choice);
                }
            }
        }while(displayMenu);
    }

    protected virtual void OnSaveVehicle(IVehicle vehicle)
    {
        if (SaveVehicleEvent is not null)
        {
            SaveVehicleEvent(this, new VehicleEvent() {Vehicle = vehicle});
        }
    }
}