namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Gold : BaseMethod
    {
        public override void CalculateByType(SearchType mType)
        {
            float answer = 0;
            float a = (float)this.A;
            float b = (float)this.B;
            double e = this.E;
            float x1;
            float x2;
            float y1;
            float y2;
            if (mType.HasFlag(SearchType.Minimum))
            {
                this.minStepsArray = new List<Segment>();
            }
            this.AddStep(a, b, mType);
            while (Math.Abs(b - a) > e)
            {
                x1 = b - (b - a) / BaseMethod.F;
                x2 = a + (b - a) / BaseMethod.F;
                y1 = this.Y(x1);
                y2 = this.Y(x2);

                if (this.Compare(mType, y1, y2))
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                }
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
                "Данный метод заключается в делении интервала неопределенности в пропорциях золотого сечения. На первом шаге вычисляются значения x1 и x2. длины отрезков [a,x1] и [x2,b] одинаковы и составляют 0,382 от длины (a,b). Значениям f(x1) и f(x2) определяется новей интервал (a,x2) или (x1,b) , в котором локализован экстремум. Найденный интервал снова делится двумя точками в том же отношении, причем одна из новых точек деления совпадает с уже использованной на предыдущем шаге. ",
                "a + 0,382( b - a )",
                "b - 0,382( b - a )", 
                string.Empty, 
                string.Empty, 
                string.Empty, 
                string.Empty);
        }
    }
}
