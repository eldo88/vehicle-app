namespace vehicle_app;

public class VehicleModel
{
    public VehicleModel()
    {
        VehicleModelDict = FileOperations.ReadModelDataIntoDict(modelDataFilePaths);
    }

    public List<string> modelDataFilePaths = [
            "./data/vehicle-data/toyota-car-data.csv",
            "./data/vehicle-data/toyota-truck-data.csv",
            "./data/vehicle-data/toyota-suv-data.csv",
            "./data/vehicle-data/ford-car-data.csv",
            "./data/vehicle-data/ford-truck-data.csv",
            "./data/vehicle-data/ford-suv-data.csv",
            "./data/vehicle-data/chevrolet-car-data.csv",
            "./data/vehicle-data/chevrolet-truck-data.csv",
            "./data/vehicle-data/chevrolet-suv-data.csv"
        ];

    public Dictionary<string, List<string>> VehicleModelDict {get; set;}

    public string GetVehicleModelByIdx(string vehicleMakeKey, int idx)
    {
        var modelList = VehicleModelDict[vehicleMakeKey];

        return modelList[idx];
    }
}