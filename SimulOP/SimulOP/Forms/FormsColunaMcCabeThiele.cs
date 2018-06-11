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
    public partial class FormsColunaMcCabeThiele : Form
    {
        // Objetos para cálculo da coluna
        private FluidoIdealOPIII fluidoLK;
        private FluidoIdealOPIII fluidoHK;
        private MisturaBinaria mistura;
        private ColunaMcCabeThiele ColunaMcCabeThiele;

        // Strings e doubles da UI - Input Inicial
        private string cmbFluidoLKTxt;
        private string cmbFluidoHKTxt;
        private string cmbCondicaoEntradaTxt;
        private double nudRazaoQDbl;
        private double nudFracaoEntradaLKDbl;
        private double nudRefluxoDbl;
        private double nudTemperaturaDbl;
        private double nudPressaoDbl;

        // Strings, doubles e ints da UI - Variáveis Dinâmicas
        private double nudFracaoEntradaLKDinDbl;
        private int trbFracaoEntradaLKDinInt;
        private double nudCondicaoEntradaDinDbl;
        private string cmbCondicaoEntradaDinTxt;
        private int trbCondicaoEntradaDinInt;
        private double nudRefluxoDinDbl;
        private int trbRefluxoDinInt;
        private double nudXdDbl;
        private int trbXdInt;
        private double nudXbDbl;
        private int trbXbInt;
        private double nudTemperaturaDinDbl;
        private int trbTemperaturaDinInt;

        public FormsColunaMcCabeThiele()
        {
            InitializeComponent();
        }

        private void FormsColunaMcCabeThiele_Load(object sender, EventArgs e)
        {

        }

        private void btnInputInicial_Click(object sender, EventArgs e)
        {
            cmbFluidoLKTxt = cmbFluidoLK.Text;
            cmbFluidoHKTxt = cmbFluidoHK.Text;
            cmbCondicaoEntradaTxt = cmbCondicaoEntrada.Text;
            nudRazaoQDbl = Convert.ToDouble(nudRazaoQ.Value);
            nudFracaoEntradaLKDbl = Convert.ToDouble(nudFracaoEntradaLK.Value);
            nudRefluxoDbl = Convert.ToDouble(nudRefluxo.Value);
            nudTemperaturaDbl = Convert.ToDouble(nudTemperatura.Value) + 273.15; // Temperatura tem que ser usada em Kelvin
            nudPressaoDbl = Convert.ToDouble(nudPressao.Value);

            if (cmbFluidoLKTxt != null && cmbFluidoHKTxt != null)
            {
                fluidoLK = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII(cmbFluidoLKTxt), nudTemperaturaDbl);
                fluidoHK = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII(cmbFluidoHKTxt), nudTemperaturaDbl);
                mistura = new MisturaBinaria(fluidoLK, fluidoHK, nudFracaoEntradaLKDbl, nudTemperaturaDbl, nudPressaoDbl);
                ColunaMcCabeThiele = new ColunaMcCabeThiele(mistura, 0.9, 0.01, nudFracaoEntradaLKDbl, nudRefluxoDbl, nudRazaoQDbl);

                List<double> eqX = new List<double>();
                List<double> eqY = new List<double>();

                (eqX, eqY) = ColunaMcCabeThiele.PlotEquilibrio(100);

                chart.Series[0].Points.DataBindXY(eqX, eqY);
                chart.Series[2].Points.DataBindXY(new double[2] { 0, 1 }, new double[2] { 0, 1 });

                List<double> pratosX = new List<double>();
                List<double> pratosY = new List<double>();

                (pratosX, pratosY) = ColunaMcCabeThiele.PlotPratos();

                chart.Series[1].Points.DataBindXY(pratosX, pratosY);
            }

        }
    }
}
