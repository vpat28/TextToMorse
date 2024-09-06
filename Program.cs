namespace TexttoMorse
{
    public class Program
    {
        public static void Main()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(1000);  Console.WriteLine("████████╗███████╗██╗  ██╗████████╗               ████████╗ ██████╗                ███╗   ███╗ ██████╗ ██████╗ ███████╗███████╗      \r\n╚══██╔══╝██╔════╝╚██╗██╔╝╚══██╔══╝               ╚══██╔══╝██╔═══██╗               ████╗ ████║██╔═══██╗██╔══██╗██╔════╝██╔════╝      \r\n   ██║   █████╗   ╚███╔╝    ██║   █████╗   █████╗   ██║   ██║   ██║█████╗   █████╗██╔████╔██║██║   ██║██████╔╝███████╗█████╗        \r\n   ██║   ██╔══╝   ██╔██╗    ██║   ╚════╝   ╚════╝   ██║   ██║   ██║╚════╝   ╚════╝██║╚██╔╝██║██║   ██║██╔══██╗╚════██║██╔══╝        \r\n   ██║   ███████╗██╔╝ ██╗   ██║         ██╗         ██║   ╚██████╔╝      ██╗      ██║ ╚═╝ ██║╚██████╔╝██║  ██║███████║███████╗██╗██╗\r\n   ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝         ╚═╝         ╚═╝    ╚═════╝       ╚═╝      ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝╚═╝╚═╝\r\n                                                                                                                                    ");
            GetUserInput();
        }
        public static void EndofGame()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press 'R' to restart. Press 'Q' to quit.");
                string userinput = Console.ReadLine();

                switch (userinput.ToLower())
                {
                    case "r":
                        Console.Clear();
                        GetUserInput();
                        isValid = true;
                        break;
                    case "q":
                        System.Environment.Exit(0);
                        Console.ForegroundColor = ConsoleColor.White;
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid option!");
                        Thread.Sleep(1500); Console.Clear();
                        break;

                }
            }
        }

        static void GetUserInput()
        {
            bool validinput = false;
            while (!validinput)
            {
                Console.WriteLine("Press 'F' to enter a file path \n Press 'T' to enter your own text to be converted ");
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "f":
                        Console.WriteLine("Enter a file path: ");
                        string fileInput = Console.ReadLine();
                        MorseFunct.fileToMorse(fileInput);
                        validinput = true;
                        break;
                    case "t":
                        Console.WriteLine("Enter your text: ");
                        string textInput = Console.ReadLine().ToUpper();
                        MorseFunct.TranslateToMorse(textInput);
                        validinput = true;
                        break;
                    default:
                        
                        Console.WriteLine("Please pick a valid option!");
                        Thread.Sleep(1500); Console.Clear();
                        break;
                }

                EndofGame();
            }
        }



    }
}
