namespace diplom
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
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
        static Minimax result;
        Thread tr;
        delegate int Del();
        delegate void newDel();
        bool pauseDrawingFlag = false;
        bool drawingProcessFlag = false;

        public Form1()
        {
            InitializeComponent();
            cbFunctionType.DataSource = GetFunctionList();
            cbFunctionType.ValueMember = "Key";
            cbFunctionType.DisplayMember = "Value";
            cbFunctionType.SelectedIndex = 0;

            TurnOffControlButton();

            cb_mode.DataSource = GetModeList();
            cb_mode.ValueMember = "Key";
            cb_mode.DisplayMember = "Value";
            cb_mode.SelectedIndex = 0;

            cbMethodType.DataSource = GetMethodList();
            cbMethodType.ValueMember = "Key";
            cbMethodType.DisplayMember = "Value";
            cbMethodType.SelectedIndex = 0;
            rb_min.Checked = true;

            tr = new Thread(StartDrawing);
            tr.Priority = ThreadPriority.BelowNormal;
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
                var funcNum = ((KeyValuePair<int, string>)cbFunctionType.SelectedItem).Key;
                var method_num = ((KeyValuePair<int, string>)cbMethodType.SelectedItem).Key;

                var calcmt = MethodFabric.GetMethodType(method_num);

                calcmt.SetValues(temp_start, temp_end, temp_cur, FunctionLibrary.GetFunction(funcNum));
                calcmt.Calculate();
                results_massiv = calcmt.GetResults(mt);

                result.min = calcmt.GetYbyX(calcmt.Min) - 1;
                result.max = calcmt.GetYbyX(calcmt.Max) + 1;

                //some magic
                pointList = calcmt.GetPoints();
                stepList = calcmt.GetSteps(mt);
                FillStepPointRangeList();
                index = 0;
                //StepPointList = calcmt.TreatLastElement(StepPointList);
                DrawGraph(index);
                TurnOnControlButton();
                //some magic

                switch (((KeyValuePair<int, string>)cb_mode.SelectedItem).Key)
                {
                    case 1:
                        {
                            p_dynamic.Visible = true;
                            p_step.Visible = false;
                            p_static.Visible = false;
                            break;
                        }
                    case 2:
                        {
                            p_dynamic.Visible = false;
                            p_step.Visible = true;
                            p_static.Visible = false;
                            break;
                        }
                    case 3:
                        {
                            p_dynamic.Visible = false;
                            p_step.Visible = false;
                            p_static.Visible = true;
                            DrawGraph(StepPointList.Count - 1);
                            break;
                        }
                    default:
                        break;
                }

                //TODO
                tb_res.Text = results_massiv[0].Substring(0, 7);
                tb_func_res.Text = results_massiv[1].Substring(0, 7);
                tb_stepnumber.Text = stepList.Count().ToString();
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

        private List<KeyValuePair<int, string>> GetFunctionList()
        {
            return new List<KeyValuePair<int, string>>(10)
            {
                new KeyValuePair<int, string>(1,"x * x + 2 * x"),
                new KeyValuePair<int, string>(2,"x * x - 2 * x"),
                new KeyValuePair<int, string>(3,"x + 2 * x"),
                new KeyValuePair<int, string>(4,"x - 2 * x"),
            };
        }

        private IEnumerable<KeyValuePair<int, string>> GetMethodList()
        {
            return new List<KeyValuePair<int, string>>(10)
            {
                new KeyValuePair<int, string>(1,"Метод золотого сечения"),
                new KeyValuePair<int, string>(2,"Фибоначчи"),
                new KeyValuePair<int, string>(3,"Дихотомии"),
            };
        }

        private IEnumerable<KeyValuePair<int, string>> GetModeList()
        {
            return new List<KeyValuePair<int, string>>(10)
            {
                new KeyValuePair<int, string>(1,"Автоматический"),
                new KeyValuePair<int, string>(2,"Пошаговый"),
                new KeyValuePair<int, string>(3,"Статический")
            };
        }

        private void DrawGraph(int localindex)
        {
            var ilStartPoints = new ILPoints()
            {
                Positions = pointList,
                Size = 1,
                Color = Color.Teal
            };

            var ilstepPoint = new ILPoints()
            {
                Positions = StepPointList.ElementAt(localindex),
                Size = 1,
                Color = Color.PowderBlue
            };

            localindex = (localindex == StepPointList.Count - 1) ? localindex - 1 : localindex;

            float[,] start = new float[2, 3];
            float[,] end = new float[2, 3];
            Array.Copy(StepPointList.ElementAt(localindex), start, 3);
            Array.Copy(StepPointList.ElementAt(localindex), StepPointList.ElementAt(localindex).Length - 7, end, 2, 3);
            start[1, 0] = start[0, 0];
            start[0, 1] = result.min;
            start[1, 1] = result.max;
            end[0, 0] = end[1, 0];
            end[0, 1] = result.min;
            end[1, 1] = result.max;

            float[,] ex = new float[4, 3];
            Array.Copy(start, ex, 6);
            Array.Copy(end, 0, ex, 6, 6);

            var exLine = new ILLines
            {
                Positions = ex,
                Width = 1,
                Color = Color.MediumVioletRed
            };

            var scene = new ILScene {
        new ILPlotCube(twoDMode: true) {
            ilStartPoints, ilstepPoint, exLine
        }
    };
            this.ilPanel1.Scene = SetScaleModes(scene);
            this.ilPanel1.Invoke(new newDel(() => ilPanel1.Refresh()));
        }

        private static ILScene SetScaleModes(ILScene scene)
        {
            var pcsm = scene.First<ILPlotCube>().ScaleModes;
            pcsm.XAxisScale = AxisScale.Linear;
            pcsm.YAxisScale = AxisScale.Linear;
            pcsm.ZAxisScale = AxisScale.Linear;
            return scene;
        }

        private void bt_firstStep_Click(object sender, EventArgs e)
        {
            this.bt_previousStep.Enabled = false;
            this.bt_nextStep.Enabled = true;
            index = 0;
            this.DrawGraph(index);
        }

        private void bt_previousStep_Click(object sender, EventArgs e)
        {
            index--;
            this.bt_nextStep.Enabled = true;
            this.bt_previousStep.Enabled = (index == 0) ? false : true;
            this.DrawGraph(index);
        }

        private void bt_nextStep_Click(object sender, EventArgs e)
        {
            index++;
            this.bt_previousStep.Enabled = true;
            this.bt_nextStep.Enabled = (index == StepPointList.Count - 1) ? false : true;
            this.DrawGraph(index);
        }

        private void bt_lastStep_Click(object sender, EventArgs e)
        {
            index = StepPointList.Count - 1;
            this.bt_nextStep.Enabled = false;
            this.bt_previousStep.Enabled = true;
            this.DrawGraph(index);
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            pauseDrawingFlag = true;
            new Thread(stopDrawingFunction).Start();
        }

        private void stopDrawingFunction()
        {
            int retries = 0;
            while (drawingProcessFlag)
            {
                if (retries > 5)
                {
                    throw new Exception("Количество попыток ожидания потока исчерпано");
                }
                retries++;
                Thread.Sleep(500);
            }
            resetGraph();
        }

        private void resetGraph()
        {
            index = 0;
            DrawGraph(index);
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            pauseDrawingFlag = false;
            drawingProcessFlag = true;
            tr = new Thread(StartDrawing);
            tr.Start();
        }

        private void bt_pause_Click(object sender, EventArgs e)
        {
            pauseDrawingFlag = true;
        }

        private void StartDrawing()
        {
            while (index < StepPointList.Count)
            {
                var delay = (int)(((float)(1.0 / (int)this.t_speed.Invoke(new Del(() => t_speed.Value)))) * 2000);
                if (pauseDrawingFlag)
                {
                    drawingProcessFlag = false;
                    return;
                }
                DrawGraph(index);
                index++;
                Thread.Sleep(delay);
            }
            drawingProcessFlag = false;
        }

        struct Minimax
        {
            public float min;
            public float max;
        }
    }
}
