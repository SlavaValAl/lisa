namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Fibonachi : BaseMethod
    {
        public override void Calculate(MethodType mType)
        {
            float answer = 0;
            float a = (float)this.A;
            float b = (float)this.B;
            double e = this.E;
            float D = 0;
            int N = 1;
            Dictionary<int, int> IndexValueList = new Dictionary<int, int>();
            IndexValueList.Add(0, 1);
            IndexValueList.Add(1, 1);
            double de;
            float dx;
            float x1;
            float x2;
            double y1;
            double y2;

            de = (b - a) / e;

            while (IndexValueList[N - 1] < de)
            {
                N++;
                IndexValueList.Add(N, (IndexValueList[N - 1] + IndexValueList[N - 2]));
            }

            dx = (b - a) / IndexValueList[N];
            x1 = a + dx * IndexValueList[N - 2];
            y1 = this.Y(x1);
            x2 = a + dx * IndexValueList[N - 1];
            y2 = this.Y(x2);

            if (mType.HasFlag(MethodType.Minimum))
            {
                this.StepsArray = new List<Segment>();
            }

            for (int j = 1; j <= (N - 3); j++)
            {
                if (Compare(mType, y1, y2))
                {
                    b = x2;
                    x2 = x1;
                    y2 = y1;
                    x1 = a + b - x2;
                    y1 = this.Y(x1);
                }

                else
                {
                    a = x1;
                    x1 = x2;
                    y1 = y2;

                    x2 = a + b - x1;
                    y2 = this.Y(x2);
                }
                if (mType.HasFlag(MethodType.Minimum))
                {
                    this.AddStep(a, b);
                }
            }

            if (Compare(mType, y1, y2))
            {
                b = x2;
                x2 = x1;
                y2 = y1;
            }
            else
            {
                a = x1;
            }
            x1 = x2 - D;
            y1 = this.Y(x1);

            if (mType.HasFlag(MethodType.Minimum))
            {
                this.AddStep(a, b);
            }

            if (Compare(mType, y1, y2))
            {
                b = x2;
            }
            else
            {
                a = x1;
            }

            answer = (a + b) / 2;
            if (mType.HasFlag(MethodType.Minimum))
            {
                this.AddStep(answer, answer);
            }

            switch (mType)
            {
                case MethodType.Minimum: this.Min = answer;
                    break;
                case MethodType.Maximum: this.Max = answer;
                    break;
                default: throw new Exception("Передан неверный тип значения");
            }
        }

        private static bool Compare(MethodType mType, double y1, double y2)
        {
            switch (mType)
            {
                case MethodType.Minimum: return y1 < y2;
                case MethodType.Maximum: return y1 > y2;
                default: throw new Exception("Передан неверный тип значения");
            }
        }
    }
}
