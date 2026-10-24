using System;

namespace Practica03.Command
{
    public class Luz
    {
        public void Encender()
        {
            Console.WriteLine("Luz encendida");
        }

        public void Apagar()
        {
            Console.WriteLine("Luz apagada");
        }
    }

    public interface IComando
    {
        void Ejecutar();
        void Deshacer();
    }

    public class ComandoEncenderLuz : IComando
    {
        private readonly Luz _luz;

        public ComandoEncenderLuz(Luz luz)
        {
            _luz = luz;
        }

        public void Ejecutar()
        {
            _luz.Encender();
        }

        public void Deshacer()
        {
            _luz.Apagar();
        }
    }

    public class ComandoApagarLuz : IComando
    {
        private readonly Luz _luz;

        public ComandoApagarLuz(Luz luz)
        {
            _luz = luz;
        }

        public void Ejecutar()
        {
            _luz.Apagar();
        }

        public void Deshacer()
        {
            _luz.Encender();
        }
    }

    public class ControlRemoto
    {
        private IComando _ultimoComando;

        public void Ejecutar(IComando comando)
        {
            comando.Ejecutar();
            _ultimoComando = comando;
        }

        public void DeshacerUltimo()
        {
            if (_ultimoComando != null)
            {
                _ultimoComando.Deshacer();
                _ultimoComando = null;
            }
        }
    }
}