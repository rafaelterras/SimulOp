using System;
using System.Collections.Generic;

using System.Windows.Forms;

using SimulOP.Properties;

namespace SimulOP.Forms
{
    public partial class FormsTrocadorBiTubilar : Form
    {
        // Objetos para o cálculo do trocador
        private TrocadorDuploTubo trocador;

        private TubulacaoDuploTubo tubulacaoAnular;
        private IMaterialFluidoOPII materialFluidoAnular;
        private FluidoOPII fluidoAnularEnt;
        private FluidoOPII fluidoAnularSai;

        private TubulacaoDuploTubo tubulacaoInterna;
        private IMaterialFluidoOPII materialFluidoInterno;
        private FluidoOPII fluidoInternoEnt;
        private FluidoOPII fluidoInternoSai;

        // Inputs que podem ser variadas
        private double nudVarFluidoInternoVazaoDbl;
        private double nudVarFluidoInternoTempDbl;
        private double nudVarFluidoAnularVazaoDbl;
        private double nudVarFluidoAnularTempDbl;
        private double nudVarTrocadorComprimentoDbl;
        private double nudVarTrocadorDiamAnularDbl;
        private double nudVarTrocadorDiamInternoDbl;
        
        // Forms de ajuda
        private Form formAberto;

        // Text box
        string[] txbFigFluidoAnularTxt;
        string[] txbFigFluidoInternoTxt;
        
        public FormsTrocadorBiTubilar()
        {
            InitializeComponent();

            txbFigFluidoAnularTxt = txbFigFluidoAnular.Lines;
            txbFigFluidoInternoTxt = txbFigFluidoInterno.Lines;
        }

        /// <summary>
        /// Inscreve ou desinscreve os eventos das variaveis dinâmicas de acordo com o parametro.
        /// </summary>
        /// <param name="ativar">Se True inscreve os eventos, e False desinscreve os eventos.</param>
        private void EventosInputs(bool ativar)
        {
            if (ativar)
            {
                nudVarFluidoInternoVazao.ValueChanged += nudVarFluidoInternoVazao_ValueChanged;
                trbVarFluidoInternoVazao.Scroll += trbVarFluidoInternoVazao_Scroll;
                nudVarFluidoInternoTemp.ValueChanged += nudVarFluidoInternoTemp_ValueChanged;
                trbVarFluidoInternoTemp.Scroll += trbVarFluidoInternoTemp_Scroll;
                nudVarFluidoAnularVazao.ValueChanged += nudVarFluidoAnularVazao_ValueChanged;
                trbVarFluidoAnularVazao.Scroll += trbVarFluidoAnularVazao_Scroll;
                nudVarFluidoAnularTemp.ValueChanged += nudVarFluidoAnularTemp_ValueChanged;
                trbVarFluidoAnularTemp.Scroll += trbVarFluidoAnularTemp_Scroll;
                nudVarTrocadorComprimento.ValueChanged += nudVarTrocadorComprimento_ValueChanged;
                trbVarTrocadorComprimento.Scroll += trbVarTrocadorComprimento_Scroll;
                nudVarTrocadorDiamAnular.ValueChanged += nudVarTrocadorDiamAnular_ValueChanged;
                trbVarTrocadorDiamAnular.Scroll += trbVarTrocadorDiamAnular_Scroll;
                nudVarTrocadorDiamInterno.ValueChanged += nudVarTrocadorDiamExterno_ValueChanged;
                trbVarTrocadorDiamInterno.Scroll += trbVarTrocadorDiamExterno_Scroll;
            }
            else
            {
                nudVarFluidoInternoVazao.ValueChanged -= nudVarFluidoInternoVazao_ValueChanged;
                trbVarFluidoInternoVazao.Scroll -= trbVarFluidoInternoVazao_Scroll;
                nudVarFluidoInternoTemp.ValueChanged -= nudVarFluidoInternoTemp_ValueChanged;
                trbVarFluidoInternoTemp.Scroll -= trbVarFluidoInternoTemp_Scroll;
                nudVarFluidoAnularVazao.ValueChanged -= nudVarFluidoAnularVazao_ValueChanged;
                trbVarFluidoAnularVazao.Scroll -= trbVarFluidoAnularVazao_Scroll;
                nudVarFluidoAnularTemp.ValueChanged -= nudVarFluidoAnularTemp_ValueChanged;
                trbVarFluidoAnularTemp.Scroll -= trbVarFluidoAnularTemp_Scroll;
                nudVarTrocadorComprimento.ValueChanged -= nudVarTrocadorComprimento_ValueChanged;
                trbVarTrocadorComprimento.Scroll -= trbVarTrocadorComprimento_Scroll;
                nudVarTrocadorDiamAnular.ValueChanged -= nudVarTrocadorDiamAnular_ValueChanged;
                trbVarTrocadorDiamAnular.Scroll -= trbVarTrocadorDiamAnular_Scroll;
                nudVarTrocadorDiamInterno.ValueChanged -= nudVarTrocadorDiamExterno_ValueChanged;
                trbVarTrocadorDiamInterno.Scroll -= trbVarTrocadorDiamExterno_Scroll;
            }
        }

