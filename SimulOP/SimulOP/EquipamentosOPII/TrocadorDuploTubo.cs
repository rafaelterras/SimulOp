using System;
using System.Collections.Generic;

namespace SimulOP
{
    /// <summary>
    /// Classe para representar trocadores de calor do tipo duplo tubo.
    /// </summary>
    public class TrocadorDuploTubo : TrocadordeCalor
    {
        // Variavéis da parte Anular.
        private TubulacaoDuploTubo tubulacaoAnular;
        private FluidoOPII fluidoAnularEnt;
        private IMaterialFluidoOPII materialBulckAnular;
        private double tBulckAnular;
        private FluidoTroca anular;
        private double tempAnularSaida;

        // Variavéis da parte interna.
        private TubulacaoDuploTubo tubulacaoInterna;
        private FluidoOPII fluidoInternoEnt;
        private IMaterialFluidoOPII materialBulckInterno;
        private double tBulckInterno;
        private FluidoTroca interno;
        private double tempInternoSaida;

        private double vazaoQuente;
        private double vazaoFrio;

        // Fluidos de saida.
        private FluidoOPII fluidoAnularSai;
        private FluidoOPII fluidoInternoSai;

        // Outras variaveis do trocador.
        private double comprimento;
        private double fatorIncrustacao;
        private double areaTroca;
        private double coefTrocaTermGlobal;
        private double calorTransferido;
        private ConfgCorrentes configuracao;

        private const double criterioConvergencia = 1e-1; // Critério de convergencia do trocador

        /// <summary>
        /// Tubulação representativa da parte anular do trocador.
        /// </summary>
        public TubulacaoDuploTubo TubulacaoAnular { get => tubulacaoAnular; set => tubulacaoAnular = value; }
        /// <summary>
        /// Fluido que está escoando na parte anular do trocador.
        /// </summary>
        public FluidoOPII FluidoAnularEnt { get => fluidoAnularEnt; set => fluidoAnularEnt = value; }
        /// <summary>
        /// Enum Fluido troca associado ao fluido anular, se é o fluido quente ou frio.
        /// </summary>
        public FluidoTroca Anular { get => anular; }
        /// <summary>
        /// Temperatura de saida do fluido anular [K].
        /// </summary>
        public double TempAnularSaida { get => tempAnularSaida; set => tempAnularSaida = value; }
        /// <summary>
        /// Tubulação representativa da parte interna do trocador.
        /// </summary>
        public TubulacaoDuploTubo TubulacaoInterna { get => tubulacaoInterna; set => tubulacaoInterna = value; }
        /// <summary>
        /// Fluido que está escoando na parte interna do trocador.
        /// </summary>
        public FluidoOPII FluidoInternoEnt { get => fluidoInternoEnt; set => fluidoInternoEnt = value; }
        /// <summary>
        /// Enum Fluido troca associado ao fluido interno, se é o fluido quente ou frio.
        /// </summary>
        public FluidoTroca Interno { get => interno; }
        /// <summary>
        /// Temperatura de saida do fluido interno [K].
        /// </summary>
        public double TempInternoSaida { get => tempInternoSaida; set => tempInternoSaida = value; }
        /// <summary>
        /// Vazão do fluido Qente [m^3/s].
        /// </summary>
        public double VazaoQuente { get => vazaoQuente; set => vazaoQuente = value; }
        /// <summary>
        /// Vazão do fluido Frio [m^3/s].
        /// </summary>
        public double VazaoFrio { get => vazaoFrio; set => vazaoFrio = value; }
        /// <summary>
        /// Fluido de saida da parte anular.
        /// </summary>
        public FluidoOPII FluidoAnularSai { get => fluidoAnularSai; }
        /// <summary>
        /// Fluido de saida da parte interna.
        /// </summary>
        public FluidoOPII FluidoInternoSai { get => fluidoInternoSai; }
        /// <summary>
        /// Comprimento linear do trocado [m].
        /// </summary>
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
        /// <summary>
        /// Fator de incrustação do projeto do trocador.
        /// </summary>
        public double FatorIncrustacao { get => fatorIncrustacao; set => fatorIncrustacao = value; }
        /// <summary>
        /// Área de troca do trocador [m].
        /// </summary>
        public double AreaTroca
        {
            get
            {
                CalculaAreaDeTroca();
                return areaTroca;
            }
        }
        /// <summary>
        /// Coeficiente de troca térmica gobla do trocador. [W/m*ºC]
        /// </summary>
        public double CoefTrocaTermGlobal
        {
            get
            {
                CalculaCoefGlobal();
                return coefTrocaTermGlobal;
            }
        }
        /// <summary>
        /// Calor total transferido pelo trocador.
        /// </summary>
        public double CalorTransferido
        {
            get
            {
                CalculaCalorTrans();
                return calorTransferido;
            }
        }
        /// <summary>
        /// Enum ConfigCorrentes do trocador, se o trocador está na conformação contra ou co corrente.
        /// </summary>
        public ConfgCorrentes Configuracao { get => configuracao; set => configuracao = value; }
     
