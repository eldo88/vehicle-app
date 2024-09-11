using vehicle_app.Builder;
using vehicle_app.Vehicle.Builder;

namespace vehicle_app;

public class TruckBuilder
{
    public static ISpecifyColor Create()
    {
        return new Impl();
    }
    private class Impl :
        ISpecifyColor,
        ISpecifyCapacity,
        ISpecifyMake,
        ISpecifyModel,
        ISpecifyYear,
        ISpecifyType,
        ISpecifyEngineType,
        ISpecifyMpg,
        ISpecifyMileage,
        ISpecifyEngine,
        ISpecifyWheels,
        ISpecifyTires,
        IBuildVehicle
    {
        private Truck _truck = new Truck();
        
        public ISpecifyCapacity WithColor(string color)
        {
            _truck.Color = color;
            return this;
        }

        public ISpecifyMake WithCapacity(int capacity)
        {
            _truck.Capacity = capacity;
            return this;
        }

        public ISpecifyModel WithMake(string make)
        {
            _truck.Make = make;
            return this;
        }

        public ISpecifyYear WithModel(string model)
        {
            _truck.Model = model;
            return this;
        }

        public ISpecifyType WithYear(int year)
        {
            _truck.Year = year;
            return this;
        }

        public ISpecifyEngineType OfType(string type)
        {
            _truck.VehicleTypeEnum = (VehicleTypeEnum) Enum.Parse(typeof(VehicleTypeEnum), type);
            return this;
        }

        public ISpecifyMpg WithEngineType(string engineType, int mpg)
        {
            _truck.EngineType = engineType;
            if (engineType == "Electric")
            {
                _truck.Range = 350;
                _truck.FuelCapacity = 0;
                _truck.MPG = 0;
            }
            else
            {
                _truck.MPG = mpg;
                _truck.FuelCapacity = 20;
                _truck.Range = _truck.FuelCapacity * _truck.MPG;
            }
            return this;
        }

        public ISpecifyMileage WithMpg(int mpg)
        {
            _truck.MPG = mpg;
            return this;
        }

        public ISpecifyEngine WithMileage(int currentMileage)
        {
            _truck.CurrentMileage = currentMileage;
            return this;
        }

        public ISpecifyWheels WithEngine(IEngine engine)
        {
            _truck.Engine = engine;
            return this;
        }

        public ISpecifyTires WithWheels(IWheels wheels)
        {
            _truck.Wheels = wheels;
            return this;
        }

        public IBuildVehicle WithTires(ITires tires)
        {
            _truck.Tires = tires;
            return this;
        }

        public IMotorizedVehicle Build()
        {
            return _truck;
        }
        
    }
}