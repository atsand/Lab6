﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (char vowel in vowels)
            {
                if (vowel==c)
                {
                    return true;
                }
            }
            return false;
        }

        //if the first letter is a vowel, run this to print
        public static void FirstIsVowelPrint(string input)
        {
            Console.Write(input + "way ");
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

        //translate word not starting in vowel into Pig Latin and print
        public static void Translate(string input)
        {
            string lowerInput = input.ToLower();
            if (FirstIsVowel(lowerInput[0]))
            {
                FirstIsVowelPrint(input);
                return;
            }
            else
            {
                int index = FindVowel(lowerInput);
                Console.Write(input.Substring(index) + input.Substring(0, index) + "ay ");
            }
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
