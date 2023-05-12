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
            GameLogics Game;
            int boardSize;
            int amountOfPlayers;
            string validMove;

            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            boardSize = GetGameBoardSizeInput();
            amountOfPlayers = GetAmountOfPlayers();
            if (amountOfPlayers == 1)
            {
                Game = new GameLogics(boardSize, true);//1 player
            }
            else
            {
                Game = new GameLogics(boardSize, false);//2 players
            }
            Game.m_CurrentGameBoard.PrintBoard();

            validMove = getPlayerMoveInput(Game);
            ExecuteValidMove(validMove);

            Console.WriteLine("testttttt ");
            Console.WriteLine("test ");

        }

        public static int GetGameBoardSizeInput()
        {
            int userInputBoardSize = 0;
            string inputString;

            Console.WriteLine("Please enter the size of the game board (the board is square shaped and its' size must be between 3 to 9):");
            inputString = Console.ReadLine();
            while (GameLogics.CheckBoardSizeValidity(inputString) != true)
            {
                Console.WriteLine("Invalid input, please enter a number between 3 to 9");
                inputString = Console.ReadLine();
            }
            userInputBoardSize = int.Parse(inputString);

            return userInputBoardSize;
        }

        public static int GetAmountOfPlayers()
        {
            int userInputAmountPlayers = 0;
            string inputString;

            Console.WriteLine("Please enter the amount of players (1 for Palyer VS Computer , 2 for Player VS Player:");
            inputString = Console.ReadLine();
            while (GameLogics.CheckAmountOfPlayersValidity(inputString) != true)
            {
                Console.WriteLine("Invalid input, please enter a number between 1 to 2");
                inputString = Console.ReadLine();
            }
            userInputAmountPlayers = int.Parse(inputString);
            return userInputAmountPlayers;
        }

        private static string getPlayerMoveInput(GameLogics io_CurrentGame)
        {
            string inputString;

            Console.WriteLine("Please enter your next move in the format of row,column or 'Q' to quit.", Environment.NewLine);
            inputString = Console.ReadLine();

            while (GameLogics.CheckMoveValidity(inputString, io_CurrentGame) != true)
            {
                Console.WriteLine("Invalid move input, please make sure you choose empty cell or 'Q' to quit.");
                inputString = Console.ReadLine();
            }
            // if player press q so go to EndGame
            // getPlayerMove(io_CurrentGame);
            return inputString;
        }

  
    }
}
