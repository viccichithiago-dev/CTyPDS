using System.Collections.Generic;

namespace Practica4.Strategy
{
    public class BusquedaLineal : EstrategiaDeBusqueda
    {
        public Alumno Buscar(List<Alumno> alumnos, int legajo)
        {
            foreach (Alumno alumno in alumnos)
            {
                Contador.sumar();
                if (alumno.getLegajo() == legajo)
                {
                    return alumno;
                }
            }
            return null;
        }
    }
}
