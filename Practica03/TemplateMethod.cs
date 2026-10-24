using System;

namespace Practica03.TemplateMethod
{
    public abstract class PreparadorDeBebida
    {
        public void PrepararBebida()
        {
            HervirAgua();
            AgregarBaseDeSaborizante();
            VerterEnTaza();
            AgregarCondimentos();
        }

        private void HervirAgua()
        {
            Console.WriteLine("Hirviendo agua");
        }

        protected abstract void AgregarBaseDeSaborizante();

        private void VerterEnTaza()
        {
            Console.WriteLine("Vertiendo en taza");
        }

        protected virtual void AgregarCondimentos()
        {
            Console.WriteLine("Agregando azúcar");
        }
    }

    public class PreparadorDeCafe : PreparadorDeBebida
    {
        protected override void AgregarBaseDeSaborizante()
        {
            Console.WriteLine("Agregando café");
        }

        protected override void AgregarCondimentos()
        {
            Console.WriteLine("Agregando azúcar y leche");
        }
    }

    public class PreparadorDeTe : PreparadorDeBebida
    {
        protected override void AgregarBaseDeSaborizante()
        {
            Console.WriteLine("Agregando té");
        }

        protected override void AgregarCondimentos()
        {
            Console.WriteLine("Agregando miel y limón");
        }
    }
}