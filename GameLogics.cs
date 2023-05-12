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
        private const int k_MinimumSizeOfBoard = 3;
        private const int k_MaximumSizeOfBoard = 9;
        public const char k_PlayerOneSymbol = 'X';
        public const char k_PlayerTwoSymbol = 'O';
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private GameBoard m_CurrentGameBoard;
        private readonly bool r_IsPlayerVsAI;
        private int m_PlayerTurn;
        public GameLogics(int i_BoardSize, bool i_IsPlayerVsAI)
        {
            m_PlayerOne = new Player(k_PlayerOneSymbol);
            m_PlayerTwo = new Player(k_PlayerTwoSymbol);
            m_CurrentGameBoard = new GameBoard(i_BoardSize);
            r_IsPlayerVsAI = i_IsPlayerVsAI;
            m_PlayerTurn = 1;
        }

        public static bool CheckGameBoardSize(int i_BoardSize)
        {
            bool isTheSizeValid = false;
            if (i_BoardSize >= k_MinimumSizeOfBoard && i_BoardSize <= k_MaximumSizeOfBoard)
            {
                isTheSizeValid = true;
            }

            return isTheSizeValid;
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

        public bool IsPlayerVsAI
        {
            get
            {
                return r_IsPlayerVsAI;
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