        private void btnTrocaFluidos_Click(object sender, EventArgs e)
        {
            string temp;

            for (int i = 1; i < 3; i++)
            {
                temp = txbFigFluidoAnularTxt[i];
                txbFigFluidoAnularTxt[i] = txbFigFluidoInternoTxt[i];
                txbFigFluidoInternoTxt[i] = temp;
            }

            txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;
            txbFigFluidoInterno.Lines = txbFigFluidoInternoTxt;

            double tempTemp = nudVarFluidoInternoTempDbl;
            double tmpVaz = nudVarFluidoInternoVazaoDbl;

            nudVarFluidoInternoTemp.Value = Convert.ToDecimal(nudVarFluidoAnularTempDbl);
            nudVarFluidoInternoVazao.Value = Convert.ToDecimal(nudVarFluidoAnularVazaoDbl);
            nudVarFluidoAnularTemp.Value = Convert.ToDecimal(tempTemp);
            nudVarFluidoAnularVazao.Value = Convert.ToDecimal(tmpVaz);
            
            // TODO: Atualizar os resultados

            EventosInputs(true);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Fluido Anular
            string fluidoAnularNome = cmbFluidoAnular.Text;
            double fluidoAnularAPI = Convert.ToDouble(nudFluidoAnularAPI.Value);
            double fluidoAnularTemp = Convert.ToDouble(nudFluidoAnularTempEnt.Value);
            double fluidoAnularVazao = Convert.ToDouble(nudFluidoAnularVazao.Value);

            if (fluidoAnularNome == "Óleo (ºAPI)")
            {
                materialFluidoAnular = new MaterialOleoAPI(fluidoAnularAPI, fluidoAnularTemp);
            }
            else
            {
                materialFluidoAnular = InicializadorObjetos.MaterialFluidoOPII(fluidoAnularNome, fluidoAnularTemp);
            }

            fluidoAnularEnt = new FluidoOPII(materialFluidoAnular, fluidoAnularTemp);

            // Fluido Interno
            string fluidoInternoNome = cmbFluidoInterno.Text;
            double fluidoInternoAPI = Convert.ToDouble(nudFluidoInternoAPI.Value);
            double fluidoInternoTemp = Convert.ToDouble(nudFluidoInternoTempEnt.Value);
            double fluidoInternoVazao = Convert.ToDouble(nudFluidoInternoVazao.Value);

            if (fluidoInternoNome == "Óleo (ºAPI)")
            {
                materialFluidoInterno = new MaterialOleoAPI(fluidoInternoAPI, fluidoInternoTemp);
            }
            else
            {
                materialFluidoInterno = InicializadorObjetos.MaterialFluidoOPII(fluidoInternoNome, fluidoInternoTemp);
            }

            fluidoInternoEnt = new FluidoOPII(materialFluidoInterno, fluidoInternoTemp);

            // Tubulações
            string tubulacaoMaterialNome = cmbTrocadorMaterial.Text;
            double tubulacaoComprimento = Convert.ToDouble(nudTrocadorComprimento);
            MaterialTubulacao materialTubulacao = InicializadorObjetos.MaterialTubulacao(tubulacaoMaterialNome);
            const double especura = 0; // TODO: Definir espeçura

            // Tubulação Anular
            double tubAnularDiam = Convert.ToDouble(nudTrocadorDiametroAnular);
            tubulacaoAnular = new TubulacaoDuploTubo(tubAnularDiam, especura, tubulacaoComprimento, materialTubulacao, EquipamentoOPII.TipoTubo.anular);

            // Tubulação Interna
            double tubInternaDiam = Convert.ToDouble(nudTrocadorDiametroInterno.Value);
            tubulacaoInterna = new TubulacaoDuploTubo(tubInternaDiam, especura, tubulacaoComprimento, materialTubulacao, EquipamentoOPII.TipoTubo.interno);

            // Trocador
            double fatorIncrustacao = Convert.ToDouble(nudTrocadorFatorEncrustacao.Value);
            trocador = new TrocadorDuploTubo(fluidoAnularEnt, fluidoAnularVazao, fluidoInternoEnt, fluidoInternoVazao,
                tubulacaoAnular, tubulacaoInterna, tubulacaoComprimento, fatorIncrustacao);

            chartPerdaCarga.Series["fluidoFrio"].Points.DataBindXY(new double[] { 0, 0.5, 1 }, new double[] { 0, 50, 80 });
            chartTemperatura.Series["temperatura"].Points.DataBindXY(new double[] { 0, 0.5, 1 }, new double[] { 0, 50, 80 });
        }

