using SnakePOO;
using System;
using System.Collections.Generic;

public class Serpiente
{
    public List<Point> Cuerpo { get; private set; }
    public ConsoleKey DireccionActual { get; private set; }
    public Point Cabeza => ObtenerCabeza(); // Nueva propiedad

    public Serpiente(int tamañoInicial, int posicionInicioX, int posicionInicioY)
    {
        Cuerpo = new List<Point>();
        DireccionActual = ConsoleKey.RightArrow;

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

    public void Mover(ConsoleKey nuevaDireccion, bool crecer = false)
    {
        CambiarDireccion(nuevaDireccion); // Actualiza la dirección si es válida
        Point nuevaCabeza = CalcularNuevaCabeza();
        Cuerpo.Add(nuevaCabeza);
        if (!crecer)
            Cuerpo.RemoveAt(0);
    }

    public bool ColisionConPared(int tamaño)
    {
        return Cabeza.X <= 0 || Cabeza.Y <= 0 || Cabeza.X >= tamaño - 1 || Cabeza.Y >= tamaño - 1;
    }

    public bool ColisionConCuerpo()
    {
        for (int i = 0; i < Cuerpo.Count - 1; i++)
        {
            if (Cuerpo[i].Equals(Cabeza))
                return true;
        }
        return false;
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
        return (nuevaDireccion == ConsoleKey.LeftArrow && direccionActual == ConsoleKey.RightArrow) ||
               (nuevaDireccion == ConsoleKey.RightArrow && direccionActual == ConsoleKey.LeftArrow) ||
               (nuevaDireccion == ConsoleKey.UpArrow && direccionActual == ConsoleKey.DownArrow) ||
               (nuevaDireccion == ConsoleKey.DownArrow && direccionActual == ConsoleKey.UpArrow);
    }
}
