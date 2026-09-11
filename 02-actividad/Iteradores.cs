using System.Collections.Generic;

namespace tp2
{
    // ===== Práctica 2, Ejercicio 5: iteradores concretos =====
    // Un único iterador sobre lista alcanza para Pila, Cola y Playlist,
    // ya que las tres guardan sus elementos en orden de inserción.
    public class IteradorLista : IIterador
    {
        private readonly IList<IComparable> datos;
        private int indice;

        public IteradorLista(IList<IComparable> datos)
        {
            this.datos = datos;
            this.indice = 0;
        }

        public void primero() => indice = 0;
        public void siguiente() => indice++;
        public bool fin() => indice >= datos.Count;
        public IComparable actual() => datos[indice];
    }
}
