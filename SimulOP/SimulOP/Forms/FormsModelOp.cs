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
    public partial class FormsModelOp : Form
    {
        public FormsModelOp()
        {
            InitializeComponent();
        }

        public void CalculaTudo(object sender, EventArgs e)
        {
            Fluido agua = new Fluido
            {
                Densidade = Convert.ToDouble(numericUpDown1.Value) * 1000,
                Viscosidade = Convert.ToDouble(numericUpDown8.Value) / 1000,
            };

            Tubulacao tubo1 = new Tubulacao
            {
                Comprimento = Convert.ToDouble(numericUpDown3.Value),
                Diametro = Convert.ToDouble(numericUpDown4.Value) / 100,
                Elevacao = Convert.ToDouble(numericUpDown5.Value),
                Rugosidade = Convert.ToDouble(numericUpDown9.Value) / 1000000,
            };

            tubo1.RugosidadeRelativa = tubo1.Rugosidade / tubo1.Diametro;

            label25.Visible = true;
            label26.Visible = true;
            label26.Text = (Math.Round(tubo1.CalculaPerdaCarga(agua, Convert.ToDouble(numericUpDown2.Value) / 3600) + tubo1.Elevacao, 6)).ToString() + " m";
            if (this.numericUpDown6.Value == -1)
            {
                if (this.numericUpDown7.Value != -1)
                {
                    label27.Visible = true;
                    label27.Text = "Pressão na saída";
                    label28.Visible = true;
                    label28.Text = (Math.Round((Convert.ToDouble(numericUpDown7.Value)) - ((agua.Densidade * 9.80665 * tubo1.CalculaPerdaCarga(agua, Convert.ToDouble(numericUpDown2.Value) / 3600) + tubo1.Elevacao) / 101325), 6)).ToString() + " atm";
                }
            }
            else
            {
                if (this.numericUpDown7.Value != -1)
                {
                    label27.Visible = true;
                    label27.Text = "Compatibilidade";
                    label28.Visible = true;
                    label28.Text = (Math.Round((Convert.ToDouble(numericUpDown7.Value) - (Convert.ToDouble(numericUpDown6.Value))) - ((agua.Densidade * 9.80665 * tubo1.CalculaPerdaCarga(agua, Convert.ToDouble(numericUpDown2.Value) / 3600) + tubo1.Elevacao) / 101325), 6)).ToString() + " atm";
                }
                else
                {
                    label27.Visible = true;
                    label27.Text = "Pressão na entrada";
                    label28.Visible = true;
                    label28.Text = (Math.Round((Convert.ToDouble(numericUpDown6.Value)) + ((agua.Densidade * 9.80665 * tubo1.CalculaPerdaCarga(agua, Convert.ToDouble(numericUpDown2.Value) / 3600) + tubo1.Elevacao) / 101325), 6)).ToString() + " atm";
                }
            }
        }
        
    };

}

// Bomba[] arrayBombas = new Bomba[] { bomba1, bomba2 };

// bombaEq.BombaEquivalente(new Bomba[] { bomba1, bomba2 },"Série");

/*
Console.WriteLine("==========Dados da Simulação========");
Console.WriteLine("===>Fluido");
Console.WriteLine("Densidade : {0} Kg/m^3", agua.densidade);
Console.WriteLine("Viscosidade : {0} Pa*s", agua.viscosidade);
Console.WriteLine("===>Tubulação");
Console.WriteLine("Diametro : {0} m", tubo1.diametro);
Console.WriteLine("Comprimento : {0} m",tubo1.comprimento);
Console.WriteLine("Comprimento Eq das singularidades: {0} m", tubo1.comprimentoEquivalente);
Console.WriteLine("Comprimento total: {0} m", tubo1.comprimentoEquivalente + tubo1.comprimento);
Console.WriteLine("===>Bomba");
Console.WriteLine("Eq. da bomba: {0}*Q^3 + {1}*Q^2 + {2}*Q^1 + {3}",bomba1.equacaoCurva[0], bomba1.equacaoCurva[1], bomba1.equacaoCurva[2], bomba1.equacaoCurva[3]);
Console.WriteLine("Eq. da bombaEQ: {0}*Q^3 + {1}*Q^2 + {2}*Q^1 + {3}", bombaEq.equacaoCurva[0], bombaEq.equacaoCurva[1], bombaEq.equacaoCurva[2], bombaEq.equacaoCurva[3]);

bomba1.CalculaVazao(agua, tubo1);

Console.WriteLine("==========Resultados da Simulação========");
Console.WriteLine("Vazão : {0} m^3/h", bomba1.vazao * 3600);
Console.WriteLine("Perda de carga  : {0} m", tubo1.perdaCarga);
Console.WriteLine("Altura da bomba : {0} m", bomba1.alturaManometrica);

Console.ReadLine();
*/
