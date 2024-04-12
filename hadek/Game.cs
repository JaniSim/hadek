namespace hadek
{
    public class Game
    {
        public Game()
        {
            m_gui = new ConsoleGui();
            m_snake = new Snake(new Pixel(m_gui.ScreenWidth / 2, m_gui.ScreenHeight / 2, ConsoleColor.Red), m_gui);
            m_berry = new Berry(m_gui.ScreenWidth, m_gui.ScreenHeight, m_gui);
        }

        public void Start()
        {
            DateTime time = DateTime.Now;
            DateTime time2 = DateTime.Now;
            while (!m_gameOver)
            {
                m_gui.ClearScreen();
                m_gui.DrawBorders();
                m_snake.Draw();
                if (m_berry.DrawAndCheckIfEaten(m_snake.Head))
                {
                    m_score++;
                }
                time = DateTime.Now;
                m_buttonPressed = false;
                while (true)
                {
                    time2 = DateTime.Now;
                    if (time2.Subtract(time).TotalMilliseconds > 500) { break; }
                    if (m_gui.KeyPressed)
                    {
                        Direction direction = m_gui.GetDirection();
                        ChangeDirection(direction);
                    }
                }
                m_gameOver = m_snake.MoveAndCheckIfDead(m_gui.ScreenWidth, m_gui.ScreenHeight, m_movement, m_score);
            }
            m_gui.SetGameOver("Game over, Score: " + m_score);
        }

        private void ChangeDirection(Direction direction)
        {
            if (m_buttonPressed) return;
            m_buttonPressed = true;
            if (s_oppositeDirections[m_movement] != direction)
            {
                m_movement = direction;
            }
        }

        private static readonly Dictionary<Direction, Direction> s_oppositeDirections = new()
        {
            { Direction.Up, Direction.Down },
            { Direction.Down, Direction.Up },
            { Direction.Left, Direction.Right },
            { Direction.Right, Direction.Left },
        };

        private Direction m_movement = Direction.Right;
        private int m_score = 5;
        private bool m_gameOver;
        private readonly Snake m_snake;
        private readonly Berry m_berry;
        private bool m_buttonPressed;
        private readonly ConsoleGui m_gui;
    }
}
