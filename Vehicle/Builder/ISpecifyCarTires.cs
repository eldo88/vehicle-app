using vehicle_app.Vehicle.Builder;

namespace vehicle_app.Builder;

public interface ISpecifyCarTires
{
    public IBuildCar WithTires(ITires tires);
}