        /// <summary>
        /// Constructor para o trocador de calor duplo Tubo.
        /// </summary>
        /// <param name="fluidoAnularEnt">Fluido anular na condição de entrada.</param>
        /// <param name="fluidoInternoEnt">Fluido interno na condição de entrada.</param>
        /// <param name="vazaoQuente">vazão do fluido Quente.</param>
        /// <param name="tubulacaoAnular">Tubulação da parte anular.</param>
        /// <param name="tubulacaoInterna">Tubulação da parte interna.</param>
        /// <param name="confgCorrentes">Configuração das correntes.</param>
        public TrocadorDuploTubo(FluidoOPII fluidoAnularEnt, double tempAnularSaida, FluidoOPII fluidoInternoEnt, double tempInternoSaida, double vazaoQuente,
            TubulacaoDuploTubo tubulacaoAnular, TubulacaoDuploTubo tubulacaoInterna, double fatorIncrustacao,
            ConfgCorrentes confgCorrentes = ConfgCorrentes.contraCorrente)
        {
            this.fluidoAnularEnt = fluidoAnularEnt ?? throw new ArgumentNullException(nameof(fluidoAnularEnt));
            this.tempAnularSaida = tempAnularSaida;
            this.fluidoInternoEnt = fluidoInternoEnt ?? throw new ArgumentNullException(nameof(fluidoInternoEnt));
            this.tempInternoSaida = tempInternoSaida;
            this.vazaoQuente = (vazaoQuente > 0.0) ? vazaoQuente : throw new ArgumentException(nameof(vazaoQuente));
            this.tubulacaoAnular = tubulacaoAnular ?? throw new ArgumentNullException(nameof(tubulacaoAnular));
            this.tubulacaoInterna = tubulacaoInterna ?? throw new ArgumentNullException(nameof(tubulacaoInterna));

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
            // 1. Estimativa do tBulck
            materialBulckAnular.Temperatura = (fluidoAnularEnt.Temperatura + tempAnularSaida) / 2.0;
            materialBulckInterno.Temperatura = (fluidoInternoEnt.Temperatura + tempInternoSaida) / 2.0;

            // Criação dos fluidos de saida com temperaturas de saida.
            fluidoAnularSai = new FluidoOPII(fluidoAnularEnt.Material.Clone(), tempAnularSaida);
            fluidoInternoSai = new FluidoOPII(fluidoInternoEnt.Material.Clone(), tempInternoSaida);

            //bool convergencia = false;
            //int count = 0;

            // 2. Cálculo do calor trocado
            CalculaCalorTrans();

            if (anular == FluidoTroca.quente)
            {
                this.vazaoFrio = this.calorTransferido / (materialBulckInterno.Densidade * materialBulckInterno.CalorEspecifico * (tempInternoSaida - fluidoInternoEnt.Temperatura));
            }
            else
            {
                this.vazaoFrio = this.calorTransferido / (materialBulckAnular.Densidade * materialBulckAnular.CalorEspecifico * (tempAnularSaida - fluidoAnularEnt.Temperatura));
            }

            // 3. Cálculo do coeficiente global de troca.
            CalculaCoefGlobal();

            // 4. Cálculo da área de troca necessária.
            CalculaAreaDeTroca();

            // 5. Atualiza o comprimento do trocador
            Comprimento = this.areaTroca / (Math.PI * tubulacaoInterna.Diametro);

            // 6. Calculo da perda de carga
            double vazaoAnular = (anular == FluidoTroca.quente) ? vazaoQuente : vazaoFrio;
            double vazaoInterna = (interno == FluidoTroca.quente) ? vazaoQuente : vazaoFrio;

            CalculaPerdaCarga(tubulacaoAnular, vazaoAnular);
            CalculaPerdaCarga(tubulacaoInterna, vazaoInterna);

            //do
            //{
            //    // Atualiza os materiais com a temperatura bulck estimada.
            //    materialBulckAnular.Temperatura = tBulckAnular;
            //    materialBulckInterno.Temperatura = tBulckInterno;

            //    CalculaCoefGlobal(); // Atualiza os coeficientes de troca termica.

            //    CalculaCalorTrans(); // Calcula o calor transferido entre os fluidos.

            //    // 2.3.1. Cálculo da nova temperatura estimada de saida e dos tBulcks.
            //    tAnularSaiEstimado = TemperaturaSaida(materialBulckAnular, anular, vazaoAnular, fluidoAnularEnt.Temperatura);
            //    tInternoSaiEstimado = TemperaturaSaida(materialBulckInterno, interno, vazaoInterna, fluidoInternoEnt.Temperatura);

            //    double tBulckAnularEstimado = (tAnularSaiEstimado + fluidoAnularEnt.Temperatura) / 2.0;
            //    double tBulckInternoEstimado = (tInternoSaiEstimado + FluidoInternoEnt.Temperatura) / 2.0;

            //    // Critério de convergencia (erro < 1e-1)
            //    if (Math.Abs(tBulckAnularEstimado - tBulckAnular) < criterioConvergencia && Math.Abs(tBulckInternoEstimado - tBulckInterno) < criterioConvergencia)
            //    {
            //        convergencia = true;
            //    }

            //    Console.WriteLine($"err = {Math.Abs(tBulckAnularEstimado - tBulckAnular)}");

            //    tBulckAnular = (tBulckAnular + tBulckAnularEstimado) / 2;
            //    tBulckInterno = (tBulckInterno + tBulckInternoEstimado) / 2;

            //    fluidoAnularSai.Temperatura = tAnularSaiEstimado;
            //    fluidoInternoSai.Temperatura = tInternoSaiEstimado;

            //    count++;

            //} while (!convergencia && count < 200);

            //if (count >= 200)
            //{
            //    Console.WriteLine("===! Nao Convergiu! !===");
            //    Console.ReadLine();
            //    throw new Exception("Erro de convergência no trocador, não convergiu em 200 iterações");
            //}
            //Console.WriteLine($"Número de iterações: {count}");
        }

