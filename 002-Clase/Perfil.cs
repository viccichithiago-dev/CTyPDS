using System;
namespace tp2
{
    public abstract class Perfil : IComparable
    {
        private string nombre;
        private int id;
        public Perfil(string nombre, int id)
        {
            this.nombre = nombre;
            this.id = id;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public int getId()
        {
            return this.id;
        }
        public bool sosIgual(IComparable c)
        {
            Perfil p = (Perfil)c;
            return this.id == p.getId();
        }
        public bool sosMenor(IComparable c)
        {
            Perfil p = (Perfil)c;
            return this.id < p.getId();
        }
        public bool sosMayor(IComparable c)
        {
            Perfil p = (Perfil)c;
            return this.id > p.getId();
        }
    }
}