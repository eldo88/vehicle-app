namespace vehicle_app;

public class ExitProgram
{
    public static bool ExitProgramValidator(Dictionary<string, int> menuCHoices)
    {
        if(menuCHoices["vehicle"] == 99)
        {
            StandardUiMessages.ExitProgramMessage();
            return true;
        }
        return false;
    }
}