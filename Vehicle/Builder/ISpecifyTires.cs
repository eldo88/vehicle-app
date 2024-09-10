namespace vehicle_app.Vehicle.Builder;

public interface ISpecifyTires
{
    public IBuildCar WithTires(ITires tires);
}