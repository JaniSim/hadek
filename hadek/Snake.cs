namespace hadek
{
    internal class Snake
    {
        public Snake(Pixel head, ConsoleGui gui)
        {
            Head = head;
            m_gui = gui;
        }
        public Pixel Head { get; }

        public void Draw()
        {
            for (var i = 0; i < m_xBody.Count(); i++)
            {
                m_gui.DisplayRect(m_xBody[i], m_yBody[i], "■");
            }
            m_gui.DisplayRect(Head.XPos, Head.YPos, "■", Head.Color);
        }

        public bool MoveAndCheckIfDead(int screenWidth, int screenHeight, Direction movement, int score)
        {
            var gameOver = false;
            m_xBody.Add(Head.XPos);
            m_yBody.Add(Head.YPos);
            switch (movement)
            {
                case Direction.Up:
                    Head.YPos--;
                    break;
                case Direction.Down:
                    Head.YPos++;
                    break;
                case Direction.Left:
                    Head.XPos--;
                    break;
                case Direction.Right:
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
            for (var i = 0; i < m_xBody.Count(); i++)
            {
                if (m_xBody[i] == Head.XPos && m_yBody[i] == Head.YPos)
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }

        private readonly List<int> m_xBody = new();
        private readonly List<int> m_yBody = new();
        private readonly ConsoleGui m_gui;
    }
}
