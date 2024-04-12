using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadek
{
    internal class Berry
    {
        public Berry(int x, int y)
        {
            m_x = x;
            m_y = y;
            m_randNum = new Random();
        }

        public bool DrawAndCheckIfEaten(Pixel snakeHead, int screenWidth, int screenHeight)
        {
            var berryEaten = false;
            if (m_x == snakeHead.XPos && m_y == snakeHead.YPos)
            {
                m_x = m_randNum.Next(1, screenWidth - 2);
                m_y = m_randNum.Next(1, screenHeight - 2);
                berryEaten = true;
            }
            Console.SetCursorPosition(m_x, m_y);
            Console.ForegroundColor = c_color;
            Console.Write("■");
            return berryEaten;
        }

        private int m_x;
        private int m_y;
        private const ConsoleColor c_color = ConsoleColor.Cyan;
        private readonly Random m_randNum;
    }
}
