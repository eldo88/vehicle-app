namespace vehicle_app;

public static class MenuActions
{
    public static int GoToPreviousNextOrSameMenu(int menuItemNum, int menuChoice)
    {
        const int changeMenuValue = 0;

        if (menuItemNum == menuChoice) // go back
        {
            return changeMenuValue - 1;
        }
        if (menuChoice < 0 || menuChoice > menuItemNum) // invalid input
        {
            return changeMenuValue;
        }
        return changeMenuValue + 1; // go to next menu
    }
}