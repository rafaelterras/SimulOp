using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public class TrocadorDuploTubo : EquipamentoOPII
    {
        private FluidoOPII fluidoAnularEnt;
        private double vazaoAnular;
        private double perdaDePressaoAnular;
        private FluidoOPII fluidoExternoEnt;
        private double vazaoExterno;
        private double perdaDePressaoExterno;

        private FluidoOPII fluidoAnularSai;
        private FluidoOPII fluidoExternoSai;

        private Tubulacao tubulacaoAnular;
        private Tubulacao tubulacaoExterna;
        private double comprimento;

        private double coefTrocaTermGlobal;
        private double areaTroca;
        private ConfgCorrentes configuracao;
        private double colorTransferido;

        public FluidoOPII FluidoAnularEnt { get => fluidoAnularEnt; set => fluidoAnularEnt = value; }
        public double VazaoAnular { get => vazaoAnular; set => vazaoAnular = value; }
        public double PerdaDePressaoAnular { get => perdaDePressaoAnular; }
        public FluidoOPII FluidoExternoEnt { get => fluidoExternoEnt; set => fluidoExternoEnt = value; }
        public double VazaoExterno { get => vazaoExterno; set => vazaoExterno = value; }
        public double PerdaDePressaoExterno { get => perdaDePressaoExterno; }

        public FluidoOPII FluidoAnularSai { get => fluidoAnularSai; }
        public FluidoOPII FluidoExternoSai { get => fluidoExternoSai; }

        public Tubulacao TubulacaoAnular { get => tubulacaoAnular; set => tubulacaoAnular = value; }
        public Tubulacao TubulacaoExterna { get => tubulacaoExterna; set => tubulacaoExterna = value; }
        public double Comprimento
        {
            get => comprimento;
            set
            {
                comprimento = value;
                tubulacaoAnular.Comprimento = comprimento;
                tubulacaoExterna.Comprimento = comprimento;
            }
        }

        public double CoefTrocaTermGlobal { get => coefTrocaTermGlobal; }
        public double AreaTroca { get => areaTroca;  }
        public double ColorTransferido { get => colorTransferido; }
        public ConfgCorrentes Configuracao { get => configuracao; set => configuracao = value; }

        public TrocadorDuploTubo(FluidoOPII fluidoQenteEnt, double vazaoAnular, FluidoOPII fluidoFrioEnt, double vazaoExterno, 
            Tubulacao tubulacaoAnular, Tubulacao tubulacaoExterna, double comprimento, ConfgCorrentes confgCorrentes = ConfgCorrentes.ContraCorrente)
        {
            this.fluidoAnularEnt = fluidoQenteEnt ?? throw new ArgumentNullException(nameof(fluidoQenteEnt));
            this.vazaoAnular = vazaoAnular;
            this.fluidoExternoEnt = fluidoFrioEnt ?? throw new ArgumentNullException(nameof(fluidoFrioEnt));
            this.vazaoExterno = vazaoExterno;
            this.tubulacaoAnular = tubulacaoAnular ?? throw new ArgumentNullException(nameof(tubulacaoAnular));
            this.tubulacaoExterna = tubulacaoExterna ?? throw new ArgumentNullException(nameof(tubulacaoExterna));
            Comprimento = comprimento;
            this.configuracao = confgCorrentes;
        }

        // TODO
        public void CalculaTroca()
        {
            AtualizaCoefGlobal();

            CalculaPerdaCarga("anular");
            CalculaPerdaCarga("externo");

            throw new NotImplementedException();
        }

        private double CalculaPerdaCarga(string pos)
        {
            throw new NotImplementedException();
        }


        private void AtualizaCoefGlobal()
        {
            double hAnular = CalculaCoefConvec("anular");
            double hExterno = CalculaCoefConvec("externo");


            throw new NotImplementedException();
        }

        private double CalculaCoefConvec(string pos)
        {
            throw new NotImplementedException();
        }

        public void TrocaPosicaoFluidos()
        {
            FluidoOPII temp = fluidoExternoEnt.Clone();
            fluidoExternoEnt = fluidoAnularEnt;
            fluidoAnularEnt = temp;

            CalculaTroca();
        }

        public (List<double> PlotX, List<double> PlotYAnular, List<double> PlotYExterno) PlotPerdaCarga(double vInical, double vFinal ,int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotYAnular = new List<double>();
            List<double> PlotYExterno = new List<double>();

            throw new NotImplementedException();
        }

        public (List<double> PlotX, List<double> PlotYAnular, List<double> PlotYExterno) PlotTemperatura(double vInical, double vFinal, int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotYAnular = new List<double>();
            List<double> PlotYExterno = new List<double>();

            throw new NotImplementedException();
        }

    }
}