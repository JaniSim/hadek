using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadek
{
    public class Game
    {
        public Game()
        {
            m_screenWidth = Console.WindowWidth;
            m_screenHeight = Console.WindowHeight;
            m_randNum = new Random();
            m_snake = new Snake(new Pixel(m_screenWidth / 2, m_screenHeight / 2, ConsoleColor.Red));
            m_berry = new Berry(m_randNum.Next(0, m_screenWidth), m_randNum.Next(0, m_screenHeight));
        }

        public void Start()
        {
            DateTime time = DateTime.Now;
            DateTime time2 = DateTime.Now;
            string buttonPressed = "no";
            while (true)
            {
                DrawBorders();
                m_snake.Draw();
                if (m_berry.DrawAndCheckIfEaten(m_snake.Head, m_screenWidth, m_screenHeight))
                {
                    m_score++;
                }
                time = DateTime.Now;
                buttonPressed = "no";
                while (true)
                {
                    time2 = DateTime.Now;
                    if (time2.Subtract(time).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo input = Console.ReadKey(true);
                        ChangeDirection(input, ref buttonPressed);
                    }
                }
                if (m_snake.MoveAndCheckIfDead(m_screenWidth, m_screenHeight, m_movement, m_score))
                {
                    break;
                }
                Console.Clear();
            }
            Console.SetCursorPosition(m_screenWidth / 5, m_screenHeight / 2);
            Console.WriteLine("Game over, Score: " + m_score);
            Console.SetCursorPosition(m_screenWidth / 5, m_screenHeight / 2 + 1);
        }

        private void DrawBorders()
        {
            for (int i = 0; i < m_screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, m_screenHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < m_screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(m_screenWidth - 1, i);
                Console.Write("■");
            }
        }


        private void ChangeDirection(ConsoleKeyInfo input, ref string buttonPressed)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (m_movement != "DOWN" && buttonPressed == "no")
                    {
                        m_movement = "UP";
                        buttonPressed = "yes";
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (m_movement != "UP" && buttonPressed == "no")
                    {
                        m_movement = "DOWN";
                        buttonPressed = "yes";
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (m_movement != "RIGHT" && buttonPressed == "no")
                    {
                        m_movement = "LEFT";
                        buttonPressed = "yes";
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (m_movement != "LEFT" && buttonPressed == "no")
                    {
                        m_movement = "RIGHT";
                        buttonPressed = "yes";
                    }
                    break;
            }
        }

        private string m_movement = "RIGHT";
        private int m_score = 5;
        private bool m_gameOver;
        private readonly Random m_randNum;
        private readonly int m_screenWidth;
        private readonly int m_screenHeight;
        private Snake m_snake;
        private Berry m_berry;
    }
}
