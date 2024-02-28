using System.Reflection.Metadata.Ecma335;

namespace vehicle_app;

public class EngineHelper
{
    public static string GetFuelType(string engineType)
    {
        switch (engineType)
        {
            case "V4":
            case "V6":
            case "V8":
            case "V6 Hybrid":
                return "Gas";
            case "Electric":
                return "Electric";
            case "Turbo Diesel":
                return "Diesel";
            default:
                return "Gas";
        }
    }

    public static int GetNumberOfCylinders(string engineType)
    {
        switch (engineType)
        {
            case "V4":
                return 4;
            case "V6":
                return 6;
            case "V8":
                return 8;
            case "V6 Hybrid":
                return 6;
            case "Electric":
                return 0;
            case "Turbo Diesel":
                return 6;
            default:
                return 6;
        }
    }

    public static bool HasTurbo(string engineType)
    {
        if (engineType == "Turbo Diesel") {return true;}
        return false;
    }
}