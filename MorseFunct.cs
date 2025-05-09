using System.Text;
using TexttoMorse;

public class MorseFunct
{
    public static Dictionary<char, string?> morseDict = new Dictionary<char, string?>
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


    public static void TranslateToMorse(string input)
    {
        char delimiter = '\u001F'; // Universal string end character
        input = input + delimiter;
        string MorseEquivalent;
        StringBuilder tempWord = new StringBuilder(" ");
        CharEnumerator parse = input.GetEnumerator();
        bool test = false;

        while (!test)
        {
            parse.MoveNext();
            char c = parse.Current;

            try
            {
                MorseEquivalent = morseDict.GetValueOrDefault(c, null);
                tempWord.Append(c);
                Program.ResetConsoleColor();
                Console.Write(MorseEquivalent);

                if (!c.ToString().Equals(" ") && !(c.Equals(delimiter)))
                {
                    string whitespaceString = new string(' ', MorseEquivalent.Length);
                    if (MorseEquivalent.Length == 1)
                    {
                        tempWord.Append(whitespaceString + " ");
                    }
                    else
                    {
                        tempWord.Append(whitespaceString + " ");
                    }
                }

                Console.Write("  ");

                if (c.Equals(' ') || c.Equals(delimiter))
                {
                    Console.WriteLine("\n");
                    Program.SetConsoleColor("blue");
                    Console.WriteLine(tempWord);
                    Console.WriteLine("\n");
                    tempWord.Clear();
                    Console.WriteLine();
                    if (c.Equals(delimiter))
                    {
                        test = true;
                        break;
                    }
                }
            }
            catch (Exception e) {
                Program.SetConsoleColor("yellow");
                Console.Write("\n" + "The character ");

                Program.SetConsoleColor("red");
                Console.Write(c.ToString());

                Program.SetConsoleColor("yellow");
                Console.Write(" does NOT exist in Morse Code. Try something else.");
                Console.WriteLine("");

                Program.EndofGame();
                throw new Exception("Not a valid morse code character!"); 
            }
        }
    }

  
    public static void FileToMorse(string fileName)
    {
        try
        {
            // Open the text file using a stream reader.
            using StreamReader reader = new StreamReader(fileName);

            // Read the stream as a string.
            string text = reader.ReadToEnd();

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