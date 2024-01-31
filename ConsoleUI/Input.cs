namespace vehicle_app;

public class Input
{
    public static int MenuInput(int menuItemNum)
    {
        var choiceStr = Console.ReadLine();
        var validInput = int.TryParse(choiceStr, out int result);

        if (validInput && result >= 1 && result <= menuItemNum)
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