        /// <summary>
        /// Cálcula o calor total transferido do fluido quente para o fluido frio.
        /// </summary>
        /// <returns>O calor total [W].</returns>
        private double CalculaCalorTrans()
        {
            double calorTrns;

            if (anular == FluidoTroca.quente)
            {
                calorTrns = vazaoQuente * materialBulckAnular.Densidade * materialBulckAnular.CalorEspecifico * (fluidoAnularEnt.Temperatura - tempAnularSaida);
            }
            else
            {
                calorTrns = vazaoQuente * materialBulckInterno.Densidade * materialBulckInterno.CalorEspecifico * (fluidoInternoEnt.Temperatura - tempInternoSaida);
            }

            this.calorTransferido = calorTrns;

            return calorTrns;
        }

        /// <summary>
        /// Cálcula o coeficiente de troca termica global do trocador.
        /// </summary>
        /// <returns>O coeficiente global U [W/m^2*ºC].</returns>
        private double CalculaCoefGlobal()
        {
            double vazaoAnular = (anular == FluidoTroca.quente) ? vazaoQuente : vazaoFrio;
            double vazaoInterna = (interno == FluidoTroca.quente) ? vazaoQuente : vazaoFrio;

            double hAnular = CalculaCoefConvec(tubulacaoAnular, materialBulckAnular, vazaoAnular);
            double hInterno = CalculaCoefConvec(tubulacaoInterna, materialBulckInterno, vazaoInterna);

            double hTotal = 0;

            // 1/ A*hT = Sum(1/A*h)
            double invH;

            invH = (1.0 / hInterno) + (1.0 / hAnular) + this.fatorIncrustacao;
            hTotal = 1.0 / invH;
            hTotal = 1.0 / (1.0 / hTotal);

            this.coefTrocaTermGlobal = hTotal;

            return hTotal;
        }

