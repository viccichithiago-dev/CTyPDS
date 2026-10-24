using System;
using System.Collections.Generic;

namespace Practica03.Composite
{
    public interface IElementoSistemaArchivos
    {
        long ObtenerTamano();
        void Mostrar(int nivelIndentacion = 0);
    }

    public class Archivo : IElementoSistemaArchivos
    {
        private readonly string _nombre;
        private readonly long _tamano;

        public Archivo(string nombre, long tamano)
        {
            _nombre = nombre;
            _tamano = tamano;
        }

        public long ObtenerTamano()
        {
            return _tamano;
        }

        public void Mostrar(int nivelIndentacion = 0)
        {
            string indentacion = new string(' ', nivelIndentacion * 4);
            Console.WriteLine($"{indentacion}{_nombre} ({_tamano} bytes)");
        }
    }

    public class Carpeta : IElementoSistemaArchivos
    {
        private readonly string _nombre;
        private readonly List<IElementoSistemaArchivos> _hijos;

        public Carpeta(string nombre)
        {
            _nombre = nombre;
            _hijos = new List<IElementoSistemaArchivos>();
        }

        public void Agregar(IElementoSistemaArchivos elemento)
        {
            _hijos.Add(elemento);
        }

        public long ObtenerTamano()
        {
            long total = 0;
            foreach (var hijo in _hijos)
            {
                total += hijo.ObtenerTamano();
            }
            return total;
        }

        public void Mostrar(int nivelIndentacion = 0)
        {
            string indentacion = new string(' ', nivelIndentacion * 4);
            Console.WriteLine($"{indentacion}{_nombre}");
            foreach (var hijo in _hijos)
            {
                hijo.Mostrar(nivelIndentacion + 1);
            }
        }
    }
}