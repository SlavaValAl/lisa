namespace optimization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class MethodFabric
    {
        public static BaseMethod GetMethodType(string str)
        {
            switch (str)
            {
                case "1": return new Gold();
                case "2": return new Fibonachi();
                case "3": return new Dichotomy();
                default: throw new Exception();
            }
        }		
    }
}
