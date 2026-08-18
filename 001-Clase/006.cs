using System;
namespace tp1 {

    public static class ej6
    {
        public static void informar(IColeccionable c)
        {
            try
            {
                Console.WriteLine("Cantidad de elementos: " + c.cuantos());
                Console.WriteLine("Elemento mínimo: " + c.minimo());
                Console.WriteLine("Elemento máximo: " + c.maximo());
                
                Console.Write("Ingrese un número a buscar: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("No se ingresó valor.");
                    return;
                }
                
                IComparable ic = new Visualizacion(int.Parse(input));
                if (c.contiene(ic))
                {
                    Console.WriteLine("El elemento leido esta en la coleccion.");
                }
                else
                {
                    Console.WriteLine("El elemento leido no esta en la coleccion.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en informar: " + ex.Message);
            }
        }
    }
}