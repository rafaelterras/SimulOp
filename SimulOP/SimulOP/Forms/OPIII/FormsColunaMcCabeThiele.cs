using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SimulOP.Properties;

namespace SimulOP.Forms
{
    /// <summary>
    /// Forms para o método de McCabe-Thiele.
    /// </summary>
    public partial class FormsColunaMcCabeThiele : Form
    {
        // Objetos para cálculo da coluna
        private FluidoIdealOPIII fluidoLK;
        private FluidoIdealOPIII fluidoHK;
        private MisturaBinaria mistura;
        private ColunaMcCabeThiele ColunaMcCabeThiele;
        private bool erroConvergencia = false;
        
        private Form formAberto;
                
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
        private double nudPressaoDinDbl;
        private int trbPressaoDinInt;

        public FormsColunaMcCabeThiele()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inscreve ou desiscreve os eventos do forms.
        /// </summary>
        /// <param name="ativar">Se True ativa os eventos, se False desativa.</param>
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
                nudPressaoDin.ValueChanged += nudPressaoDin_ValueChanged;
                trbPressaoDin.Scroll += trbPressaoDin_Scroll;
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
                nudPressaoDin.ValueChanged -= nudPressaoDin_ValueChanged;
                trbPressaoDin.Scroll -= trbPressaoDin_Scroll;
                nudCondicaoEntradaDin.ValueChanged -= nudCondicaoEntradaDin_ValueChanged;
                cmbCondicaoEntradaDin.SelectedIndexChanged -= cmbCondicaoEntradaDin_SelectedIndexChanged;
                trbCondicaoEntradaDin.Scroll -= trbCondicaoEntradaDin_Scroll;
            }
        }

        /// <summary>
        /// Atualiza o gráfico do equilibrio líquido vapor.
        /// </summary>
        private void AtualizaEquilibrio()
        {
            eqX.Clear();
            eqY.Clear();
            chart.Series["Equilibrio"].Points.Clear();

            (eqX, eqY) = ColunaMcCabeThiele.PlotEquilibrio(100);

            chart.Series["Equilibrio"].Points.DataBindXY(eqX, eqY);

            txbAlpha.Text = Math.Round(ColunaMcCabeThiele.MisturaBinaria.Alpha, 2).ToString();
        }

        /// <summary>
        /// Atualiza o gráfico dos pratos e atualiza o resultado.
        /// </summary>
        private void AtualizaPratos()
        {
            pratosX.Clear();
            pratosY.Clear();
            chart.Series["Pratos"].Points.Clear();

            try
            {
                (pratosX, pratosY) = ColunaMcCabeThiele.PlotPratos();
            }
            catch (Exception)
            {
                erroConvergencia = true;
                VerificaConvergencia();
            }

            chart.Series["Pratos"].Points.DataBindXY(pratosX, pratosY);
        }

        /// <summary>
        /// Atualiza o gráfico das linhas de operações.
        /// </summary>
        private void AtualizaLinhasOP()
        {
            linhaOPX.Clear();
            linhaOPY.Clear();
            chart.Series["LinhaOP"].Points.Clear();

            (linhaOPX, linhaOPY) = ColunaMcCabeThiele.PlotCurvaOP(100);

            chart.Series["LinhaOP"].Points.DataBindXY(linhaOPX, linhaOPY);
        }

        /// <summary>
        /// Atualiza o gráfico da linha q.
        /// </summary>
        private void AtualizaLinhaQ()
        {
            linhaQX.Clear();
            linhaQY.Clear();
            chart.Series["PontoQ"].Points.Clear();

            (linhaQX, linhaQY) = ColunaMcCabeThiele.PlotCurvaQ();

            chart.Series["PontoQ"].Points.DataBindXY(linhaQX, linhaQY);
        }

        /// <summary>
        /// Verifica a convergencia da coluna e atualiza a variavél erroConvergencia.
        /// </summary>
        private void VerificaConvergencia()
        {
            string localPratoIdeal = "-";

            if (erroConvergencia)
            {
                txbConvergencia.Text = "Erro de convergência!";
                txbConvergencia.ForeColor = System.Drawing.Color.Maroon;

                txbNPratos.Text = "-";
                txbPratoIdeal.Text = "-";

                erroConvergencia = false;
            }
            else
            {
                // Equilibrio
                double pVapPontoP;

                try
                {
                    pVapPontoP = ColunaMcCabeThiele.MisturaBinaria.CalculaVap(ColunaMcCabeThiele.PontoP[0]);
                }
                catch (Exception)
                {
                    erroConvergencia = true;
                    VerificaConvergencia();
                    return;
                }

                if (ColunaMcCabeThiele.PontoP[1] > pVapPontoP)
                {
                    erroConvergencia = true;
                }
                else
                {
                    erroConvergencia = false;
                }

                // Pratos
                if (erroConvergencia || pratosX.Count == 100)
                {
                    erroConvergencia = true;
                }
                else
                {
                    if (pratosX.Count == 0)
                    {
                        erroConvergencia = true;
                        return;
                    }

                    double dis = Math.Abs(ColunaMcCabeThiele.PontoP[0] - pratosX[1]);
                    localPratoIdeal = "1";

                    for (int i = 3; i < pratosX.Count - 2; i = i + 2)
                    {
                        if (Math.Abs(ColunaMcCabeThiele.PontoP[0] - pratosX[i]) < dis)
                        {
                            dis = Math.Abs(ColunaMcCabeThiele.PontoP[0] - pratosX[i]);
                            localPratoIdeal = $"{(i + 1) / 2}";
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (erroConvergencia)
                {
                    txbConvergencia.Text = "Erro de convergência!";
                    txbConvergencia.ForeColor = System.Drawing.Color.Maroon;

                    txbNPratos.Text = "-";
                    txbPratoIdeal.Text = "-";
                }
                else
                {
                    txbConvergencia.Text = "OK";
                    txbConvergencia.ForeColor = System.Drawing.Color.Green;

                    txbNPratos.Text = ((pratosX.Count - 1) / 2).ToString();
                    txbPratoIdeal.Text = localPratoIdeal;
                }
            }
        }
 
        /// <summary>
        /// Botão para calculo inicial da coluna.
        /// </summary>
        private void btnInputInicial_Click(object sender, EventArgs e)
        {
            cmbFluidoLKTxt = cmbFluidoLK.Text;
            cmbFluidoHKTxt = cmbFluidoHK.Text;
            cmbCondicaoEntradaTxt = "Líquido saturado";
            nudRazaoQDbl = 0.0;
            nudFracaoEntradaLKDbl = 0.5;
            nudRefluxoDbl = 2.0;
            nudXdDbl = 0.9;
            nudXbDbl = 0.1;
            nudTemperaturaDbl = 50 + 273.15; // Temperatura tem que ser usada em Kelvin
            nudPressaoDbl = 1E5;

            if ((cmbFluidoLKTxt != "" && cmbFluidoHKTxt != "") && cmbFluidoLKTxt != cmbFluidoHKTxt)
            {
                //EventosInputs(false);
                
                fluidoLK = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII(cmbFluidoLKTxt), nudTemperaturaDbl);
                fluidoHK = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII(cmbFluidoHKTxt), nudTemperaturaDbl);
                mistura = new MisturaBinaria(fluidoLK, fluidoHK, nudFracaoEntradaLKDbl, nudTemperaturaDbl, nudPressaoDbl);

                if (mistura.Alpha > 1) // Condição para que a coluna fique em função do LK
                {
                    ColunaMcCabeThiele = new ColunaMcCabeThiele(mistura, nudXdDbl, nudXbDbl, nudFracaoEntradaLKDbl, nudRefluxoDbl, nudRazaoQDbl);

                    AtualizaEquilibrio();
                    AtualizaLinhasOP();
                    AtualizaLinhaQ();
                    AtualizaPratos();

                    chart.Series["Equilibrio"].LegendText = $"ELV {cmbFluidoLKTxt}, {cmbFluidoHKTxt}";
                    chart.Series["LinhaOP"].LegendText = "Linha de Operação";
                    chart.Series["PontoQ"].LegendText = "Linha Q";
                    chart.Series["Linha45"].Points.DataBindXY(new double[] { 0, 1 }, new double[] { 0, 1 });
                    txbConvergencia.Text = "OK";
                    txbConvergencia.ForeColor = System.Drawing.Color.Green;

                    cmbCondicaoEntradaDin.Text = cmbCondicaoEntradaTxt.ToLower();
                    nudFracaoEntradaLKDin.Value = Convert.ToDecimal(nudFracaoEntradaLKDbl);
                    nudRefluxoDin.Value = Convert.ToDecimal(nudRefluxoDbl);
                    nudXd.Value = Convert.ToDecimal(nudXdDbl);
                    nudXb.Value = Convert.ToDecimal(nudXbDbl);
                    nudPressaoDin.Value = Convert.ToDecimal(nudPressaoDbl / 1e5);

                    VerificaConvergencia();

                    txbConvergencia.Visible = true;
                    labMudanca.Visible = true;
                    gubVariaveis.Visible = true;
                    gubResultados.Visible = true;
                    gubGrafico.Visible = true;
                    labResultados.Visible = true;
                }
                else
                {
                    txbConvergencia.Visible = true;
                    txbConvergencia.Text = "Fluido HK é mais volátil";
                    txbConvergencia.ForeColor = System.Drawing.Color.Maroon;
                    labMudanca.Visible = false;
                    gubGrafico.Visible = false;
                    gubVariaveis.Visible = false;
                    gubResultados.Visible = false;
                    labResultados.Visible = false;
                }
            }
            else
            {
                txbConvergencia.Visible = true;
                txbConvergencia.Text = "Fluidos idêndicos!";
                txbConvergencia.ForeColor = System.Drawing.Color.Maroon;
                labMudanca.Visible = false;
                gubGrafico.Visible = false;
                gubVariaveis.Visible = false;
                gubResultados.Visible = false;
                labResultados.Visible = false;
            }
        }

        #region === Variaveis Dinamicas ===
        /// <summary>
        /// Atualiza o par de NumecricUpDown e TrackBar para o mesmo valor.
        /// </summary>
        /// <param name="nud">O NumericUpDown.</param>
        /// <param name="trb">A TrackBar.</param>
        /// <param name="x">O valor para ser atualizado.</param>
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
                    AtualizaLinhasOP();
                    AtualizaPratos();
                    AtualizaLinhaQ();
                    break;
                case "nudRefluxoDin": // Mudança no refluxo
                    nudRefluxoDinDbl = x;
                    trbRefluxoDinInt = trbInt;
                    ColunaMcCabeThiele.RefluxRatio = nudRefluxoDinDbl;
                    AtualizaLinhasOP();
                    AtualizaPratos();
                    AtualizaLinhaQ();
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
                case "nudPressaoDin": // Mudança na temperatura
                    nudPressaoDinDbl = x * 1e5;
                    trbPressaoDinInt = trbInt;
                    ColunaMcCabeThiele.MisturaBinaria.Pressao = nudPressaoDinDbl;
                    AtualizaEquilibrio();
                    AtualizaLinhasOP();
                    AtualizaLinhaQ();
                    AtualizaPratos();
                    break;
                default:
                    throw new Exception($"{nud.Name} nao era esperado!");
            }

            VerificaConvergencia();

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

            VerificaConvergencia();

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

        #region Pressão
        private void nudPressaoDin_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudPressaoDin, trbPressaoDin, Convert.ToDouble(nudPressaoDin.Value));
        }

        private void trbPressaoDin_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudPressaoDin.Minimum) +
                (Convert.ToDouble(nudPressaoDin.Maximum) - Convert.ToDouble(nudPressaoDin.Minimum))
                * Convert.ToDouble(trbPressaoDin.Value) / Convert.ToDouble(trbPressaoDin.Maximum);

            AtualizaParDin(nudPressaoDin, trbPressaoDin, x);
        }
        #endregion

        #endregion

        #region Ajuda

        private void MostrarPopOut(string ajuda)
        {
            formAberto = Application.OpenForms["FormsPopOut"];

            if (formAberto != null)
            {
                formAberto.Close();
            }

            FormsPopOut popOut = new FormsPopOut(TextoAjuda.ResourceManager.GetString(ajuda));

            popOut.Show();
        }

        private void picAjudaResultados_Click(object sender, EventArgs e)
        {
            MostrarPopOut("ajudaColunaResultados");
        }

        private void picAjudaFluido_Click(object sender, EventArgs e)
        {
            MostrarPopOut("ajudaColunaFluido");
        }

        private void picAjudaCondEntrada_Click(object sender, EventArgs e)
        {
            MostrarPopOut("ajudaCondicaoEntrada");
        }

        #endregion

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
