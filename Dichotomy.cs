namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Dichotomy : BaseMethod
    {
        public override void CalculateByType(SearchType mType)
        {
            float answer = 0;
            float a = (float)this.A;
            float b = (float)this.B;
            float e = (float)this.E;
            float x1 = 0;
            float x2 = 0;
            float y1 = 0;
            float y2 = 0;
            float delta = 0;

            if (mType.HasFlag(SearchType.Minimum))
            {
                this.minStepsArray = new List<Segment>();
            }

            this.AddStep(a, b, mType);
            addInfoList.Add(new AdditionInfo(0, e));
            while (b - a > e)
            {
                delta = (b - a) / 4;
                x1 = ((b + a) / 2) - delta;
                x2 = ((b + a) / 2) + delta;
                y1 = this.Y(x1);
                y2 = this.Y(x2);

                if (this.Compare(mType, y1, y2))
                {
                    a = x1;
                }
                else
                {
                    b = x2;
                }

                addInfoList.Add(new AdditionInfo(0, delta));
                this.AddStep(a, b, mType);

                answer = (a + b) / 2;
            }
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
                "Данный метод заключается в последовательном делении заданного интервала пополам. На каждом шаге поиска экстремума вычисляются значения x1 и x2, затем вычисляются значения f(x1) и f(x2). После чего сравниваются полученные значения.",
                "( b + a ) / 2  - δ",
                "( b + a ) / 2  + δ",
                "( b - a ) / 4", 
                string.Empty, 
                string.Empty, 
                string.Empty);
        }
    }
}
