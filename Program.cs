using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace TheScrabbleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrabble Test! V1.0"); 
            //Do this until the esc key is pressed
            do
            {
                try
                {
                    Console.WriteLine("\nPlease enter a word to be scored:");
                    var ScrabbleWord = new Word(Console.ReadLine());
                    Console.WriteLine("Your word is: {0}", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ScrabbleWord.Value.ToLower()));
                    Console.WriteLine("Your letter score is: {0}", ScrabbleWord.GetLetterPoints());
                    Console.WriteLine("Your bonus score is: {0}", ScrabbleWord.GetBonusPoints());
                    Console.WriteLine("Your multplier is: {0}", ScrabbleWord.GetMultiplier());
                    Console.WriteLine("Your total score is: {0}\n", ScrabbleWord.Score);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
                Console.WriteLine("Hit the ESC key to end or other key to contiue");
            
            } 
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
