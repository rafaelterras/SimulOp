using System;
using System.Collections.Generic;

using System.Windows.Forms;

using SimulOP.Properties;

namespace SimulOP.Forms
{
    /// <summary>
    /// Forms para o trocador de calor Duplo Tubo.
    /// </summary>
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
        private double nudVarFluidoInternoTempDbl;
        private double nudVarFluidoInternoTempSaiDbl;
        private double nudVarFluidoAnularTempDbl;
        private double nudVarFluidoAnularTempSaiDbl;
        private double nudVarTrocadorVazaoQuenteDbl;
        private double nudVarTrocadorDiamAnularDbl;
        private double nudVarTrocadorDiamInternoDbl;

        // Resultados
        private string txbResultadoPerdaCargaInternaTxt;
        private string txbResultadoPerdaCargaAnularTxt;
        private string txbResultadosCoefTrocaTxt;

        private string txbResultadoCompTrocadorTxt;
        private string txbResultadoVazaoFrioTxt;
        private string txbResultadosCalorTrocadoTxt;

        // Listas para Plot
        private List<double> tempQuentSaiX = new List<double>();
        private List<double> perdaCargaInternoY = new List<double>();
        private List<double> perdaCargaAnularY = new List<double>();
        private List<double> comprimentoY = new List<double>();

        // Forms de ajuda e auxiliares
        private Form formAberto;
        private EquipamentoOPII.TipoTubo tuboQente;
        private bool atualizaParametros = false;

        private decimal nudFrioEntMax = 40;
        private decimal nudFrioEntMin = 10;
        private decimal nudQuenteEntMax = 200;
        private decimal nudQuenteEntMin = 40;

        private decimal nudFrioSaiMax = 100;
        private decimal nudFrioSaiMin = 42;
        private decimal nudQuenteSaiMax = 38;
        private decimal nudQuenteSaiMin = 12;
        
