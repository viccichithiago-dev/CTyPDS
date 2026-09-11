namespace tp2
{
    // Práctica 1, Ej 2 (en el nuevo namespace).
    public class Visualizacion : IComparable
    {
        private int cantidad;

        public Visualizacion(int cantidad)
        {
            this.cantidad = cantidad;
        }

        public int getCantidad()
        {
            return this.cantidad;
        }

        public bool sosIgual(IComparable c)
        {
            Visualizacion v = (Visualizacion)c;
            return this.cantidad == v.getCantidad();
        }

        public bool sosMenor(IComparable c)
        {
            Visualizacion v = (Visualizacion)c;
            return this.cantidad < v.getCantidad();
        }

        public bool sosMayor(IComparable c)
        {
            Visualizacion v = (Visualizacion)c;
            return this.cantidad > v.getCantidad();
        }

        public override string ToString()
        {
            return $"Visualizacion({cantidad})";
        }
    }
}
