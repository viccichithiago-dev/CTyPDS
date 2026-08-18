using System;
namespace tp1 { 
    public class Suscriptor : Perfil, IComparable
    {
        private int mesesDeSuscripcion;
        private int horasVistas;
        public Suscriptor(string nombre, int id,int mesesDeSuscripcion,int horasVistas) : base(nombre, id)
        {
            this.mesesDeSuscripcion = mesesDeSuscripcion;
            this.horasVistas = horasVistas;
        }
        public int getMesesDeSuscripcion() { return mesesDeSuscripcion; }
        public int getHorasVistas() { return horasVistas; }
        public bool sosIgual(IComparable c) {
            Suscriptor s = (Suscriptor)c;
            return this.mesesDeSuscripcion == s.getMesesDeSuscripcion();   
        }
        public bool sosMayor(IComparable c)
        {
            Suscriptor s = (Suscriptor)c;
            return this.mesesDeSuscripcion > s.getMesesDeSuscripcion();
        }
        public bool sosMenor(IComparable c)
        {
            Suscriptor s = (Suscriptor)c;
            return this.mesesDeSuscripcion < s.getMesesDeSuscripcion();
        }
    }
}