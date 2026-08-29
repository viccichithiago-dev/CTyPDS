namespace tp2 
{
    public interface StrategyComparacion {
        bool sosIgual(IComparable c1, IComparable c2);
        bool sosMayor(IComparable c1, IComparable c2);
        bool sosMenor(IComparable c1, IComparable c2);
    }
    public class StrategyNombre : StrategyComparacion 
    {
        public bool sosIgual(IComparable c1, IComparable c2) { 
            return ((Suscriptor)c1).getNombre() == ((Suscriptor)c2).getNombre();
        }

        public bool sosMayor(IComparable c1, IComparable c2) {
            return string.Compare(((Suscriptor)c1).getNombre(), ((Suscriptor)c2).getNombre()) > 0;        }

        public bool sosMenor(IComparable c1, IComparable c2) 
        {
            return string.Compare(((Suscriptor)c1).getNombre(), ((Suscriptor)c2).getNombre()) < 0;
        }
    }
    public class StrategyId : StrategyComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getId() == ((Suscriptor)c2).getId();
        }

        public bool sosMayor(IComparable c1, IComparable c2) {
            return ((Suscriptor)c1).getId() > ((Suscriptor)c2).getId();
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getId() < ((Suscriptor)c2).getId();
        }
    }
    public class StrategyMeses : StrategyComparacion {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getMesesDeSuscripcion() == ((Suscriptor)c2).getMesesDeSuscripcion();
        }

        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getMesesDeSuscripcion() > ((Suscriptor)c2).getMesesDeSuscripcion();
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getMesesDeSuscripcion() < ((Suscriptor)c2).getMesesDeSuscripcion();
        }
    }
    public class StrategyHoras : StrategyComparacion 
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getHorasVistas() == ((Suscriptor)c2).getHorasVistas();
        }

        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getHorasVistas() > ((Suscriptor)c2).getHorasVistas();
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Suscriptor)c1).getHorasVistas() < ((Suscriptor)c2).getHorasVistas();
        }
    }
}