using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Code_Ideas
{
    public static class Tic_Tac_Toe
    {
        //Store the state of the 3x3 grid
        static State[] Grid;

        public enum State //Allows us to have custom values for the state, in our case BLANK(_) or X or O
        {
            _, X, O
        }

        public static void PlayTicTacToe()
        {
            Grid = new State[9]; //Create a 3x3 grid of BLANK(_)
            State player = State.X; //Start with player X

            while (Victory() == State._) //While no one has won
            {
                DoTurn(player); //Run the DoTurn Function
                player = (State) ((int)player % 2) + 1; //Moves us to the next player
            }

            Console.Clear();
            Console.WriteLine($"{Victory()} Won The Game");
            ShowGrid();
        }

        private static State Victory()
        {
            for (int i = 0; i < 3; i++) //Check Each Collumn and Row
            {
                if (Grid[i] == Grid[i + 1] && Grid[i] == Grid[i + 2]) return Grid[i]; //If a Row is all one State return a win
                else if (Grid[i] == Grid[i + 3] && Grid[i] == Grid[i + 6]) return Grid[i]; //If a collumn is all one State return a win
            }

            if (Grid[0] == Grid[4] && Grid[0] == Grid[8]) return Grid[0]; //Check diagonals for a win
            if (Grid[2] == Grid[4] && Grid[2] == Grid[6]) return Grid[2];

            return State._; //Just return that no one has won
        }

        private static void ShowGrid()
        {
            // \n indicates a new line should be added here
            // {Grid[x]} will be replaced by the value in our state array
            Console.WriteLine($"1,2,3 {Grid[0]} {Grid[1]} {Grid[2]}\n4,5,6 {Grid[3]} {Grid[4]} {Grid[5]}\n7,8,9 {Grid[6]} {Grid[7]} {Grid[8]}");
        }

        private static void DoTurn(State playerSymbol)
        {
            string Position = "TEXT TO FORCE ERROR";
            int p = -1;

            while ((!int.TryParse(Position, out p) //Check that the user input is a valid number
                || p < 1 || p > 9) //Ensure the user number is withing the bounds
                || Grid[p-1] != State._) //Ensure the position is BLANK(_)
            {
                Console.Clear(); //Prompt the user to input
                Console.WriteLine($"Player {playerSymbol}\nInput a grid position");
                ShowGrid();

                Position = Console.ReadLine();
            }

            p -= 1; //User inputs between 1-9, but array is 0-8 so need to shift

            Grid[p] = playerSymbol; //Set the position in the grid to the players symbol
        }
    }
}
