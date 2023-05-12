using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversed_TicTacToe_For_Console
{
    public class GameBoard
    {
        private int m_AmountOfMarkedBoardCells;
        private int m_BoardSize;
        private char[,] m_GameBoard;

        public GameBoard(int i_BoardSize)
        {
            m_AmountOfMarkedBoardCells = 0;
            m_BoardSize = i_BoardSize;
            m_GameBoard = new char[m_BoardSize, m_BoardSize];
            gameBoardInitialization();
        }

        public int AmountOfMarkedBoardCells
        {
            get
            {
                return m_AmountOfMarkedBoardCells;
            }
            set
            {
                m_AmountOfMarkedBoardCells = value;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
            set
            {
                m_BoardSize = value;
            }
        }

        private void gameBoardInitialization()
        {
            for (int row = 0; row < m_BoardSize; row++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    m_GameBoard[row, col] = ' ';
                }
            }
        }
    }
}