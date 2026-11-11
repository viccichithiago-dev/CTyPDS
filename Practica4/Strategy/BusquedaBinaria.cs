using System.Collections.Generic;

namespace Practica4.Strategy
{
    public class BusquedaBinaria : EstrategiaDeBusqueda
    {
        public Alumno Buscar(List<Alumno> alumnos, int legajo)
        {
            int inicio = 0;
            int fin = alumnos.Count - 1;
            while (inicio <= fin)
            {
                Contador.sumar();
                int medio = (inicio + fin) / 2;
                Alumno alumno = alumnos[medio];
                if (alumno.getLegajo() == legajo)
                {
                    return alumno;
                }
                if (alumno.getLegajo() < legajo)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }
            return null;
        }
    }
}
