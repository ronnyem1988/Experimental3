using System;
using System.Collections.Generic;
using System.Diagnostics;

class Biblioteca
{
    private HashSet<string> libros; // Conjunto para almacenar títulos únicos
    private Dictionary<string, (string Autor, int Año)> detallesLibros; // Mapa para detalles de libros

    public Biblioteca()
    {
        libros = new HashSet<string>();
        detallesLibros = new Dictionary<string, (string, int)>();
    }

    // Registrar un libro
    public void RegistrarLibro(string titulo, string autor, int año)
    {
        if (!libros.Contains(titulo))
        {
            libros.Add(titulo);
            detallesLibros[titulo] = (autor, año);
            Console.WriteLine($"Libro '{titulo}' registrado con éxito.");
        }
        else
        {
            Console.WriteLine($"El libro '{titulo}' ya está registrado.");
        }
    }

    // Consultar un libro por título
    public void ConsultarLibro(string titulo)
    {
        if (detallesLibros.TryGetValue(titulo, out var detalles))
        {
            Console.WriteLine($"Título: {titulo}, Autor: {detalles.Autor}, Año: {detalles.Año}");
        }
        else
        {
            Console.WriteLine($"El libro '{titulo}' no está registrado.");
        }
    }

    // Visualizar todos los libros registrados
    public void VisualizarLibros()
    {
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        Console.WriteLine("Libros registrados:");
        foreach (var titulo in libros)
        {
            var detalles = detallesLibros[titulo];
            Console.WriteLine($"Título: {titulo}, Autor: {detalles.Autor}, Año: {detalles.Año}");
        }
    }

    // Eliminar un libro por título
    public void EliminarLibro(string titulo)
    {
        if (libros.Remove(titulo))
        {
            detallesLibros.Remove(titulo);
            Console.WriteLine($"Libro '{titulo}' eliminado con éxito.");
        }
        else
        {
            Console.WriteLine($"El libro '{titulo}' no está registrado.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        Stopwatch stopwatch = new Stopwatch();

        // Registrar libros
        stopwatch.Start();
        biblioteca.RegistrarLibro("El Hobbit", "J.R.R.", 1920);
        biblioteca.RegistrarLibro("1920", "J.R.R.", 1930);
        biblioteca.RegistrarLibro("El Señor de los Anillos", "J.R.R.", 1954);
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de inserción: {stopwatch.Elapsed.TotalSeconds} segundos\n");

        // Consultar un libro
        stopwatch.Restart();
        biblioteca.ConsultarLibro("1925");
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de consulta: {stopwatch.Elapsed.TotalSeconds} segundos\n");

        // Visualizar todos los libros
        stopwatch.Restart();
        biblioteca.VisualizarLibros();
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de visualización: {stopwatch.Elapsed.TotalSeconds} segundos\n");

        // Eliminar un libro
        stopwatch.Restart();
        biblioteca.EliminarLibro("El Señor de los Anillos");
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de eliminación: {stopwatch.Elapsed.TotalSeconds} segundos\n");

        // Visualizar todos los libros después de la eliminación
        biblioteca.VisualizarLibros();
    }
}