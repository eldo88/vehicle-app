using vehicle_app.Vehicle.Builder;

namespace vehicle_app.Builder;

public interface ISpecifyWheels
{
    public ISpecifyTires WithWheels(IWheels wheels);
}