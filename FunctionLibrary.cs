namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public delegate float MyDel(float x);

    public static class FunctionLibrary
    {
        public static float MyPI = (float)Math.PI;
        public static MyDel GetFunction(string id)
        {
            switch (id)
            {
                case "1": return Function1;
                case "2": return Function2;
                case "3": return Function3;
                case "4": return Function4;
                default: throw new InvalidOperationException();
            }
        }

        private static float Function1(float x)
        {
            return x * x + 2 * x;
        }

        private static float Function2(float x)
        {
            return x * x - 2 * x;
        }

        private static float Function3(float x)
        {
            return x + 2 * x;
        }

        private static float Function4(float x)
        {
            return x - 2 * x;
        }
    }
}
