using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public class TrocadorDuploTubo : EquipamentoOPII
    {
        private TubulacaoDuploTubo tubulacaoAnular;
        private FluidoOPII fluidoAnularEnt;
        private double vazaoAnular;
        private double perdaDePressaoAnular;
        private FluidoTroca anular;
        
        private TubulacaoDuploTubo tubulacaoInterna;
        private FluidoOPII fluidoInternoEnt;
        private double vazaoInterna;
        private double perdaDePressaoExterno;
        private FluidoTroca interno;
        
        private FluidoOPII fluidoAnularSai;
        private FluidoOPII fluidoInternoSai;

        private double comprimento;

        private double areaTroca;
        private double coefTrocaTermGlobal;
        private double colorTransferido;
        private ConfgCorrentes configuracao;

        public TubulacaoDuploTubo TubulacaoAnular { get => tubulacaoAnular; set => tubulacaoAnular = value; }
        public FluidoOPII FluidoAnularEnt { get => fluidoAnularEnt; set => fluidoAnularEnt = value; }
        public double VazaoAnular { get => vazaoAnular; set => vazaoAnular = value; }
        public double PerdaDePressaoAnular { get => perdaDePressaoAnular; }
        public FluidoTroca Anular { get => anular; }
        
        public TubulacaoDuploTubo TubulacaoInterna { get => tubulacaoInterna; set => tubulacaoInterna = value; }
        public FluidoOPII FluidoInternoEnt { get => fluidoInternoEnt; set => fluidoInternoEnt = value; }
        public double VazaoInterna { get => vazaoInterna; set => vazaoInterna = value; }
        public double PerdaDePressaoExterno { get => perdaDePressaoExterno; }
        public FluidoTroca Interno { get => interno; }
        
        public FluidoOPII FluidoAnularSai { get => fluidoAnularSai; }
        public FluidoOPII FluidoInternoSai { get => fluidoInternoSai; }

        public double Comprimento
        {
            get => comprimento;
            set
            {
                comprimento = value;
                tubulacaoAnular.Comprimento = comprimento;
                tubulacaoInterna.Comprimento = comprimento;
            }
        }

        public double AreaTroca
        {
            get
            {
                CalculaAreaDeTroca();
                return areaTroca;
            }
        }
        public double CoefTrocaTermGlobal
        {
            get
            {
                CalculaCoefGlobal();
                return coefTrocaTermGlobal;
            }
        }
        public double ColorTransferido
        {
            get
            {
                CalculaCalorTrans();
                return colorTransferido;
            }
        }

        public ConfgCorrentes Configuracao { get => configuracao; set => configuracao = value; }

        /// <summary>
        /// Constructor para o trocador de calor duplo Tubo.
        /// </summary>
        /// <param name="fluidoAnularEnt">Fluido anular na condição de entrada.</param>
        /// <param name="vazaoAnular">Vazão do fluido anular.</param>
        /// <param name="fluidoInternoEnt">Fluido interno na condição de entrada.</param>
        /// <param name="vazaoInterno">vazão do fluido interno.</param>
        /// <param name="tubulacaoAnular">Tubulação da parte anular.</param>
        /// <param name="tubulacaoInterna">Tubulação da parte interna.</param>
        /// <param name="comprimento">Comprimento do trocador</param>
        /// <param name="confgCorrentes">Configuração das correntes.</param>
        public TrocadorDuploTubo(FluidoOPII fluidoAnularEnt, double vazaoAnular, FluidoOPII fluidoInternoEnt, double vazaoInterno, 
            TubulacaoDuploTubo tubulacaoAnular, TubulacaoDuploTubo tubulacaoInterna, double comprimento, ConfgCorrentes confgCorrentes = ConfgCorrentes.contraCorrente)
        {
            this.fluidoAnularEnt = fluidoAnularEnt ?? throw new ArgumentNullException(nameof(fluidoAnularEnt));
            this.vazaoAnular = (vazaoAnular > 0.0) ? vazaoAnular : throw new ArgumentException(nameof(vazaoAnular));
            this.fluidoInternoEnt = fluidoInternoEnt ?? throw new ArgumentNullException(nameof(fluidoInternoEnt));
            this.vazaoInterna = (vazaoInterno > 0.0) ? vazaoInterno : throw new ArgumentException(nameof(vazaoInterno));
            this.tubulacaoAnular = tubulacaoAnular ?? throw new ArgumentNullException(nameof(tubulacaoAnular));
            this.tubulacaoInterna = tubulacaoInterna ?? throw new ArgumentNullException(nameof(tubulacaoInterna));
            Comprimento = (comprimento > 0.0) ? comprimento : throw new ArgumentException(nameof(comprimento));
            this.configuracao = confgCorrentes;

            if (fluidoAnularEnt.Temperatura > fluidoInternoEnt.Temperatura)
            {
                anular = FluidoTroca.quente;
                interno = FluidoTroca.frio;
            }
            else
            {
                anular = FluidoTroca.frio;
                interno = FluidoTroca.quente;
            }

            if (confgCorrentes == ConfgCorrentes.coCorrente) throw new NotImplementedException(); // Configuração co-corrente não implementada
        }

        /// <summary>
        /// Função principal do trocador que calcula a troca termica e gera os fluidos de saida.
        /// </summary>
        public void CalculaTroca()
        {
            AtualizaCoefGlobal();

            CalculaPerdaCarga(tubulacaoAnular);
            CalculaPerdaCarga(tubulacaoInterna);

            throw new NotImplementedException();
        }

        private double CalculaPerdaCarga(TubulacaoDuploTubo tubo)
        {
            throw new NotImplementedException();
        }
        
        private void AtualizaCoefGlobal()
        {
            double hAnular = CalculaCoefConvec(tubulacaoAnular);
            double hExterno = CalculaCoefConvec(tubulacaoInterna);
            
            throw new NotImplementedException();
        }

        private double CalculaCoefConvec(TubulacaoDuploTubo tubo)
        {
            throw new NotImplementedException();
        }

        private double CalculaAreaDeTroca()
        {
            throw new NotImplementedException();
        }
        
        private void CalculaCoefGlobal()
        {
            throw new NotImplementedException();
        }

        private void CalculaCalorTrans()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Troca de posição os fluidos, o fluido anular passa para a ser o interno e o interno passa a ser o anular. E re-calcula os parametros.
        /// </summary>
        public void TrocaPosicaoFluidos()
        {
            FluidoOPII temp = fluidoInternoEnt.Clone();
            fluidoInternoEnt = fluidoAnularEnt;
            fluidoAnularEnt = temp;

            if (fluidoAnularEnt.Temperatura > fluidoInternoEnt.Temperatura)
            {
                anular = FluidoTroca.quente;
                interno = FluidoTroca.frio;
            }
            else
            {
                anular = FluidoTroca.frio;
                interno = FluidoTroca.quente;
            }

            CalculaTroca();
        }

        /// <summary>
        /// Plot da variação das perdas de cargas dos fluidos anular e interno.
        /// </summary>
        /// <param name="compI">Comprimento do trocador inicial do plot.</param>
        /// <param name="compF">Comprimento do trocador final do plot.</param>
        /// <param name="div">Número de divisões do plot.</param>
        /// <returns>PlotX = Lista dos comprimentos, PlotYAnular = lista das perdas de carga do fluido anular, 
        /// PlotYInterno = lista das perdas de carga do fluido interno.</returns>
        public (List<double> PlotX, List<double> PlotYAnular, List<double> PlotYInterno) PlotPerdaCarga(double compI, double compF ,int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotYAnular = new List<double>();
            List<double> PlotYInterno = new List<double>();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Plot da variação das temperaturas de saida dos fluidos anular e interno.
        /// </summary>
        /// <param name="compI">Comprimento do trocador inicial do plot.</param>
        /// <param name="compF">Comprimento do trocador final do plot.</param>
        /// <param name="div">Número de divisões do plot.</param>
        /// <returns>PlotX = Lista dos comprimentos, PlotYAnular = lista das temperaturas do fluido anular, 
        /// PlotYInterno = lista das temperaturas do fluido interno.</returns>
        public (List<double> PlotX, List<double> PlotYAnular, List<double> PlotYInterno) PlotTemperatura(double compI, double compF, int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotYAnular = new List<double>();
            List<double> PlotYInterno = new List<double>();

            throw new NotImplementedException();
        }
    }
}