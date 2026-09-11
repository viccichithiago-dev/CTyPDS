using System;

namespace tp2
{
    // ===== Práctica 2, Ejercicio 1: cuatro estrategias para Suscriptor =====

    // Compara por nombre (alfabético).
    public class EstrategiaPorNombre : IEstrategiaComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getNombre() == ((Suscriptor)c2).getNombre();
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return string.Compare(
                ((Suscriptor)c1).getNombre(),
                ((Suscriptor)c2).getNombre(),
                StringComparison.Ordinal) < 0;
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return string.Compare(
                ((Suscriptor)c1).getNombre(),
                ((Suscriptor)c2).getNombre(),
                StringComparison.Ordinal) > 0;
        }
        public override string ToString() => "Estrategia por nombre";
    }

    // Compara por id (numérico).
    public class EstrategiaPorId : IEstrategiaComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getId() == ((Suscriptor)c2).getId();
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getId() < ((Suscriptor)c2).getId();
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getId() > ((Suscriptor)c2).getId();
        }
        public override string ToString() => "Estrategia por id";
    }

    // Compara por horas vistas.
    public class EstrategiaPorHorasVistas : IEstrategiaComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getHorasVistas() == ((Suscriptor)c2).getHorasVistas();
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getHorasVistas() < ((Suscriptor)c2).getHorasVistas();
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getHorasVistas() > ((Suscriptor)c2).getHorasVistas();
        }
        public override string ToString() => "Estrategia por horas vistas";
    }

    // Compara por meses de suscripción.
    public class EstrategiaPorMesesSuscripcion : IEstrategiaComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getMesesDeSuscripcion() == ((Suscriptor)c2).getMesesDeSuscripcion();
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getMesesDeSuscripcion() < ((Suscriptor)c2).getMesesDeSuscripcion();
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getMesesDeSuscripcion() > ((Suscriptor)c2).getMesesDeSuscripcion();
        }
        public override string ToString() => "Estrategia por meses de suscripcion";
    }
}
