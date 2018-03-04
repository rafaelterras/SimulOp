﻿namespace SimulOP.Forms
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label22 = new System.Windows.Forms.Label();
            this.numericViscosidade = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericDensidade = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.numericRugosidade = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericElevacao = new System.Windows.Forms.NumericUpDown();
            this.numericDiametro = new System.Windows.Forms.NumericUpDown();
            this.numericComprimento = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarDeq = new System.Windows.Forms.TrackBar();
            this.trackBarCeq = new System.Windows.Forms.TrackBar();
            this.trackBarBeq = new System.Windows.Forms.TrackBar();
            this.trackBarAeq = new System.Windows.Forms.TrackBar();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericViscosidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRugosidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericElevacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiametro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericComprimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAeq)).BeginInit();
            this.SuspendLayout();
            // 
            // chart2
            // 
            chartArea7.AxisX.Maximum = 40D;
            chartArea7.AxisX.Minimum = 0D;
            chartArea7.AxisX.Title = "Vazão [m^3/h]";
            chartArea7.AxisX2.Maximum = 40D;
            chartArea7.AxisX2.Minimum = 0D;
            chartArea7.AxisY.Maximum = 30D;
            chartArea7.AxisY.Minimum = 0D;
            chartArea7.AxisY.Title = "Carga [m]";
            chartArea7.AxisY2.Maximum = 30D;
            chartArea7.AxisY2.Minimum = 0D;
            chartArea7.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea7);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chart2.Legends.Add(legend7);
            this.chart2.Location = new System.Drawing.Point(414, 3);
            this.chart2.Name = "chart2";
            series19.BorderWidth = 3;
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series19.Legend = "Legend1";
            series19.Name = "Altura da bomba";
            series20.BorderWidth = 3;
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series20.Legend = "Legend1";
            series20.Name = "Curva da tubulacao";
            series21.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series21.BorderWidth = 2;
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series21.Label = "Ponto de operacao";
            series21.LabelBackColor = System.Drawing.Color.White;
            series21.LabelBorderColor = System.Drawing.Color.Black;
            series21.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series21.Legend = "Legend1";
            series21.Name = "Ponto de operacao";
            series21.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            this.chart2.Series.Add(series19);
            this.chart2.Series.Add(series20);
            this.chart2.Series.Add(series21);
            this.chart2.Size = new System.Drawing.Size(953, 743);
            this.chart2.TabIndex = 7;
            this.chart2.Text = "chart2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 749);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(405, 743);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MediumBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(399, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "Entradas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 365);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Variáveis";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.trackBarDeq);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarCeq);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarBeq);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarAeq);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.Controls.Add(this.label17);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Size = new System.Drawing.Size(393, 338);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label22);
            this.splitContainer2.Panel1.Controls.Add(this.numericViscosidade);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.numericDensidade);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBox1);
            this.splitContainer2.Panel2.Controls.Add(this.numericRugosidade);
            this.splitContainer2.Panel2.Controls.Add(this.label24);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.numericElevacao);
            this.splitContainer2.Panel2.Controls.Add(this.numericDiametro);
            this.splitContainer2.Panel2.Controls.Add(this.numericComprimento);
            this.splitContainer2.Panel2.Controls.Add(this.label14);
            this.splitContainer2.Panel2.Controls.Add(this.label15);
            this.splitContainer2.Panel2.Controls.Add(this.label12);
            this.splitContainer2.Panel2.Controls.Add(this.label13);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Size = new System.Drawing.Size(393, 138);
            this.splitContainer2.SplitterDistance = 131;
            this.splitContainer2.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(58, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 11);
            this.label22.TabIndex = 14;
            this.label22.Text = "cP";
            // 
            // numericViscosidade
            // 
            this.numericViscosidade.DecimalPlaces = 1;
            this.numericViscosidade.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericViscosidade.Location = new System.Drawing.Point(6, 93);
            this.numericViscosidade.Name = "numericViscosidade";
            this.numericViscosidade.Size = new System.Drawing.Size(46, 18);
            this.numericViscosidade.TabIndex = 13;
            this.numericViscosidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 11);
            this.label7.TabIndex = 12;
            this.label7.Text = "g/cm³";
            // 
            // numericDensidade
            // 
            this.numericDensidade.DecimalPlaces = 1;
            this.numericDensidade.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericDensidade.Location = new System.Drawing.Point(6, 42);
            this.numericDensidade.Name = "numericDensidade";
            this.numericDensidade.Size = new System.Drawing.Size(46, 18);
            this.numericDensidade.TabIndex = 11;
            this.numericDensidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 11);
            this.label2.TabIndex = 2;
            this.label2.Text = "Viscosidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 11);
            this.label1.TabIndex = 1;
            this.label1.Text = "Densidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fluido";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Lucida Console", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 8;
            this.listBox1.Items.AddRange(new object[] {
            "Sugestões:",
            "Tubo liso (25 um)",
            "Aço comercial (45 um)",
            "Concreto (300 um)"});
            this.listBox1.Location = new System.Drawing.Point(103, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(127, 32);
            this.listBox1.TabIndex = 35;
            // 
            // numericRugosidade
            // 
            this.numericRugosidade.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericRugosidade.Location = new System.Drawing.Point(8, 42);
            this.numericRugosidade.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericRugosidade.Name = "numericRugosidade";
            this.numericRugosidade.Size = new System.Drawing.Size(46, 18);
            this.numericRugosidade.TabIndex = 33;
            this.numericRugosidade.Value = new decimal(new int[] {
            46,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(60, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(19, 11);
            this.label24.TabIndex = 34;
            this.label24.Text = "um";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(236, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 11);
            this.label10.TabIndex = 32;
            this.label10.Text = "m";
            // 
            // numericElevacao
            // 
            this.numericElevacao.DecimalPlaces = 1;
            this.numericElevacao.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericElevacao.Location = new System.Drawing.Point(184, 93);
            this.numericElevacao.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericElevacao.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.numericElevacao.Name = "numericElevacao";
            this.numericElevacao.Size = new System.Drawing.Size(46, 18);
            this.numericElevacao.TabIndex = 31;
            this.numericElevacao.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericDiametro
            // 
            this.numericDiametro.DecimalPlaces = 1;
            this.numericDiametro.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericDiametro.Location = new System.Drawing.Point(103, 93);
            this.numericDiametro.Name = "numericDiametro";
            this.numericDiametro.Size = new System.Drawing.Size(46, 18);
            this.numericDiametro.TabIndex = 30;
            this.numericDiametro.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericComprimento
            // 
            this.numericComprimento.DecimalPlaces = 1;
            this.numericComprimento.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericComprimento.Location = new System.Drawing.Point(8, 93);
            this.numericComprimento.Name = "numericComprimento";
            this.numericComprimento.Size = new System.Drawing.Size(46, 18);
            this.numericComprimento.TabIndex = 25;
            this.numericComprimento.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(60, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 11);
            this.label14.TabIndex = 29;
            this.label14.Text = "m";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(182, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 11);
            this.label15.TabIndex = 28;
            this.label15.Text = "Elevação";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(155, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 11);
            this.label12.TabIndex = 27;
            this.label12.Text = "cm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(101, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 11);
            this.label13.TabIndex = 26;
            this.label13.Text = "Diâmetro";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 11);
            this.label11.TabIndex = 24;
            this.label11.Text = "Comprimento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 11);
            this.label9.TabIndex = 23;
            this.label9.Text = "Rugosidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tubulação";
            // 
            // trackBarDeq
            // 
            this.trackBarDeq.Location = new System.Drawing.Point(31, 138);
            this.trackBarDeq.Maximum = 1000;
            this.trackBarDeq.Minimum = 1;
            this.trackBarDeq.Name = "trackBarDeq";
            this.trackBarDeq.Size = new System.Drawing.Size(347, 45);
            this.trackBarDeq.TabIndex = 46;
            this.trackBarDeq.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarDeq.Value = 500;
            this.trackBarDeq.Scroll += new System.EventHandler(this.AtualizaGrafico);
            // 
            // trackBarCeq
            // 
            this.trackBarCeq.Location = new System.Drawing.Point(31, 97);
            this.trackBarCeq.Maximum = 1000;
            this.trackBarCeq.Name = "trackBarCeq";
            this.trackBarCeq.Size = new System.Drawing.Size(347, 45);
            this.trackBarCeq.TabIndex = 45;
            this.trackBarCeq.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarCeq.Value = 500;
            this.trackBarCeq.Scroll += new System.EventHandler(this.AtualizaGrafico);
            // 
            // trackBarBeq
            // 
            this.trackBarBeq.Location = new System.Drawing.Point(31, 54);
            this.trackBarBeq.Maximum = 1000;
            this.trackBarBeq.Name = "trackBarBeq";
            this.trackBarBeq.Size = new System.Drawing.Size(347, 45);
            this.trackBarBeq.TabIndex = 44;
            this.trackBarBeq.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBeq.Value = 500;
            this.trackBarBeq.Scroll += new System.EventHandler(this.AtualizaGrafico);
            // 
            // trackBarAeq
            // 
            this.trackBarAeq.Location = new System.Drawing.Point(31, 19);
            this.trackBarAeq.Maximum = 1000;
            this.trackBarAeq.Name = "trackBarAeq";
            this.trackBarAeq.Size = new System.Drawing.Size(347, 45);
            this.trackBarAeq.TabIndex = 43;
            this.trackBarAeq.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarAeq.Scroll += new System.EventHandler(this.AtualizaGrafico);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 11);
            this.label18.TabIndex = 42;
            this.label18.Text = "D";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 11);
            this.label17.TabIndex = 40;
            this.label17.Text = "C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 11);
            this.label8.TabIndex = 38;
            this.label8.Text = "B";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Bomba";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 11);
            this.label16.TabIndex = 36;
            this.label16.Text = "A";
            // 
            // FormsAutoBomba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormsAutoBomba";
            this.Text = "FormsAutoBomba";
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericViscosidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRugosidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericElevacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiametro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericComprimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAeq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numericViscosidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericDensidade;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown numericRugosidade;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericElevacao;
        private System.Windows.Forms.NumericUpDown numericDiametro;
        private System.Windows.Forms.NumericUpDown numericComprimento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar trackBarDeq;
        private System.Windows.Forms.TrackBar trackBarCeq;
        private System.Windows.Forms.TrackBar trackBarBeq;
        private System.Windows.Forms.TrackBar trackBarAeq;
    }
}