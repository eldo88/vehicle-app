namespace vehicle_app.Builder;

public interface ISpecifyNumberOfCylinders
{
    public ISpecifyTurbo WithNumberOfCylinders(int numberOfCylinders);
}