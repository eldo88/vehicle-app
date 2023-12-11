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
                makeChoice = MakeSelectionMenu(menuChoices);
            }

            if (choice != 0 && makeChoice != 4) 
            {
                displayMenu = false;
            }

        } while(displayMenu);

        return menuChoices;
    }

    public static int MakeSelectionMenu(Dictionary<string, int> menuChoices)
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

            var modelSelection = 0;

            if (makeSelection != 4 && makeSelection != 0)
            {
                switch (makeSelection)
                {
                    case 1:
                        modelSelection = ToyotaModelSelectionMenu(menuChoices);
                        break;
                }
                //switch statement goes here for model
                //each make should have it's own menu
            }

            if (makeSelection != 0 && modelSelection != 99)
            {
                displayMenu = false;
            }

        } while (displayMenu);
        menuChoices["make"] = makeSelection;

        return makeSelection;
    }

    public static int ToyotaModelSelectionMenu(Dictionary<string, int> menuChoices)
    {
        var modelSelection = 0;
        var displayMenu = true;

        do
        {
            if (menuChoices["vehicle"] == 1)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. Camry");
                Console.WriteLine("\t 2. Corrolla");
                Console.WriteLine("\t 3. Prius");
                Console.WriteLine("\t 4. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");
            }
            else if (menuChoices["vehicle"] == 2)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. Tacoma");
                Console.WriteLine("\t 2. Tundra");
                Console.WriteLine("\t 3. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");
            }
            else
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. 4Runner");
                Console.WriteLine("\t 2. Land Cruiser");
                Console.WriteLine("\t 3. Sequoia");
                Console.WriteLine("\t 4. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");
            }


            var result = 0;
            var choiceStr = Console.ReadLine();
            var validInput = int.TryParse(choiceStr, out result);

            if (validInput && result >= 1 && result <= 4)
            {
                modelSelection = result;
            }
            else
            {
                Console.WriteLine($"{choiceStr} is not a valid input");
                modelSelection = 0;
            }

            if (menuChoices["vehicle"] == 1)
            {
                if (modelSelection == 4)
                {
                    modelSelection = 99;
                }
            }

            if (menuChoices["vehicle"] == 2)
            {
                switch (modelSelection)
                {
                    case 1:
                        modelSelection = 4;
                        break;
                    case 2: 
                        modelSelection = 5;
                        break;
                    case 3:
                        modelSelection = 99;
                        break;
                    default:
                        break;
                }
            }

            if (menuChoices["vehicle"] == 3)
            {
                switch (modelSelection)
                {
                    case 1:
                        modelSelection = 6;
                        break;
                    case 2:
                        modelSelection = 7;
                        break;
                    case 3:
                        modelSelection = 8;
                        break;
                    case 4:
                        modelSelection = 99;
                        break;
                    default:
                        break;
                }
            }

            var engineSelection = 0;

            if (modelSelection != 99 && modelSelection != 0)
            {
                //switch statement goes here for model
                //each make should have it's own menu
                var mainMenuChoice = 1;
                engineSelection = EngineSelectionMenu(mainMenuChoice, menuChoices);
            }

            if (modelSelection != 0 && engineSelection != 5)
            {
                displayMenu = false;
            }

        } while (displayMenu);
        menuChoices["model"] = modelSelection;

        return modelSelection;
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

                var vehicleYear = VehicleYearSelectionMenu(menuChoices);


                if (engineSelection != 0 && vehicleYear != 1)
                {
                    displayMenu = false;
                }
            }
        } while (displayMenu);
       menuChoices["engine"] = engineSelection;

        return engineSelection;
    }

    public static int VehicleYearSelectionMenu(Dictionary<string, int> menuChoices)
    {
        var vehicleYear = 0;
        var inputStr = "";
        var displayMenu = true;

        do
        {
            Console.WriteLine("***************************************************************");
            Console.Write($"\n Please enter the year of your vehicle, if you want to exit enter 1: ");
            inputStr = Console.ReadLine();
            Console.WriteLine("\n***************************************************************\n");

            var result = 0;
            var validInput = int.TryParse(inputStr, out result);

            if (validInput && result <= 2025)
            {
                vehicleYear = result;
                displayMenu = false;
            }
            else
            {
                Console.WriteLine("Year entered not valid, please enter another year");
            }

        } while(displayMenu);
        menuChoices["year"] = vehicleYear;

        return vehicleYear;
    }
}