namespace vehicle_app;

public delegate void PrintMessages();

public class MainMenu
{
    private int SelectedIndex { get; set; }
    private readonly List<string> Options;
    private readonly string Prompt;
    // private readonly MenuChoices? MenuChoices;
    // private readonly string Key;

    public MainMenu() 
    {
        Options = new();
        Prompt = "";
        SelectedIndex = 0;
        // Key = "";
    }

    public MainMenu(List<string> options, string prompt) 
    {
        Options = options;
        Options.Add("Go back");
        Prompt = prompt;
        SelectedIndex = 0;
    }

    public static void Show(ref int menuItemNum, ref int menuChoice, ref int menuControl, MainMenuData mainMenuData, MenuChoices menuChoices)
    {
        StandardUiMessages.MenuSeparator();
        StandardUiMessages.BuildAVehicleBanner();
        StandardUiMessages.LineOfVehicles();

        var menuText = "";
        menuItemNum = MenuActions.ShowMenuItems(mainMenuData.MainMenuDataList, menuText);
        menuChoice = Input.MenuInput(menuItemNum);
        menuChoices.MenuChoicesFromUserInput["vehicle"] = menuChoice;
        menuControl += MenuActions.GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
    }

    private void DisplayOptions()
    {
        Console.WriteLine(Prompt);

        for (int i = 0; i < Options.Count; i++) 
        {
            if (i == SelectedIndex) 
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White; 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($" {i + 1}.  << {Options[i]} >>");
        }
        Console.ResetColor();
    }

    private void TestDisplayOptions(PrintMessages printMessages) //testing delegate
    {
        Console.WriteLine(Prompt);
        printMessages();

        for (int i = 0; i < Options.Count; i++) 
        {
            if (i == SelectedIndex) 
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White; 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
            Console.WriteLine($" {i + 1}.  << {Options[i]} >>");
        }
        Console.ResetColor();
    }

    public int TestRun(PrintMessages printMessages) 
    {
        ConsoleKey consoleKey;

        do
        {
            Console.Clear();
        
            TestDisplayOptions(printMessages);

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            consoleKey = consoleKeyInfo.Key;

            if (consoleKey == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex < 0)
                {
                    SelectedIndex = Options.Count - 1;
                }
            }
            else if (consoleKey == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex > Options.Count - 1)
                {
                    SelectedIndex = 0;
                }
            }

        } while (consoleKey != ConsoleKey.Enter);

        return SelectedIndex;
    }

    public int Run()
    {
        ConsoleKey consoleKey;

        do
        {
            Console.Clear();
            DisplayOptions();
            //TestDisplayOptions(PrintUiMessage);

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            consoleKey = consoleKeyInfo.Key;

            if (consoleKey == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex < 0)
                {
                    SelectedIndex = Options.Count - 1;
                }
            }
            else if (consoleKey == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex > Options.Count - 1)
                {
                    SelectedIndex = 0;
                }
            }

        } while (consoleKey != ConsoleKey.Enter);

        return SelectedIndex;
    }
}
