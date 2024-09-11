using vehicle_app.Builder;
using vehicle_app.Vehicle.Builder;

namespace vehicle_app;

public class CarBuilder
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
        //IBuildCar, 
        IBuildVehicle,
        ISpecifyTires
    {
        private Car _car = new Car();
        
        public ISpecifyCapacity WithColor(string color)
        {
            _car.Color = color;
            return this;
        }

        public ISpecifyMake WithCapacity(int capacity)
        {
            _car.Capacity = capacity;
            return this;
        }

        public ISpecifyModel WithMake(string make)
        {
            _car.Make = make;
            return this;
        }

        public ISpecifyYear WithModel(string model)
        {
            _car.Model = model;
            return this;
        }

        public ISpecifyType WithYear(int year)
        {
            _car.Year = year;
            return this;
        }

        public ISpecifyEngineType OfType(string type)
        {
            _car.VehicleTypeEnum = (VehicleTypeEnum) Enum.Parse(typeof(VehicleTypeEnum), type);
            return this;
        }

        public ISpecifyMpg WithEngineType(string engineType, int mpg)
        {
            _car.EngineType = engineType;
            if (engineType == "Electric")
            {
                _car.Range = 350;
                _car.FuelCapacity = 0;
                _car.MPG = 0;
            }
            else
            {
                _car.MPG = mpg;
                _car.FuelCapacity = 20;
                _car.Range = _car.FuelCapacity * _car.MPG;
            }
            return this;
        }

        public ISpecifyMileage WithMpg(int mpg)
        {
            _car.MPG = mpg;
            return this;
        }

        public ISpecifyEngine WithMileage(int currentMileage)
        {
            _car.CurrentMileage = currentMileage;
            return this;
        }

        public ISpecifyWheels WithEngine(IEngine engine)
        {
            _car.Engine = engine;
            return this;
        }

        public ISpecifyTires WithWheels(IWheels wheels)
        {
            _car.Wheels = wheels;
            return this;
        }

        public IBuildVehicle WithTires(ITires tires)
        {
            _car.Tires = tires;
            return this;
        }

        public IMotorizedVehicle Build()
        {
            return _car;
        }
    }
}