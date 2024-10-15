namespace vehicle_app;

public static class StandardUiMessages
{
    public static void MenuSeparator()
    {
        Console.WriteLine("***************************************************************");
    }

    public static void InvalidInputMessage(string choiceStr)
    {
        Console.WriteLine($"{choiceStr} is not a valid input");
    }

    public static void GeneralInvalidInput()
    {
        Console.WriteLine("Invalid input, please try again");
    }

    public static void MenuSubject(string? menuText)
    {
        Console.WriteLine($"\n Please choose {menuText} from the following options:");
    }

    public static void EnterMenuChoice()
    {
        Console.WriteLine("Enter an integer value of your choice: ");
    }

    public static void ShowMenuItemsInUi(int menuItemNum, string menuItem)
    {
        Console.WriteLine($"\t{menuItemNum}. {menuItem}");
    }

    public static void GoBack(int menuItemNum)
    {
        Console.WriteLine($"\t{menuItemNum}. Go Back");
    }

    public static void YearSelectionMessage()
    {
        Console.WriteLine($"\nPlease enter the year of your vehicle (must be newer than 1990), if you want to go back enter 1 ");
    }

    public static void TakeOnDriveMessage(string vehicleMakeAndModel)
    {
        Console.WriteLine($"Would you like to take your {vehicleMakeAndModel} on a drive? (enter Y/N)");
    }

    public static void DriveLengthMessage()
    {
        Console.WriteLine("\nHow many miles are you driving?");
    }

    public static void DriveLengthDefaultMessage()
    {
        Console.WriteLine("Default drive length of 20 miles is being used.");
    }

    public static void ExitProgramMessage()
    {
        Console.WriteLine("Exiting program.....");
    }

    public static void SaveVehicleMessage(IVehicle vehicle)
    {
        Console.WriteLine($"Would you like to save your {vehicle.Make} {vehicle.Model}? (Y/N)");
    }

    public static void BuildAVehicleBanner()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"
        
 ____   __ __  ____  _      ___         ____      __ __    ___  __ __  ____   __  _        ___ 
|    \ |  |  ||    || |    |   \       /    |    |  |  |  /  _]|  |  ||    | /  ]| |      /  _]
|  o  )|  |  | |  | | |    |    \     |  o  |    |  |  | /  [_ |  |  | |  | /  / | |     /  [_ 
|     ||  |  | |  | | |___ |  D  |    |     |    |  |  ||    _]|  _  | |  |/  /  | |___ |    _]
|  O  ||  :  | |  | |     ||     |    |  _  |    |  :  ||   [_ |  |  | |  /   \_ |     ||   [_ 
|     ||     | |  | |     ||     |    |  |  |     \   / |     ||  |  | |  \     ||     ||     |
|_____| \__,_||____||_____||_____|    |__|__|      \_/  |_____||__|__||____\____||_____||_____|
                                                                                               
".TrimEnd());
    Console.ResetColor();

    }

    public static void LineOfVehicles()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(@"
  
                                                         _________________________   
                    /\\      _____          _____       |   |     |     |    | |  \  
     ,-----,       /  \\____/__|__\_    ___/__|__\___   |___|_____|_____|____|_|___\ 
  ,--'---:---`--, /  |  _     |     `| |      |      `| |                    | |    \
 ==(o)-----(o)==J    `(o)-------(o)=   `(o)------(o)'   `--(o)(o)--------------(o)--'  
`````````````````````````````````````````````````````````````````````````````````````");
        Console.WriteLine();
        Console.ResetColor();
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue....");
    }
}