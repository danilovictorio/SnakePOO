using System;
using System.Collections.Generic;

namespace SnakePOO
{
    public class Render
    {
        private int Tamaño;
        private Serpiente Serpiente;
        private Energia Energia;
        private List<Letal> ObstaculosLetales;
        private int Puntaje;

        public Render(int tamaño, Serpiente serpiente, Energia energia, List<Letal> obstaculosLetales, int puntaje)
        {
            Tamaño = tamaño;
            Serpiente = serpiente;
            Energia = energia;
            ObstaculosLetales = obstaculosLetales;
            Puntaje = puntaje;
        }

        public void Renderizar()
        {
            Console.Clear();

            // Dibujar el borde
            for (int y = 0; y <= Tamaño + 1; y++)
            {
                for (int x = 0; x <= Tamaño + 1; x++)
                {
                    Console.SetCursorPosition(x * 2, y);
                    if (y == 0 || y == Tamaño + 1 || x == 0 || x == Tamaño + 1)
                        Console.Write("||");
                    else
                        Console.Write("  ");
                }
            }

            // Dibujar la serpiente
            for (int i = 0; i < Serpiente.Cuerpo.Count; i++)
            {
                var segmento = Serpiente.Cuerpo[i];
                Console.SetCursorPosition((segmento.X + 1) * 2, segmento.Y + 1);
                Console.Write(i == Serpiente.Cuerpo.Count - 1 ? "O " : "# ");
            }

            // Dibujar la energía
            Console.SetCursorPosition((Energia.Posicion.X + 1) * 2, Energia.Posicion.Y + 1);
            Console.Write("@ ");

            // Dibujar los obstáculos letales
            foreach (var obstaculo in ObstaculosLetales)
            {
                Console.SetCursorPosition((obstaculo.Posicion.X + 1) * 2, obstaculo.Posicion.Y + 1);
                Console.Write("$ ");
            }

            // Mostrar puntuación
            Console.SetCursorPosition(0, Tamaño + 3);
            Console.WriteLine($"Puntaje: {Puntaje}");
        }
    }
}
