namespace vehicle_app;

public static class DisplayMenus
{

    public static Dictionary<string, int> MainMenu()
    {
        var choice = 0;
        bool displayMenu = true;
        Dictionary<string, int> menuChoices = new Dictionary<string, int>();

        do 
        {
            Console.WriteLine("\nThe program will allow you to build a vehicle to take on a trip");
            Console.WriteLine("***************************************************************");
            Console.WriteLine($"\n Please choose from the following options:");
            Console.WriteLine("\t 1. Car");
            Console.WriteLine("\t 2. Pickup Truck");
            Console.WriteLine("\t 3. SUV");
            Console.WriteLine("\t 4. Exit Program");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            var result = 0;
            var choiceStr = Console.ReadLine();
            var validInput = int.TryParse(choiceStr, out result);


            if (validInput && result >= 1 && result <= 4)
            {
                choice = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
            }
            menuChoices["vehicle"] = choice;

            if (choice == 4)
            {
                return menuChoices;
            }

            var makeChoice = 0;

            if (choice != 0)
            {
                makeChoice = MakeSelectionMenu(choice, menuChoices);
            }

            if (choice != 0 && makeChoice != 4) 
            {
                displayMenu = false;
            }

        } while(displayMenu);

        return menuChoices;
    }

    public static int MakeSelectionMenu(int mainMenuChoice, Dictionary<string, int> menuChoices)
    {
        var makeSelection = 0;
        var displayMenu = true;

        do
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
            Console.WriteLine("\t 1. Toyota");
            Console.WriteLine("\t 2. Ford");
            Console.WriteLine("\t 3. Chevy");
            Console.WriteLine("\t 4. Go back");
            Console.WriteLine("\n****************************************************************\n");
            Console.Write("Enter an integer value of your choice: ");

            var result = 0;
            var choiceStr = Console.ReadLine();
            var validInput = int.TryParse(choiceStr, out result);

            if (validInput && result >= 1 && result <= 4)
            {
                makeSelection = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
                makeSelection = 0;
            }

            var engineSelection = 0;

            if (makeSelection != 4 && makeSelection != 0)
            {
                //switch statement goes here for model
                //each make should have it's own menu
                engineSelection = EngineSelectionMenu(mainMenuChoice, menuChoices);
            }

            if (makeSelection != 0 && engineSelection != 5)
            {
                displayMenu = false;
            }

        } while (displayMenu);
        menuChoices["make"] = makeSelection;

        return makeSelection;
    }

    public static int EngineSelectionMenu(int mainMenuChoice, Dictionary<string, int> menuChoices)
    {
        var engineSelection = 0;
        var displayMenu = true;

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
                var validInput = int.TryParse(choiceStr, out result);

                if (validInput && result >= 1 && result <= 5)
                {
                    engineSelection = result;
                }
                else
                {
                    Console.WriteLine($"{choiceStr} is not a valid input");
                    engineSelection = 0;
                }

                if (engineSelection != 0)
                {
                    displayMenu = false;
                }
            }
        } while (displayMenu);
       menuChoices["engine"] = engineSelection;

        return engineSelection;
    }
}