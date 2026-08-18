using System;
using System.Collections.Generic;

namespace tp1
{
    public class Pila<T> : IColeccionable where T : IComparable
    {
        private List<T> datos = new List<T>();

        public void apilar(T elem) {
            this.datos.Add(elem);
        }

        public T desapilar() {
            T temp = this.datos[this.datos.Count - 1];
            this.datos.RemoveAt(this.datos.Count - 1);
            return temp;
        }

        public T tope() {
            return this.datos[this.datos.Count - 1]; 
        }

        public bool esVacia() {
            return this.datos.Count == 0;
        }
        // Implementación de los métodos de IColeccionable
        public int cuantos()
        {
            return this.datos.Count;
        }
        public int minimo()
        {
            if (this.datos.Count == 0)
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
            IComparable min = (IComparable)this.datos[0];
            foreach (T elem in this.datos)
            {
                IComparable comparableElem = (IComparable)elem;
                if (comparableElem.sosMenor(min))
                {
                    min = comparableElem;
                }
            }
            return ExtractComparableValue(min);
        }
        public int maximo()
        {
            if (this.datos.Count == 0)
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
            IComparable max = (IComparable)this.datos[0];
            foreach (T elem in this.datos)
            {
                IComparable comparableElem = (IComparable)elem;
                if (comparableElem.sosMayor(max))
                {
                    max = comparableElem;
                }
            }
            return ExtractComparableValue(max);
        }

        private int ExtractComparableValue(IComparable c)
        {
            if (c is Visualizacion v) return v.getCantidad();
            if (c is Suscriptor s) return s.getMesesDeSuscripcion();
            if (c is Perfil p) return p.getId();
            throw new InvalidOperationException($"Tipo no soportado para extracción de valor: {c.GetType().Name}");
        }
        public void agregar(IComparable c)
        {
            this.apilar((T)c);
        }
        public bool contiene(IComparable c)
        {
            foreach (T elem in this.datos)
            {
                IComparable comparableElem = (IComparable)elem;
                if (comparableElem.sosIgual(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}