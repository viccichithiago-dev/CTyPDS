using System;

namespace tp2
{
    // ===== Práctica 2, Ejercicio 19 =====
    public interface Mostrable
    {
        string mostrarInfo();
        Suscriptor getSuscriptor();
    }

    // ===== Práctica 2, Ejercicio 20: decorador abstracto =====
    public abstract class DecoradorSuscriptor : Mostrable
    {
        protected Mostrable componente;

        public DecoradorSuscriptor(Mostrable componente)
        {
            this.componente = componente;
        }

        public abstract string mostrarInfo();

        public Suscriptor getSuscriptor()
        {
            return componente.getSuscriptor();
        }
    }

    // Agrega los meses de antigüedad: Juan (Suscriptor hace 14 meses) - 45 horas vistas
    public class DecoradoAntiguedad : DecoradorSuscriptor
    {
        public DecoradoAntiguedad(Mostrable componente) : base(componente) { }

        public override string mostrarInfo()
        {
            Suscriptor s = getSuscriptor();
            string interno = componente.mostrarInfo();
            // Separa "Nombre - resto" para insertar "(Suscriptor hace N meses)" tras el nombre.
            int sep = interno.IndexOf(" - ");
            if (sep < 0)
                return $"{s.getNombre()} (Suscriptor hace {s.getMesesDeSuscripcion()} meses)";
            string head = interno.Substring(0, sep);
            string tail = interno.Substring(sep); // incluye " - ..."
            return $"{head} (Suscriptor hace {s.getMesesDeSuscripcion()} meses){tail}";
        }
    }

    // Agrega nivel de fanático según horas: Bronce (<10), Plata (10-49), Oro (>=50).
    // Ejemplo: [Plata] Juan - 45 horas vistas
    public class DecoradoFanatico : DecoradorSuscriptor
    {
        public DecoradoFanatico(Mostrable componente) : base(componente) { }

        public override string mostrarInfo()
        {
            Suscriptor s = getSuscriptor();
            string nivel = s.getHorasVistas() < 10 ? "Bronce"
                : s.getHorasVistas() < 50 ? "Plata" : "Oro";
            return $"[{nivel}] {componente.mostrarInfo()}";
        }
    }

    // Agrega el estado de la cuenta: Activo si tiene horas vistas, Inactivo si no.
    // Ejemplo: Juan (Cuenta Activa) - 45 horas vistas
    // Si el interior ya tiene "(...)" (p.ej. antigüedad), lo combina:
    // "(Suscriptor hace 14 meses, Cuenta Activa)" como pide el Ej 21.
    public class DecoradoEstadoCuenta : DecoradorSuscriptor
    {
        public DecoradoEstadoCuenta(Mostrable componente) : base(componente) { }

        public override string mostrarInfo()
        {
            Suscriptor s = getSuscriptor();
            string estado = s.getHorasVistas() > 0 ? "Cuenta Activa" : "Cuenta Inactiva";
            string interno = componente.mostrarInfo();
            int sep = interno.IndexOf(" - ");
            string head = sep < 0 ? interno : interno.Substring(0, sep);
            string tail = sep < 0 ? "" : interno.Substring(sep);
            if (head.EndsWith(")"))
                head = head.Substring(0, head.Length - 1) + $", {estado})";
            else
                head = $"{head} ({estado})";
            return head + tail;
        }
    }

    // Envuelve el resultado en un recuadro:
    // ****************************
    // * Juan - 45 horas vistas *
    // ****************************
    public class DecoradoRecuadro : DecoradorSuscriptor
    {
        public DecoradoRecuadro(Mostrable componente) : base(componente) { }

        public override string mostrarInfo()
        {
            string interno = componente.mostrarInfo();
            string borde = new string('*', interno.Length + 4);
            return $"{borde}\n* {interno} *\n{borde}";
        }
    }

    // ===== Práctica 2, Ejercicio 21: combinación completa =====
    // Orden: antigüedad, nivel de fanático, estado de cuenta y recuadro.
    // Resultado: recuadro con "[Plata] Juan (Suscriptor hace 14 meses, Cuenta Activa) - 45 horas vistas"
    public static class DecoradosHelper
    {
        public static Mostrable conTodosLosDecorados(Mostrable base_)
        {
            Mostrable m = new DecoradoAntiguedad(base_);
            m = new DecoradoFanatico(m);
            m = new DecoradoEstadoCuenta(m);
            m = new DecoradoRecuadro(m);
            return m;
        }
    }
}
