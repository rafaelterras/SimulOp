using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulOP
{
    public partial class FormBomba : Form
    {
        public FormBomba()
        {
            InitializeComponent();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cria o fluido agua usando o constructor
            Fluido agua = new Fluido(1000, 8.90E-4);

            // Cria a tubulação tubo1 usando o constructor
            Tubulacao tubo1 = new Tubulacao(0.05, 10, 4.572E-5, 20);

            // Cira as singularidades usando o constructor
            Singularidade s1 = new Singularidade(1, "Cotovelo");
            Singularidade s2 = new Singularidade(2, "Cotovelo");

            tubo1.ListaSingulariedades = new List<Singularidade> { s1, s2 };

            Bomba bomba1 = new Bomba(new double[] { 0, -2096928, 2649.96, 26 }, agua, tubo1);

            // Atualiza os valores da bomba
            bomba1.CalculaVazao();

            double[] plotX;
            double[] plotYBomba;
            double[] plotYtubo;

            // Prepara os pontos para plotagem
            (plotX, plotYBomba, plotYtubo) = bomba1.PreparaPlot(40);

            // Ponto de operacao para plotagem
            double[] pontoOperacaoX = new double[1];
            double[] pontoOperacaoY = new double[1];

            // Definicao do ponto de operacao
            pontoOperacaoX[0] = bomba1.Vazao * 3600; // m^3/h
            pontoOperacaoY[0] = bomba1.CalcAlturaBomba(bomba1.Vazao);

            // Plotagem da curva da bomba e da tubulacao
            chart1.Series[0].Points.DataBindXY(plotX, plotYBomba);
            chart1.Series[1].Points.DataBindXY(plotX, plotYtubo);

            // Plotagem do ponto de operacao
            chart1.Series[2].Points.DataBindXY(pontoOperacaoX, pontoOperacaoY);
            chart1.Series[2].Label = "Ponto de operacao (" + Math.Round(pontoOperacaoX[0], 1) + " [m^3/h] ; "
                + Math.Round(pontoOperacaoY[0], 1) + " [m])";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double EqBomba = ((trackBar1.Value + 1) / 10.0) * -2096928;

            // Cria o fluido agua usando o constructor
            Fluido agua = new Fluido(1000, 8.90E-4);

            // Cria a tubulação tubo1 usando o constructor
            Tubulacao tubo1 = new Tubulacao(0.05, 10, 4.572E-5, 20);

            // Cira as singularidades usando o constructor
            Singularidade s1 = new Singularidade(1, "Cotovelo");
            Singularidade s2 = new Singularidade(2, "Cotovelo");

            tubo1.ListaSingulariedades = new List<Singularidade> { s1, s2 };

            Bomba bomba1 = new Bomba(new double[] { 0, EqBomba, 2649.96, 26 }, agua, tubo1);

            // Atualiza os valores da bomba
            bomba1.CalculaVazao();

            double[] plotX;
            double[] plotYBomba;
            double[] plotYtubo;

            // Prepara os pontos para plotagem
            (plotX, plotYBomba, plotYtubo) = bomba1.PreparaPlot(40);

            // Ponto de operacao para plotagem
            double[] pontoOperacaoX = new double[1];
            double[] pontoOperacaoY = new double[1];

            // Definicao do ponto de operacao
            pontoOperacaoX[0] = bomba1.Vazao * 3600; // m^3/h
            pontoOperacaoY[0] = bomba1.CalcAlturaBomba(bomba1.Vazao);

            // Plotagem da curva da bomba e da tubulacao
            chart1.Series[0].Points.DataBindXY(plotX, plotYBomba);
            chart1.Series[1].Points.DataBindXY(plotX, plotYtubo);

            // Plotagem do ponto de operacao
            chart1.Series[2].Points.DataBindXY(pontoOperacaoX, pontoOperacaoY);
            chart1.Series[2].Label = "Ponto de operacao (" + Math.Round(pontoOperacaoX[0], 1) + " [m^3/h] ; "
                + Math.Round(pontoOperacaoY[0], 1) + " [m])";
        }
    }
}
