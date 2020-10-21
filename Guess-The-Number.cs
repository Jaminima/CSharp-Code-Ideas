using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Code_Ideas
{
    public static class Guess_The_Number
    {
        static Random Rnd = new Random();

        public static void PlaySimple(int Rounds = 3, int Limit = 10)
        {
            //Stores for information
            int Target, intInput;
            string input;

            for (int i = 0; i < Rounds; i++) //Loop through the number of times there are rounds
            {
                input = "TEXT TO FORCE ERROR"; //Need to force the TryParse to error

                Target = Rnd.Next(0, Limit); //Pick a random number between 0 and Limit

                //While the input cant be converted to an int. IE it contains letters/symbols
                while (!int.TryParse(input, out intInput)) //If successful the int is stored in intInput
                {
                    Console.WriteLine($"Pick a number between 0 and {Limit} : "); //Prompt the user to pick a number
                    input = Console.ReadLine(); //Read the users result
                }

                //Check if the Target and input match
                if (intInput == Target) Console.WriteLine("You got it right!"); //Tell the user they got it right
                else Console.WriteLine($"Incorrect it was {Target}"); //Tell the user the correct answer
            }
        }
    }
}
