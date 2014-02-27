namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BaseMethod
    {
        protected double A { get; set; }
        protected double B { get; set; }
        protected double E { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        protected const float F = 1.618F;
        protected MyDel Y { get; set; }
        protected List<Segment> StepsArray { get; set; }

        public float GetYbyX(float x)
        {
            return this.Y(x);

        }


        public void SetValues(double start, double end, double cur, MyDel y)
        {
            this.A = start;
            this.B = end;
            this.E = cur;
            this.Y = y;
        }

        public virtual void Calculate(MethodType mType)
        { }

        public string[] GetResults(MethodType mt)
        {
            return mt.HasFlag(MethodType.Minimum) ?
                new string[2]
                    {
                       this.Min.ToString().PadRight(7,'0'),
                       this.Y(this.Min).ToString().PadRight(7,'0')
                    }
            :
            new string[2]
                    {
                       this.Max.ToString().PadRight(7,'0'),
                       this.Y(this.Max).ToString().PadRight(7,'0')
                    };
        }

        public List<Segment> GetSteps()
        {
            return this.StepsArray;
        }

        public void AddStep(float x1, float x2)
        {
            this.StepsArray.Add(new Segment(x1, x2));
        }

        public float[,] GetPoints()
        {
            float step = 0.001F;
            float a = (float)this.A;
            float b = (float)this.B;

            int N = (int)Math.Round(Math.Abs(b - a) / step) + 1;
            Form1.searcheablePointList = new List<Point>(N);

            var temp = new float[N, 3];

            for (int i = 0; b > a; i++, a = a + step)
            {
                if (N == i)
                {
                    break;
                }
                temp[i, 0] = a;
                temp[i, 1] = this.Y(a);
                temp[i, 2] = 0;
                Form1.searcheablePointList.Add(new Point(a, temp[i, 1]));
            }
            return DeleteEmptyElements(temp);
        }

        private float[,] DeleteEmptyElements(float[,] temp)
        {
            var emptynum = 0;
            var n = temp.GetLength(0) - 4;
            while (n != temp.GetLength(0) - 1)
            {
                if (temp[n, 0] == 0 && temp[n, 1] == 0)
                {
                    emptynum++;
                }
                n++;
            }
            var resultarray = new float[temp.GetLength(0) - emptynum, 3];
            Array.Copy(temp, 0, resultarray, 0, temp.Length - emptynum * 3 - 1);
            return resultarray;
        }
    }


    public struct Segment
    {
        public double x1;
        public double x2;
        public Segment(double X1, double X2)
        {
            this.x1 = X1;
            this.x2 = X2;
        }
    }

    public struct Point
    {
        public float x;
        public float y;
        public float z;

        public Point(float X, float Y)
        {
            this.x = X;
            this.y = Y;
            this.z = 0;
        }
    }
}
