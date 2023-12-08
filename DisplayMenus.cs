namespace vehicle_app;

public class DisplayMenus
{

    private Dictionary<string, int> finalMenuChoices = new Dictionary<string, int>();

    public Dictionary<string, int> MainMenu()
    {
        var choice = 0;
        bool displayMenu = true;

        do 
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


            // TODO: add additional check for valid choice
            if (validInput)
            {
                choice = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
            }

            finalMenuChoices["vehicle"] = choice;

            var engineChoice = EngineSelectionMenu(choice);

            if (choice != 0 && engineChoice != 5) 
            {
                displayMenu = false;
            }

        } while(displayMenu);

        Dictionary<string, int> menuChoices = finalMenuChoices;

        return menuChoices;
    }

    public int EngineSelectionMenu(int mainMenuChoice)
    {
        int engineSelection = 0;
        bool displayMenu = true;

        do
        {
            if (mainMenuChoice == 1 || mainMenuChoice == 2 || mainMenuChoice == 3)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine($"\n Please choose from the following options for your engine type:");
                Console.WriteLine("\t    Engine/powertrain type     Fuel Type            HP ");
                Console.WriteLine("\t 1. V6                        Gas powered          300 ");
                Console.WriteLine("\t 2. V8                        Gas powered          380 ");
                Console.WriteLine("\t 3. V6 Hybrid                 Hybrid               360 ");
                Console.WriteLine("\t 4. Electric                  Hybrid               450 ");
                Console.WriteLine("\t 5. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");

                var result = 0;
                var choiceStr = Console.ReadLine();
                var validInput = Int32.TryParse(choiceStr, out result);

                if (validInput)
                {
                    engineSelection = result;
                }
                else
                {
                    Console.WriteLine($"{choiceStr} is not a valid input");
                }

                if (engineSelection != 0)
                {
                    displayMenu = false;
                }
            }
        } while (displayMenu);
        
        finalMenuChoices["engine"] = engineSelection;
        return engineSelection;
    }
}