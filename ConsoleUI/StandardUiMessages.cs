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

    public static void MenuSubject(string menuText)
    {
        Console.WriteLine($"\n Please choose the {menuText} of your vehicle from the following options:");
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

    public static void TakeOnDriveMessage(string vehicleMake, string vehicleModel)
    {
        Console.WriteLine($"Would you like to take your {vehicleMake} {vehicleModel} on a drive? (enter Y/N)");
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
}