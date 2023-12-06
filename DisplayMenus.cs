namespace vehicle_app;

public static class DisplayMenus
{
    public static int MainMenu()
    {
        var choice = 0;
        bool displayMenu = true;

        while (displayMenu) 
        {
            Console.WriteLine("\nThe program will allow you to build a vehicle to take on a trip");
            Console.WriteLine("***************************************************************");
            Console.WriteLine($"\n Please choose from the following options:");
            Console.WriteLine("\t 1. Car");
            Console.WriteLine("\t 2. Truck");
            Console.WriteLine("\t 3. Motorcycle");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            var result = 0;
            var choiceStr = Console.ReadLine();
            bool validInput = Int32.TryParse(choiceStr, out result);

            if (validInput)
            {
                choice = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
            }

            if (choice != 0) 
            {
                displayMenu = false;
            }
        }
        return choice;
    }
}