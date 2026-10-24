using Practica03.TemplateMethod;

namespace Practica03
{
    public class ProgramTemplateMethod
    {
        public static void Run()
        {
            var cafe = new PreparadorDeCafe();
            cafe.PrepararBebida();

            var te = new PreparadorDeTe();
            te.PrepararBebida();
        }
    }
}