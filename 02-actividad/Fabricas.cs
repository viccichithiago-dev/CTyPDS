using System;

namespace tp2
{
    // ===== Práctica 2, Ejercicio 12: fábrica abstracta =====
    public abstract class FabricaDeComparables
    {
        public const int OPCION_VISUALIZACION = 1;
        public const int OPCION_SUSCRIPTOR = 2;

        // Devuelve un Comparable generado aleatoriamente según la opción.
        public static IComparable crearAleatorio(int opcion)
        {
            return getFabrica(opcion).crearAleatorio();
        }

        // Devuelve un Comparable con datos ingresados por teclado según la opción.
        public static IComparable crearPorTeclado(int opcion)
        {
            return getFabrica(opcion).crearPorTeclado();
        }

        private static FabricaDeComparables getFabrica(int opcion)
        {
            switch (opcion)
            {
                case OPCION_VISUALIZACION: return new FabricaDeVisualizaciones();
                case OPCION_SUSCRIPTOR: return new FabricaDeSuscriptores();
                default: throw new ArgumentException("Opción desconocida: " + opcion);
            }
        }

        public abstract IComparable crearAleatorio();
        public abstract IComparable crearPorTeclado();
    }

    // ===== Práctica 2, Ejercicio 13: fábricas concretas =====
    public class FabricaDeVisualizaciones : FabricaDeComparables
    {
        public override IComparable crearAleatorio()
        {
            return new Visualizacion(GeneradorDeDatosAleatorios.numeroAleatorio(100));
        }

        public override IComparable crearPorTeclado()
        {
            Console.Write("Ingrese cantidad de visualizaciones: ");
            int cantidad = LectorDeDatos.numeroPorTeclado();
            return new Visualizacion(cantidad);
        }
    }

    public class FabricaDeSuscriptores : FabricaDeComparables
    {
        public override IComparable crearAleatorio()
        {
            string nombre = GeneradorDeDatosAleatorios.stringAleatorio(5);
            int id = GeneradorDeDatosAleatorios.numeroAleatorio(10000);
            int meses = GeneradorDeDatosAleatorios.numeroAleatorio(100);
            int horas = GeneradorDeDatosAleatorios.numeroAleatorio(10000);
            // Todo suscriptor se crea con alguna estrategia (Ej 2).
            var s = new Suscriptor(nombre, id, meses, horas);
            s.setEstrategia(new EstrategiaPorNombre());
            return s;
        }

        public override IComparable crearPorTeclado()
        {
            Console.Write("Ingrese nombre: ");
            string nombre = LectorDeDatos.stringPorTeclado();
            Console.Write("Ingrese id: ");
            int id = LectorDeDatos.numeroPorTeclado();
            Console.Write("Ingrese meses de suscripción: ");
            int meses = LectorDeDatos.numeroPorTeclado();
            Console.Write("Ingrese horas vistas: ");
            int horas = LectorDeDatos.numeroPorTeclado();
            var s = new Suscriptor(nombre, id, meses, horas);
            s.setEstrategia(new EstrategiaPorNombre());
            return s;
        }
    }

    // Fábrica correspondiente al Canal (Ejercicio 15).
    public class FabricaDeCanales
    {
        public static Canal crearAleatorio()
        {
            return new Canal(GeneradorDeDatosAleatorios.stringAleatorio(6));
        }

        public static Canal crearPorTeclado()
        {
            Console.Write("Ingrese nombre del canal: ");
            return new Canal(LectorDeDatos.stringPorTeclado());
        }
    }

    // ===== Práctica 2, Ejercicio 14: funciones unificadas =====
    public static class FuncionesFactory
    {
        public static void llenarFactory(IColeccionable coleccionable, int opcion)
        {
            for (int i = 0; i < 20; i++)
                coleccionable.agregar(FabricaDeComparables.crearAleatorio(opcion));
        }

        public static void informarFactory(IColeccionable coleccionable, int opcion)
        {
            Console.WriteLine(coleccionable.cuantos());
            Console.WriteLine(coleccionable.minimo());
            Console.WriteLine(coleccionable.maximo());
            IComparable comparable = FabricaDeComparables.crearPorTeclado(opcion);
            if (coleccionable.contiene(comparable))
                Console.WriteLine("El elemento leído está en la colección");
            else
                Console.WriteLine("El elemento leído no está en la colección");
        }
    }
}
