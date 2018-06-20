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
            label24.Text = Convert.ToString(numericUpDown6.Value + numericUpDown5.Value);

            FluidoOPI agua = new FluidoOPI(Convert.ToDouble(numericUpDown9.Value), Convert.ToDouble(numericUpDown10.Value));

            Tubulacao tuboCompleto = new Tubulacao(Convert.ToDouble(numericUpDown4.Value) / 100,
                Convert.ToDouble(label24.Text), Convert.ToDouble(numericUpDown3.Value) / 1000,
                Convert.ToDouble(numericUpDown2.Value), "haaland");

            Tubulacao tuboSuccao = new Tubulacao(Convert.ToDouble(numericUpDown4.Value) / 100,
                Convert.ToDouble(numericUpDown6.Value), Convert.ToDouble(numericUpDown3.Value) / 1000,
                Convert.ToDouble(numericUpDown8.Value), "haaland");

            Tubulacao tuboRecalque = new Tubulacao(Convert.ToDouble(numericUpDown4.Value) / 100, 
                Convert.ToDouble(numericUpDown5.Value), Convert.ToDouble(numericUpDown3.Value) / 1000, 
                Convert.ToDouble(label24.Text) - Convert.ToDouble(numericUpDown8.Value), "haaland");

            label38.Text = Convert.ToString(Math.Round(tuboCompleto.CalculaReynolds(agua, Convert.ToDouble(numericUpDown1.Value))));
            label39.Text = Convert.ToString(Math.Round(100000 * tuboCompleto.CalculaFAtrito(agua, Convert.ToDouble(numericUpDown1.Value))) / 100000);
            label44.Text = Convert.ToString(Math.Round(10000 * tuboCompleto.CalculaPerdaCarga(agua, Convert.ToDouble(numericUpDown1.Value))) / 10000);
            label48.Text = Convert.ToString(Math.Round(10000 * tuboCompleto.CalculaPerdaCarga(agua, Convert.ToDouble(numericUpDown1.Value))) / 10000 + tuboCompleto.Elevacao);

        }

        public void OcultaMostraItemA(object sender, EventArgs e)
        {
            if(groupBox2.Visible == true)
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
                groupBox2.Visible = false;
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
                groupBox2.Visible = true;
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
                groupBox2.Visible = false;
            }
            else if(label37.Visible == false)
            {
                groupBox2.Visible = true;
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
            }
        }

    }
}
