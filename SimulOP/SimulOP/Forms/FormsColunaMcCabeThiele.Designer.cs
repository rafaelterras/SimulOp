namespace SimulOP.Forms
{
    partial class FormsColunaMcCabeThiele
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
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gubInputInicial = new System.Windows.Forms.GroupBox();
            this.btnInputInicial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFluidoHK = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFluidoLK = new System.Windows.Forms.ComboBox();
            this.gubVariaveis = new System.Windows.Forms.GroupBox();
            this.nudRefluxoDin = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCondicaoEntradaDin = new System.Windows.Forms.ComboBox();
            this.nudCondicaoEntradaDin = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.trbFracaoEntradaLKDin = new System.Windows.Forms.TrackBar();
            this.nudFracaoEntradaLKDin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.trbPressaoDin = new System.Windows.Forms.TrackBar();
            this.nudPressaoDin = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.trbXb = new System.Windows.Forms.TrackBar();
            this.nudXb = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.trbXd = new System.Windows.Forms.TrackBar();
            this.nudXd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.trbCondicaoEntradaDin = new System.Windows.Forms.TrackBar();
            this.trbRefluxoDin = new System.Windows.Forms.TrackBar();
            this.gubResultados = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbAlpha = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txbPratoIdeal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txbNPratos = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gubGrafico = new System.Windows.Forms.GroupBox();
            this.txbConvergencia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.gubInputInicial.SuspendLayout();
            this.gubVariaveis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefluxoDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCondicaoEntradaDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFracaoEntradaLKDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracaoEntradaLKDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPressaoDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPressaoDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCondicaoEntradaDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRefluxoDin)).BeginInit();
            this.gubResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.AxisX.Interval = 0.1D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Maximum = 1D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 0.1D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Interval = 0.1D;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.Interval = 0.1D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(239, 29);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Equilibrio";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Black;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Pratos";
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Gray;
            series3.Legend = "Legend1";
            series3.Name = "LinhaOP";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Color = System.Drawing.Color.Tomato;
            series4.Legend = "Legend1";
            series4.Name = "PontoQ";
            series4.YValuesPerPoint = 2;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(603, 404);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            this.chart.Visible = false;
            // 
            // gubInputInicial
            // 
            this.gubInputInicial.Controls.Add(this.btnInputInicial);
            this.gubInputInicial.Controls.Add(this.label2);
            this.gubInputInicial.Controls.Add(this.cmbFluidoHK);
            this.gubInputInicial.Controls.Add(this.label1);
            this.gubInputInicial.Controls.Add(this.cmbFluidoLK);
            this.gubInputInicial.Location = new System.Drawing.Point(12, 10);
            this.gubInputInicial.Name = "gubInputInicial";
            this.gubInputInicial.Size = new System.Drawing.Size(206, 103);
            this.gubInputInicial.TabIndex = 3;
            this.gubInputInicial.TabStop = false;
            this.gubInputInicial.Text = "Input inicial";
            // 
            // btnInputInicial
            // 
            this.btnInputInicial.Location = new System.Drawing.Point(125, 74);
            this.btnInputInicial.Name = "btnInputInicial";
            this.btnInputInicial.Size = new System.Drawing.Size(75, 23);
            this.btnInputInicial.TabIndex = 2;
            this.btnInputInicial.Text = "Calcular";
            this.btnInputInicial.UseVisualStyleBackColor = true;
            this.btnInputInicial.Click += new System.EventHandler(this.btnInputInicial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fluido HK";
            // 
            // cmbFluidoHK
            // 
            this.cmbFluidoHK.FormattingEnabled = true;
            this.cmbFluidoHK.Items.AddRange(new object[] {
            "Benzeno",
            "Tolueno",
            "Naftaleno"});
            this.cmbFluidoHK.Location = new System.Drawing.Point(79, 47);
            this.cmbFluidoHK.Name = "cmbFluidoHK";
            this.cmbFluidoHK.Size = new System.Drawing.Size(121, 21);
            this.cmbFluidoHK.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fluido LK";
            // 
            // cmbFluidoLK
            // 
            this.cmbFluidoLK.FormattingEnabled = true;
            this.cmbFluidoLK.Items.AddRange(new object[] {
            "Benzeno",
            "Tolueno",
            "Naftaleno"});
            this.cmbFluidoLK.Location = new System.Drawing.Point(79, 20);
            this.cmbFluidoLK.Name = "cmbFluidoLK";
            this.cmbFluidoLK.Size = new System.Drawing.Size(121, 21);
            this.cmbFluidoLK.TabIndex = 0;
            // 
            // gubVariaveis
            // 
            this.gubVariaveis.Controls.Add(this.nudRefluxoDin);
            this.gubVariaveis.Controls.Add(this.label14);
            this.gubVariaveis.Controls.Add(this.cmbCondicaoEntradaDin);
            this.gubVariaveis.Controls.Add(this.nudCondicaoEntradaDin);
            this.gubVariaveis.Controls.Add(this.label13);
            this.gubVariaveis.Controls.Add(this.trbFracaoEntradaLKDin);
            this.gubVariaveis.Controls.Add(this.nudFracaoEntradaLKDin);
            this.gubVariaveis.Controls.Add(this.label12);
            this.gubVariaveis.Controls.Add(this.trbPressaoDin);
            this.gubVariaveis.Controls.Add(this.nudPressaoDin);
            this.gubVariaveis.Controls.Add(this.label7);
            this.gubVariaveis.Controls.Add(this.trbXb);
            this.gubVariaveis.Controls.Add(this.nudXb);
            this.gubVariaveis.Controls.Add(this.label6);
            this.gubVariaveis.Controls.Add(this.trbXd);
            this.gubVariaveis.Controls.Add(this.nudXd);
            this.gubVariaveis.Controls.Add(this.label5);
            this.gubVariaveis.Controls.Add(this.trbCondicaoEntradaDin);
            this.gubVariaveis.Controls.Add(this.trbRefluxoDin);
            this.gubVariaveis.Location = new System.Drawing.Point(12, 191);
            this.gubVariaveis.Name = "gubVariaveis";
            this.gubVariaveis.Size = new System.Drawing.Size(206, 384);
            this.gubVariaveis.TabIndex = 4;
            this.gubVariaveis.TabStop = false;
            this.gubVariaveis.Text = "Variáveis dinâmicas";
            this.gubVariaveis.Visible = false;
            // 
            // nudRefluxoDin
            // 
            this.nudRefluxoDin.DecimalPlaces = 1;
            this.nudRefluxoDin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRefluxoDin.Location = new System.Drawing.Point(147, 153);
            this.nudRefluxoDin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRefluxoDin.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.nudRefluxoDin.Name = "nudRefluxoDin";
            this.nudRefluxoDin.Size = new System.Drawing.Size(50, 20);
            this.nudRefluxoDin.TabIndex = 5;
            this.nudRefluxoDin.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.nudRefluxoDin.ValueChanged += new System.EventHandler(this.nudRefluxoDin_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Location = new System.Drawing.Point(6, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Razão de refluxo:";
            // 
            // cmbCondicaoEntradaDin
            // 
            this.cmbCondicaoEntradaDin.FormattingEnabled = true;
            this.cmbCondicaoEntradaDin.Items.AddRange(new object[] {
            "Líquido sub-resfriado",
            "Líquido saturado",
            "Parcialmente vaporizado",
            "Vapor saturado",
            "Vapor super aquecido"});
            this.cmbCondicaoEntradaDin.Location = new System.Drawing.Point(42, 93);
            this.cmbCondicaoEntradaDin.Name = "cmbCondicaoEntradaDin";
            this.cmbCondicaoEntradaDin.Size = new System.Drawing.Size(138, 21);
            this.cmbCondicaoEntradaDin.TabIndex = 17;
            this.cmbCondicaoEntradaDin.SelectedIndexChanged += new System.EventHandler(this.cmbCondicaoEntradaDin_SelectedIndexChanged);
            // 
            // nudCondicaoEntradaDin
            // 
            this.nudCondicaoEntradaDin.DecimalPlaces = 1;
            this.nudCondicaoEntradaDin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudCondicaoEntradaDin.Location = new System.Drawing.Point(147, 67);
            this.nudCondicaoEntradaDin.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCondicaoEntradaDin.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.nudCondicaoEntradaDin.Name = "nudCondicaoEntradaDin";
            this.nudCondicaoEntradaDin.Size = new System.Drawing.Size(50, 20);
            this.nudCondicaoEntradaDin.TabIndex = 4;
            this.nudCondicaoEntradaDin.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudCondicaoEntradaDin.ValueChanged += new System.EventHandler(this.nudCondicaoEntradaDin_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(6, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Condição entrada";
            // 
            // trbFracaoEntradaLKDin
            // 
            this.trbFracaoEntradaLKDin.LargeChange = 1;
            this.trbFracaoEntradaLKDin.Location = new System.Drawing.Point(9, 31);
            this.trbFracaoEntradaLKDin.Maximum = 50;
            this.trbFracaoEntradaLKDin.Name = "trbFracaoEntradaLKDin";
            this.trbFracaoEntradaLKDin.Size = new System.Drawing.Size(188, 45);
            this.trbFracaoEntradaLKDin.TabIndex = 9;
            this.trbFracaoEntradaLKDin.Value = 25;
            this.trbFracaoEntradaLKDin.Scroll += new System.EventHandler(this.trbFracaoEntradaLKDin_Scroll);
            // 
            // nudFracaoEntradaLKDin
            // 
            this.nudFracaoEntradaLKDin.DecimalPlaces = 2;
            this.nudFracaoEntradaLKDin.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudFracaoEntradaLKDin.Location = new System.Drawing.Point(147, 13);
            this.nudFracaoEntradaLKDin.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.nudFracaoEntradaLKDin.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudFracaoEntradaLKDin.Name = "nudFracaoEntradaLKDin";
            this.nudFracaoEntradaLKDin.Size = new System.Drawing.Size(50, 20);
            this.nudFracaoEntradaLKDin.TabIndex = 3;
            this.nudFracaoEntradaLKDin.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudFracaoEntradaLKDin.ValueChanged += new System.EventHandler(this.nudFracaoEntradaLKDin_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(6, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Fração do LK na entrada:";
            // 
            // trbPressaoDin
            // 
            this.trbPressaoDin.Location = new System.Drawing.Point(9, 325);
            this.trbPressaoDin.Maximum = 50;
            this.trbPressaoDin.Name = "trbPressaoDin";
            this.trbPressaoDin.Size = new System.Drawing.Size(188, 45);
            this.trbPressaoDin.TabIndex = 14;
            this.trbPressaoDin.Scroll += new System.EventHandler(this.trbPressaoDin_Scroll);
            // 
            // nudPressaoDin
            // 
            this.nudPressaoDin.DecimalPlaces = 1;
            this.nudPressaoDin.Location = new System.Drawing.Point(147, 307);
            this.nudPressaoDin.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPressaoDin.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudPressaoDin.Name = "nudPressaoDin";
            this.nudPressaoDin.Size = new System.Drawing.Size(50, 20);
            this.nudPressaoDin.TabIndex = 8;
            this.nudPressaoDin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPressaoDin.ValueChanged += new System.EventHandler(this.nudPressaoDin_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(6, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Pressão (bar):";
            // 
            // trbXb
            // 
            this.trbXb.Location = new System.Drawing.Point(9, 274);
            this.trbXb.Maximum = 50;
            this.trbXb.Name = "trbXb";
            this.trbXb.Size = new System.Drawing.Size(188, 45);
            this.trbXb.TabIndex = 13;
            this.trbXb.Value = 10;
            this.trbXb.Scroll += new System.EventHandler(this.trbXb_Scroll);
            // 
            // nudXb
            // 
            this.nudXb.DecimalPlaces = 3;
            this.nudXb.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudXb.Location = new System.Drawing.Point(147, 256);
            this.nudXb.Maximum = new decimal(new int[] {
            49,
            0,
            0,
            131072});
            this.nudXb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudXb.Name = "nudXb";
            this.nudXb.Size = new System.Drawing.Size(50, 20);
            this.nudXb.TabIndex = 7;
            this.nudXb.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudXb.ValueChanged += new System.EventHandler(this.nudXb_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(6, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fração molar xB:";
            // 
            // trbXd
            // 
            this.trbXd.Location = new System.Drawing.Point(9, 223);
            this.trbXd.Maximum = 50;
            this.trbXd.Name = "trbXd";
            this.trbXd.Size = new System.Drawing.Size(188, 45);
            this.trbXd.TabIndex = 12;
            this.trbXd.Value = 45;
            this.trbXd.Scroll += new System.EventHandler(this.trbXd_Scroll);
            // 
            // nudXd
            // 
            this.nudXd.DecimalPlaces = 3;
            this.nudXd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudXd.Location = new System.Drawing.Point(147, 205);
            this.nudXd.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.nudXd.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudXd.Name = "nudXd";
            this.nudXd.Size = new System.Drawing.Size(50, 20);
            this.nudXd.TabIndex = 6;
            this.nudXd.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.nudXd.ValueChanged += new System.EventHandler(this.nudXd_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(6, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fração molar xD:";
            // 
            // trbCondicaoEntradaDin
            // 
            this.trbCondicaoEntradaDin.Location = new System.Drawing.Point(9, 120);
            this.trbCondicaoEntradaDin.Maximum = 50;
            this.trbCondicaoEntradaDin.Name = "trbCondicaoEntradaDin";
            this.trbCondicaoEntradaDin.Size = new System.Drawing.Size(188, 45);
            this.trbCondicaoEntradaDin.TabIndex = 10;
            this.trbCondicaoEntradaDin.Value = 25;
            this.trbCondicaoEntradaDin.Scroll += new System.EventHandler(this.trbCondicaoEntradaDin_Scroll);
            // 
            // trbRefluxoDin
            // 
            this.trbRefluxoDin.LargeChange = 1;
            this.trbRefluxoDin.Location = new System.Drawing.Point(9, 171);
            this.trbRefluxoDin.Maximum = 50;
            this.trbRefluxoDin.Name = "trbRefluxoDin";
            this.trbRefluxoDin.Size = new System.Drawing.Size(188, 45);
            this.trbRefluxoDin.TabIndex = 11;
            this.trbRefluxoDin.Value = 5;
            this.trbRefluxoDin.Scroll += new System.EventHandler(this.trbRefluxoDin_Scroll);
            // 
            // gubResultados
            // 
            this.gubResultados.Controls.Add(this.pictureBox1);
            this.gubResultados.Controls.Add(this.txbAlpha);
            this.gubResultados.Controls.Add(this.label17);
            this.gubResultados.Controls.Add(this.txbPratoIdeal);
            this.gubResultados.Controls.Add(this.label16);
            this.gubResultados.Controls.Add(this.txbNPratos);
            this.gubResultados.Controls.Add(this.label15);
            this.gubResultados.Location = new System.Drawing.Point(233, 449);
            this.gubResultados.Name = "gubResultados";
            this.gubResultados.Size = new System.Drawing.Size(623, 126);
            this.gubResultados.TabIndex = 17;
            this.gubResultados.TabStop = false;
            this.gubResultados.Text = "Resultados";
            this.gubResultados.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::SimulOP.Properties.Resources.info;
            this.pictureBox1.Location = new System.Drawing.Point(166, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txbAlpha
            // 
            this.txbAlpha.Location = new System.Drawing.Point(126, 19);
            this.txbAlpha.Name = "txbAlpha";
            this.txbAlpha.ReadOnly = true;
            this.txbAlpha.Size = new System.Drawing.Size(34, 20);
            this.txbAlpha.TabIndex = 24;
            this.txbAlpha.Text = "-";
            this.txbAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Valor do alpha:";
            // 
            // txbPratoIdeal
            // 
            this.txbPratoIdeal.Location = new System.Drawing.Point(126, 71);
            this.txbPratoIdeal.Name = "txbPratoIdeal";
            this.txbPratoIdeal.ReadOnly = true;
            this.txbPratoIdeal.Size = new System.Drawing.Size(34, 20);
            this.txbPratoIdeal.TabIndex = 22;
            this.txbPratoIdeal.Text = "-";
            this.txbPratoIdeal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Prato de entrada ideal:";
            // 
            // txbNPratos
            // 
            this.txbNPratos.Location = new System.Drawing.Point(126, 45);
            this.txbNPratos.Name = "txbNPratos";
            this.txbNPratos.ReadOnly = true;
            this.txbNPratos.Size = new System.Drawing.Size(34, 20);
            this.txbNPratos.TabIndex = 20;
            this.txbNPratos.Text = "-";
            this.txbNPratos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Número de pratos:";
            // 
            // gubGrafico
            // 
            this.gubGrafico.Location = new System.Drawing.Point(233, 10);
            this.gubGrafico.Name = "gubGrafico";
            this.gubGrafico.Size = new System.Drawing.Size(623, 433);
            this.gubGrafico.TabIndex = 18;
            this.gubGrafico.TabStop = false;
            this.gubGrafico.Text = "Gráfico";
            // 
            // txbConvergencia
            // 
            this.txbConvergencia.BackColor = System.Drawing.SystemColors.Control;
            this.txbConvergencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbConvergencia.ForeColor = System.Drawing.Color.Green;
            this.txbConvergencia.Location = new System.Drawing.Point(12, 135);
            this.txbConvergencia.Name = "txbConvergencia";
            this.txbConvergencia.ReadOnly = true;
            this.txbConvergencia.Size = new System.Drawing.Size(206, 29);
            this.txbConvergencia.TabIndex = 25;
            this.txbConvergencia.Text = "OK";
            this.txbConvergencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbConvergencia.Visible = false;
            // 
            // FormsColunaMcCabeThiele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 581);
            this.Controls.Add(this.txbConvergencia);
            this.Controls.Add(this.gubResultados);
            this.Controls.Add(this.gubVariaveis);
            this.Controls.Add(this.gubInputInicial);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.gubGrafico);
            this.Name = "FormsColunaMcCabeThiele";
            this.Text = "FormsColunaMcCabeThiele";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.gubInputInicial.ResumeLayout(false);
            this.gubInputInicial.PerformLayout();
            this.gubVariaveis.ResumeLayout(false);
            this.gubVariaveis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefluxoDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCondicaoEntradaDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFracaoEntradaLKDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracaoEntradaLKDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPressaoDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPressaoDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCondicaoEntradaDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRefluxoDin)).EndInit();
            this.gubResultados.ResumeLayout(false);
            this.gubResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox gubInputInicial;
        private System.Windows.Forms.ComboBox cmbFluidoLK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFluidoHK;
        private System.Windows.Forms.Button btnInputInicial;
        private System.Windows.Forms.GroupBox gubVariaveis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudXd;
        private System.Windows.Forms.TrackBar trbXd;
        private System.Windows.Forms.TrackBar trbXb;
        private System.Windows.Forms.NumericUpDown nudXb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trbPressaoDin;
        private System.Windows.Forms.NumericUpDown nudPressaoDin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trbFracaoEntradaLKDin;
        private System.Windows.Forms.NumericUpDown nudFracaoEntradaLKDin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trbCondicaoEntradaDin;
        private System.Windows.Forms.NumericUpDown nudCondicaoEntradaDin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbCondicaoEntradaDin;
        private System.Windows.Forms.TrackBar trbRefluxoDin;
        private System.Windows.Forms.NumericUpDown nudRefluxoDin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gubResultados;
        private System.Windows.Forms.GroupBox gubGrafico;
        private System.Windows.Forms.TextBox txbNPratos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbPratoIdeal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txbAlpha;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txbConvergencia;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}