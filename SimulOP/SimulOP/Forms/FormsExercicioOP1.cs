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
    public partial class FormsExercicioOP1 : Form
    {
        public FormsExercicioOP1()
        {
            InitializeComponent();
        }

        public void CalculaTudo(object sender, EventArgs e)
        {
            double vazao = Convert.ToDouble(numericUpDown1.Value);
            double pressaoAtm = Convert.ToDouble(numericUpDown11.Value);

            FluidoOPI agua = new FluidoOPI(InicializadorObjetos.MaterialFluidoOPI("água"));

            Tubulacao tubulacaoSuccao = new Tubulacao(Convert.ToDouble(numericUpDown4.Value) / 100,
                Convert.ToDouble(numericUpDown6.Value), Convert.ToDouble(numericUpDown3.Value) / 1000,
                Convert.ToDouble(numericUpDown8.Value), "haaland");

            Tubulacao tubulacaoRecalque = new Tubulacao(Convert.ToDouble(numericUpDown4.Value) / 100, 
                Convert.ToDouble(numericUpDown5.Value), Convert.ToDouble(numericUpDown3.Value) / 1000, 
                Convert.ToDouble(numericUpDown2.Value) - Convert.ToDouble(numericUpDown8.Value), "haaland");

            label24.Text = Convert.ToString(tubulacaoSuccao.Comprimento + tubulacaoRecalque.Comprimento);

            Tubulacao tubulacaoCompleta = new Tubulacao(Convert.ToDouble(numericUpDown4.Value) / 100,
                Convert.ToDouble(label24.Text), Convert.ToDouble(numericUpDown3.Value) / 1000,
                Convert.ToDouble(numericUpDown2.Value), "haaland");

            BombaCompleta bombaCompleta = new BombaCompleta(new double[] { 0.00, 0.00, 0.00, 0.00 }, agua, tubulacaoSuccao, 
                tubulacaoRecalque, Convert.ToDouble(numericUpDown11.Value), Convert.ToDouble(numericUpDown13.Value), Convert.ToDouble(numericUpDown12.Value));

            /// Item a)
            label38.Text = Convert.ToString(Math.Round(tubulacaoCompleta.CalculaReynolds(agua, vazao)));
            label39.Text = Convert.ToString(Math.Round(100000 * tubulacaoCompleta.CalculaFAtrito(agua, vazao)) / 100000);
            label44.Text = Convert.ToString(Math.Round(10000 * tubulacaoCompleta.CalculaPerdaCarga(agua, vazao)) / 10000);
            label48.Text = Convert.ToString(Math.Round(10000 * tubulacaoCompleta.CalculaPerdaCarga(agua, vazao)) / 10000 + tubulacaoCompleta.Elevacao);

            /// Item b)
            label50.Text = Convert.ToString(Math.Round(100 * agua.ConvertePressaoEmM(pressaoAtm)) / 100);
            label51.Text = Convert.ToString(numericUpDown8.Value);
            label55.Text = Convert.ToString(Math.Round(1000 * agua.ConvertePressaoEmM(agua.PresaoVapor)) / 1000);
            label53.Text = Convert.ToString(Math.Round(100 * tubulacaoSuccao.CalculaPerdaCarga(agua, vazao)) / 100);
            label57.Text = Convert.ToString(Math.Round(100 * bombaCompleta.npshDisponivel(pressaoAtm, agua.PresaoVapor)) / 100);
            label60.Text = Convert.ToString(bombaCompleta.NPSHRequerido);
            if (Convert.ToDouble(label57.Text) > Convert.ToDouble(label60.Text))
            {
                label59.Text = ">";
                label61.Text = "Não pode haver cavitação!";
            } else
            {
                label61.Text = "Pode haver cavitação!";
                if (Convert.ToDouble(label57.Text) == Convert.ToDouble(label60.Text)) label59.Text = "=";
                else label59.Text = "<"; 
            }

            /// Item c)
            bombaCompleta.CalcAlturaBomba(vazao);
            double potenciaW = bombaCompleta.CalculaPotencia(vazao);
            double tempoS = Convert.ToDouble(numericUpDown14.Value) / vazao;

            label63.Text = Convert.ToString(Math.Round(potenciaW));
            label65.Text = Convert.ToString(Math.Round(potenciaW / 1000));
            label68.Text = Convert.ToString(Math.Round(tempoS));
            label70.Text = Convert.ToString(Math.Round(10000 * tempoS / 3600) / 10000);
            label73.Text = Convert.ToString(Math.Round(100 * potenciaW * tempoS / 3600000) / 100);
            label76.Text = Convert.ToString(Math.Round(1000 * potenciaW * tempoS * 
                Convert.ToDouble(numericUpDown15.Value) / 3600000) / 1000);

        }

        public void OcultaMostraItemA(object sender, EventArgs e)
        {
            if(label48.Visible == true)
            {
                label37.Visible = false;
                label38.Visible = false;
                label39.Visible = false;
                label40.Visible = false;
                label41.Visible = false;
                label42.Visible = false;
                label43.Visible = false;
                label44.Visible = false;
                label45.Visible = false;
                label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                label78.Visible = false;
                label79.Visible = false;
            } else
            {
                label37.Visible = true;
                label38.Visible = true;
                label39.Visible = true;
                label40.Visible = true;
                label41.Visible = true;
                label42.Visible = true;
                label43.Visible = true;
                label44.Visible = true;
                label45.Visible = true;
                label46.Visible = true;
                label47.Visible = true;
                label48.Visible = true;
                label78.Visible = true;
                label79.Visible = true;
            }
        }

        public void OcultaMostraItemB(object sender, EventArgs e)
        {
            if (label61.Visible == true)
            {
                label49.Visible = false;
                label50.Visible = false;
                label51.Visible = false;
                label52.Visible = false;
                label53.Visible = false;
                label54.Visible = false;
                label55.Visible = false;
                label56.Visible = false;
                label57.Visible = false;
                label58.Visible = false;
                label59.Visible = false;
                label60.Visible = false;
                label61.Visible = false;
                label80.Visible = false;
            }
            else
            {
                label49.Visible = true;
                label50.Visible = true;
                label51.Visible = true;
                label52.Visible = true;
                label53.Visible = true;
                label54.Visible = true;
                label55.Visible = true;
                label56.Visible = true;
                label57.Visible = true;
                label58.Visible = true;
                label59.Visible = true;
                label60.Visible = true;
                label61.Visible = true;
                label80.Visible = true;
            }
        }

        public void OcultaMostraItemC(object sender, EventArgs e)
        {
            if (label77.Visible == true)
            {
                label62.Visible = false;
                label63.Visible = false;
                label64.Visible = false;
                label65.Visible = false;
                label66.Visible = false;
                label67.Visible = false;
                label68.Visible = false;
                label69.Visible = false;
                label70.Visible = false;
                label71.Visible = false;
                label72.Visible = false;
                label73.Visible = false;
                label74.Visible = false;
                label75.Visible = false;
                label76.Visible = false;
                label77.Visible = false;
                label81.Visible = false;
            }
            else
            {
                label62.Visible = true;
                label63.Visible = true;
                label64.Visible = true;
                label65.Visible = true;
                label66.Visible = true;
                label67.Visible = true;
                label68.Visible = true;
                label69.Visible = true;
                label70.Visible = true;
                label71.Visible = true;
                label72.Visible = true;
                label73.Visible = true;
                label74.Visible = true;
                label75.Visible = true;
                label76.Visible = true;
                label77.Visible = true;
                label81.Visible = true;
            }
        }

        public void OcultaMostraProximoItemA(object sender, EventArgs e)
        {
            if(label48.Visible == true)
            {
                label37.Visible = false;
                label38.Visible = false;
                label39.Visible = false;
                label40.Visible = false;
                label41.Visible = false;
                label42.Visible = false;
                label43.Visible = false;
                label44.Visible = false;
                label45.Visible = false;
                label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                label78.Visible = false;
                label79.Visible = false;
            }
            else if(label37.Visible == false)
            {
                label37.Visible = true;
                label41.Visible = true;
            }
            else if(label38.Visible == false)
            {
                label38.Visible = true;
            }
            else if(label40.Visible == false)
            {
                label40.Visible = true;
                label42.Visible = true;
            }
            else if(label39.Visible == false)
            {
                label39.Visible = true;
            }
            else if(label45.Visible == false)
            {
                label45.Visible = true;
                label43.Visible = true;
            }
            else if(label44.Visible == false)
            {
                label44.Visible = true;
            }
            else if(label46.Visible == false)
            {
                label46.Visible = true;
                label47.Visible = true;
            }
            else
            {
                label48.Visible = true;
                label78.Visible = true;
                label79.Visible = true;
            }
        }

        public void OcultaMostraProximoItemB(object sender, EventArgs e)
        {
            if (label61.Visible == true)
            {
                label49.Visible = false;
                label50.Visible = false;
                label51.Visible = false;
                label52.Visible = false;
                label53.Visible = false;
                label54.Visible = false;
                label55.Visible = false;
                label56.Visible = false;
                label57.Visible = false;
                label58.Visible = false;
                label59.Visible = false;
                label60.Visible = false;
                label61.Visible = false;
                label80.Visible = false;
            }
            else if (label49.Visible == false)
            {
                label49.Visible = true;
            }
            else if (label50.Visible == false)
            {
                label50.Visible = true;
            }
            else if (label52.Visible == false)
            {
                label52.Visible = true;
            }
            else if (label51.Visible == false)
            {
                label51.Visible = true;
            }
            else if (label56.Visible == false)
            {
                label56.Visible = true;
            }
            else if (label55.Visible == false)
            {
                label55.Visible = true;
            }
            else if (label54.Visible == false)
            {
                label54.Visible = true;
            }
            else if (label53.Visible == false)
            {
                label53.Visible = true;
            }
            else if (label58.Visible == false)
            {
                label58.Visible = true;
            }
            else if (label57.Visible == false)
            {
                label57.Visible = true;
            }
            else if (label59.Visible == false)
            {
                label59.Visible = true;
                label60.Visible = true;
            }
            else
            {
                label61.Visible = true;
                label80.Visible = true;
            }
        }

        public void OcultaMostraProximoItemC(object sender, EventArgs e)
        {
            if (label77.Visible == true)
            {
                label62.Visible = false;
                label63.Visible = false;
                label64.Visible = false;
                label65.Visible = false;
                label66.Visible = false;
                label67.Visible = false;
                label68.Visible = false;
                label69.Visible = false;
                label70.Visible = false;
                label71.Visible = false;
                label72.Visible = false;
                label73.Visible = false;
                label74.Visible = false;
                label75.Visible = false;
                label76.Visible = false;
                label77.Visible = false;
                label81.Visible = false;
            }
            else if (label62.Visible == false)
            {
                label62.Visible = true;
            }
            else if (label63.Visible == false)
            {
                label63.Visible = true;
                label64.Visible = true;
                label65.Visible = true;
                label66.Visible = true;
            }
            else if (label67.Visible == false)
            {
                label67.Visible = true;
            }
            else if (label68.Visible == false)
            {
                label68.Visible = true;
                label69.Visible = true;
                label70.Visible = true;
                label71.Visible = true;
            }
            else if (label72.Visible == false)
            {
                label72.Visible = true;
            }
            else if (label73.Visible == false)
            {
                label73.Visible = true;
                label74.Visible = true;
            }
            else if (label75.Visible == false)
            {
                label75.Visible = true;
            }
            else
            {
                label76.Visible = true;
                label77.Visible = true;
                label81.Visible = true;
            }
        }
    }
}
