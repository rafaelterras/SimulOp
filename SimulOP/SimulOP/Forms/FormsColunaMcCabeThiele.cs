using System;
using System.Collections.Generic;
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

        // Listas para plots
        private List<double> eqX = new List<double>();
        private List<double> eqY = new List<double>();
        private List<double> pratosX = new List<double>();
        private List<double> pratosY = new List<double>();
        private List<double> linhaOPX = new List<double>();
        private List<double> linhaOPY = new List<double>();
        private List<double> linhaQX = new List<double>();
        private List<double> linhaQY = new List<double>();

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
        private double nudRazaoQDinDbl;
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

        private void EventosInputs(bool ativar)
        {
            if (ativar)
            {
                // Re-inscreve aos eventos
                nudFracaoEntradaLKDin.ValueChanged += nudFracaoEntradaLKDin_ValueChanged;
                trbFracaoEntradaLKDin.Scroll += trbFracaoEntradaLKDin_Scroll;
                nudRefluxoDin.ValueChanged += nudRefluxoDin_ValueChanged;
                trbRefluxoDin.Scroll += trbRefluxoDin_Scroll;
                nudXd.ValueChanged += nudXd_ValueChanged;
                trbXd.Scroll += trbXd_Scroll;
                nudXb.ValueChanged += nudXb_ValueChanged;
                trbXb.Scroll += trbXb_Scroll;
                nudTemperaturaDin.ValueChanged += nudTemperaturaDin_ValueChanged;
                trbTemperaturaDin.Scroll += trbTemperaturaDin_Scroll;
                nudCondicaoEntradaDin.ValueChanged += nudCondicaoEntradaDin_ValueChanged;
                cmbCondicaoEntradaDin.SelectedIndexChanged += cmbCondicaoEntradaDin_SelectedIndexChanged;
                trbCondicaoEntradaDin.Scroll += trbCondicaoEntradaDin_Scroll;
            }
            else
            {
                // Desincreve dos eventos para evitar chamar as funcoes mais de uma vez
                nudFracaoEntradaLKDin.ValueChanged -= nudFracaoEntradaLKDin_ValueChanged;
                trbFracaoEntradaLKDin.Scroll -= trbFracaoEntradaLKDin_Scroll;
                nudRefluxoDin.ValueChanged -= nudRefluxoDin_ValueChanged;
                trbRefluxoDin.Scroll -= trbRefluxoDin_Scroll;
                nudXd.ValueChanged -= nudXd_ValueChanged;
                trbXd.Scroll -= trbXd_Scroll;
                nudXb.ValueChanged -= nudXb_ValueChanged;
                trbXb.Scroll -= trbXb_Scroll;
                nudTemperaturaDin.ValueChanged -= nudTemperaturaDin_ValueChanged;
                trbTemperaturaDin.Scroll -= trbTemperaturaDin_Scroll;
                nudCondicaoEntradaDin.ValueChanged -= nudCondicaoEntradaDin_ValueChanged;
                cmbCondicaoEntradaDin.SelectedIndexChanged -= cmbCondicaoEntradaDin_SelectedIndexChanged;
                trbCondicaoEntradaDin.Scroll -= trbCondicaoEntradaDin_Scroll;
            }
        }

        private void AtualizaEquilibrio()
        {
            eqX.Clear();
            eqY.Clear();
            chart.Series[0].Points.Clear();
            
            (eqX, eqY) = ColunaMcCabeThiele.PlotEquilibrio(100);

            chart.Series[0].Points.DataBindXY(eqX, eqY);
        }

        private void AtualizaPratos()
        {
            pratosX.Clear();
            pratosY.Clear();
            chart.Series[1].Points.Clear();

            (pratosX, pratosY) = ColunaMcCabeThiele.PlotPratos();

            chart.Series[1].Points.DataBindXY(pratosX, pratosY);
        }

        private void AtualizaLinhasOP()
        {
            linhaOPX.Clear();
            linhaOPY.Clear();
            chart.Series[2].Points.Clear();

            (linhaOPX, linhaOPY) = ColunaMcCabeThiele.PlotCurvaOP(100);
            
            chart.Series[2].Points.DataBindXY(linhaOPX, linhaOPY);
        }

        private void AtualizaLinhaQ()
        {
            linhaQX.Clear();
            linhaQY.Clear();
            //chart.Series[1].Points.Clear();
            
            //(linhaQX, linhaQY) = ColunaMcCabeThiele.PlotCurvaQ(20);


        }      
 
        private void btnInputInicial_Click(object sender, EventArgs e)
        {
            cmbFluidoLKTxt = cmbFluidoLK.Text;
            cmbFluidoHKTxt = cmbFluidoHK.Text;
            cmbCondicaoEntradaTxt = "Vapor saturado";
            nudRazaoQDbl = 0.0;
            nudFracaoEntradaLKDbl = 0.5;
            nudRefluxoDbl = 2.0;
            nudXdDbl = 0.9;
            nudXbDbl = 0.1;
            nudTemperaturaDbl = 50 + 273.15; // Temperatura tem que ser usada em Kelvin
            nudPressaoDbl = 1E5;

            if (cmbFluidoLKTxt != "" && cmbFluidoHKTxt != "")
            {
                fluidoLK = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII(cmbFluidoLKTxt), nudTemperaturaDbl);
                fluidoHK = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII(cmbFluidoHKTxt), nudTemperaturaDbl);
                mistura = new MisturaBinaria(fluidoLK, fluidoHK, nudFracaoEntradaLKDbl, nudTemperaturaDbl, nudPressaoDbl);
                ColunaMcCabeThiele = new ColunaMcCabeThiele(mistura, nudXdDbl, nudXbDbl, nudFracaoEntradaLKDbl, nudRefluxoDbl, nudRazaoQDbl);

                AtualizaEquilibrio();
                AtualizaLinhasOP();
                AtualizaLinhaQ();
                AtualizaPratos();

                EventosInputs(false);

                cmbCondicaoEntradaDin.Text = cmbCondicaoEntradaTxt.ToLower();
                nudFracaoEntradaLKDin.Value = Convert.ToDecimal(nudFracaoEntradaLKDbl);
                nudRefluxoDin.Value = Convert.ToDecimal(nudRefluxoDbl);
                nudXd.Value = Convert.ToDecimal(nudXdDbl);
                nudXb.Value = Convert.ToDecimal(nudXbDbl);
                nudTemperaturaDin.Value = Convert.ToDecimal(nudTemperaturaDbl - 273.15);

                EventosInputs(true);

                gubVariaveis.Visible = true;
            }
        }

        #region === Input Inicial ===

        /// <summary>
        /// Altera o numero da variavel q da entrada conforme a combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCondicaoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCondicaoEntradaTxt = cmbCondicaoEntrada.Text;

            switch (cmbCondicaoEntradaTxt.ToLower())
            {
                case "líquido sub-resfriado":
                    nudRazaoQDbl = 1.25;
                    break;
                case "líquido saturado":
                    nudRazaoQDbl = 1.0;
                    break;
                case "parcialmente vaporizado":
                    nudRazaoQDbl = 0.5;
                    break;
                case "vapor saturado":
                    nudRazaoQDbl = 0;
                    break;
                case "vapor super aquecido":
                    nudRazaoQDbl = -0.25;
                    break;
                default:
                    throw new Exception($"Condição do líquido de entrada não estabelecida, o valor [{cmbCondicaoEntradaTxt}] não era esperado!");
            }
            nudRazaoQ.Value = Convert.ToDecimal(nudRazaoQDbl);
        }

        /// <summary>
        /// Altera a texto da combobox conforme o numero da varial q de entrada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudRazaoQ_ValueChanged(object sender, EventArgs e)
        {
            nudRazaoQDbl = Convert.ToDouble(nudRazaoQ.Value);

            if (nudRazaoQDbl > 1.0)
            {
                cmbCondicaoEntradaTxt = "Líquido sub-resfriado";
            }
            else if (nudRazaoQDbl == 1.0)
            {
                cmbCondicaoEntradaTxt = "Líquido saturado";
            }
            else if (nudRazaoQDbl > 0.0 && nudRazaoQDbl < 1.0)
            {
                cmbCondicaoEntradaTxt = "Parcialmente vaporizado";
            }
            else if (nudRazaoQDbl == 0.0)
            {
                cmbCondicaoEntradaTxt = "Vapor saturado";
            }
            else if (nudRazaoQDbl < 0.0)
            {
                cmbCondicaoEntradaTxt = "Vapor super aquecido";
            }

            cmbCondicaoEntrada.Text = cmbCondicaoEntradaTxt;
        }



        #endregion

        #region === Variaveis Dinamicas ===

        private void AtualizaParDin(NumericUpDown nud, TrackBar trb, double x)
        {
            // Desincreve dos eventos para evitar chamar as funcoes mais de uma vez
            EventosInputs(false);

            // Numeric Up and Down
            nud.Value = Convert.ToDecimal(x);

            // Track Bar
            int trbInt = Convert.ToInt32((Convert.ToDouble(trb.Maximum - trb.Minimum)) * (Convert.ToDouble(nud.Value) - Convert.ToDouble(nud.Minimum)) 
                / (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum)));
            trb.Value = trbInt;

            switch (nud.Name)
            {
                case "nudFracaoEntradaLKDin": // Mudança na fração molar da entrada
                    nudFracaoEntradaLKDinDbl = x;
                    trbFracaoEntradaLKDinInt = trbInt;
                    ColunaMcCabeThiele.FeedZF = nudFracaoEntradaLKDinDbl;
                    AtualizaLinhaQ();
                    AtualizaLinhasOP();
                    AtualizaPratos();
                    break;
                case "nudRefluxoDin": // Mudança no refluxo
                    nudRefluxoDinDbl = x;
                    trbRefluxoDinInt = trbInt;
                    ColunaMcCabeThiele.RefluxRatio = nudRefluxoDinDbl;
                    AtualizaLinhaQ();
                    AtualizaLinhasOP();
                    AtualizaPratos();
                    break;
                case "nudXd": // Mudança no target Xd
                    nudXdDbl = x;
                    trbXdInt = trbInt;
                    ColunaMcCabeThiele.TargetXD = nudXdDbl;
                    AtualizaLinhasOP();
                    AtualizaPratos();
                    break;
                case "nudXb": // Mudança do target Xb
                    nudXbDbl = x;
                    trbXbInt = trbInt;
                    ColunaMcCabeThiele.TargetXB = nudXbDbl;
                    AtualizaLinhasOP();
                    AtualizaPratos();
                    break;
                case "nudTemperaturaDin": // Mudança na temperatura
                    nudTemperaturaDinDbl = x + 273.15; // Temperatura em K
                    trbTemperaturaDinInt = trbInt;
                    ColunaMcCabeThiele.MisturaBinaria.Temperatura = nudTemperaturaDinDbl;
                    AtualizaEquilibrio();
                    AtualizaLinhasOP();
                    AtualizaLinhaQ();
                    AtualizaPratos();
                    break;
                default:
                    throw new Exception($"{nud.Name} nao era esperado!");
            }

            // Re-inscreve-se aos eventos
            EventosInputs(true);
        }               

        #region Fracao LK Din
        private void nudFracaoEntradaLKDin_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudFracaoEntradaLKDin, trbFracaoEntradaLKDin, Convert.ToDouble(nudFracaoEntradaLKDin.Value));
        }

        private void trbFracaoEntradaLKDin_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudFracaoEntradaLKDin.Minimum) +
                (Convert.ToDouble(nudFracaoEntradaLKDin.Maximum) - Convert.ToDouble(nudFracaoEntradaLKDin.Minimum))
                * Convert.ToDouble(trbFracaoEntradaLKDin.Value) / Convert.ToDouble(trbFracaoEntradaLKDin.Maximum);

            AtualizaParDin(nudFracaoEntradaLKDin, trbFracaoEntradaLKDin, x);
        }
        #endregion

        #region Condicao Entrada Q Din
        private void nudCondicaoEntradaDin_ValueChanged(object sender, EventArgs e)
        {
            AtualizaCondicaoEntradaDinIputs(Convert.ToDouble(nudCondicaoEntradaDin.Value));
        }

        private void cmbCondicaoEntradaDin_SelectedIndexChanged(object sender, EventArgs e)
        {
            double q;

            switch (cmbCondicaoEntradaDin.Text.ToLower())
            {
                case "líquido sub-resfriado":
                    q = 1.25;
                    break;
                case "líquido saturado":
                    q = 1.0;
                    break;
                case "parcialmente vaporizado":
                    q = 0.5;
                    break;
                case "vapor saturado":
                    q = 0;
                    break;
                case "vapor super aquecido":
                    q = -0.25;
                    break;
                default:
                    throw new Exception($"Condição do líquido de entrada não estabelecida, o valor [{cmbCondicaoEntradaDinTxt}] não era esperado!");
            }
            AtualizaCondicaoEntradaDinIputs(q);
        }

        private void trbCondicaoEntradaDin_Scroll(object sender, EventArgs e)
        {
            double q;

            q = Convert.ToDouble(nudCondicaoEntradaDin.Minimum) + (Convert.ToDouble(nudCondicaoEntradaDin.Maximum) - Convert.ToDouble(nudCondicaoEntradaDin.Minimum))
                * Convert.ToDouble(trbCondicaoEntradaDin.Value) / Convert.ToDouble(trbCondicaoEntradaDin.Maximum);

            AtualizaCondicaoEntradaDinIputs(q);
        }

        private void AtualizaCondicaoEntradaDinIputs(double q)
        {
            // Desincreve dos eventos para evitar chamar as funcoes mais de uma vez
            EventosInputs(false);

            // Numeric Up and Down
            nudRazaoQDinDbl = q;
            nudCondicaoEntradaDin.Value = Convert.ToDecimal(q);

            // ComboBox
            if (q > 1.0)
            {
                cmbCondicaoEntradaDinTxt = "Líquido sub-resfriado";
            }
            else if (q == 1.0)
            {
                cmbCondicaoEntradaDinTxt = "Líquido saturado";
            }
            else if (q > 0.0 && q < 1.0)
            {
                cmbCondicaoEntradaDinTxt = "Parcialmente vaporizado";
            }
            else if (q == 0.0)
            {
                cmbCondicaoEntradaDinTxt = "Vapor saturado";
            }
            else if (q < 0.0)
            {
                cmbCondicaoEntradaDinTxt = "Vapor super aquecido";
            }
            cmbCondicaoEntradaDin.Text = cmbCondicaoEntradaDinTxt;

            // Track Bar
            trbCondicaoEntradaDinInt = Convert.ToInt32(50.0 * (q - Convert.ToDouble(nudCondicaoEntradaDin.Minimum))
                / (Convert.ToDouble(nudCondicaoEntradaDin.Maximum) - Convert.ToDouble(nudCondicaoEntradaDin.Minimum)));
            trbCondicaoEntradaDin.Value = trbCondicaoEntradaDinInt;

            // Atualia o valor da coluna e o grafico
            ColunaMcCabeThiele.FeedConditionQ = q;
            AtualizaLinhasOP();
            AtualizaLinhaQ();
            AtualizaPratos();

            // Re-inscreve aos eventos
            EventosInputs(true);
        }
        #endregion

        #region Refluxo Din
        private void nudRefluxoDin_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudRefluxoDin, trbRefluxoDin, Convert.ToDouble(nudRefluxoDin.Value));
        }

        private void trbRefluxoDin_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudRefluxoDin.Minimum) +
                (Convert.ToDouble(nudRefluxoDin.Maximum) - Convert.ToDouble(nudRefluxoDin.Minimum))
                * Convert.ToDouble(trbRefluxoDin.Value) / Convert.ToDouble(trbRefluxoDin.Maximum);

            AtualizaParDin(nudRefluxoDin, trbRefluxoDin, x);
        }
        #endregion

        #region Xd
        private void nudXd_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudXd, trbXd, Convert.ToDouble(nudXd.Value));
        }

        private void trbXd_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudXd.Minimum) + 
                (Convert.ToDouble(nudXd.Maximum) - Convert.ToDouble(nudXd.Minimum))
                * Convert.ToDouble(trbXd.Value) / Convert.ToDouble(trbXd.Maximum);

            AtualizaParDin(nudXd, trbXd, x);
        }
        #endregion

        #region Xb
        private void nudXb_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudXb, trbXb, Convert.ToDouble(nudXb.Value));

        }

        private void trbXb_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudXb.Minimum) +
                (Convert.ToDouble(nudXb.Maximum) - Convert.ToDouble(nudXb.Minimum))
                * Convert.ToDouble(trbXb.Value) / Convert.ToDouble(trbXb.Maximum);

            AtualizaParDin(nudXb, trbXb, x);
        }
        #endregion

        #region Temperatura
        private void nudTemperaturaDin_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudTemperaturaDin, trbTemperaturaDin, Convert.ToDouble(nudTemperaturaDin.Value));

        }

        private void trbTemperaturaDin_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudTemperaturaDin.Minimum) +
                (Convert.ToDouble(nudTemperaturaDin.Maximum) - Convert.ToDouble(nudTemperaturaDin.Minimum))
                * Convert.ToDouble(trbTemperaturaDin.Value) / Convert.ToDouble(trbTemperaturaDin.Maximum);

            AtualizaParDin(nudTemperaturaDin, trbTemperaturaDin, x);
        }
        #endregion

        #endregion
    }
}
