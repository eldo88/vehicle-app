namespace vehicle_app;

public static class MenuDataFactory
{
    public static IVehicleColor CreateVehicleColor()
    {
        return new VehicleColor();
    }

    public static IVehicleEngine CreateVehicleEngine()
    {
        return new VehicleEngine();
    }

    public static IVehicleMake CreateVehicleMake()
    {
        return new VehicleMake();
    }

    public static IVehicleModel CreateVehicleModel()
    {
        return new VehicleModel();
    }

    public static IVehicleType CreateVehicleType()
    {
        return new VehicleType();
    }

    public static IMenuChoices CreateMenuChoices()
    {
        return new MenuChoices();
    }

    public static IMainMenuData CreateMainMenuData()
    {
        return new MainMenuData();
    }
}
