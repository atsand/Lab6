using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin translator.");
            Start();
        }

        //get the input and start translation loops
        public static void Start()
        {
            Console.WriteLine("Enter a word or sentence to translate:");
            string input = Console.ReadLine();
            if (input.Count() == 0)
            {
                Console.WriteLine("Input cannot be blank");
                Start();
            }
            else
            {
                input = input.Trim();
                input = Regex.Replace(input, @"\s+", " ");
                string[] sentenceArray = input.Split(' ');
                foreach (string word in sentenceArray)
                {
                    Translate(word);
                }
                Console.WriteLine();
                TranslateAgain();
            }
        }
            
        //check if first letter is a vowel
        public static bool FirstIsVowel(char c)
        {

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(c);

        }

        //return index of first vowel as an int
        public static int FindVowel(string input)
        {
            char[] wordArray = input.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char letter in wordArray)
            {
                if (vowels.Contains(letter))
                {
                    return Array.IndexOf(wordArray, letter);
                }
            }
            return wordArray.Length;
        }

        //translate word into Pig Latin and print
        public static void Translate(string input)
        {
            input = input.Trim(' ');
            char[] endPunctuations = { '!', '%', ',', '.', '?', ';', '"' };
            string punctuationHold = " ", last = input.Last().ToString();
            Regex rgx = new Regex("[A-Za-z]");
            

            if (!rgx.IsMatch(last))
            {
                punctuationHold = (input[input.Length - 1].ToString() + " ");
                input = input.Substring(0, input.Length - 1);
            }

            string lowerInput = input.ToLower();

            if (ContainsSymbolNumber(input))
            {
                Console.WriteLine(input +punctuationHold.ToString());
            }
            else if(FirstIsVowel(lowerInput[0]))
            {
                Console.Write(input + "way" + punctuationHold.ToString());
                return;
            }
            else
            {
                int index = FindVowel(lowerInput);
                Console.Write(input.Substring(index) + input.Substring(0, index) + "ay" + punctuationHold.ToString());
            }
        }

        //checks if the individual work contains a symbol or number
        public static bool ContainsSymbolNumber(string input)
        {
            Regex rgx = new Regex("[A-Za-z']");
            foreach (char x in input)
            {
                if (!rgx.IsMatch(x.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
     
        //ask if user would like to translate something else
        public static void TranslateAgain()
        {
            string input;

            Console.WriteLine("Would you like to translate something else? (Y/N)");
            input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Start();
            }
            else if (input.ToLower() == "n")
            {
                Console.WriteLine("Oodbyegay!");
            }
            else
            {
                Console.WriteLine("Sorry, I couldn't understand your input.");
                TranslateAgain();
            }
        }
    }
}
