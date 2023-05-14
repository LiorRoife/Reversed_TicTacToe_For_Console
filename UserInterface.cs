using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private const string k_SyntacticallyIncorrectInput = "input Syntax Error";        //Syntactically incorrect input
        private const string k_SubstantiallyincorrectInput = "Input Out Of Range";       //Substantially incorrect input

        private const string k_AskForNumberOfGuessesMsg = "Please Enter the maximal number of Guesses for the game (number between 4-10).";
        private const string k_AskForGuesseMsg = "Please type your next move row,col or 'Q' to quit";
        private const string k_AskIfNewGameMsg = "Would you like to start a new game? <Y/N>";
        private const string k_NewGameSymbol = "Y";
        private const string k_NotNewGameSymbol = "N";
        private const string k_QuitGameSymbol = "Q";
       // private const string k_NoMoreGuessesAllowedMsg = "No more guesses allowed. You Lost.";
        private const string k_GoodByeMsg = "Good bye!";
        //methods
        //public GameLogics GameLogics;
        public static void Run()
        {
            GameLogics Game;
            int boardSize;
            int amountOfPlayers;
            string validMove;
            bool isPlayerWon = false;
            int NumOfPlayer = 0;
            bool isEndGame = false;

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
            PrintBoard(Game);//empty board

            while (isEndGame==false)//run game until game ends
            {
                validMove = getPlayerMoveInput(Game);
                ExecuteValidMove(validMove, Game);

                //check if Win / Tie
                isPlayerWon = Game.CheckWinner(ref NumOfPlayer);
                if (isPlayerWon == true)
                {
                    Console.WriteLine("Congratulations Player {0} you are the winner", NumOfPlayer);
                    PrintGameResults(Game);
                    isEndGame = true;
                }
                else
                {
                    if (Game.CheckIfDraw() == true)
                    {
                        Console.WriteLine("The board is full , you are in a TIE");
                        PrintGameResults(Game);
                        isEndGame = true;
                    }
                }
                if(isEndGame==false)
                {
                    Screen.Clear();
                    PrintBoard(Game);
                    Game.SwitchPlayerTurn();
                }


            }

            PrintBoard(Game);//print board after updating move

            /*

            //if yes, print results , ask game 
            io_CurrentGame.SwitchPlayerTurn();

            // if endGame AskForAnotherRound(io_CurrentGame);
            Console.WriteLine(k_AskIfNewGameMsg);
            isNewGame = Console.ReadLine();
            if (string.Compare(isNewGame, k_NewGameSymbol) == 0)
            {
                io_CurrentGame.CurrentBoard.CreateNewBoard();
                PrintBoard(io_CurrentGame);
                io_CurrentGame.PlayerTurn = GameLogics.ePlayerID.Player1Turn;
            }

            else if (string.Compare(isNewGame, k_NotNewGameSymbol) == 0)
            {
                Console.WriteLine(k_GoodByeMsg);
                Environment.Exit(1);
            }

    */
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

            Console.WriteLine("Player {0}, please enter your next move in the format of row,column or 'Q' to quit.", io_CurrentGame.GetCurrentPlayerTurn());
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

        public static void PrintBoard(GameLogics i_CurrentGame)
        {
            Screen.Clear();
            StringBuilder boardBuilder = new StringBuilder();

            // Print first row of numbers
            boardBuilder.Append("  ");
            for (int colNum = 0; colNum < i_CurrentGame.CurrentBoard.BoardSize; colNum++)
            {
                boardBuilder.Append($"{colNum + 1}   ");
            }
            boardBuilder.AppendLine();

            // Print each row
            for (int rowNum = 0; rowNum < i_CurrentGame.CurrentBoard.BoardSize; rowNum++)
            {
                boardBuilder.Append($"{rowNum + 1}|");
                for (int colNum = 0; colNum < i_CurrentGame.CurrentBoard.BoardSize; colNum++)
                {
                    boardBuilder.Append($" {i_CurrentGame.CurrentBoard.GetCellValue(rowNum, colNum)} |");
                }
                boardBuilder.AppendLine();

                boardBuilder.Append(" ");
                for (int colNum = 0; colNum < ((i_CurrentGame.CurrentBoard.BoardSize) * 4) + 1; colNum++)
                {
                    boardBuilder.Append("=");
                }
                boardBuilder.AppendLine();
            }
            Console.WriteLine(boardBuilder.ToString());
        }

        public static void ExecuteValidMove(string i_ValidMove, GameLogics io_CurrentGame)
        {
            string isNewGame;
            int NumOfPlayer = 0;

            if (i_ValidMove.Equals(k_QuitGameSymbol))
            {
                //user {0} quited msg
                //add 1 point to user {1}
                //print score
                //get input (ask if play another game) 
                Console.WriteLine("Player {0} has quited the game.", io_CurrentGame.PlayerTurn);
                if (io_CurrentGame.PlayerTurn == GameLogics.ePlayerID.Player1Turn)
                {
                    io_CurrentGame.PlayerTwo.Score++;
                }
                else//player 2 quited
                {
                    io_CurrentGame.PlayerOne.Score++;
                }
                PrintGameResults(io_CurrentGame);
                isNewGame = AskForAnotherRound(io_CurrentGame);
                if (isNewGame.Equals(k_NewGameSymbol))//'Y'
                {
                    //empty board
                    io_CurrentGame.CurrentBoard.CreateNewBoard();
                    PrintBoard(io_CurrentGame);
                    io_CurrentGame.m_PlayerTurn = GameLogics.ePlayerID.Player1Turn;
                }
                else// 'N'
                {
                    Console.WriteLine(k_GoodByeMsg);
                    Thread.Sleep(1000);
                    Environment.Exit(1);
                }
                //Make New game
            }
            else//valid move
            {
                string exportedRow = i_ValidMove.Substring(0,1);
                string exportedCol = i_ValidMove.Substring(2,1);
                int convertedRow = int.Parse(exportedRow);
                int convertedCol = int.Parse(exportedCol);

                if (io_CurrentGame.PlayerTurn == GameLogics.ePlayerID.Player1Turn)
                {
                    io_CurrentGame.CurrentBoard.UpdateChosenCell(convertedRow, convertedCol, io_CurrentGame.PlayerOne.PlayerSymbol);
                }
                else //if (io_CurrentGame.PlayerTurn == GameLogics.ePlayerID.Player1Turn)
                {
                    io_CurrentGame.CurrentBoard.UpdateChosenCell(convertedRow, convertedCol, io_CurrentGame.PlayerTwo.PlayerSymbol);
                }
/*
                PrintBoard(io_CurrentGame);//print board after updating move

                //check if Win / Tie
                bool isPlayerWon = io_CurrentGame.CheckWinner(ref NumOfPlayer);
                if (isPlayerWon == true)
                {
                    Console.WriteLine("Congratulations Player {0} you are the winner", NumOfPlayer);
                    PrintGameResults(io_CurrentGame);
                }
                else
                {
                    if (io_CurrentGame.CheckIfDraw() == true)
                    {
                        Console.WriteLine("The board is full , you are in a TIE");
                        PrintGameResults(io_CurrentGame);
                    }
                }


                //if yes, print results , ask game 
                io_CurrentGame.SwitchPlayerTurn();
                // if endGame AskForAnotherRound(io_CurrentGame);
                Console.WriteLine(k_AskIfNewGameMsg);
                isNewGame = Console.ReadLine();
                if (string.Compare(isNewGame, k_NewGameSymbol) == 0)
                {
                    io_CurrentGame.CurrentBoard.CreateNewBoard();
                    PrintBoard(io_CurrentGame);
                    io_CurrentGame.PlayerTurn = GameLogics.ePlayerID.Player1Turn;
                }

                else if (string.Compare(isNewGame, k_NotNewGameSymbol) == 0)
                {
                    Console.WriteLine(k_GoodByeMsg);
                    Environment.Exit(1);
                }
*/
            }
        }

        public static void PrintGameResults(GameLogics i_CurrentGame)
        {
            Console.Write($"Game Results:{ Environment.NewLine}");
            Console.WriteLine("Player One Score: {0} , Player Two Score: {1}.", i_CurrentGame.PlayerOne.Score, i_CurrentGame.PlayerTwo.Score);
        }

        public static string AskForAnotherRound(GameLogics i_CurrentGame)
        {
            string validInputString;

            Console.WriteLine("If you want to play another round press {0}, else press {1}.", k_NewGameSymbol, k_NotNewGameSymbol);
            validInputString = Console.ReadLine();
            while (!(validInputString.Equals(k_NewGameSymbol) || validInputString.Equals(k_NotNewGameSymbol)))
            {
                Console.WriteLine("Invalid input, please enter {0} for new game or {1} to exit.", k_NewGameSymbol, k_NotNewGameSymbol);
                validInputString = Console.ReadLine();
            }
            return validInputString;
        }
    }
}
