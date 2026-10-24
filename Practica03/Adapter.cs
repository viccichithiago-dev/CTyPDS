using System;

namespace Practica03.Adapter
{
    public interface IReproductor
    {
        void Reproducir(string archivo);
    }

    public class ReproductorMp3 : IReproductor
    {
        public void Reproducir(string archivo)
        {
            Console.WriteLine($"Reproduciendo archivo MP3: {archivo}");
        }
    }

    public class ReproductorAvanzadoExterno
    {
        public void ReproducirArchivoAvi(string archivo)
        {
            Console.WriteLine($"Reproduciendo archivo AVI: {archivo}");
        }

        public void ReproducirArchivoMp4(string archivo)
        {
            Console.WriteLine($"Reproduciendo archivo MP4: {archivo}");
        }
    }

    public class AdaptadorReproductorAvanzado : IReproductor
    {
        private readonly ReproductorAvanzadoExterno _reproductorExterno;

        public AdaptadorReproductorAvanzado(ReproductorAvanzadoExterno reproductorExterno)
        {
            _reproductorExterno = reproductorExterno;
        }

        public void Reproducir(string archivo)
        {
            string extension = System.IO.Path.GetExtension(archivo).ToLower();
            switch (extension)
            {
                case ".avi":
                    _reproductorExterno.ReproducirArchivoAvi(archivo);
                    break;
                case ".mp4":
                    _reproductorExterno.ReproducirArchivoMp4(archivo);
                    break;
                default:
                    Console.WriteLine($"Formato no soportado: {extension}");
                    break;
            }
        }
    }

    public static class ReproductorHelper
    {
        public static void ReproducirArchivo(IReproductor reproductor, string archivo)
        {
            reproductor.Reproducir(archivo);
        }
    }
}