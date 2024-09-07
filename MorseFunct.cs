using System;
using TexttoMorse;

public class MorseFunct
{
    public static Dictionary<char, string?> morseCodeDictionary = new Dictionary<char, string?>
    {
        { 'A', ".-" }, { 'B', "-..." }, { 'C', "-.-." }, { 'D', "-.." },
        { 'E', "." }, { 'F', "..-." }, { 'G', "--." }, { 'H', "...." },
        { 'I', ".." }, { 'J', ".---" }, { 'K', "-.-" }, { 'L', ".-.." },
        { 'M', "--" }, { 'N', "-." }, { 'O', "---" }, { 'P', ".--." },
        { 'Q', "--.-" }, { 'R', ".-." }, { 'S', "..." }, { 'T', "-" },
        { 'U', "..-" }, { 'V', "...-" }, { 'W', ".--" }, { 'X', "-..-" },
        { 'Y', "-.--" }, { 'Z', "--.." },
        { '0', "-----" }, { '1', ".----" }, { '2', "..---" }, { '3', "...--" },
        { '4', "....-" }, { '5', "....." }, { '6', "-...." }, { '7', "--..." },
        { '8', "---.." }, { '9', "----." },
        { '.', ".-.-.-" }, { ',', "--..--" }, { '?', "..--.." }, { '!', "-.-.--" },
        { ':', "---..." }, { ';', "-.-.-." }, { '(', "-.--." }, { ')', "-.--.-" },
        { '&', ".-..." }, { '=', "-...-" }, { '+', ".-.-." }, { '-', "-....-" },
        { '_', "..--.-" }, { '"', ".-..-." }, { '$', "...-..-" }, { '@', ".--.-." },
        { '\'', ".----." }, { '/', "-..-." }, {' '," " }
    };


    static void ConvertToMorse(string input)
    {
        string MorseEquivalent;

        foreach (char c in input)
        {
            MorseEquivalent = morseCodeDictionary.GetValueOrDefault(c, null);
            Console.Write(MorseEquivalent);
            Console.Write("  ");
            if (c.Equals(' '))
            {
                Console.WriteLine("\n");
            }
        }
    }


    public static void TranslateToMorse(string input)
    {
        char delimiter = '\u001F'; // Universal string end character
        input = input + delimiter;
        string MorseEquivalent;
        string tempword = " ";
        CharEnumerator parse = input.GetEnumerator();
        bool test = false;

        while (!test)
        {
            parse.MoveNext();
            char c = parse.Current;

            try
            {
                MorseEquivalent = morseCodeDictionary.GetValueOrDefault(c, null);
                tempword = tempword + c;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(MorseEquivalent);
                if (!c.ToString().Equals(" ") && !(c.Equals(delimiter)))
                {
                    string whitespaceString = new string(' ', MorseEquivalent.Length);
                    if (MorseEquivalent.Length == 1)
                    {
                        tempword += whitespaceString + " ";
                    }
                    else
                    {
                        tempword += whitespaceString + " ";
                    }

                }
                Console.Write("  ");
                if (c.Equals(' ') || c.Equals(delimiter))
                {
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(tempword);
                    Console.WriteLine("\n");
                    tempword = "";
                    Console.WriteLine();
                    if (c.Equals(delimiter))
                    {
                        test = true;
                        break;
                    }
                }
            }
            catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n" + "The character: ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(c.ToString()); 

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" does NOT exist in Morse Code. Try something else.");
                Console.WriteLine("");

                Program.EndofGame();
                throw new Exception("Not a valid morse code character!"); 
            }
        }
    }

  
    public static void FileToMorse(string filename)
    {
        try
        {
            // Open the text file using a stream reader.
            using StreamReader reader = new StreamReader(filename);

            // Read the stream as a string.
            string text = reader.ReadToEnd();
            // string text = reader.ReadLine();

            //foreach (char c in text)
            //{
            //    TranslateToMorse(c.ToString());
            //}
            //calling convert method



            // Write the text to the console.
             Console.WriteLine(text);
            text  = text.ToUpper();
            text = text.TrimEnd();
            text = text.TrimStart();
            TranslateToMorse(text);
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}