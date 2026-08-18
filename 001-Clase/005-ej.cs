using System;
namespace tp1
{
    public static class ej5
    {
        public static void llenar(IColeccionable c)
        {
            Random rand = new Random();
            for (int i = 1; i <= 20; i++)
            {
                IComparable n = new Visualizacion(rand.Next(100));
                c.agregar(n);
            }
        }
    }
}
