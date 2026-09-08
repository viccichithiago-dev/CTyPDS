namespace tp2
{
    // ===== Práctica 1, Ej 3 (en el nuevo namespace) =====
    // NOTA: a diferencia de la Práctica 1 donde minimo()/maximo() devolvían int,
    // aquí devuelven IComparable para que funcionen con cualquier estrategia
    // (por nombre, por id, por horas, por meses) como pide la Práctica 2, Ej 9 y Ej 14.
    // Además Coleccionable extiende Iterable (Ej 5/6: todo coleccionable tiene iterador).
    public interface IColeccionable : IIterable
    {
        int cuantos();
        IComparable minimo();
        IComparable maximo();
        void agregar(IComparable c);
        bool contiene(IComparable c);
    }

    // ===== Práctica 2, Ejercicio 5: interfaces vistas en teoría =====
    public interface IIterable
    {
        IIterador crearIterador();
    }

    public interface IIterador
    {
        void primero();
        void siguiente();
        bool fin();
        IComparable actual();
    }
}
