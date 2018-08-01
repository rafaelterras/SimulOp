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

        // Text box
        string[] txbFigFluidoAnularTxt;
        string[] txbFigFluidoInternoTxt;

        // Inputs que podem ser variadas
        private double nudVarFluidoInternoVazaoDbl;
        private double nudVarFluidoInternoTempDbl;
        private double nudVarFluidoAnularVazaoDbl;
        private double nudVarFluidoAnularTempDbl;
        private double nudVarTrocadorComprimentoDbl;
        private double nudVarTrocadorDiamAnularDbl;
        private double nudVarTrocadorDiamInternoDbl;

        // Resultados
        private string txbResultadoPerdaCargaInternaTxt;
        private string txbResultadoPerdaCargaAnularTxt;
        private string txbResultadosCoefTrocaTxt;

        private string txbResultadoTempFluidoInternoSaiTxt;
        private string txbResultadoTempFluidoAnularSaiTxt;
        private string txbResultadosCalorTrocadoTxt;

        // Listas para Plot
        private List<double> comprimentoX = new List<double>();
        private List<double> perdaCargaInternoY = new List<double>();
        private List<double> perdaCargaAnularY = new List<double>();
        private List<double> temperaturaInternoY = new List<double>();
        private List<double> temperaturaAnularY = new List<double>();

        // Forms de ajuda e auxiliares
        private Form formAberto;
        private bool calculado = false;
        
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
                nudTrocadorComprimento.ValueChanged += nudTrocadorComprimento_ValueChanged;
                nudTrocadorDiametroAnular.ValueChanged += nudTrocadorDiametroAnular_ValueChanged;
                nudTrocadorDiametroInterno.ValueChanged += nudTrocadorDiametroInterno_ValueChanged;

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
                nudTrocadorComprimento.ValueChanged -= nudTrocadorComprimento_ValueChanged;
                nudTrocadorDiametroAnular.ValueChanged -= nudTrocadorDiametroAnular_ValueChanged;
                nudTrocadorDiametroInterno.ValueChanged -= nudTrocadorDiametroInterno_ValueChanged;

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
            // Caixas de texto
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
            int trbTempTemp = trbVarFluidoInternoTemp.Value;
            double tmpVaz = nudVarFluidoInternoVazaoDbl;
            int trbVazTemp = trbVarFluidoInternoVazao.Value;

            EventosInputs(false);

            nudVarFluidoInternoTemp.Value = Convert.ToDecimal(nudVarFluidoAnularTempDbl);  //  Temperatura fluido interno
            trbVarFluidoInternoTemp.Value = trbVarFluidoAnularTemp.Value;

            nudVarFluidoInternoVazao.Value = Convert.ToDecimal(nudVarFluidoAnularVazaoDbl); // Vazão fluido interno
            trbVarFluidoInternoVazao.Value = trbVarFluidoAnularVazao.Value;

            nudVarFluidoAnularTemp.Value = Convert.ToDecimal(tempTemp);                     // Temperatura fluido anular
            trbVarFluidoAnularTemp.Value = trbTempTemp;

            nudVarFluidoAnularVazao.Value = Convert.ToDecimal(tmpVaz);                      // Vazão fluido anular
            trbVarFluidoAnularVazao.Value = trbVazTemp;

            EventosInputs(true);

            // AtualizaForms();
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
            double tubulacaoComprimento = Convert.ToDouble(nudTrocadorComprimento.Value);
            MaterialTubulacao materialTubulacao = InicializadorObjetos.MaterialTubulacao(tubulacaoMaterialNome);
            const double espessura = 0;

            // Tubulação Anular
            double tubAnularDiam = Convert.ToDouble(nudTrocadorDiametroAnular.Value);
            tubulacaoAnular = new TubulacaoDuploTubo(tubAnularDiam, espessura, tubulacaoComprimento, materialTubulacao, EquipamentoOPII.TipoTubo.anular);

            // Tubulação Interna
            double tubInternaDiam = Convert.ToDouble(nudTrocadorDiametroInterno.Value);
            tubulacaoInterna = new TubulacaoDuploTubo(tubInternaDiam, espessura, tubulacaoComprimento, materialTubulacao, EquipamentoOPII.TipoTubo.interno);

            // Trocador
            double fatorIncrustacao = Convert.ToDouble(nudTrocadorFatorEncrustacao.Value);
            trocador = new TrocadorDuploTubo(fluidoAnularEnt, fluidoAnularVazao, fluidoInternoEnt, fluidoInternoVazao,
                tubulacaoAnular, tubulacaoInterna, tubulacaoComprimento, fatorIncrustacao);


            txbFigFluidoAnular.Lines = new string[] { "Fluido Anular: ", $"[{trocador.Anular}]", $"{trocador.FluidoAnularEnt.Material.Componente}",
                $"T ent = {trocador.FluidoAnularEnt.Temperatura} ºF", $"  Vazão = {trocador.VazaoAnular} ft3/min" };
            txbFigFluidoInterno.Lines = new string[] { "Fluido Interno: ", $"[{trocador.Interno}]", $"{trocador.FluidoInternoEnt.Material.Componente}",
                $"T ent = {trocador.FluidoInternoEnt.Temperatura} ºF", $"  Vazão = {trocador.VazaoInterna} ft3/min" };

            txbFigFluidoAnularTxt = txbFigFluidoAnular.Lines;
            txbFigFluidoInternoTxt = txbFigFluidoInterno.Lines;

            trocador.CalculaTroca();
            fluidoAnularSai = trocador.FluidoAnularSai;
            fluidoInternoSai = trocador.FluidoInternoSai;
            
            
            txbFigFluidoAnular.Lines = new string[] { txbFigFluidoAnularTxt[0], txbFigFluidoAnularTxt[1], txbFigFluidoAnularTxt[2], txbFigFluidoAnularTxt[3], txbFigFluidoAnularTxt[4] };
            txbFigFluidoInterno.Lines = new string[] { txbFigFluidoInternoTxt[0], txbFigFluidoInternoTxt[1], txbFigFluidoInternoTxt[2], txbFigFluidoInternoTxt[3], txbFigFluidoInternoTxt[4] };
            
            calculado = true;

            // Ativa os elementos da UI.
            txbFigFluidoAnular.Visible = true;
            txbFigFluidoInterno.Visible = true;
            chartPerdaCarga.Visible = true;
            chartTemperatura.Visible = true;
            gubResultados.Visible = true;
            gubVarFluidoInterno.Visible = true;
            gubVarFluidoAnular.Visible = true;
            gubVarTrocador.Visible = true;
            tabControl.SelectedIndex = 1;

            chartPerdaCarga.Series["fluidoInterno"].Points.DataBindXY(new double[] { 0, 0.5, 1 }, new double[] { 0, 50, 80 });
            chartTemperatura.Series["tempInterno"].Points.DataBindXY(new double[] { 0, 0.5, 1 }, new double[] { 0, 50, 80 });
        }

        private void AtualizaForms()
        {
            AtualizaPlots();
            AtualizaResultados(nudVarTrocadorComprimentoDbl);
        }

        private void AtualizaPlots()
        {
            comprimentoX.Clear();
            perdaCargaInternoY.Clear();
            perdaCargaAnularY.Clear();
            temperaturaInternoY.Clear();
            temperaturaAnularY.Clear();

            chartPerdaCarga.Series.Clear();
            chartTemperatura.Series.Clear();

            // TODO: [VERIFICAR] Função para atualizar plot da perda de carga.
            (comprimentoX, perdaCargaInternoY, perdaCargaAnularY, temperaturaInternoY, temperaturaAnularY) = trocador.PlotResultados(2.1, 2.5, 40);

            // Gráfico da perda de carga
            chartPerdaCarga.Series["fluidoInterno"].Points.DataBindXY(comprimentoX, perdaCargaInternoY);
            chartPerdaCarga.Series["fluidoAnular"].Points.DataBindXY(comprimentoX, perdaCargaAnularY);

            // Gráfico das temperaturas
            chartTemperatura.Series["tempInterno"].Points.DataBindXY(comprimentoX, temperaturaInternoY);
            chartTemperatura.Series["tempAnular"].Points.DataBindXY(comprimentoX, temperaturaAnularY);
        }

        private void AtualizaResultados(double comprimento)
        {
            // Cálculo do trocador com o novo comprimento
            trocador.Comprimento = comprimento;
            trocador.CalculaTroca();

            // Display dos resultados
            txbResultadoPerdaCargaInternaTxt = Math.Round(trocador.TubulacaoInterna.PerdaCarga, 2).ToString();
            txbResultadoPerdaCargaAnularTxt = Math.Round(trocador.TubulacaoAnular.PerdaCarga, 2).ToString();
            txbResultadosCoefTrocaTxt = Math.Round(trocador.CoefTrocaTermGlobal, 2).ToString();

            txbResultadoTempFluidoInternoSaiTxt = Math.Round(trocador.FluidoInternoSai.Temperatura, 2).ToString();
            txbResultadoTempFluidoAnularSaiTxt = Math.Round(trocador.FluidoAnularSai.Temperatura, 2).ToString();
            txbResultadosCalorTrocadoTxt = Math.Round(trocador.CalorTransferido, 0).ToString();

            txbResultadoPerdaCargaInterna.Text = txbResultadoPerdaCargaInternaTxt;
            txbResultadoPerdaCargaAnular.Text = txbResultadoPerdaCargaAnularTxt;
            txbResultadosCoefTroca.Text = txbResultadosCoefTrocaTxt;

            txbResultadoTempFluidoInternoSai.Text = txbResultadoTempFluidoInternoSaiTxt;
            txbResultadoTempFluidoAnularSai.Text = txbResultadoTempFluidoAnularSaiTxt;
            txbResultadosCalorTrocado.Text = txbResultadosCalorTrocadoTxt;

            // Atualização da linha do comprimento nos gráficos            
            double perdaCargaMax = Math.Max(trocador.TubulacaoAnular.PerdaCarga, trocador.TubulacaoInterna.PerdaCarga);
            double temperaturaMax = Math.Max(trocador.FluidoAnularSai.Temperatura, trocador.FluidoInternoSai.Temperatura);

            chartPerdaCarga.Series["linhaComprimento"].Points.DataBindXY(new double[] { comprimento, comprimento }, new double[] { 0, perdaCargaMax });
            chartTemperatura.Series["linhaComprimento"].Points.DataBindXY(new double[] { comprimento, comprimento }, new double[] { 0, temperaturaMax });
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

            if (!calculado) // Retorna sem modificar se não for atualizar.
            {
                EventosInputs(true);
                return;
            }

            switch (nud.Name) 
            {
                case "nudVarFluidoInternoVazao":
                    nudVarFluidoInternoVazaoDbl = x;
                    txbFigFluidoInternoTxt[4] = $"Vazão = {Math.Round(x,1)} ft3/min";
                    txbFigFluidoInterno.Lines = txbFigFluidoInternoTxt;

                    trocador.VazaoInterna = nudVarFluidoInternoVazaoDbl;    // Atualiza o trocador
                    AtualizaForms();                                        // Atualiza o forms
                    break;
                case "nudVarFluidoInternoTemp":
                    nudVarFluidoInternoTempDbl = x;
                    txbFigFluidoInternoTxt[3] = $"T ent = {Math.Round(x, 1)} ºF";
                    txbFigFluidoInterno.Lines = txbFigFluidoInternoTxt;

                    trocador.FluidoInternoEnt.Temperatura = nudVarFluidoInternoTempDbl; // Atualiza o trocador
                    AtualizaForms();                                                    // Atualiza o forms
                    break;
                case "nudVarFluidoAnularVazao":
                    nudVarFluidoAnularVazaoDbl = x;
                    txbFigFluidoAnularTxt[4] = $"Vazão = {Math.Round(x, 1)} ft3/min";
                    txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;

                    trocador.VazaoAnular = nudVarFluidoAnularVazaoDbl;  // Atualiza o trocador
                    AtualizaForms();                                    // Atualiza o forms
                    break;
                case "nudVarFluidoAnularTemp":
                    nudVarFluidoAnularTempDbl = x;
                    txbFigFluidoAnularTxt[3] = $"T ent = {Math.Round(x, 1)} ºF";
                    txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;

                    trocador.FluidoAnularEnt.Temperatura = nudVarFluidoAnularTempDbl;   // Atualiza o trocador
                    AtualizaForms();                                                    // Atualiza o forms
                    break;
                case "nudVarTrocadorComprimento":
                    nudTrocadorComprimento.Value = Convert.ToDecimal(x);
                    nudVarTrocadorComprimentoDbl = x;

                    AtualizaResultados(nudVarTrocadorComprimentoDbl);   // Atualiza o gráfico e resultados
                    break;
                case "nudVarTrocadorDiamAnular":
                    nudTrocadorDiametroAnular.Value = Convert.ToDecimal(x);
                    nudVarTrocadorDiamAnularDbl = x;

                    trocador.TubulacaoAnular.Diametro = nudVarTrocadorDiamAnularDbl;    // Atualiza o trocador
                    AtualizaForms();                                                    // Atualiza o forms
                    break;
                case "nudVarTrocadorDiamInterno":
                    nudTrocadorDiametroInterno.Value = Convert.ToDecimal(x);
                    nudVarTrocadorDiamInternoDbl = x;

                    trocador.TubulacaoInterna.Diametro = nudVarTrocadorDiamInternoDbl;  // Atualiza o trocador
                    AtualizaForms();                                                    // Atualiza o forms
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

        private void nudTrocadorComprimento_ValueChanged(object sender, EventArgs e)
        {
            if (calculado)
            {
                AtualizaParDin(nudVarTrocadorComprimento, trbVarTrocadorComprimento, Convert.ToDouble(nudTrocadorComprimento.Value));
            }
        }

        private void nudTrocadorDiametroAnular_ValueChanged(object sender, EventArgs e)
        {
            if (calculado)
            {
                AtualizaParDin(nudVarTrocadorDiamAnular, trbVarTrocadorDiamAnular, Convert.ToDouble(nudTrocadorDiametroAnular.Value));
            }
        }

        private void nudTrocadorDiametroInterno_ValueChanged(object sender, EventArgs e)
        {
            if (calculado)
            {
                AtualizaParDin(nudVarTrocadorDiamInterno, trbVarTrocadorDiamInterno, Convert.ToDouble(nudTrocadorDiametroInterno.Value));
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
