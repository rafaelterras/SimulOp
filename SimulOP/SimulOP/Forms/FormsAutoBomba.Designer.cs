namespace SimulOP.Forms
{
    partial class FormsAutoBomba
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.trackEqBomba = new System.Windows.Forms.TrackBar();
            this.trackTubo = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEqBomba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTubo)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Maximum = 40D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Vazão [m^3/h]";
            chartArea1.AxisX2.Maximum = 40D;
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.AxisY.Maximum = 30D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Carga [m]";
            chartArea1.AxisY2.Maximum = 30D;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(518, 12);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Altura da bomba";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Curva da tubulacao";
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Label = "Ponto de operacao";
            series3.LabelBackColor = System.Drawing.Color.White;
            series3.LabelBorderColor = System.Drawing.Color.Black;
            series3.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series3.Legend = "Legend1";
            series3.Name = "Ponto de operacao";
            series3.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(657, 374);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Equação da Bomba";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // trackEqBomba
            // 
            this.trackEqBomba.Location = new System.Drawing.Point(13, 30);
            this.trackEqBomba.Maximum = 100;
            this.trackEqBomba.Minimum = 1;
            this.trackEqBomba.Name = "trackEqBomba";
            this.trackEqBomba.Size = new System.Drawing.Size(472, 45);
            this.trackEqBomba.TabIndex = 3;
            this.trackEqBomba.Value = 50;
            this.trackEqBomba.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackTubo
            // 
            this.trackTubo.Location = new System.Drawing.Point(13, 109);
            this.trackTubo.Maximum = 100;
            this.trackTubo.Minimum = 1;
            this.trackTubo.Name = "trackTubo";
            this.trackTubo.Size = new System.Drawing.Size(472, 45);
            this.trackTubo.TabIndex = 5;
            this.trackTubo.Value = 25;
            this.trackTubo.Scroll += new System.EventHandler(this.trackTubo_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tamanho da Tubulação";
            // 
            // FormsAutoBomba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 398);
            this.Controls.Add(this.trackTubo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackEqBomba);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "FormsAutoBomba";
            this.Text = "FormsAutoBomba";
            this.Load += new System.EventHandler(this.FormsAutoBomba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEqBomba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTubo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackEqBomba;
        private System.Windows.Forms.TrackBar trackTubo;
        private System.Windows.Forms.Label label2;
    }
}