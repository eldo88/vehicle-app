namespace vehicle_app.Vehicle.Builder;

public interface ISpecifyTires
{
    public IBuildVehicle WithTires(ITires tires);
}