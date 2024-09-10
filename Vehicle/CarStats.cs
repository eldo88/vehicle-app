namespace vehicle_app;

public class CarStats : IVehicleStats
{
    public int TotalNumberOfCars;
    public int AverageCarMileage;
    private Car _car;

    public CarStats(Car car)
    {
        _car = car;
    }
    
    public int TotalNumberOfVehicles()
    {
        throw new NotImplementedException();
    }

    public int AverageMileage()
    {
        throw new NotImplementedException();
    }

    public int HighestMileage(Car car)
    {
        return car.CurrentMileage;
    }

    public void CalculateStats()
    {
        var carRepository = new CarRepository();
        var cars = carRepository.GetVehicles();
        
    }
}