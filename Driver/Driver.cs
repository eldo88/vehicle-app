namespace vehicle_app.Driver;

public class Driver
{
    private Person DriverOfVehicle { get; set; }

    public Person GetDriverOfVehicle()
    {
        return DriverOfVehicle;
    }
    
    private IMotorizedVehicle Vehicle { get; set; }

    public string GetVehicle()
    {
        return Vehicle.GetVehicleMakeAndModel();
    }

    public Driver(Person driverOfVehicle, IMotorizedVehicle vehicle)
    {
        DriverOfVehicle = driverOfVehicle;
        Vehicle = vehicle;
    }

    public List<(string, decimal)> DriveVehicle(decimal tripLength)
    {
        List<(string, decimal)> tripDetail = new();
        (string, decimal) message;

        if (tripLength <= 0)
        {
            message = ("Error", 0);
            tripDetail.Add(message);
        }

        message = ("Drive length", tripLength);
        tripDetail.Add(message);

        if (Vehicle.Mpg == 0)
        {
            var numberOfChargesNeeded = tripLength / Vehicle.Range;
            message = ("Number Of Charges Needed", numberOfChargesNeeded);
            tripDetail.Add(message);
        }
        else
        {
            var totalGallonsOfFuelNeeded = tripLength / Vehicle.Mpg;
            var numberOfTanksOfGasNeeded = totalGallonsOfFuelNeeded / Vehicle.FuelCapacity;
            message = ("Total Gallons Of Fuel Needed", totalGallonsOfFuelNeeded);
            tripDetail.Add(message);
            message = ("Number Of Tanks Of Gas Needed",numberOfTanksOfGasNeeded);
            tripDetail.Add(message);
            message = ("Vehicle Mpg", Vehicle.Mpg);
            tripDetail.Add(message);
        }

        message = ("Vehicle Range", Vehicle.Range);
        tripDetail.Add(message);

        return tripDetail;
    }
}