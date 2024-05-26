namespace vehicle_app;

public static class Input
{
    public static int MenuInput(int menuItemNum)
    {
        var choiceStr = Console.ReadLine();
        if (int.TryParse(choiceStr, out int result) && result >= 1 && result <= menuItemNum)
        {
            return result;
        }
        else if (choiceStr is not null)
        {
            StandardUiMessages.InvalidInputMessage(choiceStr);
            result = 0;
        }

        return result;
    }
}