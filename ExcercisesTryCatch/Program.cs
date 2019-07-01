using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExcercisesTryCatch
{
    class Program
    {
        static void Main()
        {
            //Module_8_1(true);
            //Module_8_2();
            Module_8_3();
        }
        static void Module_8_3()
        {
            List<string>animalList = new List<string>();
            try
            {
                Console.Write("Enter a list of animals: ");
                string input = GreenInput();

                if (input == string.Empty)
                    throw new Exception("Animal string don't contain any letters");

                string[] animals = input.Split(",");

                foreach (string animal in animals)
                {
                    animal.Trim();
                    if (animal.Length > 12)
                        throw new Exception($"This animal: '{animal}' has too many letters");
                    if (animal == string.Empty)
                        throw new Exception("One of the animals didn't contain any letters");

                    foreach (char c in animal)
                    {
                        if (char.IsLetter(c) == false)
                            throw new Exception($"Animal: '{animal}' contains invalid letters");
                    }
                    animalList.Add(animal);
                }
            }
            catch (Exception e)
            {
                ErrorMsg(e.Message);
                Module_8_3();
            }
            Console.WriteLine($"There are {animalList.Count()} animals in the list");
            Module_8_3();
        }
        static void Module_8_2()
        {
            string correctPath = "C:\\TMP";

            Console.Write("Enter a file name: ");
            try
            {
                string input = GreenInput();

                if (input.Substring(0, 6).ToUpper() != correctPath)
                    throw new Exception("You're not authorized to create this file!");
                if (input.Substring(input.Length - 4, 4).ToUpper() != ".TXT")
                    throw new Exception("The filename is not valid");


                using(StreamWriter sw = File.CreateText(input))
                {
                    Console.Write("Enter text: ");
                    sw.WriteLine(GreenInput());
                }

                Console.WriteLine($"The file '{input}' is now created");
            }
            catch(DirectoryNotFoundException)
            {
                ErrorMsg("Input output exception");
            }
            catch (Exception e)
            {
                ErrorMsg(e.Message);
            }
            Module_8_2();
        }
        static void Module_8_1(bool reset)
        {
            int numerator = 24;

            if (reset == true)
                Console.WriteLine($"The chocolate contaons {numerator} pieces.");

            try
            {
                Console.Write("How many people want to share? ");
                int denominator = int.Parse(GreenInput());
                if (denominator < 0)
                    throw new NegativeNumberException();

                if (denominator == 666)
                    throw new DevilException();

                Console.WriteLine($"Everyone get {numerator / denominator} pieces");
            }
            catch (DivideByZeroException e)
            {
                //ErrorMsg("Zero people can't divide a chocolate ");
                ErrorMsg(e.Message);
            }
            catch(NegativeNumberException e)
            {
                ErrorMsg(e.Message);
            }
            catch(DevilException e)
            {
                ErrorMsg(e.Message);
            }
            Console.ReadLine();
            Module_8_1(false);
        }
        static string GreenInput()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }
        static void ErrorMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {
            
        }
        public NegativeNumberException(string message) : base(message)
        {

        }
        public NegativeNumberException(string message, Exception inner) : base(message, inner)
        {

        }
    }
    public class DevilException : Exception
    {
        public DevilException()
        {

        }
        public DevilException(string message) : base(message)
        {

        }
        public DevilException(string message, Exception inner) : base(message, inner)
        {

        }
    }

}
