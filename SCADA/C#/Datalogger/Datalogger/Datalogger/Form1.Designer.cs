
namespace Datalogger
{
    partial class Datalogger
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TemperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ControlValueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.txtu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlValueChart)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TemperatureChart
            // 
            chartArea1.Name = "ChartArea1";
            this.TemperatureChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.TemperatureChart.Legends.Add(legend1);
            this.TemperatureChart.Location = new System.Drawing.Point(37, 12);
            this.TemperatureChart.Name = "TemperatureChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.TemperatureChart.Series.Add(series1);
            this.TemperatureChart.Size = new System.Drawing.Size(829, 232);
            this.TemperatureChart.TabIndex = 0;
            this.TemperatureChart.Text = "chart1";
            // 
            // ControlValueChart
            // 
            chartArea2.Name = "ChartArea1";
            this.ControlValueChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ControlValueChart.Legends.Add(legend2);
            this.ControlValueChart.Location = new System.Drawing.Point(37, 233);
            this.ControlValueChart.Name = "ControlValueChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ControlValueChart.Series.Add(series2);
            this.ControlValueChart.Size = new System.Drawing.Size(829, 229);
            this.ControlValueChart.TabIndex = 1;
            this.ControlValueChart.Text = "chart1";
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(892, 44);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(132, 29);
            this.txtPV.TabIndex = 2;
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(892, 143);
            this.txtSP.Name = "txtSP";
            this.txtSP.Size = new System.Drawing.Size(132, 29);
            this.txtSP.TabIndex = 3;
            // 
            // txtu
            // 
            this.txtu.Location = new System.Drawing.Point(892, 233);
            this.txtu.Name = "txtu";
            this.txtu.Size = new System.Drawing.Size(132, 29);
            this.txtu.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(892, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "PV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(892, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "SP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(892, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "u";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(892, 285);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(132, 85);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "START LOGGING";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(897, 390);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(127, 72);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "STOP LOGGING";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // Datalogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 506);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtu);
            this.Controls.Add(this.txtSP);
            this.Controls.Add(this.txtPV);
            this.Controls.Add(this.ControlValueChart);
            this.Controls.Add(this.TemperatureChart);
            this.Name = "Datalogger";
            this.Text = "Datalogger";
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlValueChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart TemperatureChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ControlValueChart;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.TextBox txtu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
    }
}

