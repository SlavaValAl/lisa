namespace optimization
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
            this.label8 = new System.Windows.Forms.Label();
            this.ilPanel1 = new ILNumerics.Drawing.ILPanel();
            this.bt_nextStep = new System.Windows.Forms.Button();
            this.bt_previousStep = new System.Windows.Forms.Button();
            this.bt_firstStep = new System.Windows.Forms.Button();
            this.bt_lastStep = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbFunctionType
            // 
            this.cbFunctionType.Location = new System.Drawing.Point(12, 57);
            this.cbFunctionType.Name = "cbFunctionType";
            this.cbFunctionType.Size = new System.Drawing.Size(121, 21);
            this.cbFunctionType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите функцию";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите метод";
            // 
            // cbMethodType
            // 
            this.cbMethodType.Location = new System.Drawing.Point(12, 128);
            this.cbMethodType.Name = "cbMethodType";
            this.cbMethodType.Size = new System.Drawing.Size(165, 21);
            this.cbMethodType.TabIndex = 3;
            // 
            // rb_min
            // 
            this.rb_min.AutoSize = true;
            this.rb_min.Location = new System.Drawing.Point(183, 76);
            this.rb_min.Name = "rb_min";
            this.rb_min.Size = new System.Drawing.Size(72, 17);
            this.rb_min.TabIndex = 4;
            this.rb_min.TabStop = true;
            this.rb_min.Text = "минимум";
            this.rb_min.UseVisualStyleBackColor = true;
            // 
            // rb_max
            // 
            this.rb_max.AutoSize = true;
            this.rb_max.Location = new System.Drawing.Point(183, 99);
            this.rb_max.Name = "rb_max";
            this.rb_max.Size = new System.Drawing.Size(78, 17);
            this.rb_max.TabIndex = 5;
            this.rb_max.TabStop = true;
            this.rb_max.Text = "максимум";
            this.rb_max.UseVisualStyleBackColor = true;
            // 
            // tb_end
            // 
            this.tb_end.Location = new System.Drawing.Point(402, 57);
            this.tb_end.Name = "tb_end";
            this.tb_end.Size = new System.Drawing.Size(94, 20);
            this.tb_end.TabIndex = 6;
            // 
            // tb_start
            // 
            this.tb_start.Location = new System.Drawing.Point(279, 57);
            this.tb_start.Name = "tb_start";
            this.tb_start.Size = new System.Drawing.Size(100, 20);
            this.tb_start.TabIndex = 7;
            // 
            // tb_currency
            // 
            this.tb_currency.Location = new System.Drawing.Point(513, 57);
            this.tb_currency.Name = "tb_currency";
            this.tb_currency.Size = new System.Drawing.Size(100, 20);
            this.tb_currency.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Начало интервала";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Конец интервала";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Точность";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Результат";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(411, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Значение функции";
            // 
            // bt_calculate
            // 
            this.bt_calculate.Location = new System.Drawing.Point(268, 133);
            this.bt_calculate.Name = "bt_calculate";
            this.bt_calculate.Size = new System.Drawing.Size(111, 23);
            this.bt_calculate.TabIndex = 14;
            this.bt_calculate.Text = "Подсчитать";
            this.bt_calculate.UseVisualStyleBackColor = true;
            this.bt_calculate.Click += new System.EventHandler(this.bt_calculate_Click);
            // 
            // tb_res
            // 
            this.tb_res.Location = new System.Drawing.Point(513, 102);
            this.tb_res.Name = "tb_res";
            this.tb_res.Size = new System.Drawing.Size(100, 20);
            this.tb_res.TabIndex = 15;
            // 
            // tb_func_res
            // 
            this.tb_func_res.Location = new System.Drawing.Point(513, 135);
            this.tb_func_res.Name = "tb_func_res";
            this.tb_func_res.Size = new System.Drawing.Size(100, 20);
            this.tb_func_res.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ilPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 444);
            this.panel1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.CausesValidation = false;
            this.label8.Location = new System.Drawing.Point(419, 431);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "                                                                    ";
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
            // bt_nextStep
            // 
            this.bt_nextStep.Location = new System.Drawing.Point(311, 623);
            this.bt_nextStep.Name = "bt_nextStep";
            this.bt_nextStep.Size = new System.Drawing.Size(106, 23);
            this.bt_nextStep.TabIndex = 18;
            this.bt_nextStep.Text = "Следующий шаг";
            this.bt_nextStep.UseVisualStyleBackColor = true;
            this.bt_nextStep.Click += new System.EventHandler(this.bt_nextStep_Click);
            // 
            // bt_previousStep
            // 
            this.bt_previousStep.Location = new System.Drawing.Point(187, 624);
            this.bt_previousStep.Name = "bt_previousStep";
            this.bt_previousStep.Size = new System.Drawing.Size(106, 23);
            this.bt_previousStep.TabIndex = 19;
            this.bt_previousStep.Text = "Предыдущий шаг";
            this.bt_previousStep.UseVisualStyleBackColor = true;
            this.bt_previousStep.Click += new System.EventHandler(this.bt_previousStep_Click);
            // 
            // bt_firstStep
            // 
            this.bt_firstStep.Location = new System.Drawing.Point(54, 624);
            this.bt_firstStep.Name = "bt_firstStep";
            this.bt_firstStep.Size = new System.Drawing.Size(106, 23);
            this.bt_firstStep.TabIndex = 20;
            this.bt_firstStep.Text = "Первый шаг";
            this.bt_firstStep.UseVisualStyleBackColor = true;
            this.bt_firstStep.Click += new System.EventHandler(this.bt_firstStep_Click);
            // 
            // bt_lastStep
            // 
            this.bt_lastStep.Location = new System.Drawing.Point(434, 623);
            this.bt_lastStep.Name = "bt_lastStep";
            this.bt_lastStep.Size = new System.Drawing.Size(106, 23);
            this.bt_lastStep.TabIndex = 21;
            this.bt_lastStep.Text = "Последний шаг";
            this.bt_lastStep.UseVisualStyleBackColor = true;
            this.bt_lastStep.Click += new System.EventHandler(this.bt_lastStep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 657);
            this.Controls.Add(this.bt_lastStep);
            this.Controls.Add(this.bt_firstStep);
            this.Controls.Add(this.bt_previousStep);
            this.Controls.Add(this.bt_nextStep);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_func_res);
            this.Controls.Add(this.tb_res);
            this.Controls.Add(this.bt_calculate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_currency);
            this.Controls.Add(this.tb_start);
            this.Controls.Add(this.tb_end);
            this.Controls.Add(this.rb_max);
            this.Controls.Add(this.rb_min);
            this.Controls.Add(this.cbMethodType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFunctionType);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label8;


    }
}

