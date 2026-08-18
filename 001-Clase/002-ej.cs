namespace tp1
{
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
    }
}
