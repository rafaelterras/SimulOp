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
    public partial class FomrsBombeamentoCompleto : Form
    {
        // Objetos para cálculo da bomba
        private FluidoIdealOPIII fluido;
        private Tubulacao tubulacaoSuccao;
        private Singularidade singEqvSuc;
        private Valvula valvulaSuc;
        private Tubulacao tubulacaoDescarga;
        private Singularidade singEqvDes;
        private Valvula valvulaDes;
        private BombaCompleta bomba;

        // Listas para Plot
        private List<double> AlturaBombaX = new List<double>();
        private List<double> AlturaBombaY = new List<double>();
        private List<double> NPSHX = new List<double>();
        private List<double> NPSHY = new List<double>();

        // Strings e doubles da UI
        // -> Fluido
        private string cmbFluidoNomeTxt;
        private double nudFluidoDensidadeDbl;
        private double nudFluidoViscosidadeDbl;
        private double nudFluidoTemperaturaDbl;
        private double nudFluidoPressaoDbl;
        // -> Tubulação de Succao
        private double nudTubSucComprimentoDbl;
        private double nudTubSucElevacaoDbl;

        private string cmbTubSucMaterialTxt;
        private string cmbTubSucSchTxt;
        private string cmbTubSucDiametroExtTxt;
        private double nudTubSucRugosidadeDbl;
        private double nudTubSucDiametroIntDbl;
        private double nudTubSucCompSingDbl;
        // -> Tubulação de Descarga
        private double nudTubDesComprimentoDbl;
        private double nudTubDesElevacaoDbl;

        private string cmbTubDesMaterialTxt;
        private string cmbTubDesSchTxt;
        private string cmbTubDesDiametroExtTxt;
        private double nudTubDesRugosidadeDbl;
        private double nudTubDesDiametroIntDbl;
        private double nudTubDesCompSingDbl;

        private double nudVazaoDesejadaDbl;

        public FomrsBombeamentoCompleto()
        {
            InitializeComponent();
        }

        private void EventosInputs(bool ativar)
        {
            if (ativar)
            {
                nudVazaoDesejada.ValueChanged += nudVazaoDesejada_ValueChanged;
                trbVazaoDesejada.Scroll += trbVazaoDesejada_Scroll;
                nudAberturaValvulaSuc.ValueChanged += nudAberturaValvulaSuc_ValueChanged;
                trbAberturaValvulaSuc.Scroll += trbAberturaValvulaSuc_Scroll;
                nudAberturaValvulaDes.ValueChanged += nudAberturaValvulaDes_ValueChanged;
                trbAberturaValvulaDes.Scroll += trbAberturaValvulaDes_Scroll;
                nudFluidoTemperaturaDin.ValueChanged += nudFluidoTemperaturaDin_ValueChanged;
                trbFluidoTemperaturaDin.Scroll += trbFluidoTemperaturaDin_Scroll;
                nudFluidoPressaoDin.ValueChanged += nudFluidoPressaoDin_ValueChanged;
                trbFluidoPressaoDin.Scroll += trbFluidoPressaoDin_Scroll;
            }
            else
            {
                nudVazaoDesejada.ValueChanged -= nudVazaoDesejada_ValueChanged;
                trbVazaoDesejada.Scroll -= trbVazaoDesejada_Scroll;
                nudAberturaValvulaSuc.ValueChanged -= nudAberturaValvulaSuc_ValueChanged;
                trbAberturaValvulaSuc.Scroll -= trbAberturaValvulaSuc_Scroll;
                nudAberturaValvulaDes.ValueChanged -= nudAberturaValvulaDes_ValueChanged;
                trbAberturaValvulaDes.Scroll -= trbAberturaValvulaDes_Scroll;
                nudFluidoTemperaturaDin.ValueChanged -= nudFluidoTemperaturaDin_ValueChanged;
                trbFluidoTemperaturaDin.Scroll -= trbFluidoTemperaturaDin_Scroll;
                nudFluidoPressaoDin.ValueChanged -= nudFluidoPressaoDin_ValueChanged;
                trbFluidoPressaoDin.Scroll-= trbFluidoPressaoDin_Scroll;
            }
        }

        private void btnTubSucCopia_Click(object sender, EventArgs e)
        {
            cmbTubDesMaterial.Text = cmbTubSucMaterial.Text;
            cmbTubDesSch.Text = cmbTubSucSch.Text;
            cmbTubDesDiametroExt.Text = cmbTubSucDiametroExt.Text;
            nudTubDesRugosidade.Value = nudTubSucRugosidade.Value;
            nudTubDesDiametroInt.Value = nudTubSucDiametroInt.Value;
            nudTubDesCompSing.Value = nudTubSucCompSing.Value;

            cmbTubDesMaterialTxt = cmbTubDesMaterial.Text;
            cmbTubDesSchTxt = cmbTubDesSch.Text;
            cmbTubDesDiametroExtTxt = cmbTubDesDiametroExt.Text;
            nudTubDesRugosidadeDbl = Convert.ToDouble(nudTubDesRugosidade.Value);
            nudTubDesDiametroIntDbl = Convert.ToDouble(nudTubDesDiametroInt.Value);
            nudTubDesCompSingDbl = Convert.ToDouble(nudTubDesCompSing.Value);
        }

        private void AtualizaNPSHDisp()
        {
            NPSHX.Clear();
            NPSHY.Clear();
            chartNPSHDisp.Series["NPSHDisp"].Points.Clear();

            (NPSHX, NPSHY) = bomba.PlotNPSHDisponivel(0.01, 2.0);

            chartNPSHDisp.Series["NPSHDisp"].Points.DataBindXY(NPSHX, NPSHY);

            AtualizaVazaoDesejada(nudVazaoDesejadaDbl);
        }

        private void AtualizaHBomba()
        {
            AlturaBombaX.Clear();
            AlturaBombaY.Clear();
            chartPerdaCarga.Series["AlturaBomba"].Points.Clear();

            (AlturaBombaX, AlturaBombaY) = bomba.PlotAlturaBomba(0.01, 2.0);

            chartPerdaCarga.Series["AlturaBomba"].Points.DataBindXY(AlturaBombaX, AlturaBombaY);

            AtualizaVazaoDesejada(nudVazaoDesejadaDbl);
        }

        private void AtualizaVazaoDesejada(double x)
        {
            chartPerdaCarga.Series["LinhaVazao"].Points.Clear();
            chartNPSHDisp.Series["LinhaVazao"].Points.Clear();

            double hBomba = bomba.CalculaAlturaManoRequerida(x);

            chartPerdaCarga.Series["LinhaVazao"].Points.DataBindXY(new double[] { x, x }, new double[] { 0, hBomba });

            double NPSHBomba = bomba.NPSHDisponivel(x);

            chartNPSHDisp.Series["LinhaVazao"].Points.DataBindXY(new double[] { x, x }, new double[] { 0, NPSHBomba });

            txbResultadoAlturaBomba.Text = $"{Math.Round(hBomba,2)}";
            txbResultadoNPSHDisp.Text = $"{Math.Round(NPSHBomba, 2)}";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (true)
            {
                // -> Fluido
                cmbFluidoNomeTxt = cmbFluidoNome.Text;
                nudFluidoDensidadeDbl = Convert.ToDouble(nudFluidoDensidade.Value);
                nudFluidoViscosidadeDbl = Convert.ToDouble(nudFluidoViscosidade.Value);
                nudFluidoTemperaturaDbl = Convert.ToDouble(nudFluidoTemperatura.Value) + 273.15; // Temperatura em K
                nudFluidoPressaoDbl = Convert.ToDouble(nudFluidoPressao.Value) * 1e5; // Pressão em Pa
                fluido = new FluidoIdealOPIII(InicializadorObjetos.MaterialFluidoOPIII(cmbFluidoNomeTxt), nudFluidoTemperaturaDbl);

                // -> Tubulação de Sucção
                nudTubSucRugosidadeDbl = Convert.ToDouble(nudTubSucRugosidade.Value) * 1e-2;
                nudTubSucDiametroIntDbl = Convert.ToDouble(nudTubSucDiametroInt.Value) * 1e-2;
                nudTubSucCompSingDbl = Convert.ToDouble(nudTubSucCompSing.Value);
                singEqvSuc = new Singularidade(nudTubSucCompSingDbl, "Equivalente");
                nudTubSucComprimentoDbl = Convert.ToDouble(nudTubSucComprimento.Value);
                nudTubSucElevacaoDbl = Convert.ToDouble(nudTubSucElevacao.Value);
                tubulacaoSuccao = new Tubulacao(nudTubSucDiametroIntDbl, nudTubSucComprimentoDbl, nudTubSucRugosidadeDbl, nudTubSucElevacaoDbl, "haaland");
                tubulacaoSuccao.AdicionaSingularidade(singEqvSuc);
                // Valvula da sucção
                valvulaSuc = new Valvula(2, 1000);
                tubulacaoSuccao.AdicionaSingularidade(valvulaSuc);

                // -> Tubulação de Descarga
                nudTubDesRugosidadeDbl = Convert.ToDouble(nudTubDesRugosidade.Value) * 1e-2;
                nudTubDesDiametroIntDbl = Convert.ToDouble(nudTubDesDiametroInt.Value) * 1e-2;
                nudTubDesCompSingDbl = Convert.ToDouble(nudTubDesCompSing.Value);
                singEqvDes = new Singularidade(nudTubDesCompSingDbl, "Equivalente");
                nudTubDesComprimentoDbl = Convert.ToDouble(nudTubDesComprimento.Value);
                nudTubDesElevacaoDbl = Convert.ToDouble(nudTubDesElevacao.Value);
                tubulacaoDescarga = new Tubulacao(nudTubDesDiametroIntDbl, nudTubDesComprimentoDbl, nudTubDesRugosidadeDbl, nudTubDesElevacaoDbl, "haaland");
                tubulacaoDescarga.AdicionaSingularidade(singEqvDes);
                // Valvula da descarga
                valvulaDes = new Valvula(2, 3000);
                tubulacaoDescarga.AdicionaSingularidade(valvulaDes);

                // Bomba
                bomba = new BombaCompleta(new double[3] { 0, 0, 0 }, fluido, tubulacaoSuccao, tubulacaoDescarga, nudFluidoPressaoDbl, 2);

                nudVazaoDesejada.Value = Convert.ToDecimal(0.5);
                nudAberturaValvulaSuc.Value = Convert.ToDecimal(1.0);
                nudAberturaValvulaDes.Value = Convert.ToDecimal(1.0);
                nudFluidoTemperaturaDin.Value = Convert.ToDecimal(nudFluidoTemperaturaDbl - 273.15);
                nudFluidoPressaoDin.Value = Convert.ToDecimal(nudFluidoPressaoDbl * 1e-5);

                AtualizaHBomba();
                AtualizaNPSHDisp();
            }
        }
        
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
                case "nudVazaoDesejada": // Mudança na vazão desejada
                    nudVazaoDesejadaDbl = x;
                    AtualizaVazaoDesejada(x);
                    break;
                case "nudAberturaValvulaSuc": // Mudança na abertura da valvula de sucção
                    valvulaSuc.Abertura = x;
                    AtualizaHBomba();
                    AtualizaNPSHDisp();
                    break;
                case "nudAberturaValvulaDes": // Mudança na abertura da valvula de descarga
                    valvulaDes.Abertura = x;
                    AtualizaHBomba();
                    break;
                case "nudFluidoTemperaturaDin": // Mudança da temperatura do fluido
                    fluido.Temperatura = x + 273.15;
                    AtualizaNPSHDisp();
                    break;
                case "nudFluidoPressaoDin": // Mudança na pressão do fluido
                    bomba.PressaoSuccao = x * 1e5;
                    AtualizaNPSHDisp();
                    AtualizaHBomba();
                    break;
                default:
                    throw new Exception($"{nud.Name} nao era esperado!");
            }

            // Re-inscreve-se aos eventos
            EventosInputs(true);
        }
        
        #region Vazão Desejada
        private void nudVazaoDesejada_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudVazaoDesejada, trbVazaoDesejada, Convert.ToDouble(nudVazaoDesejada.Value));
        }

        private void trbVazaoDesejada_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudVazaoDesejada.Minimum) +
                (Convert.ToDouble(nudVazaoDesejada.Maximum) - Convert.ToDouble(nudVazaoDesejada.Minimum))
                * Convert.ToDouble(trbVazaoDesejada.Value) / Convert.ToDouble(trbVazaoDesejada.Maximum);

            AtualizaParDin(nudVazaoDesejada, trbVazaoDesejada, x);
        }
        #endregion

        #region Abertura Valvula Sucção
        private void nudAberturaValvulaSuc_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudAberturaValvulaSuc, trbAberturaValvulaSuc, Convert.ToDouble(nudAberturaValvulaSuc.Value));
        }

        private void trbAberturaValvulaSuc_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudAberturaValvulaSuc.Minimum) +
                (Convert.ToDouble(nudAberturaValvulaSuc.Maximum) - Convert.ToDouble(nudAberturaValvulaSuc.Minimum))
                * Convert.ToDouble(trbAberturaValvulaSuc.Value) / Convert.ToDouble(trbAberturaValvulaSuc.Maximum);

            AtualizaParDin(nudAberturaValvulaSuc, trbAberturaValvulaSuc, x);
        }
        #endregion

        #region Abertura Valvula Descarga
        private void nudAberturaValvulaDes_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudAberturaValvulaDes, trbAberturaValvulaDes, Convert.ToDouble(nudAberturaValvulaDes.Value));
        }

        private void trbAberturaValvulaDes_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudAberturaValvulaDes.Minimum) +
                (Convert.ToDouble(nudAberturaValvulaDes.Maximum) - Convert.ToDouble(nudAberturaValvulaDes.Minimum))
                * Convert.ToDouble(trbAberturaValvulaDes.Value) / Convert.ToDouble(trbAberturaValvulaDes.Maximum);

            AtualizaParDin(nudAberturaValvulaDes, trbAberturaValvulaDes, x);
        }
        #endregion

        #region Temperatura do Fluido
        private void nudFluidoTemperaturaDin_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudFluidoTemperaturaDin, trbFluidoTemperaturaDin, Convert.ToDouble(nudFluidoTemperaturaDin.Value));
        }

        private void trbFluidoTemperaturaDin_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudFluidoTemperaturaDin.Minimum) +
                (Convert.ToDouble(nudFluidoTemperaturaDin.Maximum) - Convert.ToDouble(nudFluidoTemperaturaDin.Minimum))
                * Convert.ToDouble(trbFluidoTemperaturaDin.Value) / Convert.ToDouble(trbFluidoTemperaturaDin.Maximum);

            AtualizaParDin(nudFluidoTemperaturaDin, trbFluidoTemperaturaDin, x);
        }
        #endregion

        #region Pressão do Fluido
        private void nudFluidoPressaoDin_ValueChanged(object sender, EventArgs e)
        {
            AtualizaParDin(nudFluidoPressaoDin, trbFluidoPressaoDin, Convert.ToDouble(nudFluidoPressaoDin.Value));
        }

        private void trbFluidoPressaoDin_Scroll(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(nudFluidoPressaoDin.Minimum) +
                (Convert.ToDouble(nudFluidoPressaoDin.Maximum) - Convert.ToDouble(nudFluidoPressaoDin.Minimum))
                * Convert.ToDouble(trbFluidoPressaoDin.Value) / Convert.ToDouble(trbFluidoPressaoDin.Maximum);

            AtualizaParDin(nudFluidoPressaoDin, trbFluidoPressaoDin, x);
        }
        #endregion

        #region Comprimentos e alturas das tubulações
        private void nudTubSucElevacao_ValueChanged(object sender, EventArgs e)
        {
            nudTubSucElevacaoDbl = Convert.ToDouble(nudTubSucElevacao.Value);
            tubulacaoSuccao.Elevacao = nudTubSucElevacaoDbl;
            AtualizaHBomba();
            AtualizaNPSHDisp();
        }

        private void nudTubSucComprimento_ValueChanged(object sender, EventArgs e)
        {
            nudTubSucComprimentoDbl = Convert.ToDouble(nudTubSucComprimento.Value);
            tubulacaoSuccao.Comprimento = nudTubSucComprimentoDbl;
            AtualizaHBomba();
            AtualizaNPSHDisp();
        }

        private void nudTubDesComprimento_ValueChanged(object sender, EventArgs e)
        {
            nudTubDesComprimentoDbl = Convert.ToDouble(nudTubDesComprimento.Value);
            tubulacaoDescarga.Comprimento = nudTubDesComprimentoDbl;
            AtualizaHBomba();
        }

        private void nudTubDesElevacao_ValueChanged(object sender, EventArgs e)
        {
            nudTubDesElevacaoDbl = Convert.ToDouble(nudTubDesElevacao.Value);
            tubulacaoDescarga.Elevacao = nudTubDesElevacaoDbl;
            AtualizaHBomba();
        }
        #endregion
    }
}
