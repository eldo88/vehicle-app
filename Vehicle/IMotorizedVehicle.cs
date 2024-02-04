namespace vehicle_app;

public interface IMotorizedVehicle : IVehicle
{
    public string EngineType {get; set;}
    public decimal MPG {get; set;}
    public decimal Range {get; set;}
    public decimal FuelCapacity {get; set;} 
    List<(string, decimal)> Drive(decimal tripLength)
    {
        List<(string, decimal)> tripDetail = [];
        (string, decimal) message;

        if (tripLength <= 0)
        {
            message = ("Error", 0);
            tripDetail.Add(message);
        }

        message = ("Drive length", tripLength);
        tripDetail.Add(message);

        if (MPG == 0)
        {
            decimal numberOfChargesNeeded = (decimal)tripLength / (decimal)Range;
            message = ("Number Of Charges Needed", numberOfChargesNeeded);
            tripDetail.Add(message);
        }
        else
        {
            decimal totalGallonsOfFuelNeeded = (decimal)tripLength / (decimal)MPG;
            decimal numberOfTanksOfGasNeeded = totalGallonsOfFuelNeeded / FuelCapacity;
            message = ("Total Gallons Of Fuel Needed", totalGallonsOfFuelNeeded);
            tripDetail.Add(message);
            message = ("Number Of Tanks Of Gas Needed",numberOfTanksOfGasNeeded);
            tripDetail.Add(message);
            message = ("Vehicle Mpg", MPG);
            tripDetail.Add(message);
        }

        message = ("Vehicle Range", Range);
        tripDetail.Add(message);

        return tripDetail;
    }
    
    public static void Print(IMotorizedVehicle motorizedVehicle)
    {
        Console.WriteLine(motorizedVehicle);
    }
}