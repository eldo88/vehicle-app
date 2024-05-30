namespace vehicle_app;

public delegate void PrintMessages();

public class MainMenu
{
    private int SelectedIndex { get; set; }
    private readonly List<string> _options;
    private readonly string _prompt;
    // private readonly MenuChoices? MenuChoices;
    // private readonly string Key;

    public MainMenu(List<string> options, string prompt) 
    {
        _options = options;
        _options.Add("Go back");
        _prompt = prompt;
        SelectedIndex = 0;
    }

    private void DisplayOptions()
    {
        Console.WriteLine(_prompt);

        for (var i = 0; i < _options.Count; i++) 
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
            Console.WriteLine($" {i + 1}.  << {_options[i]} >>");
        }
        Console.ResetColor();
    }

    private void TestDisplayOptions(PrintMessages printMessages) //testing delegate
    {
        Console.WriteLine(_prompt);
        printMessages();

        for (var i = 0; i < _options.Count; i++) 
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
            Console.WriteLine($" {i + 1}.  << {_options[i]} >>");
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

            var consoleKeyInfo = Console.ReadKey(true);
            consoleKey = consoleKeyInfo.Key;

            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = _options.Count - 1;
                    }

                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    SelectedIndex++;
                    if (SelectedIndex > _options.Count - 1)
                    {
                        SelectedIndex = 0;
                    }

                    break;
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

            var consoleKeyInfo = Console.ReadKey(true);
            consoleKey = consoleKeyInfo.Key;

            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = _options.Count - 1;
                    }

                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    SelectedIndex++;
                    if (SelectedIndex > _options.Count - 1)
                    {
                        SelectedIndex = 0;
                    }

                    break;
                }
            }

        } while (consoleKey != ConsoleKey.Enter);

        return SelectedIndex;
    }
}
