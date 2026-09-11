using System;
using System.Collections.Generic;

namespace tp2
{
    // Práctica 1, Ej 4 + Práctica 2, Ej 5 (Iterable).
    public class Pila : IColeccionable
    {
        private List<IComparable> datos = new List<IComparable>();

        public void apilar(IComparable elem) => datos.Add(elem);
        public IComparable desapilar()
        {
            IComparable temp = datos[datos.Count - 1];
            datos.RemoveAt(datos.Count - 1);
            return temp;
        }
        public IComparable tope() => datos[datos.Count - 1];
        public bool esVacia() => datos.Count == 0;

        // Solo lectura para el iterador.
        internal IList<IComparable> getDatos() => datos.AsReadOnly();

        public int cuantos() => datos.Count;

        public IComparable minimo()
        {
            if (datos.Count == 0) throw new InvalidOperationException("La pila está vacía.");
            IComparable min = datos[0];
            foreach (IComparable elem in datos)
                if (elem.sosMenor(min)) min = elem;
            return min;
        }

        public IComparable maximo()
        {
            if (datos.Count == 0) throw new InvalidOperationException("La pila está vacía.");
            IComparable max = datos[0];
            foreach (IComparable elem in datos)
                if (elem.sosMayor(max)) max = elem;
            return max;
        }

        public void agregar(IComparable c) => apilar(c);

        public bool contiene(IComparable c)
        {
            foreach (IComparable elem in datos)
                if (elem.sosIgual(c)) return true;
            return false;
        }

        public IIterador crearIterador() => new IteradorLista(datos);
    }
}
