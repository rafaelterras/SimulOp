using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaMinuta.Forms
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
                densidade = Convert.ToDouble(numericUpDown1.Value) * 1000,
                viscosidade = Convert.ToDouble(numericUpDown8.Value) / 1000,
            };

            Tubulacao tubo1 = new Tubulacao
            {
                comprimento = Convert.ToDouble(numericUpDown3.Value),
                diametro = Convert.ToDouble(numericUpDown4.Value) / 100,
                elevacao = Convert.ToDouble(numericUpDown5.Value),
                rugosidade = Convert.ToDouble(numericUpDown9.Value) / 1000000,
            };

            tubo1.rugosidadeRelativa = tubo1.rugosidade / tubo1.diametro;

            label25.Visible = true;
            label26.Text = tubo1.CalculaPerdaCarga(agua, Convert.ToDouble(numericUpDown2.Value) / 3600).ToString();
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
