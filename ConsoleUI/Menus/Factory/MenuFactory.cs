namespace vehicle_app;

public class MenuFactory
{
    public static SaveMenu CreateSaveMenu()
    {
        return new SaveMenu();
    }

    public static ShowMenus CreateShowMenus()
    {
        return new ShowMenus();
    }
}
