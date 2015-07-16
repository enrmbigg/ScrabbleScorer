using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheScrabbleTest
{
    class Word
    {
        /// <summary>
        /// Key for each letter and its score value
        /// </summary>
        static Dictionary<char, int> letterValues = new Dictionary<char, int>()
        {
            { 'a', 1 }, { 'b', 4 },
            { 'c', 2 }, { 'd', 3 },
            { 'e', 1 }, { 'f', 2 },
            { 'g', 2 }, { 'h', 3 },
            { 'i', 2 }, { 'j', 5 },
            { 'k', 3 }, { 'l', 2 },
            { 'm', 3 }, { 'n', 3 },
            { 'o', 1 }, { 'p', 5 }, 
            { 'q', 7 }, { 'r', 2 },
            { 's', 1 }, { 't', 2 },
            { 'u', 2 }, { 'v', 8 },
            { 'w', 5 }, { 'x', 7 },
            { 'y', 5 }, { 'z', 8 }
        };

        /// <summary>
        /// Varibles for the length of words 
        /// </summary>
        static int[] lengthOfWords_Multiplier = { 4, 6, 9 };

        /// <summary>
        /// Returns the string
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Returns an array of the letters from the assigned string
        /// </summary>
        public char[] Letters
        {
            get
            {
                return Value.ToArray();
            }
        }

        /// <summary>
        /// Returns the length on the assigned string 
        /// </summary>
        public int Length
        {
            get
            {
                return Letters.Count();
            }
        }

        /// <summary>
        /// Returns the score for the assigned word
        /// </summary>
        public int Score
        {
            get
            {
                return CalculateScore();
            }
        }

        /// <summary>
        /// Initilize class, validates input
        /// </summary>
        /// <param name="input"> The word in which you assign to the instance</param>
        public Word(string input)
        {
            if (input.Length == 0)
            {
                throw new ArgumentException("Input must not be empty.", "input");
            }
            if (input.Contains(" "))
            {
                throw new ArgumentException("Input should only contain a single word.", "input");
            }
            //This regular expression removes all uppercase, numbers and symbols from the string.
            this.Value = Regex.Replace(input.ToLower(), "[^a-z]+", "");
        }


        /// <summary>
        /// Calculates the total score for the word
        /// </summary>
        /// <returns> Calculates the total score for that word (letter points, bonus points and mutipliers)</returns>
        private int CalculateScore()
        {
            int letterPoints = GetLetterPoints();
            int bonusPoints = GetBonusPoints();
            int multiplier = GetMultiplier();
            return (letterPoints + bonusPoints) * multiplier;
        }

        /// <summary>
        /// Calculates the points for each letter in the word
        /// </summary>
        /// <returns>Total score for the letters in the word</returns>
        public int GetLetterPoints()
        {
            var query = from ltr in Letters select letterValues[ltr];
            return query.Sum();
        }

        /// <summary>
        /// Calulates whether the bonus point is awarded 
        /// </summary>
        /// <returns>Returns value of 0 or 3 depending if criteria are met</returns>
        public int GetBonusPoints()
        {
            for (int i = 1; i < this.Letters.Count(); i++)
            {
                //if letter before current and letter current are the same
                //i-1 instead i+1 as it could go over array length
                if (Letters[i - 1] == Letters[i]) return 3;
            }
            return 0;
        }

        /// <summary>
        /// Calulates what multipler is awarded 
        /// </summary>
        /// <returns>Returns Int depending on length of word</returns>
        public int GetMultiplier()
        {
            int i = 0;
            // while i < current length of the multipler list and Length of word is >
            while (i < lengthOfWords_Multiplier.Length && Length > lengthOfWords_Multiplier[i++]) ;
            return i;            
        }
    }
}
