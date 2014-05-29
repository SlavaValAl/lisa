namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BaseMethod
    {
        protected const float F = 1.618F;
        protected double A { get; set; }
        protected double B { get; set; }
        protected double E { get; set; }
        protected MyDel Y { get; set; }
        protected List<Segment> minStepsArray = new List<Segment>();
        protected List<Segment> maxStepsArray = new List<Segment>();
        public float Min { get; set; }
        public float Max { get; set; }
        public InfoBlock infoBlock = new InfoBlock();
        public List<AdditionInfo> addInfoList = new List<AdditionInfo>(20);

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

        protected bool Compare(SearchType mType, double y1, double y2)
        {
            switch (mType)
            {
                case SearchType.Minimum: return y1 < y2;
                case SearchType.Maximum: return y1 > y2;
                default: throw new Exception("Передан неверный тип значения");
            }
        }

        public void SetValues(double start, double end, double cur, MyDel y)
        {
            this.A = start;
            this.B = end;
            this.E = cur;
            this.Y = y;
            this.FillInfoBlock();
        }

        public void AddStep(float x1, float x2, SearchType mt)
        {
            switch (mt)
            {
                case SearchType.Minimum: this.minStepsArray.Add(new Segment(x1, x2));
                    break;
                case SearchType.Maximum: this.maxStepsArray.Add(new Segment(x1, x2));
                    break;
                default: throw new FormatException("Unexpected enumerator MethodType value");
            }
        }

        public void Calculate()
        {
            this.CalculateByType(SearchType.Maximum);
            this.CalculateByType(SearchType.Minimum);
        }

        public float GetYbyX(float x)
        {
            return this.Y(x);
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

        public string[] GetResults(SearchType mt)
        {
            return mt.HasFlag(SearchType.Minimum) ?
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

        public virtual void CalculateByType(SearchType mType)
        { }

        public virtual void FillInfoBlock()
        { }

        public List<Segment> GetSteps(SearchType mt)
        {
            return mt.HasFlag(SearchType.Maximum) ? this.maxStepsArray : this.minStepsArray;
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

        public static BaseMethod GetMethodType(int num)
        {
            switch (num)
            {
                case 1: return new Gold();
                case 2: return new Fibonachi();
                case 3: return new Dichotomy();
                default: throw new Exception();
            }
        }
    }

    public enum SearchType
    {
        Minimum = 1,
        Maximum = 2
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

    public struct InfoBlock
    {
        public string message;
        public string left_border;
        public string right_border;
        public string delta;
        public string Fn;
        public string N;
        public string k;

        public InfoBlock(string message, string left_border, string right_border, string delta, string Fn, string N, string k)
        {
            this.message = message;
            this.left_border = left_border;
            this.right_border = right_border;
            //dichotomy method
            this.delta = delta;
            //fibonachi method
            this.Fn = Fn;
            this.N = N;
            this.k = k;
        }
    }

    public struct AdditionInfo
    {
        public static int Fn;
        public static int N;
        public float k;
        public float delta;

        public AdditionInfo(float k, float delta)
        {
            this.k = k;
            this.delta = delta;
        }
    }
}
