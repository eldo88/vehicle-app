namespace vehicle_app.Builder;

public interface ISpecifyFuelType
{
    public ISpecifyNumberOfCylinders WithFuelType(string fuelType);
}