using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;


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
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        public GameBoard m_CurrentGameBoard;
        private readonly bool r_IsPlayerVsAI;
       // public int m_PlayerTurn;
        public ePlayerID m_PlayerTurn;


        public GameLogics(int i_BoardSize, bool i_IsPlayerVsAI)
        {
            m_PlayerOne = new Player(k_PlayerOneSymbol);
            m_PlayerTwo = new Player(k_PlayerTwoSymbol);
            m_CurrentGameBoard = new GameBoard(i_BoardSize);
            r_IsPlayerVsAI = i_IsPlayerVsAI;
            m_PlayerTurn = ePlayerID.Player1Turn;
        }

        //methods
        public static bool CheckBoardSizeValidity(string i_InputStringFromUser)
        {
            bool isValidInput = false;

            if (i_InputStringFromUser.All(char.IsDigit) == true)
            {
                if (int.Parse(i_InputStringFromUser) < k_MinimumSizeOfBoard || int.Parse(i_InputStringFromUser) > k_MaximumSizeOfBoard)
                {
                    isValidInput = false;
                }
                else
                {
                    isValidInput = true;
                }
            }
            else
            {
                isValidInput = false;
            }

            return isValidInput;
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
                    isValidInput = false;
                }
            }
            else
            {
                isValidInput = false;
            }

            return isValidInput;
        }

        public static bool CheckMoveValidity(string i_InputStringFromUser, GameLogics i_Game)
        {
            bool isValidInput = false;

            if ((i_InputStringFromUser.Length == 1 && i_InputStringFromUser.Contains('Q')))
            {
                isValidInput = true;
            }
            else
            {
                if (i_InputStringFromUser.Length == 3 && i_InputStringFromUser[1] == ',')
                {
                    int convertedInputRow, convertedInputCol;
                    string i_FirstNumber = i_InputStringFromUser.Substring(0);
                    string i_SecondNumber = i_InputStringFromUser.Substring(2);

                    if ((int.TryParse(i_FirstNumber, out convertedInputRow) == true) && (int.TryParse(i_FirstNumber, out convertedInputCol) == true))
                    {
                        if (CheckRowOrColumnValidity(convertedInputRow, i_Game) == true && CheckRowOrColumnValidity(convertedInputCol, i_Game))
                        {
                            if (i_Game.CurrentBoard.GetCellValue(convertedInputRow, convertedInputCol) == ' ')
                            {
                                isValidInput = true;
                            }
                            else
                            {
                                isValidInput = false;
                            }
                        }
                        else
                        {
                            isValidInput = false;
                        }
                    }
                    else
                    {
                        isValidInput = false;
                    }
                }
                else
                {
                    isValidInput = false;
                }
            }

            return isValidInput;
        }

        public static bool CheckRowOrColumnValidity(int i_InputRowOrCol, GameLogics i_Game)
        {
            bool isValidInput = false;
            int boardSize = i_Game.CurrentBoard.BoardSize;

            if ((i_InputRowOrCol >= 1 && i_InputRowOrCol <= boardSize))
            {
                isValidInput = true;
            }
            else
            {
                isValidInput = false;
            }

            return isValidInput;
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


        //getters & setters
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

        //get GameBoard

        //CheckWin :
        //CheckHorizontal   
        //CheckDiagonal
        //CheckVertical

        //IsTheBoardFull:
        //(IsTie)

        //IsEndGame:
        //(Tie or Win Or Q)

        //UpdateBoardAfterTurn

        //IncreaseWinnerScore
    }
}
