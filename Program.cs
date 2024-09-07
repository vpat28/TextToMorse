namespace TexttoMorse
{
    public class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;   // Added this to start of program to ensure default color is restored when the program runs
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(1000);
            Console.WriteLine("████████╗███████╗██╗  ██╗████████╗               ████████╗ ██████╗                ███╗   ███╗ ██████╗ ██████╗ ███████╗███████╗      \r\n╚══██╔══╝██╔════╝╚██╗██╔╝╚══██╔══╝               ╚══██╔══╝██╔═══██╗               ████╗ ████║██╔═══██╗██╔══██╗██╔════╝██╔════╝      \r\n   ██║   █████╗   ╚███╔╝    ██║   █████╗   █████╗   ██║   ██║   ██║█████╗   █████╗██╔████╔██║██║   ██║██████╔╝███████╗█████╗        \r\n   ██║   ██╔══╝   ██╔██╗    ██║   ╚════╝   ╚════╝   ██║   ██║   ██║╚════╝   ╚════╝██║╚██╔╝██║██║   ██║██╔══██╗╚════██║██╔══╝        \r\n   ██║   ███████╗██╔╝ ██╗   ██║         ██╗         ██║   ╚██████╔╝      ██╗      ██║ ╚═╝ ██║╚██████╔╝██║  ██║███████║███████╗██╗██╗\r\n   ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝         ╚═╝         ╚═╝    ╚═════╝       ╚═╝      ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝╚═╝╚═╝\r\n                                                                                                                                    ");
            GetUserInput();
        }


        public static void EndofGame()
        {
            /* Logan changes:
             * Refactored the isValid logic here to be a bit more clear. Separates validation logic from handling user choice logic.
             * Changed userinput to userInput
             * Reset console text color to white after prompt to help better distinguish prompt from input
             */
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter [R] to restart. Enter [Q] to quit.");
            Console.ForegroundColor = ConsoleColor.White;
            string? userInput = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(userInput) || (userInput.ToLower() != "q" && userInput.ToLower() != "r"))
                {
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press 'R' to restart. Press 'Q' to quit.");
                    userInput = Console.ReadLine();
                }
                else break;
            }

            switch (userInput.ToLower())
            {
                case "r":
                    Console.Clear();
                    GetUserInput();
                    break;
                case "q":
                    System.Environment.Exit(0);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    throw new Exception();
            }
        }


        static void GetUserInput()
        {
            /* Logan changes:
             * Refactored the isValid logic here to be a bit more clear. Separates validation logic from handling user choice logic.
             * Reset console text color to white after prompt to help better distinguish prompt from input
             */
            Console.WriteLine("Enter [F] to enter a file path.\nEnter [T] to enter your own text to be converted.");
            Console.ForegroundColor = ConsoleColor.White;
            string? userInput = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(userInput) || (userInput.ToLower() != "f" && userInput.ToLower() != "t"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("[F] to convert from a file path or [T] to convert your own text.");
                    Console.ForegroundColor = ConsoleColor.White;
                    userInput = Console.ReadLine();
                }
                else break;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            switch (userInput.ToLower())
            {
                case "f":
                    /* Logan changes:
                        * Changed fileInput to filePath for clarity
                        * Added null/empty validation for file path input
                        * Added validation to check if path exists on device
                     * Perhaps consider mentioning to the user what file types are accepted
                     */
                    Console.WriteLine("Enter a file path: ");
                    string? filePath = Console.ReadLine();

                    // Validation
                    while (true)
                    {
                        if (string.IsNullOrEmpty(filePath) || !Path.Exists(filePath))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a valid file path: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            filePath = Console.ReadLine();
                        }
                        else break;
                    }

                    MorseFunct.FileToMorse(filePath);
                    break;

                case "t":
                    Console.WriteLine("Enter your text: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string? text = Console.ReadLine();  // Removed ToUpper() here because if user enters null it will error

                    while (true)
                    {
                        if (string.IsNullOrEmpty(text))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Text cannot be emtpy. Enter your text: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            text = Console.ReadLine();
                        }
                        else break;
                    }

                    MorseFunct.TranslateToMorse(text.ToUpper());    // Added ToUpper() here
                    break;

                default:
                    Console.WriteLine("Please pick a valid option!");
                    // Removed the console clear here because it made it very confusing to navigate the menu
                    break;
            }

            EndofGame();
        }
    }
}