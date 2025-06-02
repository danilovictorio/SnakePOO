using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakePOO
{
    public class Juego
    {
        private Serpiente serpiente;
        private Energia energia;
        private List<Letal> letales;
        private int puntaje;
        private int meta;
        private int tamaño;
        private ConsoleKey direccion = ConsoleKey.RightArrow;
        private int velocidad;

        public Juego(int tamaño = 20, int velocidad = 200, int meta = 10)
        {
            this.tamaño = tamaño;
            this.velocidad = velocidad;
            this.meta = meta;
            this.direccion = ConsoleKey.RightArrow;
        }

        public void Inicio()
        {
            serpiente = new Serpiente(3, tamaño / 2, tamaño / 2);
            puntaje = 0;
            energia = GenerarEnergia();
            letales = GenerarLetales(5);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var tecla = Console.ReadKey(true).Key;
                    if (EsDireccionValida(tecla))
                        serpiente.CambiarDireccion(tecla);
                }

                serpiente.Mover(direccion);

                if (serpiente.ColisionConPared(tamaño) || serpiente.ColisionConCuerpo())
                {
                    GameOver();
                    break;
                }

                if (ColisionLetal())
                {
                    GameOver();
                    break;
                }

                if (serpiente.Cabeza.X == energia.Posicion.X && serpiente.Cabeza.Y == energia.Posicion.Y)
                {
                    energia = GenerarEnergia();
                    puntaje++;

                    if (puntaje >= meta)
                    {
                        Victoria();
                        break;
                    }
                }

                var render = new Render(tamaño, serpiente, energia, letales, puntaje);
                render.Renderizar();

                Thread.Sleep(velocidad);
            }
        }


        private bool ColisionLetal()
        {
            foreach (var obstaculo in letales)
            {
                if (serpiente.Cabeza.X == obstaculo.Posicion.X && serpiente.Cabeza.Y == obstaculo.Posicion.Y)
                    return true;
            }

            return false;
        }

        private Energia GenerarEnergia()
        {
            Random rnd = new Random();
            Point punto;
            do
            {
                punto = new Point(rnd.Next(1, tamaño - 1), rnd.Next(1, tamaño - 1));
            } while (serpiente.Cuerpo.Exists(p => p.X == punto.X && p.Y == punto.Y));
            return new Energia(punto.X, punto.Y);
        }

        private List<Letal> GenerarLetales(int cantidad)
        {
            Random rnd = new Random();
            var lista = new List<Letal>();
            while (lista.Count < cantidad)
            {
                var x = rnd.Next(1, tamaño - 1);
                var y = rnd.Next(1, tamaño - 1);
                if (!serpiente.Cuerpo.Exists(p => p.X == x && p.Y == y))
                {
                    lista.Add(new Letal(x, y));
                }
            }
            return lista;
        }

        private bool EsDireccionValida(ConsoleKey tecla)
        {
            return tecla == ConsoleKey.UpArrow || tecla == ConsoleKey.DownArrow ||
                   tecla == ConsoleKey.LeftArrow || tecla == ConsoleKey.RightArrow;
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("💀 GAME OVER 💀");
            Console.WriteLine($"Puntaje: {puntaje}");
            Console.ReadKey();
        }

        private void Victoria()
        {
            Console.Clear();
            Console.WriteLine("🎉 ¡HAS GANADO! 🎉");
            Console.WriteLine($"Puntaje final: {puntaje}");
            Console.ReadKey();
        }
    }
}
