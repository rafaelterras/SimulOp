using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulOP.Forms
{
    public partial class FormsAutoBomba : Form
    {
        protected void AtualizaGrafico()
        {
            double densidade = Convert.ToDouble(numericDensidade.Value) * 1000;
            double viscosidade = Convert.ToDouble(numericViscosidade.Value) / 1000;

            double diametro = Convert.ToDouble(numericDiametro.Value) / 100;
            double comprimento = Convert.ToDouble(numericComprimento.Value);
            double rugosidade = Convert.ToDouble(numericRugosidade.Value) / 1000000;
            double elevacao = Convert.ToDouble(numericElevacao.Value);

            double AeqBomba = (trackBarAeq.Value / 500.0);
            double BeqBomba = (trackBarBeq.Value / 500.0)*(-2096928);
            double CeqBomba = (trackBarCeq.Value / 500.0)*2649.96;
            double DeqBomba = (trackBarDeq.Value / 500.0) * 26;

            // Cria o fluido agua usando o constructor
            Fluido agua = new Fluido(densidade, viscosidade);

            // Cria a tubulação tubo1 usando o constructor
            Tubulacao tubo1 = new Tubulacao(diametro, comprimento, rugosidade, elevacao);

            // Cria as singularidades usando o constructor
            Singularidade s1 = new Singularidade(1, "Cotovelo");
            Singularidade s2 = new Singularidade(2, "Cotovelo");

            tubo1.ListaSingulariedades = new List<Singularidade> { s1, s2 };

            Bomba bomba1 = new Bomba(new double[] { AeqBomba, BeqBomba, CeqBomba, DeqBomba }, agua, tubo1);

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
            chart2.Series[0].Points.DataBindXY(plotX, plotYBomba);
            chart2.Series[1].Points.DataBindXY(plotX, plotYtubo);

            // Plotagem do ponto de operacao
            chart2.Series[2].Points.DataBindXY(pontoOperacaoX, pontoOperacaoY);
            chart2.Series[2].Label = "Ponto de operacao (" + Math.Round(pontoOperacaoX[0], 1) + " [m^3/h] ; "
                + Math.Round(pontoOperacaoY[0], 1) + " [m])";
        }

        public FormsAutoBomba()
        {
            InitializeComponent();

            AtualizaGrafico();
        }

        private void AtualizaGrafico(object sender, EventArgs e)
        {
            AtualizaGrafico();
        }
    }
}
