using System;

namespace tp2
{
    // Práctica 1, Ej 10 (en el nuevo namespace). Compara por id por defecto.
    public abstract class Perfil : IComparable
    {
        private string nombre;
        private int id;

        public Perfil(string nombre, int id)
        {
            this.nombre = nombre;
            this.id = id;
        }

        public string getNombre() => this.nombre;
        public int getId() => this.id;

        public virtual bool sosIgual(IComparable c)
        {
            Perfil p = (Perfil)c;
            return this.id == p.getId();
        }

        public virtual bool sosMenor(IComparable c)
        {
            Perfil p = (Perfil)c;
            return this.id < p.getId();
        }

        public virtual bool sosMayor(IComparable c)
        {
            Perfil p = (Perfil)c;
            return this.id > p.getId();
        }
    }

    // Práctica 1, Ej 11 + Práctica 2, Ej 1/2 (Strategy), Ej 16/17 (Observer), Ej 19 (Mostrable).
    public class Suscriptor : Perfil, IObservador, Mostrable
    {
        private int mesesDeSuscripcion;
        private int horasVistas;
        private IEstrategiaComparacion estrategia;
        private static readonly Random azarReaccion = new Random();

        public Suscriptor(string nombre, int id, int mesesDeSuscripcion, int horasVistas)
            : base(nombre, id)
        {
            this.mesesDeSuscripcion = mesesDeSuscripcion;
            this.horasVistas = horasVistas;
            // Estrategia por defecto (Ej 2: todo suscriptor se crea con alguna estrategia).
            this.estrategia = new EstrategiaPorMesesSuscripcion();
        }

        public Suscriptor(string nombre, int id, int mesesDeSuscripcion, int horasVistas, IEstrategiaComparacion estrategia)
            : base(nombre, id)
        {
            this.mesesDeSuscripcion = mesesDeSuscripcion;
            this.horasVistas = horasVistas;
            this.estrategia = estrategia ?? new EstrategiaPorMesesSuscripcion();
        }

        public int getMesesDeSuscripcion() => mesesDeSuscripcion;
        public int getHorasVistas() => horasVistas;

        // ----- Patrón Strategy (Ej 1, Ej 8) -----
        public void setEstrategia(IEstrategiaComparacion estrategia)
        {
            this.estrategia = estrategia;
        }

        public IEstrategiaComparacion getEstrategia() => this.estrategia;

        public override bool sosIgual(IComparable c)
        {
            return this.estrategia.sosIgual(this, c);
        }

        public override bool sosMenor(IComparable c)
        {
            return this.estrategia.sosMenor(this, c);
        }

        public override bool sosMayor(IComparable c)
        {
            return this.estrategia.sosMayor(this, c);
        }

        // ----- Ejercicio 16 -----
        public void verContenido()
        {
            Console.WriteLine("Viendo el nuevo contenido");
        }

        public void reaccionarANotificacion()
        {
            string[] frases = { "Abriendo la notificación", "Lo veo después", "Silenciando notificaciones" };
            Console.WriteLine(" " + frases[azarReaccion.Next(frases.Length)]);
        }

        // ----- Ejercicio 17 (Observer: Suscriptor es el observador) -----
        // El canal invoca estos métodos según el evento.
        public void actualizarPublicacion()
        {
            verContenido();
        }

        public void actualizarEnVivo()
        {
            reaccionarANotificacion();
        }

        // Compatibilidad si se usa interfaz con un único método actualizar(evento).
        public void actualizar(string evento)
        {
            if (evento == "publicacion") verContenido();
            else if (evento == "envivo") reaccionarANotificacion();
        }

        // ----- Ejercicio 19 (Mostrable) -----
        public string mostrarInfo()
        {
            return $"{getNombre()} - {horasVistas} horas vistas";
        }

        public Suscriptor getSuscriptor()
        {
            return this;
        }

        public override string ToString()
        {
            return mostrarInfo();
        }
    }
}
