using System;
using System.Text;

namespace tp2
{
    // ===== Práctica 2, Ejercicio 10 =====
    public static class GeneradorDeDatosAleatorios
    {
        private static readonly Random rand = new Random();

        // Devuelve un número aleatorio entre 0 y "max".
        public static int numeroAleatorio(int max)
        {
            return rand.Next(max + 1);
        }

        // Devuelve un string aleatorio de "cant" caracteres.
        public static string stringAleatorio(int cant = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder(cant);
            for (int i = 0; i < cant; i++)
                sb.Append(chars[rand.Next(chars.Length)]);
            return sb.ToString();
        }
    }

    // ===== Práctica 2, Ejercicio 11 =====
    public static class LectorDeDatos
    {
        // Devuelve un número leído por teclado.
        public static int numeroPorTeclado()
        {
            string s = Console.ReadLine() ?? "0";
            return int.Parse(s);
        }

        // Devuelve un string leído por teclado.
        public static string stringPorTeclado()
        {
            return Console.ReadLine() ?? "";
        }
    }
}
