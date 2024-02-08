
namespace vehicle_app;

public class MainMenuData : IMainMenuData
{
    public MainMenuData()
    {
        MainMenuDataList = FileOperations.ReadDataFromFile("./data/vehicle-data/main-menu-data.csv");
    }

    public List<string> MainMenuDataList { get; set; }
}
