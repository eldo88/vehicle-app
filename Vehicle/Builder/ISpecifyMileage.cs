namespace vehicle_app.Builder;

public interface ISpecifyMileage
{
    public ISpecifyEngine WithMileage(int currentMileage);
}