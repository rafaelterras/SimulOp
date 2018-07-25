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
        private IMaterialFluidoOPII materialBulckAnular;
        private double tBulckAnular;
        private double vazaoAnular;
        private double perdaDePressaoAnular;
        private FluidoTroca anular;
        
        private TubulacaoDuploTubo tubulacaoInterna;
        private FluidoOPII fluidoInternoEnt;
        private IMaterialFluidoOPII materialBulckInterno;
        private double tBulckInterno;
        private double vazaoInterna;
        private double perdaDePressaoExterno;
        private FluidoTroca interno;
        
        private FluidoOPII fluidoAnularSai;
        private FluidoOPII fluidoInternoSai;

        private double comprimento;
        private double fatorIncrustacao;

        private double areaTroca;
        private double coefTrocaTermGlobal;
        private double calorTransferido;
        private ConfgCorrentes configuracao;

        private const double criterioConvergencia = 1e-4; // Critério de convergencia do trocador

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
        public double FatorIncrustacao { get => fatorIncrustacao; set => fatorIncrustacao = value; }

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
        public double CalorTransferido
        {
            get
            {
                CalculaCalorTrans();
                return calorTransferido;
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
            TubulacaoDuploTubo tubulacaoAnular, TubulacaoDuploTubo tubulacaoInterna, double comprimento, double fatorIncrustacao, 
            ConfgCorrentes confgCorrentes = ConfgCorrentes.contraCorrente)
        {
            this.fluidoAnularEnt = fluidoAnularEnt ?? throw new ArgumentNullException(nameof(fluidoAnularEnt));
            this.vazaoAnular = (vazaoAnular > 0.0) ? vazaoAnular : throw new ArgumentException(nameof(vazaoAnular));
            this.fluidoInternoEnt = fluidoInternoEnt ?? throw new ArgumentNullException(nameof(fluidoInternoEnt));
            this.vazaoInterna = (vazaoInterno > 0.0) ? vazaoInterno : throw new ArgumentException(nameof(vazaoInterno));
            this.tubulacaoAnular = tubulacaoAnular ?? throw new ArgumentNullException(nameof(tubulacaoAnular));
            this.tubulacaoInterna = tubulacaoInterna ?? throw new ArgumentNullException(nameof(tubulacaoInterna));
            Comprimento = (comprimento > 0.0) ? comprimento : throw new ArgumentException(nameof(comprimento));

            this.fatorIncrustacao = fatorIncrustacao;
            this.configuracao = (confgCorrentes == ConfgCorrentes.contraCorrente) ? confgCorrentes : throw new NotImplementedException("Configuração co-corrente não implementada");

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

            materialBulckAnular = fluidoInternoEnt.Material.Clone();
            materialBulckInterno = fluidoInternoEnt.Material.Clone();
        }

        #region Métodos para Cálculo
        /// <summary>
        /// Função principal do trocador que calcula a troca termica e gera os fluidos de saida.
        /// </summary>
        public void CalculaTroca()
        {
            // 1. Calcula a área de troca do trocador
            CalculaAreaDeTroca();

            // 2. Calculo iterativo do coeficiente global de troca
            // 2.1. Assumir uma temperatura de saida dos fluidos
            double tAnularSaiEstimado;
            double tInternoSaiEstimado;

            if (anular == FluidoTroca.quente)
            {
                tAnularSaiEstimado = fluidoInternoEnt.Temperatura * 1.1;
                tInternoSaiEstimado = fluidoAnularEnt.Temperatura * 0.9;
            }
            else
            {
                tAnularSaiEstimado = fluidoInternoEnt.Temperatura * 0.9;
                tInternoSaiEstimado = fluidoAnularEnt.Temperatura * 1.1;
            }

            // 2.2 Estimativa do tBulck
            tBulckAnular = (fluidoAnularEnt.Temperatura + tAnularSaiEstimado) / 2;
            tBulckInterno = (fluidoInternoEnt.Temperatura + tInternoSaiEstimado) / 2;

            // Criação dos fluidos de saida com temperaturas estimadas.
            fluidoAnularSai = new FluidoOPII(fluidoAnularEnt.Material.Clone(), tAnularSaiEstimado);
            fluidoInternoSai = new FluidoOPII(fluidoInternoEnt.Material.Clone(), tInternoSaiEstimado);

            bool convergencia = false;
            int count = 0;

            // 2.3 Loop para convergencia da temperatura
            do
            {
                // Atualiza os materiais com a temperatura bulck estimada.
                materialBulckAnular.Temperatura = tBulckAnular;
                materialBulckInterno.Temperatura = tBulckInterno;

                CalculaCoefGlobal(); // Atualiza os coeficientes de troca termica.
                
                CalculaCalorTrans(); // Calcula o calor transferido entre os fluidos.

                // 2.3.1. Cálculo da nova temperatura estimada de saida e dos tBulcks.
                tAnularSaiEstimado = TemperaturaSaida(materialBulckAnular, anular, vazaoAnular, fluidoAnularEnt.Temperatura);
                tInternoSaiEstimado = TemperaturaSaida(materialBulckInterno, interno, vazaoInterna, fluidoInternoEnt.Temperatura);

                double tBulckAnularEstimado = (tAnularSaiEstimado + fluidoAnularEnt.Temperatura) / 2;
                double tBulckInternoEstimado = (tInternoSaiEstimado + FluidoInternoEnt.Temperatura) / 2;

                // Critério de convergencia (erro < 1e-4)
                if (Math.Abs(tBulckAnularEstimado - tBulckAnular) < criterioConvergencia && Math.Abs(tBulckInternoEstimado - tBulckInterno) < criterioConvergencia)
                {
                    convergencia = true;
                }
                
                tBulckAnular = tBulckAnularEstimado;
                tBulckInterno = tBulckInternoEstimado;

                fluidoAnularSai.Temperatura = tAnularSaiEstimado;
                fluidoInternoSai.Temperatura = tInternoSaiEstimado;

                count++;
                
            } while (convergencia);

            Console.WriteLine($"Número de iterações: {count}");

            // 3. Calculo da perda de carga
            CalculaPerdaCarga(tubulacaoAnular, vazaoAnular);
            CalculaPerdaCarga(tubulacaoInterna, vazaoInterna);
        }

        private double CalculaAreaDeTroca()
        {
            double area = tubulacaoInterna.Diametro * Math.PI * this.comprimento; // TODO: [VERIFICAR UNIDADES!!]

            this.areaTroca = area;

            return area;
        }

        private double CalculaCoefGlobal()
        {
            double hAnular = CalculaCoefConvec(tubulacaoAnular, materialBulckAnular, vazaoAnular);
            double hInterno = CalculaCoefConvec(tubulacaoInterna, materialBulckInterno, vazaoInterna);

            double hTotal = 0;

            // 1/ hT = Sum(1/h)

            hTotal = 1 / ((1 / hAnular) + (1 / hInterno) + (1 / fatorIncrustacao)); // [VERIFICAR !!!]  

            this.coefTrocaTermGlobal = hTotal;

            return hTotal;
        }

        private double CalculaCoefConvec(TubulacaoDuploTubo tubo, IMaterialFluidoOPII materialBulck, double vazao)
        {
            double Ap; // Área do tubo
            double Gp; // Vazão mássica
            double mu; // Cp * 2.42 [Q Q É CP!!!] [lb/(ft*h)] viscosidade dinâmica
            double Re; // Número de Reynolds
            double Jh; // número do gráfico, [verificar se é possivel calcular com outra correlação de Nu e Pr]


            if (tubo.TipoTubo == TipoTubo.interno)
            {
                 
            }
            else
            {

            }
            
            throw new NotImplementedException(); // TODO: Implementar o calculo do coeficiente de convec.
        }

        private double CalculaCalorTrans()
        {
            double calorTrns = areaTroca * coefTrocaTermGlobal * LMTD(); // Q = A * U * dTln 
            // TODO: [VERIFICAR UNIDADES!!]

            this.calorTransferido = calorTrns;

            return calorTrns;
        }

        private double LMTD()
        {
            double dT1 = 0;
            double dT2 = 0;

            // Para Anular = quente e Interno = frio
            if (anular == FluidoTroca.quente)
            {
                dT2 = fluidoAnularEnt.Temperatura - fluidoInternoSai.Temperatura;
                dT1 = fluidoAnularSai.Temperatura - fluidoInternoEnt.Temperatura;
            }
            else if (interno == FluidoTroca.quente)
            {
                dT2 = fluidoInternoEnt.Temperatura - fluidoAnularSai.Temperatura;
                dT1 = fluidoInternoSai.Temperatura - fluidoAnularEnt.Temperatura;
            }

            return (dT2 - dT1) / (Math.Log(dT2 / dT1));
        }

        private double TemperaturaSaida(IMaterialFluidoOPII materialBulck, FluidoTroca fluidoTroca, double vazao, double tempEntrada)
        {
            double tSaida;

            // Q = V * Cp * (Tent - Tsai)

            if (fluidoTroca == FluidoTroca.quente) // Tsai = Tent - Q / (V * Cp)
            {
                tSaida = tempEntrada - (this.calorTransferido / (vazao * materialBulck.CalorEspecifico));
            }
            else // Tsai = Tent + Q / (V * Cp)
            {
                tSaida = tempEntrada + (this.calorTransferido / (vazao * materialBulck.CalorEspecifico));
            }

            return tSaida; // TODO: [VERIFICAR UNIDADES!!]
        }

        private double CalculaPerdaCarga(TubulacaoDuploTubo tubo, double vazao)
        {

     

            throw new NotImplementedException(); // TODO: Implementar o cálculo de perda de carga
        }
        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Troca de posição os fluidos, o fluido anular passa para a ser o interno e o interno passa a ser o anular. E re-calcula os parametros.
        /// </summary>
        public void TrocaPosicaoFluidos()
        {
            FluidoOPII fluidoTemp = fluidoInternoEnt.Clone();
            double vazaoTemp = vazaoInterna;

            fluidoInternoEnt = fluidoAnularEnt;
            vazaoInterna = vazaoAnular;

            fluidoAnularEnt = fluidoTemp;
            vazaoAnular = vazaoTemp;

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

            throw new NotImplementedException(); // TODO: Implementar as funções de plot.
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
        #endregion
    }
}