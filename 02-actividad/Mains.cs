using System;

namespace tp2
{
    public static class Mains
    {
        // ===== Práctica 2, Ejercicio 7 =====
        public static void MainEj7()
        {
            Console.WriteLine("===== Ej 7: pila, cola y playlist de suscriptores =====");
            Pila pila = new Pila();
            Cola cola = new Cola();
            Playlist playlist = new Playlist();
            Funciones.llenarSuscriptores(pila);
            Funciones.llenarSuscriptores(cola);
            Funciones.llenarSuscriptores(playlist);
            Console.WriteLine("--- Pila ---");
            Funciones.imprimirElementos(pila);
            Console.WriteLine("--- Cola ---");
            Funciones.imprimirElementos(cola);
            Console.WriteLine("--- Playlist ---");
            Funciones.imprimirElementos(playlist);
        }

        // ===== Práctica 2, Ejercicio 9 =====
        public static void MainEj9()
        {
            Console.WriteLine("===== Ej 9: cambiar estrategia e informar mínimo y máximo =====");
            Pila pila = new Pila(); // o Cola o Playlist
            Funciones.llenarSuscriptores(pila);

            Funciones.cambiarEstrategia(pila, new EstrategiaPorNombre());
            Console.WriteLine("--- Estrategia por nombre ---");
            Funciones.informarSinTeclado(pila);

            Funciones.cambiarEstrategia(pila, new EstrategiaPorMesesSuscripcion());
            Console.WriteLine("--- Estrategia por meses de suscripción ---");
            Funciones.informarSinTeclado(pila);

            Funciones.cambiarEstrategia(pila, new EstrategiaPorHorasVistas());
            Console.WriteLine("--- Estrategia por horas vistas ---");
            Funciones.informarSinTeclado(pila);

            Funciones.cambiarEstrategia(pila, new EstrategiaPorId());
            Console.WriteLine("--- Estrategia por id ---");
            Funciones.informarSinTeclado(pila);
        }

        // ===== Práctica 2, Ejercicio 14: mains de Práctica 1 con versiones unificadas =====
        public static void MainEj14()
        {
            Console.WriteLine("===== Ej 14: llenarFactory / informarFactory =====");
            Pila pilaV = new Pila();
            Cola colaV = new Cola();
            FuncionesFactory.llenarFactory(pilaV, FabricaDeComparables.OPCION_VISUALIZACION);
            FuncionesFactory.llenarFactory(colaV, FabricaDeComparables.OPCION_VISUALIZACION);
            Console.WriteLine("--- Pila de visualizaciones ---");
            Funciones.informarSinTeclado(pilaV);
            Console.WriteLine("--- Cola de visualizaciones ---");
            Funciones.informarSinTeclado(colaV);

            Pila pilaS = new Pila();
            Cola colaS = new Cola();
            FuncionesFactory.llenarFactory(pilaS, FabricaDeComparables.OPCION_SUSCRIPTOR);
            FuncionesFactory.llenarFactory(colaS, FabricaDeComparables.OPCION_SUSCRIPTOR);
            Console.WriteLine("--- Pila de suscriptores ---");
            Funciones.informarSinTeclado(pilaS);
            Console.WriteLine("--- Cola de suscriptores ---");
            Funciones.informarSinTeclado(colaS);
        }

        // ===== Práctica 2, Ejercicio 18 =====
        public static void MainEj18()
        {
            Console.WriteLine("===== Ej 18: observer con 20 suscriptores =====");
            Canal canal = FabricaDeCanales.crearAleatorio();
            for (int i = 0; i < 20; i++)
                canal.agregarObservador((IObservador)FabricaDeComparables.crearAleatorio(FabricaDeComparables.OPCION_SUSCRIPTOR));
            Temporada.temporadaDeContenido(canal);
        }

        // ===== Práctica 2, Ejercicio 21 =====
        public static void MainEj21()
        {
            Console.WriteLine("===== Ej 21: suscriptor con todos los decorados =====");
            Suscriptor juan = new Suscriptor("Juan", 1, 14, 45);
            Mostrable decorado = DecoradosHelper.conTodosLosDecorados(juan);
            Console.WriteLine(decorado.mostrarInfo());
        }

        // ===== Práctica 2, Ejercicio 22: combina las tres partes =====
        public static void MainEj22()
        {
            Console.WriteLine("===== Ej 22: canal + observer + decoradores =====");
            Canal canal = new Canal("CTyPDS UNAJ");
            for (int i = 0; i < 10; i++)
            {
                Suscriptor s = (Suscriptor)FabricaDeComparables.crearAleatorio(FabricaDeComparables.OPCION_SUSCRIPTOR);
                canal.agregarObservador(s);
            }
            Temporada.temporadaDeContenido(canal);
            foreach (IObservador o in canal.getObservadores())
            {
                Mostrable decorado = DecoradosHelper.conTodosLosDecorados((Mostrable)o);
                Console.WriteLine(decorado.mostrarInfo());
            }
        }
    }
}
