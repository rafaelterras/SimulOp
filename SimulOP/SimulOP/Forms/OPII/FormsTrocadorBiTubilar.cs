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
    public partial class FormsTrocadorBiTubilar : Form
    {
        // Objetos para o cálculo do trocador
        TrocadorDuploTubo trocador;






        string[] txbFigFluidoAnularTxt;
        string[] txbFigFluidoExternoTxt;
        
        public FormsTrocadorBiTubilar()
        {
            InitializeComponent();

            txbFigFluidoAnularTxt = txbFigFluidoAnular.Lines;
            txbFigFluidoExternoTxt = txbFigFluidoExterno.Lines;
        }

        private void btnTrocaFluidos_Click(object sender, EventArgs e)
        {
            string temp;

            for (int i = 1; i < txbFigFluidoAnularTxt.Length; i++)
            {
                temp = txbFigFluidoAnularTxt[i];
                txbFigFluidoAnularTxt[i] = txbFigFluidoExternoTxt[i];
                txbFigFluidoExternoTxt[i] = temp;
            }

            txbFigFluidoAnular.Lines = txbFigFluidoAnularTxt;
            txbFigFluidoExterno.Lines = txbFigFluidoExternoTxt;

            // TODO: Atualizar os resultados
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            chartPerdaCarga.Series["fluidoFrio"].Points.DataBindXY(new double[] { 0, 0.5, 1 }, new double[] { 0, 50, 80 });
            chartTemperatura.Series["temperatura"].Points.DataBindXY(new double[] { 0, 0.5, 1 }, new double[] { 0, 50, 80 });
        }

        private void EventosInputs(bool ativar)
        {
            if (ativar)
            {
                nudVarFluidoFrioVazao.ValueChanged      += nudVarFluidoFrioVazao_ValueChanged;
                trbVarFluidoFrioVazao.Scroll            += trbVarFluidoFrioVazao_Scroll;
                nudVarFluidoFrioTemp.ValueChanged       += nudVarFluidoFrioTemp_ValueChanged;
                trbVarFluidoFrioTemp.Scroll             += trbVarFluidoFrioTemp_Scroll;
                nudVarFluidoQuenteVazao.ValueChanged    += nudVarFluidoQuenteVazao_ValueChanged;
                trbVarFluidoQuenteVazao.Scroll          += trbVarFluidoQuenteVazao_Scroll;
                nudVarFluidoQuenteTemp.ValueChanged     += nudVarFluidoQuenteTemp_ValueChanged;
                trbVarFluidoQuenteTemp.Scroll           += trbVarFluidoQuenteTemp_Scroll;
                nudVarTrocadorComprimento.ValueChanged  += nudVarTrocadorComprimento_ValueChanged;
                trbVarTrocadorComprimento.Scroll        += trbVarTrocadorComprimento_Scroll;
                nudVarTrocadorDiamAnular.ValueChanged   += nudVarTrocadorDiamAnular_ValueChanged;
                trbVarTrocadorDiamAnular.Scroll         += trbVarTrocadorDiamAnular_Scroll;
                nudVarTrocadorDiamInterno.ValueChanged  += nudVarTrocadorDiamExterno_ValueChanged;
                trbVarTrocadorDiamInterno.Scroll        += trbVarTrocadorDiamExterno_Scroll;
            }
            else
            {
                nudVarFluidoFrioVazao.ValueChanged      -= nudVarFluidoFrioVazao_ValueChanged;
                trbVarFluidoFrioVazao.Scroll            -= trbVarFluidoFrioVazao_Scroll;
                nudVarFluidoFrioTemp.ValueChanged       -= nudVarFluidoFrioTemp_ValueChanged;
                trbVarFluidoFrioTemp.Scroll             -= trbVarFluidoFrioTemp_Scroll;
                nudVarFluidoQuenteVazao.ValueChanged    -= nudVarFluidoQuenteVazao_ValueChanged;
                trbVarFluidoQuenteVazao.Scroll          -= trbVarFluidoQuenteVazao_Scroll;
                nudVarFluidoQuenteTemp.ValueChanged     -= nudVarFluidoQuenteTemp_ValueChanged;
                trbVarFluidoQuenteTemp.Scroll           -= trbVarFluidoQuenteTemp_Scroll;
                nudVarTrocadorComprimento.ValueChanged  -= nudVarTrocadorComprimento_ValueChanged;
                trbVarTrocadorComprimento.Scroll        -= trbVarTrocadorComprimento_Scroll;
                nudVarTrocadorDiamAnular.ValueChanged   -= nudVarTrocadorDiamAnular_ValueChanged;
                trbVarTrocadorDiamAnular.Scroll         -= trbVarTrocadorDiamAnular_Scroll;
                nudVarTrocadorDiamInterno.ValueChanged  -= nudVarTrocadorDiamExterno_ValueChanged;
                trbVarTrocadorDiamInterno.Scroll        -= trbVarTrocadorDiamExterno_Scroll;
            }
        }

        #region Variaveis Dinamicas

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
                case "nudVarFluidoFrioVazao":

                    break;
                case "nudVarFluidoFrioTemp":

                    break;
                case "nudVarFluidoQuenteVazao":

                    break;
                case "nudVarFluidoQuenteTemp":

                    break;
                case "nudVarTrocadorComprimento":
                    nudTrocadorComprimento.Value = Convert.ToDecimal(x);
                    break;
                case "nudVarTrocadorDiamAnular":
                    nudTrocadorDiametroAnular.Value = Convert.ToDecimal(x);
                    break;
                case "nudVarTrocadorDiamInterno":
                    nudTrocadorDiametroInterno.Value = Convert.ToDecimal(x);
                    break;
                default:
                    break;
            }

            // Re-inscreve-se aos eventos
            EventosInputs(true);
        }

        private TrackBar ParTrb(NumericUpDown nud)
        {
            switch (nud.Name)
            {
                case "nudVarFluidoFrioVazao":
                    return trbVarFluidoFrioVazao;
                case "nudVarFluidoFrioTemp":
                    return trbVarFluidoFrioTemp;
                case "nudVarFluidoQuenteVazao":
                    return trbVarFluidoQuenteVazao;
                case "nudVarFluidoQuenteTemp":
                    return trbVarFluidoQuenteTemp;
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

        private NumericUpDown ParNud(TrackBar trb)
        {
            switch (trb.Name)
            {
                case "trbVarFluidoFrioVazao":
                    return nudVarFluidoFrioVazao;
                case "trbVarFluidoFrioTemp":
                    return nudVarFluidoFrioTemp;
                case "trbVarFluidoQuenteVazao":
                    return nudVarFluidoQuenteVazao;
                case "trbVarFluidoQuenteTemp":
                    return nudVarFluidoQuenteTemp;
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

        private void nudVarFluidoFrioVazao_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoFrioVazao_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarFluidoFrioTemp_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoFrioTemp_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarFluidoQuenteVazao_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoQuenteVazao_Scroll(object sender, EventArgs e)
        {
            TrackBar trb = (TrackBar)sender;
            NumericUpDown nud = ParNud(trb);

            double x = Convert.ToDouble(nud.Minimum) +
                 (Convert.ToDouble(nud.Maximum) - Convert.ToDouble(nud.Minimum))
                 * Convert.ToDouble(trb.Value) / Convert.ToDouble(trb.Maximum);

            AtualizaParDin(nud, trb, x);
        }

        private void nudVarFluidoQuenteTemp_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            AtualizaParDin(nud, ParTrb(nud), Convert.ToDouble(nud.Value));
        }

        private void trbVarFluidoQuenteTemp_Scroll(object sender, EventArgs e)
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
    }
}
