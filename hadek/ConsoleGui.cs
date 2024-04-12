namespace hadek
{
    internal class ConsoleGui
    {
        public readonly int ScreenWidth = Console.WindowWidth;
        public readonly int ScreenHeight = Console.WindowHeight;

        public bool KeyPressed => Console.KeyAvailable;

        public void SetGameOver(string gameOverText)
        {
            Console.SetCursorPosition(ScreenWidth / 5, ScreenHeight / 2);
            Console.WriteLine(gameOverText);
            Console.SetCursorPosition(ScreenWidth / 5, ScreenHeight / 2 + 1);
        }

        public void DrawBorders()
        {
            for (int i = 0; i < ScreenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, ScreenHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < ScreenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(ScreenWidth - 1, i);
                Console.Write("■");
            }
        }

        public void ClearScreen() => Console.Clear();

        public Direction GetDirection()
        {
            return Console.ReadKey(true).Key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right
            };
        }

        public void DisplayRect(int xPos, int yPos, string rect, ConsoleColor? color = null)
        {
            Console.SetCursorPosition(xPos, yPos);
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.Write(rect);
        }
    }
}
