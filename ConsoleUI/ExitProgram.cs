namespace vehicle_app;

public static class ExitProgram
{
    public static bool ExitProgramValidator(Dictionary<string, int> menuChoices)
    {
        try
        {
            if (menuChoices["vehicle"] != 99) return false;
            StandardUiMessages.ExitProgramMessage();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        return true;
    }
}