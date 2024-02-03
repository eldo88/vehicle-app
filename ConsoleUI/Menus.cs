namespace vehicle_app;

public class Menus
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

        if (menuItemNum == menuChoice)
        {
            return changeMenuValue - 1;
        }
        else if (menuChoice < 1 || menuChoice > menuItemNum)
        {
            return changeMenuValue;
        }
        else 
        {
            return changeMenuValue + 1;
        }
    }
}