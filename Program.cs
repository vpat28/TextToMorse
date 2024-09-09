﻿namespace TexttoMorse
{
    public class Program
    {

        //Awesome idea, and the execution is super cool, enjoyed this project
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
                //Nice Job! I liked the input validation here! I did enter a null value but didn't get an error message or option to restart. Maybe if we could add that in here that would be awesome.
                /* Something like this snippet?

                     if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Input cannot be null or empty. Please try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    continue;
                }
                */
                
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
                        while (userInput.Contains('#'))
                        {
                            Console.WriteLine("Text cannot contain #. Please try again\n");
                            textInput = Console.ReadLine().ToUpper();
                        }
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
