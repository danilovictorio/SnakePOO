using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePOO
{
    public class Energia
    {
        public Point Posicion { get; private set; }
        public Energia(int x, int y)
        {
            Posicion = new Point(x, y);
        }

        public void ActualizarPosicion(int x, int y)
        {
            Posicion = new Point(x, y);
        }
    }
}
