namespace tp2
{
    // ===== Ejercicio base (Práctica 1, Ej 1) en el nuevo namespace =====
    public interface IComparable
    {
        bool sosIgual(IComparable c);
        bool sosMenor(IComparable c);
        bool sosMayor(IComparable c);
    }

    // ===== Práctica 2, Ejercicio 1: Estrategia de comparación =====
    // Patrón Strategy: la comparación se delega a un objeto estrategia.
    public interface IEstrategiaComparacion
    {
        bool sosIgual(IComparable c1, IComparable c2);
        bool sosMenor(IComparable c1, IComparable c2);
        bool sosMayor(IComparable c1, IComparable c2);
    }
}