        public FormsTrocadorBiTubilar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inscreve ou desinscreve os eventos das variaveis dinâmicas de acordo com o parametro.
        /// </summary>
        /// <param name="ativar">Se True inscreve os eventos, e False desinscreve os eventos.</param>
        private void EventosInputs(bool ativar)
        {
            if (ativar)
            {
                nudTrocadorDiametroAnular.ValueChanged += nudTrocadorDiametroAnular_ValueChanged;
                nudTrocadorDiametroInterno.ValueChanged += nudTrocadorDiametroInterno_ValueChanged;

                nudVarFluidoInternoTempSai.ValueChanged += nudVarFluidoInternoVazao_ValueChanged;
                trbVarFluidoInternoTempSai.Scroll += trbVarFluidoInternoVazao_Scroll;
                nudVarFluidoInternoTemp.ValueChanged += nudVarFluidoInternoTemp_ValueChanged;
                trbVarFluidoInternoTemp.Scroll += trbVarFluidoInternoTemp_Scroll;
                nudVarFluidoInternoTempSai.ValueChanged += nudVarFluidoInternoTempSai_ValueChanged;
                trbVarFluidoInternoTempSai.Scroll += trbVarFluidoInternoTempSai_Scroll;
                nudVarFluidoAnularTemp.ValueChanged += nudVarFluidoAnularTemp_ValueChanged;
                trbVarFluidoAnularTemp.Scroll += trbVarFluidoAnularTemp_Scroll;
                nudVarTrocadorVazaoQuente.ValueChanged += nudVarTrocadorVazaoQuente_ValueChanged;
                trbVarTrocadorVazaoQuente.Scroll += trbVarTrocadorVazaoQuente_Scroll;
                nudVarTrocadorDiamAnular.ValueChanged += nudVarTrocadorDiamAnular_ValueChanged;
                trbVarTrocadorDiamAnular.Scroll += trbVarTrocadorDiamAnular_Scroll;
                nudVarTrocadorDiamInterno.ValueChanged += nudVarTrocadorDiamExterno_ValueChanged;
                trbVarTrocadorDiamInterno.Scroll += trbVarTrocadorDiamExterno_Scroll;
            }
            else
            {
                nudTrocadorDiametroAnular.ValueChanged -= nudTrocadorDiametroAnular_ValueChanged;
                nudTrocadorDiametroInterno.ValueChanged -= nudTrocadorDiametroInterno_ValueChanged;

                nudVarFluidoInternoTempSai.ValueChanged -= nudVarFluidoInternoVazao_ValueChanged;
                trbVarFluidoInternoTempSai.Scroll -= trbVarFluidoInternoVazao_Scroll;
                nudVarFluidoInternoTemp.ValueChanged -= nudVarFluidoInternoTemp_ValueChanged;
                trbVarFluidoInternoTemp.Scroll -= trbVarFluidoInternoTemp_Scroll;
                nudVarFluidoInternoTempSai.ValueChanged -= nudVarFluidoInternoTempSai_ValueChanged;
                trbVarFluidoInternoTempSai.Scroll -= trbVarFluidoInternoTempSai_Scroll;
                nudVarFluidoAnularTemp.ValueChanged -= nudVarFluidoAnularTemp_ValueChanged;
                trbVarFluidoAnularTemp.Scroll -= trbVarFluidoAnularTemp_Scroll;
                nudVarTrocadorVazaoQuente.ValueChanged -= nudVarTrocadorVazaoQuente_ValueChanged;
                trbVarTrocadorVazaoQuente.Scroll -= trbVarTrocadorVazaoQuente_Scroll;
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

            AtualizaForms();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {   
            // Fluido Anular
            string fluidoAnularNome = cmbFluidoAnular.Text;
            double fluidoAnularAPI = Convert.ToDouble(nudFluidoAnularAPI.Value);
            double fluidoAnularTemp = Convert.ToDouble(nudFluidoAnularTempEnt.Value) + 273.15; // T em K
            double tempAnularSai = Convert.ToDouble(nudFluidoAnularTempSaida.Value) + 273.15; // T em L

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
            double fluidoInternoTemp = Convert.ToDouble(nudFluidoInternoTempEnt.Value) + 273.15; // T em K
            double tempInternoSai = Convert.ToDouble(nudFluidoInternoTempSaida.Value) + 273.15; // T em K

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
            const double espessura = 0; // Considerando a tubulação sem espeçura.

            // Tubulação Interna
            double tubInternaDiam = Convert.ToDouble(nudTrocadorDiametroInterno.Value) * 1e-2; // Diametro em m
            tubulacaoInterna = new TubulacaoDuploTubo(tubInternaDiam, espessura, tubulacaoComprimento, materialTubulacao, EquipamentoOPII.TipoTubo.interno);

            // Tubulação Anular
            double tubAnularDiam = Convert.ToDouble(nudTrocadorDiametroAnular.Value) * 1e-2; // Diametro em m
            tubulacaoAnular = new TubulacaoDuploTubo(tubAnularDiam, espessura, tubulacaoComprimento, materialTubulacao, EquipamentoOPII.TipoTubo.anular, tubInternaDiam);

            // Não executa se a diferença de temperatura entre os fluido não for miníma.
            if (Math.Abs(fluidoAnularTemp - fluidoInternoTemp) < 2)
            {
                Console.ReadLine();
                return;
            }

            tuboQente = (fluidoAnularTemp > fluidoInternoTemp) ? EquipamentoOPII.TipoTubo.anular : EquipamentoOPII.TipoTubo.interno;

            // Trocador
            double vazaoQente = Convert.ToDouble(nudVazaoQuente.Value) / 3600.0; // Vazao em m^3/s
            double fatorIncrustacao = Convert.ToDouble(nudTrocadorFatorEncrustacao.Value);
            trocador = new TrocadorDuploTubo(fluidoAnularEnt, tempAnularSai, fluidoInternoEnt, tempInternoSai, vazaoQente, tubulacaoAnular, tubulacaoInterna, fatorIncrustacao);
            
            trocador.CalculaTroca();
            fluidoAnularSai = trocador.FluidoAnularSai;
            fluidoInternoSai = trocador.FluidoInternoSai;

            if (trocador.Anular == EquipamentoOPII.FluidoTroca.quente)
            {
                txbFigFluidoAnular.Lines = new string[] { "Fluido Anular: ", $"[{trocador.Anular}]", $"{trocador.FluidoAnularEnt.Material.Componente}",
                    $"T ent = {trocador.FluidoAnularEnt.Temperatura - 273.15} ºC", $"Vazão = {trocador.VazaoQuente * 3600} m^3/h" };
                txbFigFluidoInterno.Lines = new string[] { "Fluido Interno: ", $"[{trocador.Interno}]", $"{trocador.FluidoInternoEnt.Material.Componente}",
                    $"T ent = {trocador.FluidoInternoEnt.Temperatura - 273.15} ºC", $"Vazão = {Math.Round(trocador.VazaoFrio * 3600,1)} m^3/h" };
            }
            else
            {
                txbFigFluidoAnular.Lines = new string[] { "Fluido Anular: ", $"[{trocador.Anular}]", $"{trocador.FluidoAnularEnt.Material.Componente}",
                $"T ent = {trocador.FluidoAnularEnt.Temperatura - 273.15} ºC", $"Vazão = {Math.Round(trocador.VazaoFrio * 3600,1)} m^3/h" };
                txbFigFluidoInterno.Lines = new string[] { "Fluido Interno: ", $"[{trocador.Interno}]", $"{trocador.FluidoInternoEnt.Material.Componente}",
                $"T ent = {trocador.FluidoInternoEnt.Temperatura - 273.15} ºC", $"Vazão = {trocador.VazaoQuente * 3600} m^3/h" };
            }
            
            txbFigFluidoAnularTxt = txbFigFluidoAnular.Lines;
            txbFigFluidoInternoTxt = txbFigFluidoInterno.Lines;
                        
            txbFigFluidoAnular.Lines = new string[] { txbFigFluidoAnularTxt[0], txbFigFluidoAnularTxt[1], txbFigFluidoAnularTxt[2], txbFigFluidoAnularTxt[3], txbFigFluidoAnularTxt[4] };
            txbFigFluidoInterno.Lines = new string[] { txbFigFluidoInternoTxt[0], txbFigFluidoInternoTxt[1], txbFigFluidoInternoTxt[2], txbFigFluidoInternoTxt[3], txbFigFluidoInternoTxt[4] };
            
            // Ativa os elementos da UI.
            txbFigFluidoAnular.Visible = true;
            txbFigFluidoInterno.Visible = true;
            chartPerdaCarga.Visible = true;
            chartComprimento.Visible = true;
            gubResultados.Visible = true;
            gubVarFluidoInterno.Visible = true;
            gubVarFluidoAnular.Visible = true;
            gubVarTrocador.Visible = true;
            tabControl.SelectedIndex = 1;

            if (trocador.Anular == EquipamentoOPII.FluidoTroca.quente)
            {
                nudQuenteSaiMin = Convert.ToDecimal(trocador.FluidoInternoEnt.Temperatura + 2 - 273.15);
                nudFrioSaiMax = Convert.ToDecimal(trocador.FluidoAnularEnt.Temperatura - 2 - 273.15);

                nudVarFluidoAnularTemp.Minimum = nudQuenteEntMin;
                nudVarFluidoAnularTemp.Maximum = nudQuenteEntMax;
                nudVarFluidoAnularTempSai.Minimum = nudQuenteSaiMin;
                nudVarFluidoAnularTempSai.Maximum = nudQuenteSaiMax;

                nudVarFluidoInternoTemp.Minimum = nudFrioEntMin;
                nudVarFluidoInternoTemp.Maximum = nudFrioEntMax;
                nudVarFluidoInternoTempSai.Minimum = nudFrioSaiMin;
                nudVarFluidoInternoTempSai.Maximum = nudFrioSaiMax;
            }
            else
            {
                nudQuenteSaiMin = Convert.ToDecimal(trocador.FluidoAnularEnt.Temperatura + 2 - 273.15);
                nudFrioSaiMax = Convert.ToDecimal(trocador.FluidoInternoEnt.Temperatura - 2 - 273.15);

                nudVarFluidoAnularTemp.Minimum = nudFrioEntMin;
                nudVarFluidoAnularTemp.Maximum = nudFrioEntMax;
                nudVarFluidoAnularTempSai.Minimum = nudFrioSaiMin;
                nudVarFluidoAnularTempSai.Maximum = nudFrioSaiMax;

                nudVarFluidoInternoTemp.Minimum = nudQuenteEntMin;
                nudVarFluidoInternoTemp.Maximum = nudQuenteEntMax;
                nudVarFluidoInternoTempSai.Minimum = nudQuenteSaiMin;
                nudVarFluidoInternoTempSai.Maximum = nudQuenteSaiMax;
            }

            // Coloca os valores nas variaveis dinamicas
            nudVarFluidoInternoTemp.Value = Convert.ToDecimal(fluidoInternoTemp - 273.15);
            nudVarFluidoInternoTempSai.Value = Convert.ToDecimal(tempInternoSai - 273.15);

            nudVarFluidoAnularTemp.Value = Convert.ToDecimal(fluidoAnularTemp - 273.15);
            nudVarFluidoAnularTempSai.Value = Convert.ToDecimal(tempAnularSai - 273.15);

            nudVarTrocadorVazaoQuente.Value = Convert.ToDecimal(vazaoQente * 3600);
            nudTrocadorComprimento.Value = Convert.ToDecimal(tubulacaoComprimento);
            nudVarTrocadorDiamAnular.Value = Convert.ToDecimal(tubAnularDiam * 100);
            nudTrocadorDiametroAnular.Value = Convert.ToDecimal(tubAnularDiam * 100);
            nudVarTrocadorDiamInterno.Value = Convert.ToDecimal(tubInternaDiam * 100);
            nudTrocadorDiametroInterno.Value = Convert.ToDecimal(tubInternaDiam * 100);

            AtualizaForms();

            atualizaParametros = true;
        }

        private void AtualizaForms()
        {
            AtualizaPlots();
            if (tuboQente == EquipamentoOPII.TipoTubo.anular)
            {
                AtualizaResultados(nudVarFluidoAnularTempSaiDbl);
            }
            else
            {
                AtualizaResultados(nudVarFluidoInternoTempSaiDbl);
            }
        }

        private void AtualizaPlots()
        {
            tempQuentSaiX.Clear();
            perdaCargaInternoY.Clear();
            perdaCargaAnularY.Clear();
            comprimentoY.Clear();

            // TODO: [VERIFICAR] Função para atualizar plot da perda de carga.
            (tempQuentSaiX, perdaCargaInternoY, perdaCargaAnularY, comprimentoY) = trocador.PlotResultados(Convert.ToDouble(nudQuenteSaiMin), Convert.ToDouble(nudQuenteSaiMax), 20);

            // Gráfico da perda de carga
            chartPerdaCarga.Series["fluidoInterno"].Points.DataBindXY(tempQuentSaiX, perdaCargaInternoY);
            chartPerdaCarga.Series["fluidoAnular"].Points.DataBindXY(tempQuentSaiX, perdaCargaAnularY);

            // Gráfico do comprimento
            chartComprimento.Series["comprimento"].Points.DataBindXY(tempQuentSaiX, comprimentoY);
        }

        private void AtualizaResultados(double tempQuenteSai)
        {
            // Cálculo do trocador com o novo comprimento
            if (tuboQente == EquipamentoOPII.TipoTubo.anular)
            {
                trocador.TempAnularSaida = tempQuenteSai;
            }
            else
            {
                trocador.TempInternoSaida = tempQuenteSai;
            }

            trocador.CalculaTroca();

            // Display dos resultados
            txbResultadoPerdaCargaInternaTxt = Math.Round(trocador.TubulacaoInterna.PerdaCarga * 1e-3, 2).ToString(); // P em KPa
            txbResultadoPerdaCargaAnularTxt = Math.Round(trocador.TubulacaoAnular.PerdaCarga * 1e-3, 2).ToString(); // P em KPa
            txbResultadosCoefTrocaTxt = Math.Round(trocador.CoefTrocaTermGlobal, 2).ToString();

            txbResultadoCompTrocadorTxt = Math.Round(trocador.Comprimento, 2).ToString();
            txbResultadoVazaoFrioTxt = Math.Round(trocador.VazaoFrio * 3600, 2).ToString();
            txbResultadosCalorTrocadoTxt = Math.Round(trocador.CalorTransferido * 1000, 1).ToString();

            txbResultadoPerdaCargaInterna.Text = txbResultadoPerdaCargaInternaTxt;
            txbResultadoPerdaCargaAnular.Text = txbResultadoPerdaCargaAnularTxt;
            txbResultadosCoefTroca.Text = txbResultadosCoefTrocaTxt;

            txbResultadoCompTrocador.Text = txbResultadoCompTrocadorTxt;
            txbResultadoVazaoFrio.Text = txbResultadoVazaoFrioTxt;
            txbResultadosCalorTrocado.Text = txbResultadosCalorTrocadoTxt;

            // Atualização da linha do comprimento nos gráficos            
            double perdaCargaMax = Math.Max(trocador.TubulacaoAnular.PerdaCarga * 1e-3, trocador.TubulacaoInterna.PerdaCarga * 1e-3);

            chartPerdaCarga.Series["linhaTemp"].Points.DataBindXY(new double[] { tempQuenteSai - 273.15, tempQuenteSai - 273.15 }, new double[] { 0, perdaCargaMax });
            chartComprimento.Series["linhaTemp"].Points.DataBindXY(new double[] { tempQuenteSai - 273.15, tempQuenteSai - 273.15 }, new double[] { 0, trocador.Comprimento });
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
            MaterialTubulacao materialTubulacao = InicializadorObjetos.MaterialTubulacao(cmbTrocadorMaterial.Text);

            txbTrocadorRugosidade.Text = $"{Math.Round(materialTubulacao.Rugosidade * 1e2),1} cm";
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

            switch (nud.Name) 
            {
                case "nudVarFluidoInternoTempSai":
                    nudVarFluidoInternoTempSaiDbl = x + 273.15; // T em K.

                    if (!atualizaParametros) break;

                    trocador.TempInternoSaida = nudVarFluidoInternoTempSaiDbl;    // Atualiza o trocador

                    if (tuboQente == EquipamentoOPII.TipoTubo.interno)
                    {
                        AtualizaResultados(nudVarFluidoInternoTempSaiDbl);
                    }
                    else
                    {
                        AtualizaForms();                                        // Atualiza o forms
                    }

                    break;
                case "nudVarFluidoInternoTemp":
                    nudVarFluidoInternoTempDbl = x + 273.15; // T em K
                    txbFigFluidoInternoTxt[3] = $"T ent = {Math.Round(x, 1)} ºC";
                    txbFigFluidoInterno.Lines = txbFigFluidoInternoTxt;

                    if (!atualizaParametros) break;

                    trocador.FluidoInternoEnt.Temperatura = nudVarFluidoInternoTempDbl; // Atualiza o trocador
                    AtualizaForms();                                                    // Atualiza o forms
                    break;
                case "nudVarFluidoAnularTempSai":
                    nudVarFluidoAnularTempSaiDbl = x + 273.15; // T em K.

                    if (!atualizaParametros) break;

                    trocador.TempAnularSaida = nudVarFluidoAnularTempSaiDbl;        // Atualiza o trocador

                    if (tuboQente == EquipamentoOPII.TipoTubo.anular)
                    {
                        AtualizaResultados(nudVarFluidoAnularTempSaiDbl);
                    }
                    else
                    {
                        AtualizaForms();                                    // Atualiza o forms
                    }

                    break;
                case "nudVarFluidoAnularTemp":
                    nudVarFluidoAnularTempDbl = x + 273.15; // T em K
                    txbFigFluidoAnularTxt[3] = $"T ent = {Math.Round(x, 1)} ºC";
                    txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;

                    if (!atualizaParametros) break;

                    trocador.FluidoAnularEnt.Temperatura = nudVarFluidoAnularTempDbl;   // Atualiza o trocador
                    AtualizaForms();                                                    // Atualiza o forms
                    break;
                case "nudVarTrocadorVazaoQuente":
                    nudVarTrocadorVazaoQuenteDbl = x / 3600; // Q em m^3/s

                    trocador.VazaoQuente = nudVarTrocadorVazaoQuenteDbl;

                    if (tuboQente == EquipamentoOPII.TipoTubo.anular)
                    {
                        txbFigFluidoAnularTxt[4] = $"Vazão = {nudVarTrocadorVazaoQuenteDbl * 3600} m^3/h";
                        txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;
                    }
                    else
                    {
                        txbFigFluidoInternoTxt[4] = $"Vazão = {nudVarTrocadorVazaoQuenteDbl * 3600} m^3/h";
                        txbFigFluidoInterno.Lines = txbFigFluidoInternoTxt;
                    }
                    
                    if (!atualizaParametros) break;

                    AtualizaForms();    // Atualiza o forms
                    break;
                case "nudVarTrocadorDiamAnular":
                    nudTrocadorDiametroAnular.Value = Convert.ToDecimal(x);
                    nudVarTrocadorDiamAnularDbl = x * 1e-2; // Diametro em m.

                    if (!atualizaParametros) break;

                    trocador.TubulacaoAnular.Diametro = nudVarTrocadorDiamAnularDbl;    // Atualiza o trocador
                    AtualizaForms();                                                    // Atualiza o forms
                    break;
                case "nudVarTrocadorDiamInterno":
                    nudTrocadorDiametroInterno.Value = Convert.ToDecimal(x);
                    nudVarTrocadorDiamInternoDbl = x * 1e-2; // Diametro em m.

                    if (!atualizaParametros) break;

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
                case "nudVarFluidoInternoTempSai":
                    return trbVarFluidoInternoTempSai;
                case "nudVarFluidoInternoTemp":
                    return trbVarFluidoInternoTemp;
                case "nudVarFluidoAnularTemp":
                    return trbVarFluidoAnularTemp;
                case "nudVarFluidoAnularTempSai":
                    return trbVarFluidoAnularTempSai;
                case "nudVarTrocadorVazaoQuente":
                    return trbVarTrocadorVazaoQuente;
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
                case "trbVarFluidoInternoTempSai":
                    return nudVarFluidoInternoTempSai;
                case "trbVarFluidoInternoTemp":
                    return nudVarFluidoInternoTemp;
                case "trbVarFluidoAnularTempSai":
                    return nudVarFluidoAnularTempSai;
                case "trbVarFluidoAnularTemp":
                    return nudVarFluidoAnularTemp;
                case "trbVarTrocadorVazaoQuente":
                    return nudVarTrocadorVazaoQuente;
                case "trbVarTrocadorDiamAnular":
                    return nudVarTrocadorDiamAnular;
                case "trbVarTrocadorDiamInterno":
                    return nudVarTrocadorDiamInterno;
                default:
                    throw new Exception($"{trb.Name} nao era esperado");
            }
        }

        private void nudVarFluidoAnularTempSai_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoAnularTempSai_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarFluidoInternoTempSai_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoInternoTempSai_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudTrocadorDiametroAnular_ValueChanged(object sender, EventArgs e)
        {
            if (atualizaParametros)
            {
                AtualizaParDin(nudVarTrocadorDiamAnular, trbVarTrocadorDiamAnular, Convert.ToDouble(nudTrocadorDiametroAnular.Value));
            }
        }

        private void nudTrocadorDiametroInterno_ValueChanged(object sender, EventArgs e)
        {
            if (atualizaParametros)
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

        private void nudVarTrocadorVazaoQuente_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarTrocadorVazaoQuente_Scroll(object sender, EventArgs e)
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
