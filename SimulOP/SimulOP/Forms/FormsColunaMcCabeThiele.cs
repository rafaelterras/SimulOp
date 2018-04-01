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
        public FormsColunaMcCabeThiele()
        {
            InitializeComponent();
        }

        private void FormsColunaMcCabeThiele_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FluidoIdealOPIII fluidoBenzeno = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII("benzeno"), 298);
            FluidoIdealOPIII fluidoTolueno = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII("água"), 298);

            MisturaBinaria mistura = new MisturaBinaria(fluidoBenzeno, fluidoTolueno, 1, 340, 1E5);

            ColunaMcCabeThiele ColunaMcCabeThiele = new ColunaMcCabeThiele(mistura);

            List<double> plotX = new List<double>();
            List<double> plotY = new List<double>();

            (plotX, plotY) = ColunaMcCabeThiele.PlotEquilibrio(100);

            chart1.Series[0].Points.DataBindXY(plotX, plotY);

        }
    }
}
