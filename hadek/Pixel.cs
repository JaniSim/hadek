using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace hadek
{
    public class Pixel
    {
        public Pixel(int xPos, int yPos, ConsoleColor color)
        {
            XPos = xPos;
            YPos = yPos;
            Color = color;
        }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public ConsoleColor Color { get; }
    }
}
