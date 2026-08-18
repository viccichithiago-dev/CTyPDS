using System;
namespace tp1 {

    public class Catalogo : IColeccionable
    {
        private IColeccionable pila;
        private IColeccionable cola;
        public Catalogo(IColeccionable p, IColeccionable c)
        {
            this.pila = p;
            this.cola = c;
        }
        public IColeccionable GetPila() => this.pila;
        public IColeccionable GetCola() => this.cola;
        public int cuantos()
        {
            return this.pila.cuantos() + this.cola.cuantos();
        }
        public int minimo()
        {
            int minPila = this.pila.minimo();
            int minCola = this.cola.minimo();
            return Math.Min(minPila, minCola);
        }
        public int maximo()
        {
            int maxPila = this.pila.maximo();
            int maxCola = this.cola.maximo();
            return Math.Max(maxPila, maxCola);
        }
        public bool contiene(IComparable c)
        {
            return this.pila.contiene(c) || this.cola.contiene(c);
        }
        public void agregar(IComparable c)
        {
            Console.WriteLine("No se puede agregar elementos al catalogo.");
        }
    }
}