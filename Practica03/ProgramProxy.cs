using Practica03.Proxy;

namespace Practica03
{
    public class ProgramProxy
    {
        public static void Run()
        {
            var proxy = new DocumentoProxy("documento.txt");

            Console.WriteLine(proxy.Leer("usuario"));
            Console.WriteLine(proxy.Leer("admin"));
            Console.WriteLine(proxy.Leer("admin"));
        }
    }
}