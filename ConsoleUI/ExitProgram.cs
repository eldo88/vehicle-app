namespace vehicle_app;

public static class ExitProgram
{
    public static bool ExitProgramValidator(Dictionary<string, int> menuChoices)
    {
        if (menuChoices["vehicle"] != 99) return false;
        StandardUiMessages.ExitProgramMessage();
        return true;
    }
}