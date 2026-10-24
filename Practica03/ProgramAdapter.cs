using Practica03.Adapter;

namespace Practica03
{
    public class ProgramAdapter
    {
        public static void Run()
        {
            var reproductorMp3 = new ReproductorMp3();
            var reproductorExterno = new ReproductorAvanzadoExterno();
            var adaptador = new AdaptadorReproductorAvanzado(reproductorExterno);

            ReproductorHelper.ReproducirArchivo(reproductorMp3, "cancion.mp3");
            ReproductorHelper.ReproducirArchivo(adaptador, "video.avi");
            ReproductorHelper.ReproducirArchivo(adaptador, "video.mp4");
        }
    }
}