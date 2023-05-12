using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

//TO DO:

//intreface.run
//Ask for input size
//Check Input with the game logics
//Ask PVP or PVAI
//Print empty board

//while(not Q , not EndGame)
//MakeTurn:
//get X,Y choice until it's legal or Q
//check validity and print error if Cell is taken

//clear prev board and print new board

//Check EndGame?
//-no , switch player
//-yes (if vertical / diagonal / horizontal win / TIE / Q) print winner & score
//ask user if he wants new game (with same score and board size)

namespace Reversed_TicTacToe_For_Console
{
    public class UserInterface
    {
        //public GameLogics GameLogics;
        public static void Run()
        {
            int boardSize;
            int players;
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            boardSize= GetGameBoardSizeInput();
            players= GetAmountOfPlayers();

            GameLogics Game= new GameLogics()
            //set logics: BoardSize , PVP?
            int userInputBoardSize = 0;
            int userInputNumberOfPlayers = 0;
            string userInput = Console.ReadLine();
            UserInterface.
            while (CheckBoardSizeValidity(userInput) != true)
            {
                userInput = Console.ReadLine();
            }


        }

        public static int GetGameBoardSizeInput()
        {
            int userInputBoardSize = 0;
            string inputString;

            Console.WriteLine("Please enter the size of the game board (the board is square shaped and its' size must be between 3 to 9):");
            inputString = Console.ReadLine();
            while (CheckBoardSizeValidity(inputString) != true)
            {
                inputString = Console.ReadLine();
            }
            userInputBoardSize = int.Parse(inputString);

            return userInputBoardSize;
        }

        public static bool CheckBoardSizeValidity(string i_InputStringFromUser)
        {
            bool isValidInput = false;
            if (i_InputStringFromUser.All(char.IsDigit) == true)
            {
                if (int.Parse(i_InputStringFromUser) > 2 && int.Parse(i_InputStringFromUser) < 10)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number between 3-9");
                    isValidInput = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number");
                isValidInput= false;
            }

            return isValidInput;
        }

        public static int GetAmountOfPlayers()
        {
            int userInputAmountPlayers = 0;
            string inputString;

            Console.WriteLine("Please enter the amount of players (1 for Palyer VS Computer , 2 For Player VS Player:");
            inputString = Console.ReadLine();
            while (CheckAmountOfPlayersValidity(inputString) != true)
            {
                inputString = Console.ReadLine();
            }
            userInputAmountPlayers = int.Parse(inputString);
           // ticTacToeLogic = new GameLogic(boardSizeUserInput, numOfHumanPlayersUserInput);
            return userInputAmountPlayers;
        }

        public static bool CheckAmountOfPlayersValidity(string i_InputStringFromUser)
        {
            bool isValidInput = false;

            if (i_InputStringFromUser.All(char.IsDigit) == true)
            {
                if (int.Parse(i_InputStringFromUser) > 0 && int.Parse(i_InputStringFromUser) < 3)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number");
                    isValidInput= false;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number");
                isValidInput= false;
            }

            return isValidInput;
        }
    }
}


/*
            Screen.Clear();
            //Print first row of number.
            Console.Write("  ");
            for (int colNum = 0; colNum < 5; colNum++)
            {
                Console.Write("{0}   ", colNum + 1);
            }
            Console.WriteLine();
            //Print each row.
            for (int rowNum = 0; rowNum < 5; rowNum++)
            {
                Console.Write("{0}|", rowNum + 1);
                for (int colNum = 0; colNum < 5; colNum++)
                {
                    Console.Write(" {0} |", " "); // board[x,y]
                }
                Console.WriteLine();
                Console.Write(" ");
                for (int colNum = 0; colNum < (5 * 4) + 1; colNum++)
                {
                    Console.Write("=");
                }
                Console.WriteLine();
            }

            Console.WriteLine("enter size");
            size = Console.ReadLine();
            */
