using System;
using Practica4.Iterativos;
using Practica4.Recursivos;
using Practica4.Strategy;
using Practica4.Proxy;

namespace Practica4
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            ejercicio1();
            ejercicio2();
            ejercicio3();
            ejercicio4();
        }

        private static void mostrarIterativo(string nombre, int n, Action<int> algoritmo, Func<int, long> formula, string orden)
        {
            Contador.reiniciar();
            algoritmo(n);
            long operaciones = Contador.getOperaciones();
            long valorFormula = formula(n);
            string coinciden = operaciones == valorFormula ? "si" : "no";
            Console.WriteLine(nombre + " | n = " + n + " | operaciones = " + operaciones + " | formula = " + valorFormula + " | coinciden: " + coinciden + " | orden: " + orden);
        }

        private static void ejercicio1()
        {
            Console.WriteLine("Ejercicio 1");
            int[] valores = { 10, 100, 1000 };
            foreach (int n in valores)
            {
                mostrarIterativo("contar", n, AlgoritmosIterativos.contar, AlgoritmosIterativos.formulaContar, "O(n)");
                mostrarIterativo("contar2", n, AlgoritmosIterativos.contar2, AlgoritmosIterativos.formulaContar2, "O(n²)");
                mostrarIterativo("contarDependiente", n, AlgoritmosIterativos.contarDependiente, AlgoritmosIterativos.formulaDependiente, "O(n²)");
                mostrarIterativo("tiempoWhile", n, AlgoritmosIterativos.tiempoWhile, AlgoritmosIterativos.formulaWhile, "O(log n)");
            }
            Console.WriteLine();
        }

        private static void ejercicio2()
        {
            Console.WriteLine("Ejercicio 2");
            int[] valores = { 5, 10, 20, 25 };
            foreach (int n in valores)
            {
                Contador.reiniciar();
                int resultado1 = AlgoritmosRecursivos.rec1(n);
                long llamadas1 = Contador.getOperaciones();

                Contador.reiniciar();
                int resultado2 = AlgoritmosRecursivos.rec2(n);
                long llamadas2 = Contador.getOperaciones();

                string mismoResultado = resultado1 == resultado2 ? "si" : "no";
                long veces = llamadas1 / llamadas2;

                Console.WriteLine("n = " + n + " | mismo resultado: " + mismoResultado);
                Console.WriteLine("  rec1: llamadas = " + llamadas1 + " | formula = " + AlgoritmosRecursivos.formulaRec1(n));
                Console.WriteLine("  rec2: llamadas = " + llamadas2 + " | formula = " + AlgoritmosRecursivos.formulaRec2(n));
                Console.WriteLine("  rec1 hace " + veces + " veces mas llamadas que rec2");
            }
            Console.WriteLine();
        }

        private static void ejercicio3()
        {
            Console.WriteLine("Ejercicio 3");
            int[] valores = { 1000, 10000, 100000, 1000000 };
            ListaDeInscriptos lista = new ListaDeInscriptos(new BusquedaLineal());
            foreach (int n in valores)
            {
                lista.cargar(n);

                lista.setEstrategia(new BusquedaLineal());
                Contador.reiniciar();
                lista.buscar(n + 1);
                long comparacionesLineal = Contador.getOperaciones();

                lista.setEstrategia(new BusquedaBinaria());
                Contador.reiniciar();
                lista.buscar(n + 1);
                long comparacionesBinaria = Contador.getOperaciones();

                long ganancia = comparacionesLineal / comparacionesBinaria;

                Console.WriteLine("n = " + n + " | lineal = " + comparacionesLineal + " | binaria = " + comparacionesBinaria + " | ganancia = " + ganancia);
            }
            Console.WriteLine();
        }

        private static void ejercicio4()
        {
            Console.WriteLine("Ejercicio 4");
            int n = 10000;

            IServicioDeAlumnos servicio = new ServicioDeAlumnos(n);
            Contador.reiniciar();
            for (int i = 0; i < 1000; i++)
            {
                servicio.buscarAlumno(10000);
            }
            long sinProxy = Contador.getOperaciones();

            IServicioDeAlumnos servicioConCache = new ServicioDeAlumnosConCache(new ServicioDeAlumnos(n));
            Contador.reiniciar();
            for (int i = 0; i < 1000; i++)
            {
                servicioConCache.buscarAlumno(10000);
            }
            long conProxy = Contador.getOperaciones();

            long ganancia = sinProxy / conProxy;

            Console.WriteLine("comparaciones sin proxy = " + sinProxy + " | con proxy = " + conProxy + " | ganancia = " + ganancia);
        }
    }
}
