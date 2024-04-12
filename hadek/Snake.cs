using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadek
{
    internal class Snake
    {
        public Pixel Head { get; }
        private List<int> m_xBody = new();
        private List<int> m_yBody = new();

        public Snake(Pixel head)
        {
            Head = head;
        }

        public void Draw()
        {
            for (var i = 0; i < m_xBody.Count(); i++)
            {
                Console.SetCursorPosition(m_xBody[i], m_yBody[i]);
                Console.Write("■");
            }
            Console.SetCursorPosition(Head.XPos, Head.YPos);
            Console.ForegroundColor = Head.Color;
            Console.Write("■");
        }

        public bool MoveAndCheckIfDead(int screenWidth, int screenHeight, string movement, int score)
        {
            bool gameOver = false;
            m_xBody.Add(Head.XPos);
            m_yBody.Add(Head.YPos);
            switch (movement)
            {
                case "UP":
                    Head.YPos--;
                    break;
                case "DOWN":
                    Head.YPos++;
                    break;
                case "LEFT":
                    Head.XPos--;
                    break;
                case "RIGHT":
                    Head.XPos++;
                    break;
            }
            if (m_xBody.Count > score)
            {
                m_xBody.RemoveAt(0);
                m_yBody.RemoveAt(0);
            }
            if (Head.XPos == screenWidth - 1 || Head.XPos == 0 || Head.YPos == screenHeight - 1 || Head.YPos == 0)
            {
                gameOver = true;
            }
            for (int i = 0; i < m_xBody.Count(); i++)
            {
                if (m_xBody[i] == Head.XPos && m_yBody[i] == Head.YPos)
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }
    }
}
