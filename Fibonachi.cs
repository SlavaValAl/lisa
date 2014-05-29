namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Fibonachi : BaseMethod
    {
        public override void CalculateByType(SearchType mType)
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
            float y1;
            float y2;

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
            AdditionInfo.N = N;
            AdditionInfo.Fn = IndexValueList.Last().Value;

            if (mType.HasFlag(SearchType.Minimum))
            {
                this.minStepsArray = new List<Segment>();
            }

            this.AddStep(a, b, mType);
            for (int j = 0; j < (N - 2); j++)
            {
                addInfoList.Add(new AdditionInfo(j, 0));
                if (this.Compare(mType, y1, y2))
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
                case SearchType.Minimum: this.Min = answer;
                    break;
                case SearchType.Maximum: this.Max = answer;
                    break;
                default: throw new Exception("Передан неверный тип значения");
            }
        }

        public override void FillInfoBlock()
        {
            this.infoBlock = new InfoBlock(
                "метод Фибоначчи",
                "a + 0,382( b - a )",
                "b - 0,382( b - a )", 
                string.Empty, 
                string.Empty, 
                string.Empty, 
                string.Empty);
        }
    }
}