        private void AtualizaForms()
        {
            AtualizaPlotPerdaCarga();
            AtulizaPlotTemperatura();
            AtualizaResultados();
        }

        private void AtualizaPlotPerdaCarga()
        {
            // TODO: Função para atualizar plot da perda de carga.
        }

        private void AtulizaPlotTemperatura()
        {
            // TODO: Função para atualizar plot da temperatura.
        }

        private void AtualizaResultados()
        {
            // TODO: Função para atualizar os resultados.
        }

        #region Input Inicial

        private void cmbFluidoAnular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFluidoAnular.Text == "Óleo (ºAPI)")
            {
                nudFluidoAnularAPI.Enabled = true;
            }
            else
            {
                nudFluidoAnularAPI.Enabled = false;
            }
        }

        private void cmbFluidoInterno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFluidoInterno.Text == "Óleo (ºAPI)")
            {
                nudFluidoInternoAPI.Enabled = true;
            }
            else
            {
                nudFluidoInternoAPI.Enabled = false;
            }
        }

        private void cmbTrocadorMaterial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Random random = new Random();

            txbTrocadorRugosidade.Text = random.NextDouble().ToString();
            txbTrocadorK.Text = random.NextDouble().ToString();
        }

        #endregion

        #region Variaveis Dinamicas

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

            switch (nud.Name) // TODO: implementar as variações
            {
                case "nudVarFluidoInternoVazao":
                    nudVarFluidoInternoVazaoDbl = x;
                    txbFigFluidoInternoTxt[4] = $"Vazão = {Math.Round(x,1)} ft3/min";
                    txbFigFluidoInterno.Lines = txbFigFluidoInternoTxt;
                    break;
                case "nudVarFluidoInternoTemp":
                    nudVarFluidoInternoTempDbl = x;
                    txbFigFluidoInternoTxt[3] = $"T ent = {Math.Round(x, 1)} ºF";
                    txbFigFluidoInterno.Lines = txbFigFluidoInternoTxt;
                    break;
                case "nudVarFluidoAnularVazao":
                    nudVarFluidoAnularVazaoDbl = x;
                    txbFigFluidoAnularTxt[4] = $"Vazão = {Math.Round(x, 1)} ft3/min";
                    txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;
                    break;
                case "nudVarFluidoAnularTemp":
                    nudVarFluidoAnularTempDbl = x;
                    txbFigFluidoAnularTxt[3] = $"T ent = {Math.Round(x, 1)} ºF";
                    txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;
                    break;
                case "nudVarTrocadorComprimento":
                    nudTrocadorComprimento.Value = Convert.ToDecimal(x);
                    nudVarTrocadorComprimentoDbl = x;
                    break;
                case "nudVarTrocadorDiamAnular":
                    nudTrocadorDiametroAnular.Value = Convert.ToDecimal(x);
                    nudVarTrocadorDiamAnularDbl = x;
                    break;
                case "nudVarTrocadorDiamInterno":
                    nudTrocadorDiametroInterno.Value = Convert.ToDecimal(x);
                    nudVarTrocadorDiamInternoDbl = x;
                    break;
                default:
                    throw new Exception($"- {nud.Name} - Não era esperado!");
            }
            // Re-inscreve-se aos eventos
            EventosInputs(true);
        }

        /// <summary>
        /// Retorna o par do NumericUpDown.
        /// </summary>
        /// <param name="nud">O NumericUpDown.</param>
        /// <returns>A TrackBar pareada com o NumericUpDown.</returns>
        private TrackBar ParTrb(NumericUpDown nud)
        {
            switch (nud.Name)
            {
                case "nudVarFluidoInternoVazao":
                    return trbVarFluidoInternoVazao;
                case "nudVarFluidoInternoTemp":
                    return trbVarFluidoInternoTemp;
                case "nudVarFluidoAnularVazao":
                    return trbVarFluidoAnularVazao;
                case "nudVarFluidoAnularTemp":
                    return trbVarFluidoAnularTemp;
                case "nudVarTrocadorComprimento":
                    return trbVarTrocadorComprimento;
                case "nudVarTrocadorDiamAnular":
                    return trbVarTrocadorDiamAnular;
                case "nudVarTrocadorDiamInterno":
                    return trbVarTrocadorDiamInterno;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Retorna o par da TrackBar.
        /// </summary>
        /// <param name="trb">A TrackBar.</param>
        /// <returns>O NumericUpDown pareado com a TrackBar.</returns>
        private NumericUpDown ParNud(TrackBar trb)
        {
            switch (trb.Name)
            {
                case "trbVarFluidoInternoVazao":
                    return nudVarFluidoInternoVazao;
                case "trbVarFluidoInternoTemp":
                    return nudVarFluidoInternoTemp;
                case "trbVarFluidoAnularVazao":
                    return nudVarFluidoAnularVazao;
                case "trbVarFluidoAnularTemp":
                    return nudVarFluidoAnularTemp;
                case "trbVarTrocadorComprimento":
                    return nudVarTrocadorComprimento;
                case "trbVarTrocadorDiamAnular":
                    return nudVarTrocadorDiamAnular;
                case "trbVarTrocadorDiamInterno":
                    return nudVarTrocadorDiamInterno;
                default:
                    return null;
            }
        }

        private void nudVarFluidoInternoVazao_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoInternoVazao_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarFluidoInternoTemp_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoInternoTemp_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarFluidoAnularVazao_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoAnularVazao_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarFluidoAnularTemp_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoAnularTemp_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarTrocadorComprimento_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarTrocadorComprimento_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarTrocadorDiamAnular_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarTrocadorDiamAnular_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarTrocadorDiamExterno_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarTrocadorDiamExterno_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

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

        // TODO: Implementar o sistema de ajuda.

        #endregion
    }
}
