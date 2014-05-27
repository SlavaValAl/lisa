namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Dichotomy : BaseMethod
    {
        public List<float> delta_array = new List<float>(20);

        public override void CalculateByType(MethodType mType)
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

            if (mType.HasFlag(MethodType.Minimum))
            {
                this.minStepsArray = new List<Segment>();
            }

            this.AddStep(a, b, mType);
            addInfoList.Add(new AdditionInfo(e, 0));
            while (b - a > e)
            {
                delta = (b - a) / 4;
                x1 = ((b + a) / 2) - delta;
                x2 = ((b + a) / 2) + delta;
                y1 = this.Y(x1);
                y2 = this.Y(x2);

                if (Compare(mType, y1, y2))
                {
                    a = x1;
                }
                else
                {
                    b = x2;
                }

                addInfoList.Add(new AdditionInfo(delta, 0));
                this.AddStep(a, b, mType);

                answer = (a + b) / 2;
            }
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
                case MethodType.Minimum: return y1 > y2;
                case MethodType.Maximum: return y1 < y2;
                default: throw new Exception("Передан неверный тип значения");
            }
        }

        public override void FillInfoBlock()
        {
            InfoBlock.message = "Данный метод заключается в последовательном делении заданного интервала пополам. На каждом шаге поиска экстремума вычисляются значения x1 и x2, затем вычисляются значения f(x1) и f(x2). После чего сравниваются полученные значения.";
            this.infoBlock = new InfoBlock("( b + a ) / 2  - δ", "( b + a ) / 2  + δ", "( b - a ) / 4");
        }
    }
}
