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
            fluidoTolueno = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII("água"), 298);

            mistura = new MisturaBinaria(fluidoBenzeno, fluidoTolueno, 1, 340, 1E5);

            ColunaMcCabeThiele = new ColunaMcCabeThiele(mistura);

        }

        private void FormsColunaMcCabeThiele_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> plotX = new List<double>();
            List<double> plotY = new List<double>();

            (plotX, plotY) = ColunaMcCabeThiele.PlotEquilibrio(100);

            chart1.Series[0].Points.DataBindXY(plotX, plotY);

            List<double> plotXP = new List<double>();
            List<double> plotYP = new List<double>();

            (plotXP, plotYP) = ColunaMcCabeThiele.PlotPratos(0.8,0.2);

            chart1.Series[1].Points.DataBindXY(plotXP, plotYP);
            chart1.Series[2].Points.DataBindXY(new double[2] { 0, 1 }, new double[2] { 0, 1 });
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            List<double> plotXP = new List<double>();
            List<double> plotYP = new List<double>();

            double xD = 0.49 + trackBar1.Value / 100.0;

            (plotXP, plotYP) = ColunaMcCabeThiele.PlotPratos(xD, 0.05);

            chart1.Series[1].Points.DataBindXY(plotXP, plotYP);
        }
    }
}