        /// <summary>
        /// Cálcula o coeficiente de convecção para o fluido em uma dada posição.
        /// </summary>
        /// <param name="tubo">A tubulação que o fluido está escoando.</param>
        /// <param name="materialBulck">Material do fluido na temperatura Tbulck, para cálculo estimado das propriedades.</param>
        /// <param name="vazao">A vazão do fluido.</param>
        /// <returns>O coeficiente de convecção h []</returns>
        private double CalculaCoefConvec(TubulacaoDuploTubo tubo, IMaterialFluidoOPII materialBulck, double vazao)
        {
            double Re; // Número de Reynolds
            double Pr; // Número de Prandtl
            double Nu; // Númeo de Nusselt
            double h; // Coeficiente de convecção

            Re = tubo.CalcReynolds(materialBulck, vazao);
            Pr = materialBulck.CalorEspecifico * materialBulck.Viscosidade / materialBulck.CondutividadeTermica;

            //double diamEqv;

            //// Diametro equivalente para o cálculo do h quando a tubulação é anular.
            //if (tubo.TipoTubo == TipoTubo.anular)
            //{
            //    diamEqv = (Math.Pow(tubo.DiametroExterno, 2.0) - Math.Pow(tubo.DiametroIn, 2.0)) / tubo.DiametroIn;
            //}
            //else
            //{
            //    diamEqv = tubo.Diametro;
            //}                       

            // Correlação é um pouco diferente para o fluido frio e o qente
            if (tubo.TipoTubo == TipoTubo.interno)
            {
                if (Re < 2300.0) // Regime laminar
                {
                    Nu = 1.86 * Math.Pow(Re * Pr * (tubo.Diametro / this.comprimento), 0.33);
                }
                else if (Re >= 2300.0 && Re < 1e4) // Regime intermediario
                {
                    Nu = 0.023 * Math.Pow(Re, 0.8) * Math.Pow(Pr, 0.4) * (1 - (6e5 / Math.Pow(Re, 1.8)));
                }
                else // Regime turbulendo 
                {
                    Nu = 0.023 * Math.Pow(Re, 0.8) * Math.Pow(Pr, 0.4);
                }
            }
            else // Tubo anular
            {
                if (Re < 2300.0) // Regime laminar
                {
                    Nu = 4.05 * Math.Pow(Re, 0.17) * Math.Pow(Pr, 0.33);
                }
                else if (Re >= 2300.0 && Re < 1e4) // Regime intermediario
                {
                    Nu = 1.86 * Math.Pow(Re * Pr * (tubo.Diametro / this.comprimento), 0.33) * (1 - (6e5 / Math.Pow(Re, 1.8)));
                }
                else // Regime turbulendo 
                {
                    Nu = 0.023 * Math.Pow(Re, 0.8) * Math.Pow(Pr, 0.4);
                }
            }

            h = (Nu * materialBulck.CondutividadeTermica) / tubo.Diametro;

           return h;
        }

        /// <summary>
        /// Cálcula a área de troca do trocador.
        /// </summary>
        /// <returns>A área de troca do trocador.</returns>
        private double CalculaAreaDeTroca()
        {
            // Q = U*A*LMTD
            double area = this.calorTransferido / (this.coefTrocaTermGlobal * LMTD());

            this.areaTroca = area;

            return area;
        }

        /// <summary>
        /// Cálcula a média logritimica da diferença de temperatura dos fluidos de troca
        /// </summary>
        /// <returns>O LMTD [ºC].</returns>
        private double LMTD()
        {
            double dT1 = 0;
            double dT2 = 0;
            double LMTD;

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

            LMTD = (dT2 - dT1) / (Math.Log(dT2 / dT1));

            if (double.IsNaN(LMTD))
            {
                if (anular == FluidoTroca.quente)
                {
                    LMTD = ((fluidoAnularEnt.Temperatura + fluidoAnularSai.Temperatura) - (fluidoInternoEnt.Temperatura + fluidoInternoSai.Temperatura)) / 2;
                }
                else
                {
                    LMTD = ((fluidoInternoEnt.Temperatura + fluidoInternoSai.Temperatura) - (fluidoAnularEnt.Temperatura + fluidoAnularSai.Temperatura)) / 2;
                }
                Console.WriteLine($"LMTD aproximado! = {LMTD}");
            }

            return LMTD;
        }

