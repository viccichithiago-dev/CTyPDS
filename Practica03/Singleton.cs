using System;
using System.Collections.Generic;

namespace Practica03.Singleton
{
    public class ConfiguracionDelSistema
    {
        private static ConfiguracionDelSistema _instancia;
        private static readonly object _lock = new object();
        private readonly Dictionary<string, string> _valores;

        private ConfiguracionDelSistema()
        {
            _valores = new Dictionary<string, string>();
        }

        public static ConfiguracionDelSistema ObtenerInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new ConfiguracionDelSistema();
                    }
                }
            }
            return _instancia;
        }

        public void EstablecerValor(string clave, string valor)
        {
            _valores[clave] = valor;
        }

        public string ObtenerValor(string clave)
        {
            return _valores.TryGetValue(clave, out string valor) ? valor : null;
        }
    }
}