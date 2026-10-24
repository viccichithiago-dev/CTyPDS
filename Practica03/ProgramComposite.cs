using Practica03.Composite;

namespace Practica03
{
    public class ProgramComposite
    {
        public static void Run()
        {
            var raiz = new Carpeta("raiz");

            var docs = new Carpeta("Documentos");
            docs.Agregar(new Archivo("informe.pdf", 2048));
            docs.Agregar(new Archivo("notas.txt", 512));

            var imagenes = new Carpeta("Imagenes");
            imagenes.Agregar(new Archivo("foto1.jpg", 10240));
            imagenes.Agregar(new Archivo("foto2.png", 5120));

            raiz.Agregar(docs);
            raiz.Agregar(imagenes);

            raiz.Mostrar();
            Console.WriteLine($"Tamaño total: {raiz.ObtenerTamano()} bytes");
        }
    }
}