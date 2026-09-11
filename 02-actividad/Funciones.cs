using System;

namespace tp2
{
    // Funciones de llenado e informe (Práctica 1, Ej 5/6/12 adaptados + Práctica 2, Ej 2/6/8).
    public static class Funciones
    {
        private static readonly Random rand = new Random();
        private static readonly string[] Nombres = {
            "Carlos", "Sofía", "Mateo", "Lucía", "Diego", "Elena",
            "Santiago", "Valeria", "Thiago", "Ana", "Maria", "Jose",
            "Pepito", "Jaimito", "Demian", "Javier", "Gustavo", "Juan"
        };

        // Práctica 1, Ej 5.
        public static void llenar(IColeccionable c)
        {
            try
            {
                for (int i = 0; i < 20; i++)
                    c.agregar(new Visualizacion(rand.Next(100)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en llenar: " + ex.Message);
            }
        }

        // ===== Práctica 2, Ejercicio 2 =====
        // Crea suscriptores con alguna estrategia del Ejercicio 1.
        // Usa el main del ejercicio correspondiente de la práctica anterior
        // sin modificarlo: informar() funciona igual porque delega en la estrategia.
        public static void llenarSuscriptores(IColeccionable c)
        {
            try
            {
                IEstrategiaComparacion estrategia = new EstrategiaPorNombre();
                for (int i = 0; i < 20; i++)
                {
                    string nombre = Nombres[rand.Next(Nombres.Length)];
                    var s = new Suscriptor(nombre, i, rand.Next(1, 100), rand.Next(1, 10000));
                    s.setEstrategia(estrategia);
                    c.agregar(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en llenarSuscriptores: " + ex.Message);
            }
        }

        // Práctica 1, Ej 6 (adaptado: minimo()/maximo() devuelven Comparable).
        public static void informar(IColeccionable c)
        {
            try
            {
                Console.WriteLine("Cantidad de elementos: " + c.cuantos());
                Console.WriteLine("Elemento mínimo: " + c.minimo());
                Console.WriteLine("Elemento máximo: " + c.maximo());

                Console.Write("Ingrese un valor a buscar: ");
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("No se ingresó valor.");
                    return;
                }

                // Búsqueda genérica: intenta por id numérico (Suscriptor) y si no, por cantidad.
                IComparable buscado;
                if (int.TryParse(input, out int num))
                {
                    // Para no atar el tipo, se prueba contener con Visualizacion;
                    // si la colección es de suscriptores, se busca por id con estrategia temporal.
                    // Se informa con ambos intentos de forma transparente.
                    buscado = new Visualizacion(num);
                    if (c.contiene(buscado))
                    {
                        Console.WriteLine("El elemento leído está en la colección");
                        return;
                    }
                    var testigo = new Suscriptor("", num, 0, 0, new EstrategiaPorId());
                    if (c.contiene(testigo))
                    {
                        Console.WriteLine("El elemento leído está en la colección");
                        return;
                    }
                    Console.WriteLine("El elemento leído no está en la colección");
                }
                else
                {
                    var testigo = new Suscriptor(input, 0, 0, 0, new EstrategiaPorNombre());
                    if (c.contiene(testigo))
                        Console.WriteLine("El elemento leído está en la colección");
                    else
                        Console.WriteLine("El elemento leído no está en la colección");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en informar: " + ex.Message);
            }
        }

        // Informa sin pedir nada por teclado (para Ej 9 y Ej 14).
        public static void informarSinTeclado(IColeccionable c)
        {
            Console.WriteLine("Cantidad de elementos: " + c.cuantos());
            Console.WriteLine("Elemento mínimo: " + c.minimo());
            Console.WriteLine("Elemento máximo: " + c.maximo());
        }

        // ===== Práctica 2, Ejercicio 6 =====
        public static void imprimirElementos(IColeccionable coleccionable)
        {
            IIterador it = coleccionable.crearIterador();
            for (it.primero(); !it.fin(); it.siguiente())
                Console.WriteLine(it.actual());
        }

        // ===== Práctica 2, Ejercicio 8 =====
        public static void cambiarEstrategia(IColeccionable coleccionable, IEstrategiaComparacion estrategia)
        {
            IIterador it = coleccionable.crearIterador();
            for (it.primero(); !it.fin(); it.siguiente())
            {
                Suscriptor s = (Suscriptor)it.actual();
                s.setEstrategia(estrategia);
            }
        }
    }
}
