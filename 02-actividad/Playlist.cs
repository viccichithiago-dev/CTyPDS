using System;
using System.Collections.Generic;

namespace tp2
{
    // ===== Práctica 2, Ejercicio 3 =====
    // Playlist: colección que almacena elementos sin repetición.
    public class Playlist : IColeccionable
    {
        private List<IComparable> datos = new List<IComparable>();

        // Agrega el elemento solo si no existe.
        public void agregar(IComparable elemento)
        {
            if (!pertenece(elemento))
                datos.Add(elemento);
        }

        // Devuelve verdadero si el elemento ya está en la playlist.
        public bool pertenece(IComparable elemento)
        {
            foreach (IComparable elem in datos)
                if (elem.sosIgual(elemento)) return true;
            return false;
        }

        // ===== Ejercicio 4: Playlist implementa Coleccionable =====
        public int cuantos() => datos.Count;

        public IComparable minimo()
        {
            if (datos.Count == 0) throw new InvalidOperationException("La playlist está vacía.");
            IComparable min = datos[0];
            foreach (IComparable elem in datos)
                if (elem.sosMenor(min)) min = elem;
            return min;
        }

        public IComparable maximo()
        {
            if (datos.Count == 0) throw new InvalidOperationException("La playlist está vacía.");
            IComparable max = datos[0];
            foreach (IComparable elem in datos)
                if (elem.sosMayor(max)) max = elem;
            return max;
        }

        public bool contiene(IComparable c) => pertenece(c);

        // ===== Ejercicio 5: Playlist implementa Iterable =====
        public IIterador crearIterador() => new IteradorLista(datos);
    }
}
