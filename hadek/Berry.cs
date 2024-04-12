namespace hadek
{
    internal class Berry
    {
        public Berry(int screenWidth, int screenHeight, ConsoleGui gui)
        {
            m_randNum = new Random();
            m_screenWidth = screenWidth;
            m_screenHeight = screenHeight;
            m_gui = gui;
            m_berry = new Pixel(m_randNum.Next(0, screenWidth), m_randNum.Next(0, screenHeight), ConsoleColor.Cyan);
        }

        public bool DrawAndCheckIfEaten(Pixel snakeHead)
        {
            var berryEaten = false;
            if (m_berry.XPos == snakeHead.XPos && m_berry.YPos == snakeHead.YPos)
            {
                m_berry.XPos = m_randNum.Next(1, m_screenWidth - 2);
                m_berry.YPos = m_randNum.Next(1, m_screenHeight - 2);
                berryEaten = true;
            }
            m_gui.DisplayRect(m_berry.XPos, m_berry.YPos, "■", m_berry.Color);
            return berryEaten;
        }

        private readonly Pixel m_berry;
        private readonly Random m_randNum;
        private readonly int m_screenWidth;
        private readonly int m_screenHeight;
        private readonly ConsoleGui m_gui;
    }
}
