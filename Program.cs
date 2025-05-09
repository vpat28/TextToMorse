namespace TexttoMorse
{
    public class Program
    {
        public static void Main()
        {
            ResetConsoleColor();   // Added this to start of program to ensure default color is restored when the program runs (in case user force quits)
            Console.Clear();
            SetConsoleColor("blue");
            Thread.Sleep(1000);
            Console.WriteLine("████████╗███████╗██╗  ██╗████████╗               ████████╗ ██████╗                ███╗   ███╗ ██████╗ ██████╗ ███████╗███████╗      \r\n╚══██╔══╝██╔════╝╚██╗██╔╝╚══██╔══╝               ╚══██╔══╝██╔═══██╗               ████╗ ████║██╔═══██╗██╔══██╗██╔════╝██╔════╝      \r\n   ██║   █████╗   ╚███╔╝    ██║   █████╗   █████╗   ██║   ██║   ██║█████╗   █████╗██╔████╔██║██║   ██║██████╔╝███████╗█████╗        \r\n   ██║   ██╔══╝   ██╔██╗    ██║   ╚════╝   ╚════╝   ██║   ██║   ██║╚════╝   ╚════╝██║╚██╔╝██║██║   ██║██╔══██╗╚════██║██╔══╝        \r\n   ██║   ███████╗██╔╝ ██╗   ██║         ██╗         ██║   ╚██████╔╝      ██╗      ██║ ╚═╝ ██║╚██████╔╝██║  ██║███████║███████╗██╗██╗\r\n   ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝         ╚═╝         ╚═╝    ╚═════╝       ╚═╝      ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝╚═╝╚═╝\r\n                                                                                                                                    ");
            AppStartup();
        }


        public static void EndofGame()
        {
            /* Logan changes:
             * Refactored the isValid logic here to be a bit more clear. Separates validation logic from handling user choice logic.
             * Changed userinput to userInput
             * Reset console text color to white after prompt to help better distinguish prompt from input
             */
            SetConsoleColor("blue");
            string? userInput = ReadUserInput("Enter [R] to restart. Enter [Q] to quit.");

            while (true)
            {
                if (string.IsNullOrEmpty(userInput) || (userInput.ToLower() != "q" && userInput.ToLower() != "r"))
                {
                    SetConsoleColor("yellow");
                    Console.WriteLine("\n⚠️ Please enter a valid option.");
                    userInput = ReadUserInput("Enter [R] to restart. Enter [Q] to quit.");
                }
                else break;
            }

            switch (userInput.ToLower())
            {
                case "r":
                    Console.Clear();
                    AppStartup();
                    break;
                case "q":
                    System.Environment.Exit(0);
                    ResetConsoleColor();
                    break;
                default:
                    throw new Exception();
            }
        }


        static void AppStartup()
        {
            /* Logan changes:
             * Changed 'GetUserInput' to 'AppStartup' bc I thought it made more sense
             * Implemented ReadUserInput and SetConsoleColor function for more concise code
             * Changed validation/warning messages to yellow text color
             * Refactored the isValid logic here to be a bit more clear. Separates validation logic from handling user choice logic.
             * Reset console text color to white after prompt to help better distinguish prompt from input
             */
            SetConsoleColor("blue");
            string? userInput = ReadUserInput("[F] Convert file to morse.\n[T] Convert entered text to morse.\nChoose:");

            while (true)
            {
                if (string.IsNullOrEmpty(userInput) || (userInput.ToLower() != "f" && userInput.ToLower() != "t"))
                {
                    SetConsoleColor("yellow");
                    Console.WriteLine("\n⚠️ Please enter a valid option.");
                    userInput = ReadUserInput("Enter [F] to convert from a file path or [T] to convert your own text:");
                }
                else break;
            }

            Console.Clear();
            SetConsoleColor("blue");

            switch (userInput.ToLower())
            {
                case "f":
                    /* Logan changes:
                        * Changed fileInput to filePath for clarity
                        * Added null/empty validation for file path input
                        * Added validation to check if path exists on device
                     * Perhaps consider mentioning to the user what file types are accepted
                     */
                    string? filePath = ReadUserInput("Enter a file path:");

                    // Validation
                    while (true)
                    {
                        if (string.IsNullOrEmpty(filePath) || !Path.Exists(filePath))
                        {
                            SetConsoleColor("yellow");
                            Console.WriteLine("\n⚠️ Path does not exist.");
                            filePath = ReadUserInput("Enter a valid file path:");
                        }
                        else break;
                    }

                    MorseFunct.FileToMorse(filePath);
                    break;

                case "t":
                    string? text = ReadUserInput("Enter your text:");   // Removed ToUpper() here because if user enters null it will error
                    Console.WriteLine("\n");

                    while (true)
                    {
                        if (string.IsNullOrEmpty(text))
                        {
                            SetConsoleColor("yellow");
                            text = ReadUserInput("\n⚠️ Text cannot be emtpy. Enter your text:");
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


        // Method to prompt and return user input
        public static string? ReadUserInput(string prompt)
        {
            Console.Write(prompt + " ");
            ResetConsoleColor();
            string? inputLine = Console.ReadLine();

            return string.IsNullOrEmpty(inputLine) ? null : inputLine;
        }


        // Method to remove quotation marks from a file path string
        public static string? RemoveQuotations(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            else
                return path.Trim(new char[] { '"' });
        }


        // Method to change the console text color
        public static void SetConsoleColor(string color)
        {
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }


        // Method to reset the console text color to white
        public static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}