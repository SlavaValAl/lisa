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
        int index = 0;
        float[,] pointList;
        bool pauseDrawingFlag = false;
        bool drawingProcessFlag = false;
        Minimax result;
        BaseMethod calcmt;
        Thread tr;
        delegate int Del();
        delegate void newDel();
        List<float[,]> StepPointList;
        static List<Segment> stepList;
        public static List<Point> searcheablePointList;

        public Form1()
        {
            this.InitializeComponent();
            this.cbFunctionType.DataSource = this.GetFunctionList();
            this.cbFunctionType.ValueMember = "Key";
            this.cbFunctionType.DisplayMember = "Value";
            this.cbFunctionType.SelectedIndex = 0;

            this.TurnOffControlButton();

            this.cb_mode.DataSource = this.GetModeList();
            this.cb_mode.ValueMember = "Key";
            this.cb_mode.DisplayMember = "Value";
            this.cb_mode.SelectedIndex = 0;

            this.cbMethodType.DataSource = this.GetMethodList();
            this.cbMethodType.ValueMember = "Key";
            this.cbMethodType.DisplayMember = "Value";
            this.cbMethodType.SelectedIndex = 0;
            this.rb_min.Checked = true;
        }

        private void TurnOffControlButton()
        {
            this.bt_nextStep.Enabled = false;
            this.bt_firstStep.Enabled = false;
            this.bt_lastStep.Enabled = false;
            this.bt_previousStep.Enabled = false;
            this.p_fibonachi.Visible = false;
            this.p_dihotomy.Visible = false;
        }

        private void TurnOnControlButton()
        {
            this.bt_nextStep.Enabled = true;
            this.bt_firstStep.Enabled = true;
            this.bt_lastStep.Enabled = true;
            this.bt_previousStep.Enabled = false;
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
                    throw new Exception("Неверное значение полей для ввода.");
                }

                if ((temp_cur <= 0) || (temp_cur >= 1)) throw new Exception("Неверный ввод! Точность задается в диапазоне от 0 до 1.");

                var mt = rb_max.Checked ? SearchType.Maximum : SearchType.Minimum;
                var funcNum = ((KeyValuePair<int, string>)cbFunctionType.SelectedItem).Key;
                var method_num = ((KeyValuePair<int, string>)cbMethodType.SelectedItem).Key;

                this.calcmt = BaseMethod.GetMethodType(method_num);

                this.calcmt.SetValues(temp_start, temp_end, temp_cur, FunctionLibrary.GetFunction(funcNum));
                this.calcmt.Calculate();
                string[] results_massiv = this.calcmt.GetResults(mt);

                this.result.min = this.calcmt.GetYbyX(this.calcmt.Min) - 1;
                this.result.max = this.calcmt.GetYbyX(this.calcmt.Max) + 1;

                //some magic
                this.pointList = this.calcmt.GetPoints();
                Form1.stepList = this.calcmt.GetSteps(mt);
                this.FillStepPointRangeList(temp_cur);
                this.index = 0;
                //StepPointList = calcmt.TreatLastElement(StepPointList);
                this.DrawGraph(this.index);
                this.TurnOnControlButton();
                //some magic
                this.rtbInfo.Text = this.calcmt.infoBlock.message;


                switch (((KeyValuePair<int, string>)cb_mode.SelectedItem).Key)
                {
                    case 1:
                        {
                            this.p_dynamic.Visible = true;
                            this.p_step.Visible = false;
                            this.p_static.Visible = false;
                            this.panel_steps.Visible = false;
                            break;
                        }
                    case 2:
                        {
                            this.p_dynamic.Visible = false;
                            this.p_step.Visible = true;
                            this.p_static.Visible = false;
                            this.panel_steps.Visible = true;
                            break;
                        }
                    case 3:
                        {
                            this.p_dynamic.Visible = false;
                            this.p_step.Visible = false;
                            this.p_static.Visible = true;
                            this.panel_steps.Visible = false;
                            this.DrawGraph(StepPointList.Count - 1);
                            break;
                        }
                    default:
                        break;
                }

                SwitchPanelVisibility();

                //TODO
                this.tb_res.Text = results_massiv[0].Substring(0, 7);
                this.tb_func_res.Text = results_massiv[1].Substring(0, 7);
                this.tb_stepnumber.Text = Form1.stepList.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SwitchPanelVisibility()
        {
            switch (((KeyValuePair<int, string>)cbMethodType.SelectedItem).Key)
            {
                case 1:
                    {
                        this.p_fibonachi.Visible = false;
                        this.p_dihotomy.Visible = false;
                        break;
                    }
                case 2:
                    {
                        this.p_fibonachi.Visible = true;
                        this.p_dihotomy.Visible = false;
                        break;
                    }
                case 3:
                    {
                        this.p_fibonachi.Visible = false;
                        this.p_dihotomy.Visible = true;
                        break;
                    }
                default:
                    break;
            }
        }

        private void FillStepPointRangeList(double currency)
        {
            StepPointList = new List<float[,]>(stepList.Count);
            int startIndex;
            int endIndex;
            int range;
            float[,] mas;

            for (int i = 0; i < stepList.Count; i++)
            {
                var seg = stepList.ElementAt(i);
                startIndex = 3 * Form1.searcheablePointList.FindIndex(el => Math.Abs(el.x - seg.x1) <= 0.001);
                endIndex = 3 * Form1.searcheablePointList.FindIndex(el => Math.Abs(el.x - seg.x2) <= 0.001) + 2;
                range = endIndex - startIndex + 1;
                //эту хуйню так оставлять нельзя
                mas = new float[range / 3, 3];
                Array.Copy(this.pointList, startIndex, mas, 0, range);
                this.StepPointList.Add(mas);
            }
        }

        private void DrawGraph(int index)
        {
            var ilStartPoints = new ILPoints()
            {
                Positions = this.pointList,
                Size = 1,
                Color = Color.Teal
            };

            var ilstepPoint = new ILPoints()
            {
                Positions = this.StepPointList.ElementAt(index),
                Size = 1,
                Color = Color.PowderBlue
            };

            index = (index == this.StepPointList.Count - 1) ? index - 1 : index;

            float[,] start = new float[2, 3];
            float[,] end = new float[2, 3];
            Array.Copy(this.StepPointList.ElementAt(index), start, 3);
            int tempmagic = (this.StepPointList.ElementAt(index).Length < 7) ? this.StepPointList.ElementAt(index).Length : this.StepPointList.ElementAt(index).Length - 7;
            Array.Copy(this.StepPointList.ElementAt(index), tempmagic, end, 2, 3);
            //Array.Copy(this.StepPointList.ElementAt(index), this.StepPointList.ElementAt(index).Length - 7, end, 2, 3);
            start[1, 0] = start[0, 0];
            start[0, 1] = this.result.min;
            start[1, 1] = this.result.max;
            end[0, 0] = end[1, 0];
            end[0, 1] = this.result.min;
            end[1, 1] = this.result.max;

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
            this.RedrawBoundaryElements(index);
        }

        private void RedrawBoundaryElements(int index)
        {
            this.l_x1.Text = (index == 0) ? this.calcmt.infoBlock.left_border : Math.Round(Form1.stepList.ElementAt(index).x1, 4).ToString();
            this.l_x2.Text = (index == 0) ? this.calcmt.infoBlock.right_border : Math.Round(Form1.stepList.ElementAt(index).x2, 4).ToString();

            if (this.calcmt.GetType() == typeof(Dichotomy))
            {
                this.l_delta.Text = (index == 0) ? this.calcmt.infoBlock.delta : Math.Round(this.calcmt.addInfoList.ElementAt(index).delta, 4).ToString();
            }
            else if (this.calcmt.GetType() == typeof(Fibonachi))
            {
                this.l_n.Text = (index == 0) ? this.calcmt.infoBlock.N : AdditionInfo.N.ToString();
                this.l_Fn.Text = (index == 0) ? this.calcmt.infoBlock.Fn : AdditionInfo.Fn.ToString();
                this.l_kvalue.Text = (index == 0) ? this.calcmt.infoBlock.k : this.calcmt.addInfoList.ElementAt(index - 1).k.ToString();
            }
        }

        private void bt_firstStep_Click(object sender, EventArgs e)
        {
            this.bt_previousStep.Enabled = false;
            this.bt_nextStep.Enabled = true;
            this.index = 0;
            this.DrawGraph(this.index);
        }

        private void bt_previousStep_Click(object sender, EventArgs e)
        {
            this.index--;
            this.bt_nextStep.Enabled = true;
            this.bt_previousStep.Enabled = (this.index == 0) ? false : true;
            this.DrawGraph(this.index);
        }

        private void bt_nextStep_Click(object sender, EventArgs e)
        {
            this.index++;
            this.bt_previousStep.Enabled = true;
            this.bt_nextStep.Enabled = (this.index == StepPointList.Count - 1) ? false : true;
            this.DrawGraph(this.index);
        }

        private void bt_lastStep_Click(object sender, EventArgs e)
        {
            this.index = this.StepPointList.Count - 1;
            this.bt_nextStep.Enabled = false;
            this.bt_previousStep.Enabled = true;
            this.DrawGraph(this.index);
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            this.pauseDrawingFlag = true;
            new Thread(stopDrawingFunction).Start();
        }

        private void stopDrawingFunction()
        {
            int retries = 0;
            while (this.drawingProcessFlag)
            {
                if (retries > 5)
                {
                    throw new Exception("Количество попыток ожидания потока исчерпано");
                }
                retries++;
                Thread.Sleep(500);
            }
            this.resetGraph();
        }

        private void resetGraph()
        {
            this.index = 0;
            this.DrawGraph(this.index);
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            this.pauseDrawingFlag = false;
            this.drawingProcessFlag = true;
            this.tr = new Thread(StartDrawing);
            this.tr.Start();
        }

        private void bt_pause_Click(object sender, EventArgs e)
        {
            this.pauseDrawingFlag = true;
        }

        private void StartDrawing()
        {
            while (this.index < this.StepPointList.Count)
            {
                var delay = (int)(((float)(1.0 / (int)this.t_speed.Invoke(new Del(() => t_speed.Value)))) * 2000);
                if (this.pauseDrawingFlag)
                {
                    this.drawingProcessFlag = false;
                    return;
                }
                this.DrawGraph(this.index);
                this.index++;
                Thread.Sleep(delay);
            }
            this.drawingProcessFlag = false;
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

        private static ILScene SetScaleModes(ILScene scene)
        {
            var pcsm = scene.First<ILPlotCube>().ScaleModes;
            pcsm.XAxisScale = AxisScale.Linear;
            pcsm.YAxisScale = AxisScale.Linear;
            pcsm.ZAxisScale = AxisScale.Linear;
            return scene;
        }
    }

    public struct Minimax
    {
        public float min;
        public float max;
    }
}
