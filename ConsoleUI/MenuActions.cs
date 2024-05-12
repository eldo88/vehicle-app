namespace vehicle_app;

public class MenuActions
{
    public static int ShowMenuItems(List<string> menuItems, string menuText)
    {
        StandardUiMessages.MenuSeparator();
        StandardUiMessages.MenuSubject(menuText);

        var menuItemNum = 1;
        foreach (var item in menuItems)
        {
            StandardUiMessages.ShowMenuItemsInUi(menuItemNum, item);
            menuItemNum++;
        }

        StandardUiMessages.GoBack(menuItemNum);
        StandardUiMessages.MenuSeparator();
        StandardUiMessages.EnterMenuChoice();

        return menuItemNum;
    }

    public static int GoToPreviousNextOrSameMenu(int menuItemNum, int menuChoice)
    {
        var changeMenuValue = 0;

        if (menuItemNum == menuChoice) // go back
        {
            return changeMenuValue - 1;
        }
        else if (menuChoice < 0 || menuChoice > menuItemNum) // invalid input
        {
            return changeMenuValue;
        }
        else 
        {
            return changeMenuValue + 1; // go to next menu
        }
    }
}