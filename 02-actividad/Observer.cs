using System;
using System.Collections.Generic;

namespace tp2
{
    // ===== Práctica 2, Ejercicio 17: patrón Observer =====
    public interface IObservador
    {
        void actualizarPublicacion();
        void actualizarEnVivo();
    }

    public interface IObservado
    {
        void agregarObservador(IObservador o);
        void quitarObservador(IObservador o);
    }

    // ===== Práctica 2, Ejercicio 15: clase Canal (observable) =====
    public class Canal : IObservado
    {
        private string nombre;
        private List<IObservador> observadores = new List<IObservador>();

        public Canal(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre() => nombre;

        public void publicarContenido()
        {
            Console.WriteLine($"{nombre} publicó contenido nuevo");
            foreach (IObservador o in observadores)
                o.actualizarPublicacion();
        }

        public void iniciarEnVivo()
        {
            Console.WriteLine($"{nombre} está en vivo");
            foreach (IObservador o in observadores)
                o.actualizarEnVivo();
        }

        public void agregarObservador(IObservador o)
        {
            observadores.Add(o);
        }

        public void quitarObservador(IObservador o)
        {
            observadores.Remove(o);
        }

        public IReadOnlyList<IObservador> getObservadores() => observadores.AsReadOnly();
    }

    // ===== Práctica 2, Ejercicio 18 =====
    public static class Temporada
    {
        public static void temporadaDeContenido(Canal canal)
        {
            for (int i = 0; i < 5; i++)
            {
                canal.publicarContenido();
                canal.iniciarEnVivo();
            }
        }
    }
}
