using System;
namespace tp2
{
	public class Suscriptor : Perfil, IComparable
	{
		private int mesesDeSuscripcion;
		private int horasVistas;
		private StrategyComparacion estrategia;
		public Suscriptor(string nombre, int id, int mesesDeSuscripcion, int horasVistas) : base(nombre, id)
		{
			this.mesesDeSuscripcion = mesesDeSuscripcion;
			this.horasVistas = horasVistas;
			this.estrategia = new StrategyId();
		}
		public void setEstrategia(StrategyComparacion nuevaEstrategia) {
			this.estrategia = nuevaEstrategia;
		}
		public int getMesesDeSuscripcion() { return mesesDeSuscripcion; }
		public int getHorasVistas() { return horasVistas; }
		public new bool sosIgual(IComparable c)
		{
			return this.estrategia.sosIgual(this,c);
		}
		public new bool sosMayor(IComparable c)
		{
			return this.estrategia.sosMayor(this,c);
		}
		public new bool sosMenor(IComparable c)
		{
			return this.estrategia.sosMenor(this,c);
		}
	}
}