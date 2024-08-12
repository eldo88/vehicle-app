namespace vehicle_app.Builder;

public interface ISpecifyEngine
{
    public ISpecifyWheels WithEngine(IEngine engine);
}