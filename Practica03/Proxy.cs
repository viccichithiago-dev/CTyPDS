using System;

namespace Practica03.Proxy
{
    public interface IDocumento
    {
        string Leer(string usuario);
    }

    public class DocumentoReal : IDocumento
    {
        private readonly string _contenido;

        public DocumentoReal()
        {
            Console.WriteLine("Cargando documento (operación costosa)...");
            _contenido = "Contenido confidencial del documento";
        }

        public string Leer(string usuario)
        {
            return _contenido;
        }
    }

    public class DocumentoProxy : IDocumento
    {
        private DocumentoReal _documentoReal;
        private readonly string _nombreArchivo;

        public DocumentoProxy(string nombreArchivo)
        {
            _nombreArchivo = nombreArchivo;
        }

        public string Leer(string usuario)
        {
            if (usuario != "admin")
            {
                return "Acceso denegado";
            }

            if (_documentoReal == null)
            {
                _documentoReal = new DocumentoReal();
            }

            return _documentoReal.Leer(usuario);
        }
    }
}