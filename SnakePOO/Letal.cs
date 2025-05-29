using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePOO
{
    public class Letal
    {
        public Point Posicion { get; private set; }
        public Letal(int x, int y)
        {
            Posicion = new Point(x, y);
        }
    }
}
