using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Reversed_TicTacToe_For_Console
{
    public class UserInterface
    {
        private const string k_WelcomeMsg = "Welcome to Tic-Tac-Toe!";
        private const string k_BoardFullMsg = "The board is full, there is a TIE.";
        private const string k_IvalidMoveMsg = "Invalid move input, please make sure you choose empty cell or 'Q' to quit.";
        private const string k_InvalidAmountOfPlayersMsg = "Invalid input, please enter a number between 1 to 2.";
        private const string k_AskForAmountOfPlayersMsg = "Please enter the amount of players (1 for Palyer VS Computer, 2 for Player VS Player):";
        private const string k_AskForBoardSizeMsg = "Please enter the size of the game board (the board is square shaped and its' size must be between 3 to 9):";
        private const string k_InvalidBoardSizeMsg = "Invalid input, please enter a number between 3 to 9.";

        private const string k_NewGameSymbol = "Y";
        private const string k_NotNewGameSymbol = "N";
        private const string k_QuitGameSymbol = "Q";
        private const string k_GoodByeMsg = "Good bye!";

        //methods
        public static void Run()
        {
            GameLogics Game;
            int boardSize;
            int amountOfPlayers;

            Console.WriteLine(k_WelcomeMsg);
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
            RunGame(Game);
        }

        public static int GetGameBoardSizeInput()
        {
            int userInputBoardSize = 0;
            string inputString;

            Console.WriteLine(k_AskForBoardSizeMsg);
            inputString = Console.ReadLine();

            while (GameLogics.CheckBoardSizeValidity(inputString) != true)
            {
                Console.WriteLine(k_InvalidBoardSizeMsg);
                inputString = Console.ReadLine();
            }
            userInputBoardSize = int.Parse(inputString);

            return userInputBoardSize;
        }

        public static int GetAmountOfPlayers()
        {
            int userInputAmountPlayers = 0;
            string inputString;

            Console.WriteLine(k_AskForAmountOfPlayersMsg);
            inputString = Console.ReadLine();
            while (GameLogics.CheckAmountOfPlayersValidity(inputString) != true)
            {
                Console.WriteLine(k_InvalidAmountOfPlayersMsg);
                inputString = Console.ReadLine();
            }
            userInputAmountPlayers = int.Parse(inputString);

            return userInputAmountPlayers;
        }

        private static string getPlayerMoveInput(GameLogics io_CurrentGame)
        {
            string inputString;

            if (io_CurrentGame.IsPlayerVsAI == true)
            {
                if (io_CurrentGame.PlayerTurn == GameLogics.ePlayerID.Player1Turn)
                {
                    Console.WriteLine("Player {0}, please enter your next move in the format of row,column or 'Q' to quit.", io_CurrentGame.GetCurrentPlayerTurn());
                    inputString = Console.ReadLine();

                    while (GameLogics.CheckMoveValidity(inputString, io_CurrentGame) != true)
                    {
                        Console.WriteLine(k_IvalidMoveMsg);
                        inputString = Console.ReadLine();
                    }
                }

                else
                {
                    inputString = io_CurrentGame.CoumputerMove(io_CurrentGame);
                }
            }

            else
            {
                Console.WriteLine("Player {0}, please enter your next move in the format of row,column or 'Q' to quit.", io_CurrentGame.GetCurrentPlayerTurn());
                inputString = Console.ReadLine();

                while (GameLogics.CheckMoveValidity(inputString, io_CurrentGame) != true)
                {
                    Console.WriteLine(k_IvalidMoveMsg);
                    inputString = Console.ReadLine();
                }
            }

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
                boardBuilder.Append($" {colNum + 1}  ");
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

            if (i_ValidMove.Equals(k_QuitGameSymbol))
            {
                PrintBoard(io_CurrentGame);
                Console.WriteLine("Player {0} has quited the game.", io_CurrentGame.GetCurrentPlayerTurn());
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
            }
            else//valid move
            {
                string exportedRow = i_ValidMove.Substring(0, 1);
                string exportedCol = i_ValidMove.Substring(2, 1);
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
                PrintBoard(io_CurrentGame);
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

        public static void RunGame(GameLogics i_CurrentGame)
        {
            string validMove;
            bool v_PlayerWon = false;
            int NumOfPlayer = 0;
            bool v_IsEndGame = false;
            string isNewGame;

            while (v_IsEndGame == false)//run game until game ends
            {
                validMove = getPlayerMoveInput(i_CurrentGame);

                ExecuteValidMove(validMove, i_CurrentGame);
                v_PlayerWon = i_CurrentGame.CheckWinner(ref NumOfPlayer);
                if (v_PlayerWon == true)
                {
                    Console.WriteLine("Congratulations Player {0} you are the winner", NumOfPlayer);
                    PrintGameResults(i_CurrentGame);
                    v_IsEndGame = true;
                }

                else
                {
                    if (i_CurrentGame.CheckIfDraw(i_CurrentGame) == true)
                    {
                        Console.WriteLine(k_BoardFullMsg);
                        PrintGameResults(i_CurrentGame);
                        v_IsEndGame = true;
                    }
                }
                if (v_IsEndGame == false)
                {
                    i_CurrentGame.SwitchPlayerTurn();
                }
                else
                {
                    isNewGame = AskForAnotherRound(i_CurrentGame);
                    ExecuteEndGameDecision(isNewGame, i_CurrentGame);
                    v_IsEndGame = false;
                }
            }
        }

        public static void ExecuteEndGameDecision(string i_IsNewGame, GameLogics io_currGame)
        {
            if (i_IsNewGame.Equals(k_NewGameSymbol))//'Y'
            {
                //empty board
                io_currGame.CurrentBoard.CreateNewBoard();
                PrintBoard(io_currGame);
                io_currGame.m_PlayerTurn = GameLogics.ePlayerID.Player1Turn;
            }

            else// 'N'
            {
                Console.WriteLine(k_GoodByeMsg);
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
        }
    }
}
