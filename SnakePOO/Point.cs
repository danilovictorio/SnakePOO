using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePOO
{
       public class Point
       {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool Equals(Point other)
            {
                return other != null && this.X == other.X && this.Y == other.Y;
            }

            public override string ToString()
            {
                return $"({X},{Y})";
            }
       }
}
