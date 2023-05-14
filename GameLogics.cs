using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversed_TicTacToe_For_Console
{
    public class GameLogics
    {
        public enum ePlayerID
        {
            Player1Turn = 1,
            Player2Turn = 2
        }

        private const int k_MinimumSizeOfBoard = 3;
        private const int k_MaximumSizeOfBoard = 9;
        public const char k_PlayerOneSymbol = 'X';
        public const char k_PlayerTwoSymbol = 'O';
        private readonly Player m_PlayerOne;
        private readonly Player m_PlayerTwo;
        private GameBoard m_CurrentGameBoard;
        private readonly bool r_IsPlayerVsAI;
        private ePlayerID m_PlayerTurn;

        public GameLogics(int i_BoardSize, bool i_IsPlayerVsAI)
        {
            m_PlayerOne = new Player(k_PlayerOneSymbol);
            m_PlayerTwo = new Player(k_PlayerTwoSymbol);
            m_CurrentGameBoard = new GameBoard(i_BoardSize);
            r_IsPlayerVsAI = i_IsPlayerVsAI;
            m_PlayerTurn = ePlayerID.Player1Turn;
        }

        public Player PlayerOne
        {
            get
            {
                return m_PlayerOne;
            }
        }

        public Player PlayerTwo
        {
            get
            {
                return m_PlayerTwo;
            }
        }

        public GameBoard CurrentBoard
        {
            get
            {
                return m_CurrentGameBoard;
            }
        }

        public bool IsPlayerVsAI
        {
            get
            {
                return r_IsPlayerVsAI;
            }
        }

        public ePlayerID PlayerTurn
        {
            get
            {
                return m_PlayerTurn;
            }
            set
            {
                m_PlayerTurn = value;
            }
        }

        public static bool CheckBoardSizeValidity(string i_InputStringFromUser)
        {
            bool v_IsValidInput = false;

            if (i_InputStringFromUser.All(char.IsDigit) == true)
            {
                if (int.Parse(i_InputStringFromUser) < k_MinimumSizeOfBoard || int.Parse(i_InputStringFromUser) > k_MaximumSizeOfBoard)
                {
                    v_IsValidInput = false;
                }

                else
                {
                    v_IsValidInput = true;
                }
            }

            else
            {
                v_IsValidInput = false;
            }

            return v_IsValidInput;
        }

        public static bool CheckAmountOfPlayersValidity(string i_InputStringFromUser)
        {
            bool v_IsValidInput = false;

            if (i_InputStringFromUser.All(char.IsDigit) == true)
            {
                if (int.Parse(i_InputStringFromUser) > 0 && int.Parse(i_InputStringFromUser) < 3)
                {
                    v_IsValidInput = true;
                }

                else
                {
                    v_IsValidInput = false;
                }
            }

            else
            {
                v_IsValidInput = false;
            }

            return v_IsValidInput;
        }

        public static bool CheckMoveValidity(string i_InputStringFromUser, GameLogics i_Game)
        {
            bool v_IsValidInput = false;

            if ((i_InputStringFromUser.Length == 1 && i_InputStringFromUser.Contains('Q')))
            {
                v_IsValidInput = true;
            }

            else
            {
                if (i_InputStringFromUser.Length == 3 && i_InputStringFromUser[1] == ',')
                {
                    int convertedInputRow;
                    int convertedInputCol;
                    string firstNumber = i_InputStringFromUser.Substring(0, 1);
                    string secondNumber = i_InputStringFromUser.Substring(2, 1);

                    if ((int.TryParse(firstNumber, out convertedInputRow) == true) && (int.TryParse(secondNumber, out convertedInputCol) == true))
                    {
                        if (checkRowOrColumnValidity(convertedInputRow, i_Game) == true && checkRowOrColumnValidity(convertedInputCol, i_Game))
                        {
                            if (i_Game.CurrentBoard.GetCellValue(convertedInputRow - 1, convertedInputCol - 1) == ' ')
                            {
                                v_IsValidInput = true;
                            }

                            else
                            {
                                v_IsValidInput = false;
                            }
                        }

                        else
                        {
                            v_IsValidInput = false;
                        }
                    }

                    else
                    {
                        v_IsValidInput = false;
                    }
                }

                else
                {
                    v_IsValidInput = false;
                }
            }

            return v_IsValidInput;
        }

        private bool checkIsCellEmpty(int i_row, int i_col)
        {
            bool v_IsCellEmpty = false;

            if (CurrentBoard.Matrix[i_row - 1, i_col - 1] == ' ')
            {
                v_IsCellEmpty = true;
            }

            return v_IsCellEmpty;
        }

        private void addScoreToPlayer(int i_Player)
        {
            if (i_Player == 1)
            {
                PlayerOne.Score++;
            }

            if (i_Player == 2)
            {
                PlayerTwo.Score++;
            }
        }

        private bool checkHorizontal(ref int io_numOfPlayer)
        {
            bool v_PlayerWon = false;
            int playerOneScoreCounter = 0;
            int playerTwoScoreCounter = 0;

            for (int row = 0; row < CurrentBoard.BoardSize; row++)
            {
                for (int col = 0; col < CurrentBoard.BoardSize; col++)
                {
                    if (CurrentBoard.Matrix[col, row] == PlayerOne.PlayerSymbol)
                    {
                        playerOneScoreCounter++;
                    }

                    if (CurrentBoard.Matrix[col, row] == PlayerTwo.PlayerSymbol)
                    {
                        playerTwoScoreCounter++;
                    }
                }

                if (playerOneScoreCounter == CurrentBoard.BoardSize || playerTwoScoreCounter == CurrentBoard.BoardSize)
                {
                    if (playerOneScoreCounter == CurrentBoard.BoardSize)
                    {
                        io_numOfPlayer = 2;
                    }

                    else
                    {
                        io_numOfPlayer = 1;
                    }

                    v_PlayerWon = true;
                }

                playerOneScoreCounter = 0;
                playerTwoScoreCounter = 0;
            }

            return v_PlayerWon;
        }
        private bool checkDiagonal(ref int io_numOfPlayerWon)
        {
            bool v_PlayerWon = false;
            int col = CurrentBoard.BoardSize - 1;
            int playerOneCounter = 0;
            int playerTwoCounter = 0;

            for (int i = 0; i < CurrentBoard.BoardSize; i++)
            {
                if (CurrentBoard.Matrix[i, i] == PlayerOne.PlayerSymbol)
                {
                    playerOneCounter++;
                }

                if (CurrentBoard.Matrix[i, i] == PlayerTwo.PlayerSymbol)
                {
                    playerTwoCounter++;
                }

                if (playerOneCounter == CurrentBoard.BoardSize || playerTwoCounter == CurrentBoard.BoardSize)
                {
                    if (playerOneCounter == CurrentBoard.BoardSize)
                    {
                        io_numOfPlayerWon = 2;
                    }

                    else
                    {
                        io_numOfPlayerWon = 1;
                    }

                    v_PlayerWon = true;
                }
            }

            playerOneCounter = 0;
            playerTwoCounter = 0;

            for (int row = 0; row < CurrentBoard.BoardSize; row++)
            {
                if (CurrentBoard.Matrix[row, col] == PlayerOne.PlayerSymbol)
                {
                    playerOneCounter++;
                }

                if (CurrentBoard.Matrix[row, col] == PlayerTwo.PlayerSymbol)
                {
                    playerTwoCounter++;
                }

                col--;
                if (playerOneCounter == CurrentBoard.BoardSize || playerTwoCounter == CurrentBoard.BoardSize)
                {
                    if (playerOneCounter == CurrentBoard.BoardSize)
                    {
                        io_numOfPlayerWon = 2;
                    }

                    else
                    {
                        io_numOfPlayerWon = 1;
                    }

                    v_PlayerWon = true;
                }
            }

            return v_PlayerWon;
        }

        private bool checkVertical(ref int io_numOfPlayerWon)
        {
            bool v_PlayerWon = false;
            int playerOneCounter = 0;
            int playerTwoCounter = 0;

            for (int row = 0; row < CurrentBoard.BoardSize; row++)
            {
                for (int col = 0; col < CurrentBoard.BoardSize; col++)
                {
                    if (CurrentBoard.Matrix[row, col] == PlayerOne.PlayerSymbol)
                    {
                        playerOneCounter++;
                    }
                    if (CurrentBoard.Matrix[row, col] == PlayerTwo.PlayerSymbol)
                    {
                        playerTwoCounter++;
                    }
                }

                if (playerOneCounter == CurrentBoard.BoardSize || playerTwoCounter == CurrentBoard.BoardSize)
                {
                    if (playerOneCounter == CurrentBoard.BoardSize)
                    {
                        io_numOfPlayerWon = 2;
                    }
                    else
                    {
                        io_numOfPlayerWon = 1;
                    }

                    v_PlayerWon = true;
                }

                playerOneCounter = 0;
                playerTwoCounter = 0;
            }

            return v_PlayerWon;
        }

        public bool CheckIfTie(GameLogics i_CurrentGame)
        {
            bool v_IsDraw = false;

            if (i_CurrentGame.CurrentBoard.AmountOfMarkedBoardCells == i_CurrentGame.CurrentBoard.BoardSize * i_CurrentGame.CurrentBoard.BoardSize)
            {
                v_IsDraw = true;
            }

            return v_IsDraw;
        }

        public bool CheckWin(ref int io_PlayerWonNum)
        {
            bool v_PlayerWon = false;
            int playerWonNum = 0;
            bool verticalWin = checkVertical(ref playerWonNum);
            bool HorizontalWin = checkHorizontal(ref playerWonNum);
            bool DiagonalWin = checkDiagonal(ref playerWonNum);

            if (verticalWin == true || HorizontalWin == true || DiagonalWin == true)
            {
                addScoreToPlayer(playerWonNum);
                io_PlayerWonNum = playerWonNum;
                v_PlayerWon = true;
            }

            return v_PlayerWon;
        }

        private static bool checkRowOrColumnValidity(int i_InputRowOrCol, GameLogics i_Game)
        {
            bool v_IsValidInput = false;
            int boardSize = i_Game.CurrentBoard.BoardSize;

            if ((i_InputRowOrCol >= 1 && i_InputRowOrCol <= boardSize))
            {
                v_IsValidInput = true;
            }

            else
            {
                v_IsValidInput = false;
            }

            return v_IsValidInput;
        }

        public void SwitchPlayerTurn()
        {
            if (PlayerTurn == ePlayerID.Player1Turn)
            {
                PlayerTurn = ePlayerID.Player2Turn;
            }

            else
            {
                PlayerTurn = ePlayerID.Player1Turn;
            }
        }

        public int GetCurrentPlayerTurn()
        {
            int currPlayer;

            if (PlayerTurn == ePlayerID.Player1Turn)
            {
                currPlayer = 1;
            }

            else
            {
                currPlayer = 2;
            }

            return currPlayer;
        }

        public string CoumputerMove(GameLogics i_CurrentGame)
        {
            Random computerMove = new Random();
            string computerMoveInputString;
            int computerMoveRow;
            int computerMoveColumn;

            computerMoveRow = computerMove.Next(1, i_CurrentGame.CurrentBoard.BoardSize + 1);
            computerMoveColumn = computerMove.Next(1, i_CurrentGame.CurrentBoard.BoardSize + 1);
            while (i_CurrentGame.checkIsCellEmpty(computerMoveRow, computerMoveColumn) == false)
            {
                computerMoveRow = computerMove.Next(1, i_CurrentGame.CurrentBoard.BoardSize + 1);
                computerMoveColumn = computerMove.Next(1, i_CurrentGame.CurrentBoard.BoardSize + 1);
            }

            computerMoveInputString = computerMoveRow.ToString() + "," + computerMoveColumn.ToString();

            return computerMoveInputString;
        }
    }
}
