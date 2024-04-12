namespace hadek
{
    public class Games
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
            while (!m_gameOver)
            {
                Console.Clear();
                DrawBorders();
                m_snake.Draw();
                if (m_berry.DrawAndCheckIfEaten(m_snake.Head, m_screenWidth, m_screenHeight))
                {
                    m_score++;
                }
                time = DateTime.Now;
                m_buttonPressed = false;
                while (true)
                {
                    time2 = DateTime.Now;
                    if (time2.Subtract(time).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo input = Console.ReadKey(true);
                        ChangeDirection(input);
                    }
                }
                m_gameOver = m_snake.MoveAndCheckIfDead(m_screenWidth, m_screenHeight, m_movement, m_score);
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


        private void ChangeDirection(ConsoleKeyInfo input)
        {
            if (m_buttonPressed) return;
            m_buttonPressed = true;
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (m_movement != Direction.Down)
                    {
                        m_movement = Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (m_movement != Direction.Up)
                    {
                        m_movement = Direction.Down;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (m_movement != Direction.Right)
                    {
                        m_movement = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (m_movement != Direction.Left)
                    {
                        m_movement = Direction.Right;
                    }
                    break;
            }
        }

        private Direction m_movement = Direction.Right;
        private int m_score = 5;
        private bool m_gameOver;
        private readonly Random m_randNum;
        private readonly int m_screenWidth;
        private readonly int m_screenHeight;
        private Snake m_snake;
        private Berry m_berry;
        private bool m_buttonPressed;
    }
}
