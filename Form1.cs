namespace optimization
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ILNumerics;
    using ILNumerics.Drawing;
    using ILNumerics.Drawing.Plotting;

    public partial class Form1 : Form
    {
        private static string[] results_massiv;

        static int index = 0;
        static List<Segment> stepList;
        static float[,] pointList;
        public static List<Point> searcheablePointList;
        List<float[,]> StepPointList;

        public Form1()
        {
            InitializeComponent();
            cbFunctionType.DataSource = GetFunctionList();
            cbFunctionType.ValueMember = "Key";
            cbFunctionType.DisplayMember = "Value";
            cbFunctionType.SelectedValue = "1";

            TurnOffControlButton();

            cbMethodType.DataSource = GetMethodList();
            cbMethodType.ValueMember = "Key";
            cbMethodType.DisplayMember = "Value";
            cbMethodType.SelectedValue = "1";
            rb_min.Checked = true;
        }

        private void TurnOffControlButton()
        {
            this.bt_nextStep.Enabled = false;
            this.bt_firstStep.Enabled = false;
            this.bt_lastStep.Enabled = false;
            this.bt_previousStep.Enabled = false;
        }

        private void TurnOnControlButton()
        {
            this.bt_nextStep.Enabled = true;
            this.bt_firstStep.Enabled = true;
            this.bt_lastStep.Enabled = true;
            this.bt_previousStep.Enabled = true;
        }

        private void bt_calculate_Click(object sender, EventArgs e)
        {
            double temp_start;
            double temp_end;
            double temp_cur;

            try
            {
                try
                {
                    temp_start = double.Parse(this.tb_start.Text);
                    temp_end = double.Parse(this.tb_end.Text);
                    temp_cur = double.Parse(this.tb_currency.Text);
                }
                catch (Exception)
                {
                    throw new Exception("Неверное значение полей для ввода");
                }



                var mt = rb_max.Checked ? MethodType.Maximum : MethodType.Minimum;
                var funcNum = (string)cbFunctionType.SelectedValue;
                var method_num = (string)cbMethodType.SelectedValue;
                if (string.IsNullOrEmpty(funcNum) || string.IsNullOrEmpty(method_num))
                {
                    MessageBox.Show("Некорректные значения списков");
                    return;
                }
                var tempDelegate = FunctionLibrary.GetFunction(funcNum);
                var calcmt = MethodFabric.GetMethodType(method_num);

                calcmt.SetValues(temp_start, temp_end, temp_cur, tempDelegate);
                calcmt.Calculate(mt);

                //some magic
                pointList = calcmt.GetPoints();
                stepList = calcmt.GetSteps();
                FillStepPointRangeList();
                DrawGraph();
                TurnOnControlButton();
                //some magic

                results_massiv = calcmt.GetResults(mt);
                tb_res.Text = results_massiv[0].Substring(0, 7);
                tb_func_res.Text = results_massiv[1].Substring(0, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillStepPointRangeList()
        {
            StepPointList = new List<float[,]>(stepList.Count);
            int startIndex;
            int endIndex;
            int range;
            float[,] mas;
            StepPointList.Add(pointList);

            for (int i = 0; i < stepList.Count; i++)
            {
                var seg = stepList.ElementAt(i);
                startIndex = 3 * searcheablePointList.FindIndex(el => Math.Abs(el.x - seg.x1) <= 0.001);
                endIndex = 3 * searcheablePointList.FindIndex(el => Math.Abs(el.x - seg.x2) <= 0.001) + 2;
                range = endIndex - startIndex + 1;
                //эту хуйню так оставлять нельзя
                mas = new float[range / 3, 3];
                Array.Copy(pointList, startIndex, mas, 0, range);
                StepPointList.Add(mas);
            }
        }

        private List<KeyValuePair<string, string>> GetFunctionList()
        {
            return new List<KeyValuePair<string, string>>(10)
            {
                new KeyValuePair<string, string>("1","x * x + 2 * x"),
                new KeyValuePair<string, string>("2","x * x - 2 * x"),
                new KeyValuePair<string, string>("3","x + 2 * x"),
                new KeyValuePair<string, string>("4","x - 2 * x"),
            };
        }

        private List<KeyValuePair<string, string>> GetMethodList()
        {
            return new List<KeyValuePair<string, string>>(10)
            {
                new KeyValuePair<string, string>("1","Метод золотого сечения"),
                new KeyValuePair<string, string>("2","Фибоначчи"),
                new KeyValuePair<string, string>("3","Дихотомии"),
            };
        }

        private void DrawGraph()
        {
            var ilStartPoints = new ILPoints()
            {
                Positions = pointList,
                Size = 1,
                Color = Color.Red
            };

            var ilstepPoint = new ILPoints()
            {
                Positions = StepPointList.ElementAt(index),
                Size = 1,
                Color = Color.Green
            };

            float[,] start = new float[2, 3];
            float[,] end = new float[2, 3];
            var copy = StepPointList.First();
            Array.Copy(StepPointList.ElementAt(index), start, 3);
            Array.Copy(StepPointList.ElementAt(index), StepPointList.ElementAt(index).Length - 7, end, 2, 3);
            start[1, 0] = start[0, 0];
            start[0, 1] = 0;
            start[1, 1] = end[1, 1];
            end[0, 0] = end[1, 0];
            end[0, 1] = 0;

            var startLine = new ILLines
            {
                Positions = start,
                Color = Color.Red
            };
            var endLine = new ILLines
            {
                Positions = end,
                Color = Color.Red
            };
            var scene = new ILScene {
        new ILPlotCube(twoDMode: true) {
            ilStartPoints, ilstepPoint, startLine, endLine
        }
    };
            var pcsm = scene.First<ILPlotCube>().ScaleModes;
            pcsm.XAxisScale = AxisScale.Linear;
            pcsm.YAxisScale = AxisScale.Linear;
            pcsm.ZAxisScale = AxisScale.Linear;

            this.ilPanel1.Scene = scene;
            this.ilPanel1.Refresh();
        }

        private void bt_firstStep_Click(object sender, EventArgs e)
        {
            this.bt_previousStep.Enabled = false;
            this.bt_nextStep.Enabled = true;
            index = 0;
            this.DrawGraph();
        }

        private void bt_previousStep_Click(object sender, EventArgs e)
        {
            index--;
            this.bt_nextStep.Enabled = true;
            this.bt_previousStep.Enabled = (index == 0) ? false : true;
            this.DrawGraph();
        }

        private void bt_nextStep_Click(object sender, EventArgs e)
        {
            index++;
            this.bt_previousStep.Enabled = true;
            this.bt_nextStep.Enabled = (index == StepPointList.Count - 1) ? false : true;
            this.DrawGraph();
        }

        private void bt_lastStep_Click(object sender, EventArgs e)
        {
            index = StepPointList.Count - 1;
            this.bt_nextStep.Enabled = false;
            this.bt_previousStep.Enabled = true;
            this.DrawGraph();
        }
    }
}
