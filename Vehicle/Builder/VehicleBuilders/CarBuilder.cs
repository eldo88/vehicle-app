using vehicle_app.Builder;

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
        ISpecifyTires,
        IBuildCar
    {
        private Car car = new Car();
        
        public ISpecifyCapacity WithColor(string color)
        {
            car.Color = color;
            return this;
        }

        public ISpecifyMake WithCapacity(int capacity)
        {
            car.Capacity = capacity;
            return this;
        }

        public ISpecifyModel WithMake(string make)
        {
            car.Make = make;
            return this;
        }

        public ISpecifyYear WithModel(string model)
        {
            car.Model = model;
            return this;
        }

        public ISpecifyType WithYear(int year)
        {
            car.Year = year;
            return this;
        }

        public ISpecifyEngineType OfType(string type)
        {
            car.VehicleTypeEnum = (VehicleTypeEnum) Enum.Parse(typeof(VehicleTypeEnum), type);
            return this;
        }

        public ISpecifyMpg WithEngineType(string engineType, int mpg)
        {
            car.EngineType = engineType;
            if (engineType == "Electric")
            {
                car.Range = 350;
                car.FuelCapacity = 0;
                car.MPG = 0;
            }
            else
            {
                car.MPG = mpg;
                car.FuelCapacity = 20;
                car.Range = car.FuelCapacity * car.MPG;
            }
            return this;
        }

        public ISpecifyMileage WithMpg(int mpg)
        {
            car.MPG = mpg;
            return this;
        }

        public ISpecifyEngine WithMileage(int currentMileage)
        {
            car.CurrentMileage = currentMileage;
            return this;
        }

        public ISpecifyWheels WithEngine(IEngine engine)
        {
            car.Engine = engine;
            return this;
        }

        public ISpecifyTires WithWheels(IWheels wheels)
        {
            car.Wheels = wheels;
            return this;
        }

        public IBuildCar WithTires(ITires tires)
        {
            car.Tires = tires;
            return this;
        }

        public Car Build()
        {
            return car;
        }
    }
}