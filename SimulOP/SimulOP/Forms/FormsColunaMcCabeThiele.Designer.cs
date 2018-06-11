﻿namespace SimulOP.Forms
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gubInputInicial = new System.Windows.Forms.GroupBox();
            this.nudRefluxo = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudFracaoEntradaLK = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudRazaoQ = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCondicaoEntrada = new System.Windows.Forms.ComboBox();
            this.nudPressao = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInputInicial = new System.Windows.Forms.Button();
            this.nudTemperatura = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
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
            this.trbTemperaturaDin = new System.Windows.Forms.TrackBar();
            this.nudTemperaturaDin = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.trbXb = new System.Windows.Forms.TrackBar();
            this.nudXb = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.trbXd = new System.Windows.Forms.TrackBar();
            this.nudXd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.trbCondicaoEntradaDin = new System.Windows.Forms.TrackBar();
            this.trbRefluxoDin = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gubInputInicial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefluxo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracaoEntradaLK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRazaoQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPressao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperatura)).BeginInit();
            this.gubVariaveis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefluxoDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCondicaoEntradaDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFracaoEntradaLKDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracaoEntradaLKDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTemperaturaDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperaturaDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCondicaoEntradaDin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRefluxoDin)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Maximum = 1D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(270, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Black;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Gray;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(600, 426);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // gubInputInicial
            // 
            this.gubInputInicial.Controls.Add(this.nudRefluxo);
            this.gubInputInicial.Controls.Add(this.label11);
            this.gubInputInicial.Controls.Add(this.nudFracaoEntradaLK);
            this.gubInputInicial.Controls.Add(this.label10);
            this.gubInputInicial.Controls.Add(this.nudRazaoQ);
            this.gubInputInicial.Controls.Add(this.label9);
            this.gubInputInicial.Controls.Add(this.label8);
            this.gubInputInicial.Controls.Add(this.cmbCondicaoEntrada);
            this.gubInputInicial.Controls.Add(this.nudPressao);
            this.gubInputInicial.Controls.Add(this.label4);
            this.gubInputInicial.Controls.Add(this.btnInputInicial);
            this.gubInputInicial.Controls.Add(this.nudTemperatura);
            this.gubInputInicial.Controls.Add(this.label3);
            this.gubInputInicial.Controls.Add(this.label2);
            this.gubInputInicial.Controls.Add(this.cmbFluidoHK);
            this.gubInputInicial.Controls.Add(this.label1);
            this.gubInputInicial.Controls.Add(this.cmbFluidoLK);
            this.gubInputInicial.Location = new System.Drawing.Point(12, 10);
            this.gubInputInicial.Name = "gubInputInicial";
            this.gubInputInicial.Size = new System.Drawing.Size(252, 266);
            this.gubInputInicial.TabIndex = 3;
            this.gubInputInicial.TabStop = false;
            this.gubInputInicial.Text = "Input inicial";
            // 
            // nudRefluxo
            // 
            this.nudRefluxo.DecimalPlaces = 1;
            this.nudRefluxo.Location = new System.Drawing.Point(195, 153);
            this.nudRefluxo.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRefluxo.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.nudRefluxo.Name = "nudRefluxo";
            this.nudRefluxo.Size = new System.Drawing.Size(51, 20);
            this.nudRefluxo.TabIndex = 16;
            this.nudRefluxo.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(6, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Razão de refluzo:";
            // 
            // nudFracaoEntradaLK
            // 
            this.nudFracaoEntradaLK.DecimalPlaces = 1;
            this.nudFracaoEntradaLK.Location = new System.Drawing.Point(195, 127);
            this.nudFracaoEntradaLK.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.nudFracaoEntradaLK.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudFracaoEntradaLK.Name = "nudFracaoEntradaLK";
            this.nudFracaoEntradaLK.Size = new System.Drawing.Size(51, 20);
            this.nudFracaoEntradaLK.TabIndex = 14;
            this.nudFracaoEntradaLK.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(6, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Fração do LK na entrada:";
            // 
            // nudRazaoQ
            // 
            this.nudRazaoQ.DecimalPlaces = 1;
            this.nudRazaoQ.Location = new System.Drawing.Point(195, 101);
            this.nudRazaoQ.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRazaoQ.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.nudRazaoQ.Name = "nudRazaoQ";
            this.nudRazaoQ.Size = new System.Drawing.Size(51, 20);
            this.nudRazaoQ.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Valor q na entrada:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(6, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Condição entrada:";
            // 
            // cmbCondicaoEntrada
            // 
            this.cmbCondicaoEntrada.FormattingEnabled = true;
            this.cmbCondicaoEntrada.Items.AddRange(new object[] {
            "Líquido sub-resfriado",
            "Líquido saturado",
            "Parcialmente vaporizado",
            "Vapor saturado",
            "Vapor super aquecido"});
            this.cmbCondicaoEntrada.Location = new System.Drawing.Point(108, 73);
            this.cmbCondicaoEntrada.Name = "cmbCondicaoEntrada";
            this.cmbCondicaoEntrada.Size = new System.Drawing.Size(138, 21);
            this.cmbCondicaoEntrada.TabIndex = 9;
            // 
            // nudPressao
            // 
            this.nudPressao.DecimalPlaces = 1;
            this.nudPressao.Location = new System.Drawing.Point(195, 205);
            this.nudPressao.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudPressao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPressao.Name = "nudPressao";
            this.nudPressao.Size = new System.Drawing.Size(51, 20);
            this.nudPressao.TabIndex = 8;
            this.nudPressao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(6, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pressão [bar]";
            // 
            // btnInputInicial
            // 
            this.btnInputInicial.Location = new System.Drawing.Point(84, 237);
            this.btnInputInicial.Name = "btnInputInicial";
            this.btnInputInicial.Size = new System.Drawing.Size(75, 23);
            this.btnInputInicial.TabIndex = 6;
            this.btnInputInicial.Text = "Calcular";
            this.btnInputInicial.UseVisualStyleBackColor = true;
            this.btnInputInicial.Click += new System.EventHandler(this.btnInputInicial_Click);
            // 
            // nudTemperatura
            // 
            this.nudTemperatura.DecimalPlaces = 1;
            this.nudTemperatura.Location = new System.Drawing.Point(195, 179);
            this.nudTemperatura.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudTemperatura.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTemperatura.Name = "nudTemperatura";
            this.nudTemperatura.Size = new System.Drawing.Size(51, 20);
            this.nudTemperatura.TabIndex = 5;
            this.nudTemperatura.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(6, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Temperatura [ºC]";
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
            "Tolueno"});
            this.cmbFluidoHK.Location = new System.Drawing.Point(125, 46);
            this.cmbFluidoHK.Name = "cmbFluidoHK";
            this.cmbFluidoHK.Size = new System.Drawing.Size(121, 21);
            this.cmbFluidoHK.TabIndex = 2;
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
            "Tolueno"});
            this.cmbFluidoLK.Location = new System.Drawing.Point(125, 19);
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
            this.gubVariaveis.Controls.Add(this.trbTemperaturaDin);
            this.gubVariaveis.Controls.Add(this.nudTemperaturaDin);
            this.gubVariaveis.Controls.Add(this.label7);
            this.gubVariaveis.Controls.Add(this.trbXb);
            this.gubVariaveis.Controls.Add(this.nudXb);
            this.gubVariaveis.Controls.Add(this.label6);
            this.gubVariaveis.Controls.Add(this.trbXd);
            this.gubVariaveis.Controls.Add(this.nudXd);
            this.gubVariaveis.Controls.Add(this.label5);
            this.gubVariaveis.Controls.Add(this.trbCondicaoEntradaDin);
            this.gubVariaveis.Controls.Add(this.trbRefluxoDin);
            this.gubVariaveis.Location = new System.Drawing.Point(876, 12);
            this.gubVariaveis.Name = "gubVariaveis";
            this.gubVariaveis.Size = new System.Drawing.Size(206, 384);
            this.gubVariaveis.TabIndex = 4;
            this.gubVariaveis.TabStop = false;
            this.gubVariaveis.Text = "Variáveis dinâmicas";
            // 
            // nudRefluxoDin
            // 
            this.nudRefluxoDin.DecimalPlaces = 1;
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
            this.nudRefluxoDin.TabIndex = 23;
            this.nudRefluxoDin.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
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
            // 
            // nudCondicaoEntradaDin
            // 
            this.nudCondicaoEntradaDin.DecimalPlaces = 1;
            this.nudCondicaoEntradaDin.Location = new System.Drawing.Point(147, 67);
            this.nudCondicaoEntradaDin.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.nudCondicaoEntradaDin.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudCondicaoEntradaDin.Name = "nudCondicaoEntradaDin";
            this.nudCondicaoEntradaDin.Size = new System.Drawing.Size(50, 20);
            this.nudCondicaoEntradaDin.TabIndex = 20;
            this.nudCondicaoEntradaDin.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            this.trbFracaoEntradaLKDin.Location = new System.Drawing.Point(9, 31);
            this.trbFracaoEntradaLKDin.Maximum = 50;
            this.trbFracaoEntradaLKDin.Name = "trbFracaoEntradaLKDin";
            this.trbFracaoEntradaLKDin.Size = new System.Drawing.Size(188, 45);
            this.trbFracaoEntradaLKDin.TabIndex = 19;
            this.trbFracaoEntradaLKDin.Value = 25;
            // 
            // nudFracaoEntradaLKDin
            // 
            this.nudFracaoEntradaLKDin.DecimalPlaces = 1;
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
            this.nudFracaoEntradaLKDin.TabIndex = 17;
            this.nudFracaoEntradaLKDin.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            // trbTemperaturaDin
            // 
            this.trbTemperaturaDin.Location = new System.Drawing.Point(9, 325);
            this.trbTemperaturaDin.Maximum = 50;
            this.trbTemperaturaDin.Name = "trbTemperaturaDin";
            this.trbTemperaturaDin.Size = new System.Drawing.Size(188, 45);
            this.trbTemperaturaDin.TabIndex = 16;
            this.trbTemperaturaDin.Value = 7;
            // 
            // nudTemperaturaDin
            // 
            this.nudTemperaturaDin.DecimalPlaces = 1;
            this.nudTemperaturaDin.Location = new System.Drawing.Point(147, 307);
            this.nudTemperaturaDin.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudTemperaturaDin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTemperaturaDin.Name = "nudTemperaturaDin";
            this.nudTemperaturaDin.Size = new System.Drawing.Size(50, 20);
            this.nudTemperaturaDin.TabIndex = 14;
            this.nudTemperaturaDin.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(6, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Temperatura:";
            // 
            // trbXb
            // 
            this.trbXb.Location = new System.Drawing.Point(9, 274);
            this.trbXb.Maximum = 50;
            this.trbXb.Name = "trbXb";
            this.trbXb.Size = new System.Drawing.Size(188, 45);
            this.trbXb.TabIndex = 13;
            this.trbXb.Value = 10;
            // 
            // nudXb
            // 
            this.nudXb.DecimalPlaces = 3;
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
            this.nudXb.TabIndex = 11;
            this.nudXb.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
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
            this.trbXd.TabIndex = 10;
            this.trbXd.Value = 45;
            // 
            // nudXd
            // 
            this.nudXd.DecimalPlaces = 3;
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
            this.nudXd.TabIndex = 9;
            this.nudXd.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
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
            this.trbCondicaoEntradaDin.TabIndex = 22;
            this.trbCondicaoEntradaDin.Value = 25;
            // 
            // trbRefluxoDin
            // 
            this.trbRefluxoDin.Location = new System.Drawing.Point(9, 171);
            this.trbRefluxoDin.Maximum = 50;
            this.trbRefluxoDin.Name = "trbRefluxoDin";
            this.trbRefluxoDin.Size = new System.Drawing.Size(188, 45);
            this.trbRefluxoDin.TabIndex = 25;
            // 
            // FormsColunaMcCabeThiele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 527);
            this.Controls.Add(this.gubVariaveis);
            this.Controls.Add(this.gubInputInicial);
            this.Controls.Add(this.chart1);
            this.Name = "FormsColunaMcCabeThiele";
            this.Text = "FormsColunaMcCabeThiele";
            this.Load += new System.EventHandler(this.FormsColunaMcCabeThiele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gubInputInicial.ResumeLayout(false);
            this.gubInputInicial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefluxo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracaoEntradaLK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRazaoQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPressao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperatura)).EndInit();
            this.gubVariaveis.ResumeLayout(false);
            this.gubVariaveis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefluxoDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCondicaoEntradaDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFracaoEntradaLKDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracaoEntradaLKDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTemperaturaDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperaturaDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbXd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCondicaoEntradaDin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRefluxoDin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox gubInputInicial;
        private System.Windows.Forms.ComboBox cmbFluidoLK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFluidoHK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTemperatura;
        private System.Windows.Forms.Button btnInputInicial;
        private System.Windows.Forms.GroupBox gubVariaveis;
        private System.Windows.Forms.NumericUpDown nudPressao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudXd;
        private System.Windows.Forms.TrackBar trbXd;
        private System.Windows.Forms.TrackBar trbXb;
        private System.Windows.Forms.NumericUpDown nudXb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trbTemperaturaDin;
        private System.Windows.Forms.NumericUpDown nudTemperaturaDin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudRefluxo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudFracaoEntradaLK;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudRazaoQ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCondicaoEntrada;
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
    }
}