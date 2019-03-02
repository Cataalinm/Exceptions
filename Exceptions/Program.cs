using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static List<int> correctNumbers = new List<int>();
        static void Main(string[] args)
        {
            StreamReader();
            string line;
            Console.WriteLine();
            Console.WriteLine("Numbers are: ");
            //Print("correctNumbers.txt");
            for (int i = 0; i < correctNumbers.Count; i++)
            {
                Console.WriteLine(correctNumbers[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The other strings are: ");
            Print("incorrectNumbers.txt");
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();

            //deleting the files when the application is closed otherwise the strings will be appended everytime the application runs. 
            File.Delete("correctNumbers.txt");
            File.Delete("incorrectNumbers.txt");
        }

        //Method to read from file line by line.
        //Each line will be then divided into words. Words are separated by a space " ".  
        //The number of words is then counted for each line so we know how many strings we have to parse. 
        private static void StreamReader(string file = "Numbers.txt")
        {
            string line;
            string[] words;
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    Console.WriteLine("Full text is: ");
                    while ((line = reader.ReadLine()) != null)
                    {
                        words = line.Split(' ');
                        int n = 0;
                        Console.WriteLine(line);
                        foreach (string aux in words)
                        {
                            if(aux !=" ")
                            {
                                n++;
                            }
                        }
                        for(int i=0; i<n; i++)
                        {
                            TryParse(words[i]);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("File doesn't exist!");
            }
        }

        //Method that does the parsing and writes every string into the correct file using a streamwriter. 
        //Every string will be reconstructed into a number using the ASCII codes. 
        //If the new created number is exactly the same as the old word, then it's a number, otherwise it's another type of string. 
        //Numbers will also be written inside a list. 
        private static void TryParse(string text)
        {
            int number = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    int digit = text[i] - 48;
                    number = number * 10 + digit;
                }
                if (string.Compare(number.ToString(), text) == 0)
                {
                    correctNumbers.Add(number);
                    StreamWriter("correctNumbers.txt", text);
                }
                else
                {
                    StreamWriter("incorrectNumbers.txt", text);
                } 
             
        }

        //Method to write into a txt file. 
        private static void StreamWriter(string file, string text)
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(text);
            }
        }

        //Method to write the correct/incorrect numbers in the console. 
        private static void Print(string file)
        {
            string line;
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch
            {
                Console.WriteLine("File doesn't exist!");
            }
            Console.WriteLine();
        }
    }

    
}
