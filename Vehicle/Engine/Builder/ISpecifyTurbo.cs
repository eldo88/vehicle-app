namespace vehicle_app.Builder;

public interface ISpecifyTurbo
{
    public IBuildEngine WithTurbo(bool hasTurbo);
}