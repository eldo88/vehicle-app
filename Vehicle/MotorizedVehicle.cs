namespace vehicle_app;

public class MotorizedVehicle : BaseVehicle, IMotorizedVehicle
{
    public MotorizedVehicle() {}
    public MotorizedVehicle(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg) : base(color, capacity, make, model, year, vehicleType)
    {
        if (string.IsNullOrWhiteSpace(engineType))
            {throw new ArgumentException("Engine type is required");}
        EngineType = engineType;

        if (engineType == "Electric")
        {
            Range = 350;
            FuelCapacity = 0;
            MPG = 0;
        }
        else
        {
            MPG = mpg;
            FuelCapacity = 20;
            Range = FuelCapacity * MPG;
        }
    }

    public string EngineType { get; set; } = "";
    public decimal MPG { get; set; }
    public decimal Range { get; set; } = 1;
    public decimal FuelCapacity { get; set; }

    public List<(string, decimal)> Drive(decimal tripLength)
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

    public virtual void PrintDriveDetails(List<(string, decimal)> tripDetails)
    {
            Console.WriteLine("\nThe details of your drive are:\n");
            foreach (var item in tripDetails)
            {
                Console.WriteLine("{0}: {1:0.00}", item.Item1, item.Item2);
            }
    }
}