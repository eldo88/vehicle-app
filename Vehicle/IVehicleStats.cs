namespace vehicle_app;

public interface IVehicleStats
{
    public int TotalNumberOfVehicles();
    public int AverageMileage();
    public void CalculateStats();
}