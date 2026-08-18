using System;
using tp1;

namespace tp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Colecciones para Visualizacion // Ejercicio 7,9 comprobacion
            Pila<Visualizacion> pilaV = new Pila<Visualizacion>();
            Cola<Visualizacion> colaV = new Cola<Visualizacion>();
            Catalogo catalogo = new Catalogo(pilaV, colaV);
            ej5.llenar(pilaV);
            ej5.llenar(colaV);
            ej6.informar(pilaV);
            ej6.informar(colaV);
            ej6.informar(catalogo);

            // Colecciones separadas para Suscriptores,13
            Pila<Suscriptor> pilaS = new Pila<Suscriptor>();
            Cola<Suscriptor> colaS = new Cola<Suscriptor>();
            Catalogo catalogoSuscriptores = new Catalogo(pilaS, colaS);
            ej12.llenarSuscriptores(pilaS);
            ej12.llenarSuscriptores(colaS);
            ej6.informar(catalogoSuscriptores);
        }
    }
}
