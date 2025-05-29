using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePOO
{
    public class Serpiente
    {
        public List<Point> Cuerpo { get; private set; }
        public ConsoleKey DireccionActual { get; private set; }

        public Serpiente(int tamañoInicial, int posicionInicioX, int posicionInicioY)
        {
            Cuerpo = new List<Point>();
            // Dirección inicial por defecto
            DireccionActual = ConsoleKey.RightArrow;

            // Inicializar la serpiente con tamaño inicial
            for (int i = 0; i < tamañoInicial; i++)
            {
                Cuerpo.Add(new Point(posicionInicioX - i, posicionInicioY));
            }
        }

        public void CambiarDireccion(ConsoleKey nuevaDireccion)
        {
            if (EsDireccionValida(nuevaDireccion) && !EsDireccionOpuesta(nuevaDireccion, DireccionActual))
            {
                DireccionActual = nuevaDireccion;
            }
        }

        public Point ObtenerCabeza()
        {
            return Cuerpo[Cuerpo.Count - 1];
        }

        public Point CalcularNuevaCabeza()
        {
            Point cabeza = ObtenerCabeza();
            int nuevaX = cabeza.X;
            int nuevaY = cabeza.Y;

            switch (DireccionActual)
            {
                case ConsoleKey.UpArrow:
                    nuevaY--;
                    break;
                case ConsoleKey.DownArrow:
                    nuevaY++;
                    break;
                case ConsoleKey.LeftArrow:
                    nuevaX--;
                    break;
                case ConsoleKey.RightArrow:
                    nuevaX++;
                    break;
            }

            return new Point(nuevaX, nuevaY);
        }

        public void Mover(bool crecer = false)
        {
            
            Point nuevaCabeza = CalcularNuevaCabeza();
            Cuerpo.Add(nuevaCabeza);
            // Quitar la cola si no crece
            if (!crecer)
                Cuerpo.RemoveAt(0);
        }

        public bool EstaEnElCuerpo(Point punto)
        {
            foreach (var segmento in Cuerpo)
            {
                if (segmento.Equals(punto))
                    return true;
            }
            return false;
        }

        private bool EsDireccionValida(ConsoleKey tecla)
        {
            return tecla == ConsoleKey.UpArrow || tecla == ConsoleKey.DownArrow ||
                   tecla == ConsoleKey.LeftArrow || tecla == ConsoleKey.RightArrow;
        }

        private bool EsDireccionOpuesta(ConsoleKey nuevaDireccion, ConsoleKey direccionActual)
        {
            if (nuevaDireccion == ConsoleKey.LeftArrow && direccionActual == ConsoleKey.RightArrow) return true;
            if (nuevaDireccion == ConsoleKey.RightArrow && direccionActual == ConsoleKey.LeftArrow) return true;
            if (nuevaDireccion == ConsoleKey.UpArrow && direccionActual == ConsoleKey.DownArrow) return true;
            if (nuevaDireccion == ConsoleKey.DownArrow && direccionActual == ConsoleKey.UpArrow) return true;
            return false;
        }
    }
}
