using System;
using System.Collections.Generic;
using System.Threading;
using hadek;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}