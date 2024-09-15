namespace vehicle_app.Builder;

public class EngineBuilder
{
    public static ISpecifyFuelType Create()
    {
        return new Impl();
    }
    
    private class Impl :
        ISpecifyFuelType,
        ISpecifyNumberOfCylinders,
        ISpecifyTurbo,
        IBuildEngine
    {
        private GasEngine _engine = new GasEngine();
        
        public ISpecifyNumberOfCylinders WithFuelType(string fuelType)
        {
            _engine.FuelType = fuelType;
            return this;
        }

        public ISpecifyTurbo WithNumberOfCylinders(int numberOfCylinders)
        {
            _engine.NumberOfCylinders = numberOfCylinders;
            return this;
        }

        public IBuildEngine WithTurbo(bool hasTurbo)
        {
            _engine.HasTurbo = hasTurbo;
            return this;
        }

        public IEngine Build()
        {
            return _engine;
        }
    }
}