namespace vehicle_app.Builder;

public interface ISpecifyEngineType
{
    public ISpecifyMpg WithEngineType(string engineType, int mpg);
}