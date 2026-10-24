using System;

namespace Practica03.ChainOfResponsibility
{
    public class SolicitudDeGasto
    {
        public decimal Monto { get; }
        public string Descripcion { get; }

        public SolicitudDeGasto(decimal monto, string descripcion)
        {
            Monto = monto;
            Descripcion = descripcion;
        }
    }

    public abstract class AprobadorDeGastos
    {
        protected AprobadorDeGastos _sucesor;

        public void EstablecerSucesor(AprobadorDeGastos sucesor)
        {
            _sucesor = sucesor;
        }

        public virtual void Aprobar(SolicitudDeGasto solicitud)
        {
            if (_sucesor != null)
            {
                _sucesor.Aprobar(solicitud);
            }
            else
            {
                Console.WriteLine($"Nadie pudo aprobar: {solicitud.Descripcion} (${solicitud.Monto})");
            }
        }

        protected bool PuedeAprobar(decimal monto, decimal limite)
        {
            return monto <= limite;
        }
    }

    public class Supervisor : AprobadorDeGastos
    {
        private const decimal LIMITE = 1000m;

        public override void Aprobar(SolicitudDeGasto solicitud)
        {
            if (PuedeAprobar(solicitud.Monto, LIMITE))
            {
                Console.WriteLine($"Supervisor aprueba: {solicitud.Descripcion} (${solicitud.Monto})");
            }
            else
            {
                base.Aprobar(solicitud);
            }
        }
    }

    public class Gerente : AprobadorDeGastos
    {
        private const decimal LIMITE = 5000m;

        public override void Aprobar(SolicitudDeGasto solicitud)
        {
            if (PuedeAprobar(solicitud.Monto, LIMITE))
            {
                Console.WriteLine($"Gerente aprueba: {solicitud.Descripcion} (${solicitud.Monto})");
            }
            else
            {
                base.Aprobar(solicitud);
            }
        }
    }

    public class Director : AprobadorDeGastos
    {
        public override void Aprobar(SolicitudDeGasto solicitud)
        {
            Console.WriteLine($"Director aprueba: {solicitud.Descripcion} (${solicitud.Monto})");
        }
    }
}