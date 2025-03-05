using System;
using System.Collections.Generic;
using _250225;

namespace _250225
{
    class Program
    {
        static void Main()
        {
            DiscoRepository repo = new DiscoRepository();
            var conexion = new Conexion();
            conexion.ProbarConexion();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gestión de discos");
                Console.WriteLine("1. Añadir disco ");
                Console.WriteLine("2. Actualizar disco");
                Console.WriteLine("3. Eliminar disco");
                Console.WriteLine("4. Listar discos");
                Console.WriteLine("5. Salir ");
                Console.Write("Selecciona una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Opción inválida. Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Artista: ");
                        string artista = Console.ReadLine();
                        Console.Write("Género: ");
                        string genero = Console.ReadLine();
                        Console.Write("Año: ");
                        int anio = int.Parse(Console.ReadLine());
                        Console.Write("Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine());

                        repo.InsertarDisco(new Disco { nombre = nombre, artista = artista, genero = genero, anio = anio, precio = precio });
                        Console.WriteLine("Disco agregado correctamente.");
                        break;

                    case 2:
                        Console.Write("ID del disco a actualizar: ");
                        int idActualizar = int.Parse(Console.ReadLine());
                        Console.Write("Nuevo nombre: ");
                        string nuevoNombre = Console.ReadLine();
                        Console.Write("Nuevo artista: ");
                        string nuevoArtista = Console.ReadLine();
                        Console.Write("Nuevo género: ");
                        string nuevoGenero = Console.ReadLine();
                        Console.Write("Nuevo año: ");
                        int nuevoAnio = int.Parse(Console.ReadLine());
                        Console.Write("Nuevo precio: ");
                        decimal nuevoPrecio = decimal.Parse(Console.ReadLine());

                        repo.ActualizarDisco(new Disco { id = idActualizar, nombre = nuevoNombre, artista = nuevoArtista, genero = nuevoGenero, anio = nuevoAnio, precio = nuevoPrecio });
                        Console.WriteLine("Disco actualizado correctamente.");
                        break;

                    case 3:
                        Console.Write("ID del disco a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        repo.EliminarDisco(idEliminar);
                        Console.WriteLine("Disco eliminado correctamente.");
                        break;

                    case 4:
                        List<Disco> discos = repo.ObtenerDisco();
                        foreach (var item in discos)
                        {
                            Console.WriteLine($"ID: {item.id}, Nombre: {item.nombre}, Artista: {item.artista}, Género: {item.genero}, Año: {item.anio}, Precio: {item.precio:C}");
                        }
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
