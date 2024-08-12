namespace vehicle_app.Builder;

public interface ISpecifyTires
{
    public IBuildCar WithTires(ITires tires);
}