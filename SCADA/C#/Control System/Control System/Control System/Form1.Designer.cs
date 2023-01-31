
namespace Control_System
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TemperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtR = new System.Windows.Forms.TextBox();
            this.txtTi = new System.Windows.Forms.TextBox();
            this.txtKp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SimulationToggle = new System.Windows.Forms.CheckBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ControlValueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ZChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ApplyPidParams = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlValueChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(1305, 140);
            this.input.Margin = new System.Windows.Forms.Padding(4);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(105, 29);
            this.input.TabIndex = 0;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(1305, 219);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(105, 29);
            this.output.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1305, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ControlValue [V]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1300, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "ProcessValue[°C]";
            // 
            // TemperatureChart
            // 
            chartArea10.Name = "ChartArea1";
            this.TemperatureChart.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.TemperatureChart.Legends.Add(legend10);
            this.TemperatureChart.Location = new System.Drawing.Point(192, 112);
            this.TemperatureChart.Margin = new System.Windows.Forms.Padding(4);
            this.TemperatureChart.Name = "TemperatureChart";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.TemperatureChart.Series.Add(series10);
            this.TemperatureChart.Size = new System.Drawing.Size(1070, 290);
            this.TemperatureChart.TabIndex = 3;
            this.TemperatureChart.Text = "chart1";
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(25, 173);
            this.txtR.Margin = new System.Windows.Forms.Padding(4);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(74, 29);
            this.txtR.TabIndex = 4;
            // 
            // txtTi
            // 
            this.txtTi.Location = new System.Drawing.Point(25, 95);
            this.txtTi.Margin = new System.Windows.Forms.Padding(4);
            this.txtTi.Name = "txtTi";
            this.txtTi.Size = new System.Drawing.Size(74, 29);
            this.txtTi.TabIndex = 4;
            // 
            // txtKp
            // 
            this.txtKp.Location = new System.Drawing.Point(25, 28);
            this.txtKp.Margin = new System.Windows.Forms.Padding(4);
            this.txtKp.Name = "txtKp";
            this.txtKp.Size = new System.Drawing.Size(74, 29);
            this.txtKp.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ti";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Setpoint";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kp";
            // 
            // SimulationToggle
            // 
            this.SimulationToggle.AutoSize = true;
            this.SimulationToggle.Location = new System.Drawing.Point(41, 768);
            this.SimulationToggle.Name = "SimulationToggle";
            this.SimulationToggle.Size = new System.Drawing.Size(129, 29);
            this.SimulationToggle.TabIndex = 5;
            this.SimulationToggle.Text = "Simulation";
            this.SimulationToggle.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(1305, 803);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(129, 42);
            this.StopButton.TabIndex = 6;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(41, 803);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(129, 42);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ControlValueChart
            // 
            chartArea11.Name = "ChartArea1";
            this.ControlValueChart.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.ControlValueChart.Legends.Add(legend11);
            this.ControlValueChart.Location = new System.Drawing.Point(192, 396);
            this.ControlValueChart.Name = "ControlValueChart";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.ControlValueChart.Series.Add(series11);
            this.ControlValueChart.Size = new System.Drawing.Size(1070, 230);
            this.ControlValueChart.TabIndex = 8;
            this.ControlValueChart.Text = "chart2";
            // 
            // ZChart
            // 
            chartArea12.Name = "ChartArea1";
            this.ZChart.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.ZChart.Legends.Add(legend12);
            this.ZChart.Location = new System.Drawing.Point(192, 615);
            this.ZChart.Name = "ZChart";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.ZChart.Series.Add(series12);
            this.ZChart.Size = new System.Drawing.Size(1070, 230);
            this.ZChart.TabIndex = 9;
            this.ZChart.Text = "chart1";
            // 
            // ApplyPidParams
            // 
            this.ApplyPidParams.Location = new System.Drawing.Point(24, 228);
            this.ApplyPidParams.Name = "ApplyPidParams";
            this.ApplyPidParams.Size = new System.Drawing.Size(75, 38);
            this.ApplyPidParams.TabIndex = 10;
            this.ApplyPidParams.Text = "Apply";
            this.ApplyPidParams.UseVisualStyleBackColor = true;
            this.ApplyPidParams.Click += new System.EventHandler(this.ApplyPidParams_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ApplyPidParams);
            this.groupBox1.Controls.Add(this.txtKp);
            this.groupBox1.Controls.Add(this.txtTi);
            this.groupBox1.Controls.Add(this.txtR);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(42, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 298);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(548, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 54);
            this.label6.TabIndex = 12;
            this.label6.Text = "Control System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 943);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ZChart);
            this.Controls.Add(this.ControlValueChart);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.SimulationToggle);
            this.Controls.Add(this.TemperatureChart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Control System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlValueChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart TemperatureChart;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.TextBox txtTi;
        private System.Windows.Forms.TextBox txtKp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox SimulationToggle;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart ControlValueChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ZChart;
        private System.Windows.Forms.Button ApplyPidParams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
    }
}

