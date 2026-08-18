using System;
namespace tp1 {
    public static class ej12 { 
        private static Random rand = new Random();
        private static readonly string[] Nombres = {"Carlos", "Sofía", "Mateo", "Lucía", "Diego", "Elena", "Santiago", "Valeria","Thiago","Ana","Maria","Jose","Pepito","Jaimito","Demian","Javier","Gustavo"};
        public static void llenarSuscriptores(IColeccionable c)
        {
            for (int i = 0;i < 20; i++)
            {
                string nombre = Nombres[rand.Next(Nombres.Length)];
                IComparable n = new Suscriptor(nombre,i, rand.Next(1, 100), rand.Next(1, 10000));
                c.agregar(n);
            }
        }
    }
}