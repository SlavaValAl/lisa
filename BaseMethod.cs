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
        protected List<Segment> minStepsArray = new List<Segment>();
        protected List<Segment> maxStepsArray = new List<Segment>();


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

        public virtual void CalculateByType(MethodType mType)
        { }

        public virtual void Info(string str_info, string delta, string x1, string x2)
        { }


        public void Calculate()
        {
            this.CalculateByType(MethodType.Maximum);
            this.CalculateByType(MethodType.Minimum);
        }

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

        public List<Segment> GetSteps(MethodType mt)
        {
            return mt.HasFlag(MethodType.Maximum) ? this.maxStepsArray : this.minStepsArray;
        }

        public void AddStep(float x1, float x2, MethodType mt)
        {
            switch (mt)
            {
                case MethodType.Minimum: this.minStepsArray.Add(new Segment(x1, x2));
                    break;
                case MethodType.Maximum: this.maxStepsArray.Add(new Segment(x1, x2));
                    break;
                default: throw new FormatException("Unexpected enumerator MethodType value");
            }
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
            var n = temp.GetLength(0) - 9;
            while (n != temp.GetLength(0))
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

        public List<float[,]> TreatLastElement(List<float[,]> steplist)
        {
            float accuracy = 0.001F;
            var el = steplist.Last();
            var elres = new float[2, 3];
            elres[0, 0] = el[0, 0] - accuracy;
            elres[0, 1] = el[0, 1];
            elres[1, 0] = el[0, 0] + accuracy;
            elres[1, 1] = el[0, 1];
            steplist.Remove(el);
            steplist.Add(elres);
            return steplist;
        }

        //public string INFO
        //{
        //    set
        //    {
        //        this.Info(info);
        //    }
        //    get
        //    {
        //        return info;
        //    }
            
        //}
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
