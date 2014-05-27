namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Fibonachi : BaseMethod
    {
        public override void CalculateByType(MethodType mType)
        {
            float answer = 0;
            float a = (float)this.A;
            float b = (float)this.B;
            double e = this.E;
            int N = 2;
            Dictionary<int, int> IndexValueList = new Dictionary<int, int>();
            IndexValueList.Add(0, 0);
            IndexValueList.Add(1, 1);
            IndexValueList.Add(2, 1);
            double de;
            float dx;
            float x1;
            float x2;
            double y1;
            double y2;

            de = (b - a) / e;

            while (IndexValueList[N] < de)
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
                this.minStepsArray = new List<Segment>();
            }

            this.AddStep(a, b, mType);
            for (int j = 0; j < (N - 2); j++)
            {
                if (Compare(mType, y1, y2))
                {
                    b = x2;
                    x2 = x1;
                    y2 = y1;
                    x1 = a + IndexValueList[N - j - 2] * (b - a) / IndexValueList[N - j];
                    y1 = this.Y(x1);
                }

                else
                {
                    a = x1;
                    x1 = x2;
                    y1 = y2;

                    x2 = a + IndexValueList[N - j - 1] * (b - a) / IndexValueList[N - j];
                    y2 = this.Y(x2);
                }
                this.AddStep(a, b, mType);
            }

            answer = (a + b) / 2;

            this.AddStep(answer, answer, mType);

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

        public override void FillInfoBlock()
        {
            InfoBlock.message = "метод Фибоначчи";
            this.infoBlock = new InfoBlock("a + 0,382( b - a )", "b - 0,382( b - a )", string.Empty);
        }
    }
}
