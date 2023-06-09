using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Reversed_TicTacToe_For_Console
{
    public class GameBoard
    {
        private int m_AmountOfMarkedBoardCells;
        private int m_BoardSize;
        public char[,] m_GameBoard;

        public GameBoard(int i_BoardSize)
        {
            m_AmountOfMarkedBoardCells = 0;
            m_BoardSize = i_BoardSize;
            m_GameBoard = new char[m_BoardSize, m_BoardSize];
            initGameBoard();
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

        public char[,] Matrix
        {
            get
            {
                return m_GameBoard;
            }
        }

        public void CreateNewBoard()
        {
            AmountOfMarkedBoardCells = 0;
            initGameBoard();
        }

        private void initGameBoard()
        {
            for (int row = 0; row < m_BoardSize; row++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    m_GameBoard[row, col] = ' ';
                }
            }
        }

        public char GetCellValue(int i_Row, int i_Col)
        {
            return m_GameBoard[i_Row, i_Col];
        }

        public void UpdateChosenCell(int i_Row, int i_Col, char i_PlayerSymbol)
        {
            m_GameBoard[i_row - 1, i_col - 1] = i_PlayerSymbol;
        }
    }
}
