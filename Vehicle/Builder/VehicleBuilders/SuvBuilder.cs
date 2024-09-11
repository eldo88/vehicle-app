using vehicle_app.Builder;
using vehicle_app.Vehicle.Builder;

namespace vehicle_app;

public class SuvBuilder
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
        //IBuildSuv
        IBuildVehicle
    {
        private Suv _suv = new Suv();
        
        public ISpecifyCapacity WithColor(string color)
        {
            _suv.Color = color;
            return this;
        }

        public ISpecifyMake WithCapacity(int capacity)
        {
            _suv.Capacity = capacity;
            return this;
        }

        public ISpecifyModel WithMake(string make)
        {
            _suv.Make = make;
            return this;
        }

        public ISpecifyYear WithModel(string model)
        {
            _suv.Model = model;
            return this;
        }

        public ISpecifyType WithYear(int year)
        {
            _suv.Year = year;
            return this;
        }

        public ISpecifyEngineType OfType(string type)
        {
            _suv.VehicleTypeEnum = (VehicleTypeEnum) Enum.Parse(typeof(VehicleTypeEnum), type);
            return this;
        }

        public ISpecifyMpg WithEngineType(string engineType, int mpg)
        {
            _suv.EngineType = engineType;
            if (engineType == "Electric")
            {
                _suv.Range = 350;
                _suv.FuelCapacity = 0;
                _suv.MPG = 0;
            }
            else
            {
                _suv.MPG = mpg;
                _suv.FuelCapacity = 20;
                _suv.Range = _suv.FuelCapacity * _suv.MPG;
            }
            return this;
        }

        public ISpecifyMileage WithMpg(int mpg)
        {
            _suv.MPG = mpg;
            return this;
        }

        public ISpecifyEngine WithMileage(int currentMileage)
        {
            _suv.CurrentMileage = currentMileage;
            return this;
        }

        public ISpecifyWheels WithEngine(IEngine engine)
        {
            _suv.Engine = engine;
            return this;
        }

        public ISpecifyTires WithWheels(IWheels wheels)
        {
            _suv.Wheels = wheels;
            return this;
        }

        public IBuildVehicle WithTires(ITires tires)
        {
            _suv.Tires = tires;
            return this;
        }

        public IVehicle Build()
        {
            return _suv;
        }
        
    }
}