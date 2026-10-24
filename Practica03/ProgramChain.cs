using Practica03.ChainOfResponsibility;

namespace Practica03
{
    public class ProgramChain
    {
        public static void Run()
        {
            var supervisor = new Supervisor();
            var gerente = new Gerente();
            var director = new Director();

            supervisor.EstablecerSucesor(gerente);
            gerente.EstablecerSucesor(director);

            supervisor.Aprobar(new SolicitudDeGasto(500, "Material de oficina"));
            supervisor.Aprobar(new SolicitudDeGasto(3000, "Capacitación"));
            supervisor.Aprobar(new SolicitudDeGasto(10000, "Servidor"));

            var soloSupervisor = new Supervisor();
            soloSupervisor.Aprobar(new SolicitudDeGasto(3000, "Capacitación"));
        }
    }
}