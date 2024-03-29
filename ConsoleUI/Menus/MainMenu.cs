﻿namespace vehicle_app;

public class MainMenu
{
    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, MainMenuData mainMenuData, MenuChoices menuChoices)
    {
        StandardUiMessages.MenuSeparator();
        Console.WriteLine("Please make a selection");
        var menuText = "";
        menuItemNum = MenuActions.ShowMenuItems(mainMenuData.MainMenuDataList, menuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["vehicle"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }
}
