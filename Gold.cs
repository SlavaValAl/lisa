namespace optimization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Windows.Forms;

    public class Gold : BaseMethod
    {
        public override void Calculate(MethodType mType)
        {
            float answer = 0;
            float a = (float)this.A;
            float b = (float)this.B;
            double e = this.E;
            float x1;
            float x2;
            float y1;
            float y2;
            this.StepsArray = new List<Segment>();

            while (Math.Abs(b - a) > e)
            {
                x1 = b - (b - a) / BaseMethod.F;
                x2 = a + (b - a) / BaseMethod.F;
                y1 = this.Y(x1);
                y2 = this.Y(x2);

                if (Compare(mType, y1, y2))
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                }

                this.AddStep(a, b);
                answer = (a + b) / 2;
            }
            this.AddStep(answer, answer);

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
