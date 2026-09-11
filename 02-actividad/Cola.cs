using System;
using System.Collections.Generic;

namespace tp2
{
    // Práctica 1, Ej 4 + Práctica 2, Ej 5 (Iterable).
    public class Cola : IColeccionable
    {
        private List<IComparable> datos = new List<IComparable>();

        public void encolar(IComparable elem) => datos.Add(elem);
        public IComparable desencolar()
        {
            IComparable temp = datos[0];
            datos.RemoveAt(0);
            return temp;
        }
        public IComparable tope() => datos[0];
        public bool esVacia() => datos.Count == 0;

        internal IList<IComparable> getDatos() => datos.AsReadOnly();

        public int cuantos() => datos.Count;

        public IComparable minimo()
        {
            if (datos.Count == 0) throw new InvalidOperationException("La cola está vacía.");
            IComparable min = datos[0];
            foreach (IComparable elem in datos)
                if (elem.sosMenor(min)) min = elem;
            return min;
        }

        public IComparable maximo()
        {
            if (datos.Count == 0) throw new InvalidOperationException("La cola está vacía.");
            IComparable max = datos[0];
            foreach (IComparable elem in datos)
                if (elem.sosMayor(max)) max = elem;
            return max;
        }

        public void agregar(IComparable c) => encolar(c);

        public bool contiene(IComparable c)
        {
            foreach (IComparable elem in datos)
                if (elem.sosIgual(c)) return true;
            return false;
        }

        public IIterador crearIterador() => new IteradorLista(datos);
    }
}
