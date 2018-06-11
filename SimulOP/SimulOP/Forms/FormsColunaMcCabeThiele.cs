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
        private FluidoIdealOPIII fluidoBenzeno;
        private FluidoIdealOPIII fluidoTolueno;
        private MisturaBinaria mistura;
        private ColunaMcCabeThiele ColunaMcCabeThiele;

        public FormsColunaMcCabeThiele()
        {
            InitializeComponent();

            fluidoBenzeno = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII("benzeno"), 298);
            fluidoTolueno = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII("tolueno"), 298);

            mistura = new MisturaBinaria(fluidoBenzeno, fluidoTolueno, 1, 340, 1E5);

            ColunaMcCabeThiele = new ColunaMcCabeThiele(mistura, 0.95, 0.05, 0.60, 1.59, 1);
        }

        private void FormsColunaMcCabeThiele_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<double> plotX = new List<double>();
            List<double> plotY = new List<double>();

            (plotX, plotY) = ColunaMcCabeThiele.PlotEquilibrio(100);

            chart1.Series[0].Points.DataBindXY(plotX, plotY);

            List<double> plotXP = new List<double>();
            List<double> plotYP = new List<double>();

            (plotXP, plotYP) = ColunaMcCabeThiele.PlotCurvaQ(100);

            chart1.Series[1].Points.DataBindXY(plotXP, plotYP);
                        
            ColunaMcCabeThiele.CalculaPontoP();

            /*
            (plotXP, plotYP) = ColunaMcCabeThiele.PlotPratos();

            chart1.Series[1].Points.DataBindXY(plotXP, plotYP);
            chart1.Series[2].Points.DataBindXY(new double[2] { 0, 1 }, new double[2] { 0, 1 });
            */
            
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            List<double> plotXP = new List<double>();
            List<double> plotYP = new List<double>();

            double xD = 0.50 + trbXd.Value / 100.0;

            ColunaMcCabeThiele.TargetXD = xD;
            
            List<double> plotXP1 = new List<double>();
            List<double> plotYP1 = new List<double>();

            (plotXP1, plotYP1) = ColunaMcCabeThiele.PlotCurvaOP(100);

            chart1.Series[2].Points.DataBindXY(plotXP1, plotYP1);

            (plotXP, plotYP) = ColunaMcCabeThiele.PlotPratos();

            chart1.Series[1].Points.DataBindXY(plotXP, plotYP);
        }

        private void btnInputInicial_Click(object sender, EventArgs e)
        {

        }
    }
}
