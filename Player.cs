using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;


namespace Reversed_TicTacToe_For_Console
{
    public class Player
    {
        private readonly char m_PlayerSymbol;
        //private readonly string m_PlayerName;
        private int m_Score;

        public Player(char i_PlayerSymbol)
        {
            m_Score = 0;
            m_PlayerSymbol = i_PlayerSymbol;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public char PlayerSymbol
        {
            get
            {
                return m_PlayerSymbol;
            }
        }
    }
}
