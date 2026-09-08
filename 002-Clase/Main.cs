using System;

namespace tp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Suscriptor s1 = new Suscriptor("Ana", 1, 12, 50);
            Suscriptor s2 = new Suscriptor("Carlos", 2, 6, 80);
            Suscriptor s3 = new Suscriptor("Ana", 3, 12, 30);

            Console.WriteLine("=== Estrategia por ID (default) ===");
            ProbarComparacion(s1, s2, "s1 vs s2");
            ProbarComparacion(s1, s3, "s1 vs s3");

            s1.setEstrategia(new StrategyNombre());
            s2.setEstrategia(new StrategyNombre());
            s3.setEstrategia(new StrategyNombre());
            Console.WriteLine("\n=== Estrategia por Nombre ===");
            ProbarComparacion(s1, s2, "s1 vs s2");
            ProbarComparacion(s1, s3, "s1 vs s3");

            s1.setEstrategia(new StrategyMeses());
            s2.setEstrategia(new StrategyMeses());
            s3.setEstrategia(new StrategyMeses());
            Console.WriteLine("\n=== Estrategia por Meses ===");
            ProbarComparacion(s1, s2, "s1 vs s2");
            ProbarComparacion(s1, s3, "s1 vs s3");

            s1.setEstrategia(new StrategyHoras());
            s2.setEstrategia(new StrategyHoras());
            s3.setEstrategia(new StrategyHoras());
            Console.WriteLine("\n=== Estrategia por Horas ===");
            ProbarComparacion(s1, s2, "s1 vs s2");
            ProbarComparacion(s1, s3, "s1 vs s3");
        }

        static void ProbarComparacion(Suscriptor a, Suscriptor b, string etiqueta)
        {
            Console.WriteLine($"{etiqueta}: {a.getNombre()} (id={a.getId()}, meses={a.getMesesDeSuscripcion()}, hrs={a.getHorasVistas()}) " +
                $"vs {b.getNombre()} (id={b.getId()}, meses={b.getMesesDeSuscripcion()}, hrs={b.getHorasVistas()})");
            Console.WriteLine($"  Igual: {a.sosIgual(b)} | Mayor: {a.sosMayor(b)} | Menor: {a.sosMenor(b)}");
        }
    }
}