namespace tp1
{
    public interface IColeccionable
    {
        int cuantos();
        int minimo();
        int maximo();
        void agregar(IComparable c);
        bool contiene(IComparable c);
    }
}
