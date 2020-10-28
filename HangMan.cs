using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Code_Ideas
{
    class HangMan
    {
        public static string answer = "secret word";
        public static int numOfChars = 0;
        public static List<char> guesses;
        public static List<char> state;
        public static bool finished = false;
        public const int MAX_WRONG_GUESSES = 10;
        public static void Start()
        {
            Console.Clear();
            state = new List<char>();
            guesses = new List<char>();
            fillState();
            printState(0);
            gameLoop();
        }

        public static void fillState()
        {
            foreach(char c in answer)
            {
                if (c != ' ') state.Add('_');
                else state.Add(' ');
                // Advanced option:
                //state.Add(c == ' ' ? ' ' : '_');
            }
        }

        public static void gameLoop()
        {
            int guessCount = 0;
            while (!finished)
            {
                char playerGues = Char.Parse(Console.ReadLine().ToLower().Substring(0,1));
                if (answer.Contains(playerGues))
                {
                    for(int i = 0; i < answer.Length; i++)
                    {
                        if(answer[i] == playerGues)
                        {
                            state[i] = answer[i];
                        }
                    }
                }
                else
                {
                    guessCount++;
                    if(guessCount == MAX_WRONG_GUESSES)
                    {
                        Console.WriteLine("You lost :(");
                        finished = true;
                    }
                }
                // Winner!
                if (!state.Contains('_'))
                {
                    Console.WriteLine("You won!");
                    finished = true;
                }
                printState(guessCount);
            }
            // Pause the console
            Console.ReadKey();
        }

        public static void printState(int guesses)
        {
            Console.Clear();
            Console.Write("Guesses: ");
            foreach (char c in state)
            {
                Console.Write(c);
            }
            Console.Write('\n');
            Console.WriteLine($"Lives: {guesses} / {MAX_WRONG_GUESSES}");
        }
    }
}
