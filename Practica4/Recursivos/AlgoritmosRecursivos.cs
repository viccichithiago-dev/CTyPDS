namespace Practica4.Recursivos
{
    public class AlgoritmosRecursivos
    {
        public static int rec1(int n)
        {
            Contador.sumar();
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return rec1(n - 1) + rec1(n - 1);
            }
        }

        public static int rec2(int n)
        {
            Contador.sumar();
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return 2 * rec2(n - 1);
            }
        }

        public static long formulaRec1(int n)
        {
            return (1L << n) - 1;
        }

        public static long formulaRec2(int n)
        {
            return n;
        }
    }
}
