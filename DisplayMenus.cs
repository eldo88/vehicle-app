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

            menuChoices["make"] = makeSelection;

            var modelSelection = 0;

            if (makeSelection != 4 && makeSelection != 0)
            {
                switch (makeSelection)
                {
                    case 1:
                        modelSelection = ToyotaModelSelectionMenu(menuChoices);
                        break;
                    case 2:
                        modelSelection = FordModelSelectionMenu(menuChoices);
                        break;
                    case 3:
                        modelSelection = ChevroletModelSelectionMenu(menuChoices);
                        break;
                    default:
                        Console.WriteLine("An error occurred when selecting the model, default value selected");
                        modelSelection = 4;
                        break;
                }
            }

            if (makeSelection != 0 && modelSelection != 99)
            {
                displayMenu = false;
            }

        } while (displayMenu);
        // menuChoices["make"] = makeSelection;

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

            menuChoices["model"] = modelSelection;

            var engineSelection = 0;

            if (modelSelection != 99 && modelSelection != 0)
            {
                //need to have separate menu for electric vehicles
                var mainMenuChoice = 1;
                engineSelection = EngineSelectionMenu(mainMenuChoice, menuChoices);
            }

            if (modelSelection != 0 && engineSelection != 5)
            {
                displayMenu = false;
            }

        } while (displayMenu);

        return modelSelection;
    }

    public static int FordModelSelectionMenu(Dictionary<string, int> menuChoices)
    {
        var modelSelection = 0;
        var displayMenu = true;

        do
        {
            if (menuChoices["vehicle"] == 1)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. Focus");
                Console.WriteLine("\t 2. Escort");
                Console.WriteLine("\t 3. Fusion");
                Console.WriteLine("\t 4. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");
            }
            else if (menuChoices["vehicle"] == 2)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. F-150");
                Console.WriteLine("\t 2. Ranger");
                Console.WriteLine("\t 3. Maverick");
                Console.WriteLine("\t 4. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");
            }
            else
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. Explorer");
                Console.WriteLine("\t 2. Bronco");
                Console.WriteLine("\t 3. Escape");
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
                switch(modelSelection)
                {
                    case 1:
                        modelSelection = 9;
                        break;
                    case 2:
                        modelSelection = 10;
                        break;
                    case 3:
                        modelSelection = 11;
                        break;
                    case 4:
                        modelSelection = 99;
                        break;
                }
            }

            if (menuChoices["vehicle"] == 2)
            {
                switch (modelSelection)
                {
                    case 1:
                        modelSelection = 12;
                        break;
                    case 2: 
                        modelSelection = 13;
                        break;
                    case 3:
                        modelSelection = 14;
                        break;
                    case 4:
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
                        modelSelection = 15;
                        break;
                    case 2:
                        modelSelection = 16;
                        break;
                    case 3:
                        modelSelection = 17;
                        break;
                    case 4:
                        modelSelection = 99;
                        break;
                    default:
                        break;
                }
            }

            menuChoices["model"] = modelSelection;

            var engineSelection = 0;

            if (modelSelection != 99 && modelSelection != 0)
            {
                //need separate engine menu for electric vehicles
                var mainMenuChoice = 1;
                engineSelection = EngineSelectionMenu(mainMenuChoice, menuChoices);
            }

            if (modelSelection != 0 && engineSelection != 5)
            {
                displayMenu = false;
            }

        } while (displayMenu);

        return modelSelection;
    }

    public static int ChevroletModelSelectionMenu(Dictionary<string, int> menuChoices)
    {
        var modelSelection = 0;
        var displayMenu = true;

        do
        {
            if (menuChoices["vehicle"] == 1)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. Corvette");
                Console.WriteLine("\t 2. Camaro");
                Console.WriteLine("\t 3. Bolt");
                Console.WriteLine("\t 4. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");
            }
            else if (menuChoices["vehicle"] == 2)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. Silverado 1500");
                Console.WriteLine("\t 2. Silverado 2500");
                Console.WriteLine("\t 3. Colorado");
                Console.WriteLine("\t 4. Go back");
                Console.WriteLine("\n****************************************************************\n");
                Console.Write("Enter an integer value of your choice: ");
            }
            else
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\n Please choose the make of your vehicle from the following options:");
                Console.WriteLine("\t 1. Tahoe");
                Console.WriteLine("\t 2. Suburban");
                Console.WriteLine("\t 3. Blazer");
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
                switch(modelSelection)
                {
                    case 1:
                        modelSelection = 18;
                        break;
                    case 2:
                        modelSelection = 19;
                        break;
                    case 3:
                        modelSelection = 20;
                        break;
                    case 4:
                        modelSelection = 99;
                        break;
                }
            }

            if (menuChoices["vehicle"] == 2)
            {
                switch (modelSelection)
                {
                    case 1:
                        modelSelection = 21;
                        break;
                    case 2: 
                        modelSelection = 22;
                        break;
                    case 3:
                        modelSelection = 23;
                        break;
                    case 4:
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
                        modelSelection = 24;
                        break;
                    case 2:
                        modelSelection = 25;
                        break;
                    case 3:
                        modelSelection = 26;
                        break;
                    case 4:
                        modelSelection = 99;
                        break;
                    default:
                        break;
                }
            }

            menuChoices["model"] = modelSelection;

            var engineSelection = 0;

            if (modelSelection != 99 && modelSelection != 0)
            {
                //need separate engine menu for electric vehicles
                var mainMenuChoice = 1;
                engineSelection = EngineSelectionMenu(mainMenuChoice, menuChoices);
            }

            if (modelSelection != 0 && engineSelection != 5)
            {
                displayMenu = false;
            }

        } while (displayMenu);

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
                //4-cyl, and need to figure out way to only show correct engines for make/model
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

                menuChoices["engine"] = engineSelection;

                var vehicleYear = 0;
                if (engineSelection != 0 && engineSelection != 5)
                {
                    vehicleYear = VehicleYearSelectionMenu(menuChoices);
                }

                if (engineSelection != 0 && vehicleYear != 1)
                {
                    displayMenu = false;
                }
            }
        } while (displayMenu);

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
                menuChoices["year"] = vehicleYear;
                displayMenu = false;
            }
            else
            {
                Console.WriteLine("Year entered not valid, please enter another year");
            }

        } while(displayMenu);

        return vehicleYear;
    }
}