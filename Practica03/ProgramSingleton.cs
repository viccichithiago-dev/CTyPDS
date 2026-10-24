using Practica03.Singleton;

namespace Practica03
{
    public class ProgramSingleton
    {
        public static void Run()
        {
            var config1 = ConfiguracionDelSistema.ObtenerInstancia();
            config1.EstablecerValor("servidor", "192.168.1.100");

            var config2 = ConfiguracionDelSistema.ObtenerInstancia();
            Console.WriteLine(config2.ObtenerValor("servidor"));
            Console.WriteLine(ReferenceEquals(config1, config2));
        }
    }
}