        /// <summary>
        /// Cálcula a temperatura de saida com base no calor total transferido.
        /// </summary>
        /// <param name="materialBulck">Material do fluido na temperatura Tbulck,  para cálculo estimado das propriedades.</param>
        /// <param name="fluidoTroca">Se o fluido é o quente ou o frio.</param>
        /// <param name="vazao">A vazão do fluido [m^3/s].</param>
        /// <param name="tempEntrada">A temperatura de entrada [K].</param>
        /// <returns>A temperatura de saida.</returns>
        private double TemperaturaSaida(IMaterialFluidoOPII materialBulck, FluidoTroca fluidoTroca, double vazao, double tempEntrada)
        {
            double tSaida;

            // Q = V * Cp * (Tent - Tsai)

            if (fluidoTroca == FluidoTroca.quente) // Tsai = Tent - Q / (M * Cp)
            {
                tSaida = tempEntrada - (this.calorTransferido / (vazao * materialBulck.Densidade * materialBulck.CalorEspecifico));
            }
            else // Tsai = Tent + Q / (M * Cp)
            {
                tSaida = tempEntrada + (this.calorTransferido / (vazao * materialBulck.Densidade * materialBulck.CalorEspecifico));
            }

            return tSaida;
        }

        /// <summary>
        /// Calcula a perda de carga dentro do trocador.
        /// </summary>
        /// <param name="tubo">A tubulação para cálculo.</param>
        /// <param name="vazao">A vazão do fluido.</param>
        /// <returns></returns>
        private double CalculaPerdaCarga(TubulacaoDuploTubo tubo, double vazao)
        {
            double dp;

            if(tubo.TipoTubo == TipoTubo.interno)
            {
                dp = tubo.CalculaPerdaCarga(materialBulckInterno, vazao);
            }
            else
            {
                dp = tubo.CalculaPerdaCarga(materialBulckAnular, vazao);
            }

            return dp;
        }
        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Troca de posição os fluidos, o fluido anular passa para a ser o interno e o interno passa a ser o anular. E re-calcula os parametros.
        /// </summary>
        public void TrocaPosicaoFluidos()
        {
            FluidoOPII fluidoTemp = fluidoInternoEnt.Clone();
            double vazaoTemp = this.vazaoQuente;

            this.fluidoInternoEnt = fluidoAnularEnt;
            this.vazaoQuente = this.vazaoFrio;

            this.fluidoAnularEnt = fluidoTemp;
            this.vazaoQuente = vazaoTemp;

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
        /// Plot da variação das perdas de cargas e temperaturas dos fluidos anular e interno.
        /// </summary>
        /// <param name="tSaidaMin">A temperatura de saida do fluido quente inicial do plot.</param>
        /// <param name="tSaidaMax">A temperatura de saida do fluido quente final do plot.</param>
        /// <param name="div">Número de divisões do plot.</param>
        /// <returns>plotX = Lista dos comprimentos, plotPerdaCargaAnularY = lista das perdas de carga do fluido anular, 
        /// plotPerdaCargaInternoY = lista das perdas de carga do fluido interno, plotTempAnularY = lista das temperaturas de saida do fluido anular,
        /// plotTempInternoY = lista das temperaturas de saida do fluido interno.</returns>
        public (List<double> plotX, List<double> plotPerdaCargaAnularY, List<double> plotPerdaCargaInternoY,
            List<double> plotTempAnularY) PlotResultados(double tSaidaMin, double tSaidaMax, int div)
        {
            List<double> plotX = new List<double>();
            List<double> plotPerdaCargaAnularY = new List<double>();
            List<double> plotPerdaCargaInternoY = new List<double>();
            List<double> poltComprimento = new List<double>();

            double tSaida;
            double perdaCargaAnular;
            double perdaCargaInterno;
            double comprimento;

            for (int i = 0; i <= div; i++)
            {
                tSaida = tSaidaMin + i * (tSaidaMax - tSaidaMin) / div;

                tSaida = tSaida + 273.15;

                if (anular == FluidoTroca.quente)
                {
                    tempAnularSaida = tSaida;
                }
                else
                {
                    tempInternoSaida = tSaida;
                }

                CalculaTroca();

                perdaCargaAnular = this.tubulacaoAnular.PerdaCarga;
                perdaCargaInterno = this.tubulacaoInterna.PerdaCarga;
                comprimento = this.comprimento;

                plotX.Add(tSaida - 273.15); // T em K
                plotPerdaCargaAnularY.Add(perdaCargaAnular * 1e-3); // P em KPa.
                plotPerdaCargaInternoY.Add(perdaCargaInterno * 1e-3); // P em KPa.
                poltComprimento.Add(comprimento); // L em m
            }

            return (plotX, plotPerdaCargaAnularY, plotPerdaCargaInternoY, poltComprimento);
        }
        #endregion
    }
}