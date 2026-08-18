using System;
using System.Collections.Generic;
namespace tp1
{

	public class Cola<T> : IColeccionable where T : IComparable
	{


		private List<T> datos = new List<T>();

		public void encolar(T elem) {
			this.datos.Add(elem);
		}

		public T desencolar() {
			T temp = this.datos[0];
			this.datos.RemoveAt(0);
			return temp;
		}

		public T tope() {
			return this.datos[0]; 
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
				throw new InvalidOperationException("La cola está vacía.");
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
				throw new InvalidOperationException("La cola está vacía.");
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
		public void agregar(IComparable c)
		{
			this.encolar((T)c);
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
		public List<T> getDatos()
			{
				return this.datos;
			}

		private int ExtractComparableValue(IComparable c)
		{
			if (c is Visualizacion v) return v.getCantidad();
            if (c is Suscriptor s) return s.getMesesDeSuscripcion();
			if (c is Perfil p) return p.getId();
			throw new InvalidOperationException($"Tipo no soportado para extracción de valor: {c.GetType().Name}");
		}
    }
}
