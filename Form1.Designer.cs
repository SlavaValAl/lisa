﻿namespace optimization
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbFunctionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMethodType = new System.Windows.Forms.ComboBox();
            this.rb_min = new System.Windows.Forms.RadioButton();
            this.rb_max = new System.Windows.Forms.RadioButton();
            this.tb_end = new System.Windows.Forms.TextBox();
            this.tb_start = new System.Windows.Forms.TextBox();
            this.tb_currency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_calculate = new System.Windows.Forms.Button();
            this.tb_res = new System.Windows.Forms.TextBox();
            this.tb_func_res = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ilPanel1 = new ILNumerics.Drawing.ILPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_mode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.t_speed = new System.Windows.Forms.TrackBar();
            this.p_results = new System.Windows.Forms.Panel();
            this.p_step = new System.Windows.Forms.Panel();
            this.bt_firstStep = new System.Windows.Forms.Button();
            this.bt_previousStep = new System.Windows.Forms.Button();
            this.bt_nextStep = new System.Windows.Forms.Button();
            this.bt_lastStep = new System.Windows.Forms.Button();
            this.p_static = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.p_dynamic = new System.Windows.Forms.Panel();
            this.bt_pause = new System.Windows.Forms.Button();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.t_sreed = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t_speed)).BeginInit();
            this.p_results.SuspendLayout();
            this.p_step.SuspendLayout();
            this.p_static.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.p_dynamic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t_sreed)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFunctionType
            // 
            this.cbFunctionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunctionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFunctionType.Location = new System.Drawing.Point(134, 13);
            this.cbFunctionType.Name = "cbFunctionType";
            this.cbFunctionType.Size = new System.Drawing.Size(175, 23);
            this.cbFunctionType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите функцию";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите метод";
            // 
            // cbMethodType
            // 
            this.cbMethodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethodType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMethodType.Location = new System.Drawing.Point(134, 47);
            this.cbMethodType.Name = "cbMethodType";
            this.cbMethodType.Size = new System.Drawing.Size(175, 23);
            this.cbMethodType.TabIndex = 1;
            // 
            // rb_min
            // 
            this.rb_min.AutoSize = true;
            this.rb_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_min.Location = new System.Drawing.Point(128, 131);
            this.rb_min.Name = "rb_min";
            this.rb_min.Size = new System.Drawing.Size(77, 19);
            this.rb_min.TabIndex = 3;
            this.rb_min.TabStop = true;
            this.rb_min.Text = "минимум";
            this.rb_min.UseVisualStyleBackColor = true;
            // 
            // rb_max
            // 
            this.rb_max.AutoSize = true;
            this.rb_max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_max.Location = new System.Drawing.Point(227, 131);
            this.rb_max.Name = "rb_max";
            this.rb_max.Size = new System.Drawing.Size(82, 19);
            this.rb_max.TabIndex = 4;
            this.rb_max.TabStop = true;
            this.rb_max.Text = "максимум";
            this.rb_max.UseVisualStyleBackColor = true;
            // 
            // tb_end
            // 
            this.tb_end.Location = new System.Drawing.Point(438, 48);
            this.tb_end.Name = "tb_end";
            this.tb_end.Size = new System.Drawing.Size(100, 21);
            this.tb_end.TabIndex = 6;
            // 
            // tb_start
            // 
            this.tb_start.Location = new System.Drawing.Point(438, 13);
            this.tb_start.Name = "tb_start";
            this.tb_start.Size = new System.Drawing.Size(100, 21);
            this.tb_start.TabIndex = 5;
            // 
            // tb_currency
            // 
            this.tb_currency.Location = new System.Drawing.Point(438, 83);
            this.tb_currency.Name = "tb_currency";
            this.tb_currency.Size = new System.Drawing.Size(100, 21);
            this.tb_currency.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Начало интервала";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Конец интервала";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Точность";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Результат";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Значение функции";
            // 
            // bt_calculate
            // 
            this.bt_calculate.BackColor = System.Drawing.Color.White;
            this.bt_calculate.FlatAppearance.BorderSize = 0;
            this.bt_calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_calculate.ForeColor = System.Drawing.Color.Black;
            this.bt_calculate.Location = new System.Drawing.Point(438, 161);
            this.bt_calculate.Name = "bt_calculate";
            this.bt_calculate.Size = new System.Drawing.Size(100, 26);
            this.bt_calculate.TabIndex = 8;
            this.bt_calculate.Text = "Подсчитать";
            this.bt_calculate.UseVisualStyleBackColor = false;
            this.bt_calculate.Click += new System.EventHandler(this.bt_calculate_Click);
            // 
            // tb_res
            // 
            this.tb_res.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(5)))), ((int)(((byte)(95)))));
            this.tb_res.Location = new System.Drawing.Point(139, 20);
            this.tb_res.Name = "tb_res";
            this.tb_res.ReadOnly = true;
            this.tb_res.Size = new System.Drawing.Size(100, 21);
            this.tb_res.TabIndex = 9;
            // 
            // tb_func_res
            // 
            this.tb_func_res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(5)))), ((int)(((byte)(95)))));
            this.tb_func_res.Location = new System.Drawing.Point(139, 53);
            this.tb_func_res.Name = "tb_func_res";
            this.tb_func_res.ReadOnly = true;
            this.tb_func_res.Size = new System.Drawing.Size(100, 21);
            this.tb_func_res.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ilPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 444);
            this.panel1.TabIndex = 17;
            // 
            // ilPanel1
            // 
            this.ilPanel1.CausesValidation = false;
            this.ilPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilPanel1.Driver = ILNumerics.Drawing.RendererTypes.GDI;
            this.ilPanel1.Editor = null;
            this.ilPanel1.Location = new System.Drawing.Point(0, 0);
            this.ilPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ilPanel1.Name = "ilPanel1";
            this.ilPanel1.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("ilPanel1.Rectangle")));
            this.ilPanel1.ShowUIControls = false;
            this.ilPanel1.Size = new System.Drawing.Size(597, 444);
            this.ilPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(131)))), ((int)(((byte)(238)))));
            this.panel2.Controls.Add(this.cb_mode);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cbFunctionType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.bt_calculate);
            this.panel2.Controls.Add(this.cbMethodType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tb_end);
            this.panel2.Controls.Add(this.tb_start);
            this.panel2.Controls.Add(this.tb_currency);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rb_max);
            this.panel2.Controls.Add(this.rb_min);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(621, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 195);
            this.panel2.TabIndex = 22;
            // 
            // cb_mode
            // 
            this.cb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_mode.FormattingEnabled = true;
            this.cb_mode.Location = new System.Drawing.Point(134, 83);
            this.cb_mode.Name = "cb_mode";
            this.cb_mode.Size = new System.Drawing.Size(175, 23);
            this.cb_mode.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Режим";
            // 
            // t_speed
            // 
            this.t_speed.Location = new System.Drawing.Point(0, 0);
            this.t_speed.Name = "t_speed";
            this.t_speed.Size = new System.Drawing.Size(104, 45);
            this.t_speed.TabIndex = 0;
            // 
            // p_results
            // 
            this.p_results.BackColor = System.Drawing.Color.White;
            this.p_results.Controls.Add(this.tb_res);
            this.p_results.Controls.Add(this.label6);
            this.p_results.Controls.Add(this.label7);
            this.p_results.Controls.Add(this.tb_func_res);
            this.p_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.p_results.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(5)))), ((int)(((byte)(90)))));
            this.p_results.Location = new System.Drawing.Point(920, 213);
            this.p_results.Name = "p_results";
            this.p_results.Size = new System.Drawing.Size(250, 100);
            this.p_results.TabIndex = 24;
            // 
            // p_step
            // 
            this.p_step.BackColor = System.Drawing.Color.White;
            this.p_step.Controls.Add(this.bt_firstStep);
            this.p_step.Controls.Add(this.bt_previousStep);
            this.p_step.Controls.Add(this.bt_nextStep);
            this.p_step.Controls.Add(this.bt_lastStep);
            this.p_step.Location = new System.Drawing.Point(621, 213);
            this.p_step.Name = "p_step";
            this.p_step.Size = new System.Drawing.Size(290, 100);
            this.p_step.TabIndex = 10;
            this.p_step.Visible = false;
            // 
            // bt_firstStep
            // 
            this.bt_firstStep.FlatAppearance.BorderSize = 0;
            this.bt_firstStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_firstStep.Image = global::diplom.Properties.Resources.first;
            this.bt_firstStep.Location = new System.Drawing.Point(15, 20);
            this.bt_firstStep.Name = "bt_firstStep";
            this.bt_firstStep.Size = new System.Drawing.Size(65, 65);
            this.bt_firstStep.TabIndex = 20;
            this.bt_firstStep.UseVisualStyleBackColor = true;
            this.bt_firstStep.Click += new System.EventHandler(this.bt_firstStep_Click);
            // 
            // bt_previousStep
            // 
            this.bt_previousStep.FlatAppearance.BorderSize = 0;
            this.bt_previousStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_previousStep.Image = global::diplom.Properties.Resources.prev;
            this.bt_previousStep.Location = new System.Drawing.Point(80, 20);
            this.bt_previousStep.Name = "bt_previousStep";
            this.bt_previousStep.Size = new System.Drawing.Size(65, 65);
            this.bt_previousStep.TabIndex = 19;
            this.bt_previousStep.UseVisualStyleBackColor = true;
            this.bt_previousStep.Click += new System.EventHandler(this.bt_previousStep_Click);
            // 
            // bt_nextStep
            // 
            this.bt_nextStep.FlatAppearance.BorderSize = 0;
            this.bt_nextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_nextStep.Image = global::diplom.Properties.Resources.next;
            this.bt_nextStep.Location = new System.Drawing.Point(145, 20);
            this.bt_nextStep.Name = "bt_nextStep";
            this.bt_nextStep.Size = new System.Drawing.Size(65, 65);
            this.bt_nextStep.TabIndex = 18;
            this.bt_nextStep.UseVisualStyleBackColor = true;
            this.bt_nextStep.Click += new System.EventHandler(this.bt_nextStep_Click);
            // 
            // bt_lastStep
            // 
            this.bt_lastStep.FlatAppearance.BorderSize = 0;
            this.bt_lastStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_lastStep.Image = global::diplom.Properties.Resources.last;
            this.bt_lastStep.Location = new System.Drawing.Point(210, 20);
            this.bt_lastStep.Name = "bt_lastStep";
            this.bt_lastStep.Size = new System.Drawing.Size(65, 65);
            this.bt_lastStep.TabIndex = 21;
            this.bt_lastStep.UseVisualStyleBackColor = true;
            this.bt_lastStep.Click += new System.EventHandler(this.bt_lastStep_Click);
            // 
            // p_static
            // 
            this.p_static.BackColor = System.Drawing.Color.White;
            this.p_static.Controls.Add(this.panel6);
            this.p_static.Location = new System.Drawing.Point(920, 336);
            this.p_static.Name = "p_static";
            this.p_static.Size = new System.Drawing.Size(290, 100);
            this.p_static.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.button8);
            this.panel6.Controls.Add(this.button9);
            this.panel6.Controls.Add(this.button10);
            this.panel6.Controls.Add(this.trackBar2);
            this.panel6.Location = new System.Drawing.Point(621, 213);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(290, 100);
            this.panel6.TabIndex = 9;
            this.panel6.Visible = false;
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(40, 32);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(65, 65);
            this.button8.TabIndex = 6;
            this.button8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(180, 32);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(65, 65);
            this.button9.TabIndex = 4;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(111, 32);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 65);
            this.button10.TabIndex = 5;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(3, 3);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(279, 45);
            this.trackBar2.TabIndex = 0;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(0, 1);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(290, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(56, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 65);
            this.button1.TabIndex = 6;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(196, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 39);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(136, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 39);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // p_dynamic
            // 
            this.p_dynamic.BackColor = System.Drawing.Color.White;
            this.p_dynamic.Controls.Add(this.bt_pause);
            this.p_dynamic.Controls.Add(this.bt_start);
            this.p_dynamic.Controls.Add(this.bt_stop);
            this.p_dynamic.Controls.Add(this.t_sreed);
            this.p_dynamic.Location = new System.Drawing.Point(621, 336);
            this.p_dynamic.Name = "p_dynamic";
            this.p_dynamic.Size = new System.Drawing.Size(290, 100);
            this.p_dynamic.TabIndex = 25;
            this.p_dynamic.Visible = false;
            // 
            // bt_pause
            // 
            this.bt_pause.FlatAppearance.BorderSize = 0;
            this.bt_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_pause.Image = global::diplom.Properties.Resources.pause;
            this.bt_pause.Location = new System.Drawing.Point(182, 32);
            this.bt_pause.Name = "bt_pause";
            this.bt_pause.Size = new System.Drawing.Size(65, 65);
            this.bt_pause.TabIndex = 1;
            this.bt_pause.UseVisualStyleBackColor = true;
            // 
            // bt_start
            // 
            this.bt_start.FlatAppearance.BorderSize = 0;
            this.bt_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_start.Image = global::diplom.Properties.Resources.start;
            this.bt_start.Location = new System.Drawing.Point(115, 32);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(65, 65);
            this.bt_start.TabIndex = 1;
            this.bt_start.UseVisualStyleBackColor = true;
            // 
            // bt_stop
            // 
            this.bt_stop.FlatAppearance.BorderSize = 0;
            this.bt_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_stop.Image = global::diplom.Properties.Resources.stop;
            this.bt_stop.Location = new System.Drawing.Point(40, 32);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(65, 65);
            this.bt_stop.TabIndex = 1;
            this.bt_stop.UseVisualStyleBackColor = true;
            // 
            // t_sreed
            // 
            this.t_sreed.Location = new System.Drawing.Point(0, 3);
            this.t_sreed.Name = "t_sreed";
            this.t_sreed.Size = new System.Drawing.Size(287, 45);
            this.t_sreed.TabIndex = 0;
            this.t_sreed.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1184, 467);
            this.Controls.Add(this.p_dynamic);
            this.Controls.Add(this.p_step);
            this.Controls.Add(this.p_static);
            this.Controls.Add(this.p_results);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 505);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 505);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t_speed)).EndInit();
            this.p_results.ResumeLayout(false);
            this.p_results.PerformLayout();
            this.p_step.ResumeLayout(false);
            this.p_static.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.p_dynamic.ResumeLayout(false);
            this.p_dynamic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t_sreed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFunctionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMethodType;
        private System.Windows.Forms.RadioButton rb_min;
        private System.Windows.Forms.RadioButton rb_max;
        private System.Windows.Forms.TextBox tb_end;
        private System.Windows.Forms.TextBox tb_start;
        private System.Windows.Forms.TextBox tb_currency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_calculate;
        private System.Windows.Forms.TextBox tb_res;
        private System.Windows.Forms.TextBox tb_func_res;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_nextStep;
        private System.Windows.Forms.Button bt_previousStep;
        private System.Windows.Forms.Button bt_firstStep;
        private System.Windows.Forms.Button bt_lastStep;
        private ILNumerics.Drawing.ILPanel ilPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar t_speed;
        private System.Windows.Forms.Panel p_results;
        private System.Windows.Forms.Panel p_step;
        private System.Windows.Forms.ComboBox cb_mode;
        private System.Windows.Forms.Panel p_static;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel p_dynamic;
        private System.Windows.Forms.TrackBar t_sreed;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.Button bt_pause;
        private System.Windows.Forms.Button bt_start;


    }
}

