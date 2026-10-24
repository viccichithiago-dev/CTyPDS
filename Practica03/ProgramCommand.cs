using Practica03.Command;

namespace Practica03
{
    public class ProgramCommand
    {
        public static void Run()
        {
            var luz = new Luz();
            var control = new ControlRemoto();

            control.Ejecutar(new ComandoEncenderLuz(luz));
            control.Ejecutar(new ComandoApagarLuz(luz));
            control.Ejecutar(new ComandoEncenderLuz(luz));
            control.DeshacerUltimo();
        }
    }
}