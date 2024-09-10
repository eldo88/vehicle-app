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
        ISpecifySuvTires,
        IBuildSuv
    {
        private Suv suv = new Suv();
        
        public ISpecifyCapacity WithColor(string color)
        {
            suv.Color = color;
            return this;
        }

        public ISpecifyMake WithCapacity(int capacity)
        {
            suv.Capacity = capacity;
            return this;
        }

        public ISpecifyModel WithMake(string make)
        {
            suv.Make = make;
            return this;
        }

        public ISpecifyYear WithModel(string model)
        {
            suv.Model = model;
            return this;
        }

        public ISpecifyType WithYear(int year)
        {
            suv.Year = year;
            return this;
        }

        public ISpecifyEngineType OfType(string type)
        {
            suv.VehicleTypeEnum = (VehicleTypeEnum) Enum.Parse(typeof(VehicleTypeEnum), type);
            return this;
        }

        public ISpecifyMpg WithEngineType(string engineType, int mpg)
        {
            suv.EngineType = engineType;
            if (engineType == "Electric")
            {
                suv.Range = 350;
                suv.FuelCapacity = 0;
                suv.MPG = 0;
            }
            else
            {
                suv.MPG = mpg;
                suv.FuelCapacity = 20;
                suv.Range = suv.FuelCapacity * suv.MPG;
            }
            return this;
        }

        public ISpecifyMileage WithMpg(int mpg)
        {
            suv.MPG = mpg;
            return this;
        }

        public ISpecifyEngine WithMileage(int currentMileage)
        {
            suv.CurrentMileage = currentMileage;
            return this;
        }

        public ISpecifyWheels WithEngine(IEngine engine)
        {
            suv.Engine = engine;
            return this;
        }

        public IBuildSuv WithTires(ITires tires)
        {
            suv.Tires = tires;
            return this;
        }

        public Suv Build()
        {
            return suv;
        }
        
    }
}