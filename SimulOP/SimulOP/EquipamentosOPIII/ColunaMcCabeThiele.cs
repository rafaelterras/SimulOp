using System;
using System.Collections.Generic;

namespace SimulOP
{
    /// <summary>
    /// Classe para representar o método gráfico de McCabe-Thiele para estimar uma coluna de absorção.
    /// </summary>
    public class ColunaMcCabeThiele : EquipamentoOPIII
    {
        #region Inicialização das variaveis e dos constructors
        private MisturaBinaria misturaBinaria;
        private double targetXD;
        private double targetXB;
        private double feedZF;
        private double feedConditionQ;
        private double refluxRatio;

        private double[] pontoP;

        /// <summary>
        /// Mistura binária que será separada na coluna.
        /// </summary>
        public MisturaBinaria MisturaBinaria { get => misturaBinaria; set => misturaBinaria = value; }
        /// <summary>
        /// Fração molar desejada do LK no destilado.
        /// </summary>
        public double TargetXD { get => targetXD; set => targetXD = value; }
        /// <summary>
        /// Fração molar desejada do LK no fundo.
        /// </summary>
        public double TargetXB { get => targetXB; set => targetXB = value; }
        /// <summary>
        /// Fração molar do LK na estrada da coluna.
        /// </summary>
        public double FeedZF { get => feedZF; set => feedZF = value; }
        /// <summary>
        /// Condição q da entrada, representa o estado de saturação/superaquecimento/sub-resfriamento da mistura de entrada.
        /// </summary>
        public double FeedConditionQ { get => feedConditionQ; set => feedConditionQ = value; }
        /// <summary>
        /// Taxa de refluxo molar de operação da coluna.
        /// </summary>
        public double RefluxRatio { get => refluxRatio; set => refluxRatio = value; }
        /// <summary>
        /// Ponto de intersecção entre a reta q e as curvas de operações.
        /// </summary>
        public double[] PontoP { get => pontoP; }

        /// <summary>
        /// Constructor para a coluna de destilação.
        /// </summary>
        /// <param name="misturaBinaria">Mistura que será separada.</param>
        /// <param name="targetXD">Fração molar desejada do LK no destilado.</param>
        /// <param name="targetXB">Fração molar desejada do LK no fundo.</param>
        /// <param name="feedZF">Fração molar do LK na entrada da coluna.</param>
        /// <param name="refluxRatio">Taxa de refluxo molar de operação da coluna.</param>
        /// <param name="feedConditionQ">Condição q da entrada.</param>
        public ColunaMcCabeThiele(MisturaBinaria misturaBinaria, double targetXD, double targetXB, double feedZF, double refluxRatio, double feedConditionQ)
        {
            this.misturaBinaria = misturaBinaria ?? throw new ArgumentNullException(nameof(misturaBinaria));
            this.targetXB = targetXB;
            this.targetXD = targetXD;
            this.feedZF = feedZF;
            this.refluxRatio = refluxRatio;
            this.feedConditionQ = feedConditionQ;
            CalculaPontoP();
        }

        /// <summary>
        /// Constructor para a coluna de destilação.
        /// </summary>
        /// <param name="misturaBinaria">Mistura que será separada.</param>
        /// <param name="targetXD">Fração molar desejada do LK no destilado.</param>
        /// <param name="targetXB">Fração molar desejada do LK no fundo.</param>
        /// <param name="feedZF">Fração molar do LK na entrada da coluna.</param>
        /// <param name="refluxRatio">Taxa de refluxo molar de operação da coluna.</param>
        /// <param name="condicaoEntrada">Condição do fluido de entrada (líquido/vapor saturado, líquido sub-resfriado, vapor super aquecido e parcialmente vaporizado).</param>
        public ColunaMcCabeThiele(MisturaBinaria misturaBinaria, double targetXD, double targetXB, double feedZF, double refluxRatio, CondicaoMistura condicaoEntrada)
        {
            this.misturaBinaria = misturaBinaria ?? throw new ArgumentNullException(nameof(misturaBinaria));
            this.targetXD = targetXD;
            this.targetXB = targetXB;
            this.feedZF = feedZF;
            this.refluxRatio = refluxRatio;
            CondicaoEntrada(condicaoEntrada);
            CalculaPontoP();
        }

        #endregion

        /// <summary>
        /// Altera o valor q da entrada do fluido, representando o estado de aquecimento/resfriamento do líquido.
        /// </summary>
        /// <param name="condicao">Condição do fluido de entrada (líquido/vapor saturado, líquido sub-resfriado, vapor super aquecido e parcialmente vaporizado).</param>
        public void CondicaoEntrada(CondicaoMistura condicao)
        {
            switch (condicao)
            {
                case CondicaoMistura.Líquido_sub_resfriado:
                    this.feedConditionQ = 1.25;
                    break;
                case CondicaoMistura.Líquido_saturado:
                    this.feedConditionQ = 1.0;
                    break;
                case CondicaoMistura.Parcialmente_vaporizado:
                    this.feedConditionQ = 0.5;
                    break;
                case CondicaoMistura.Vapor_saturado:
                    this.feedConditionQ = 0;
                    break;
                case CondicaoMistura.Vapor_super_aquecido:
                    this.feedConditionQ = -0.25;
                    break;
            }
        }

        /// <summary>
        /// Representa a linha de operação da coluna, tanto para o esgotamento quanto para a retifiação.
        /// </summary>
        /// <param name="xLK">Concentração do Light Key no líquido.</param>
        /// <returns>O valor da linha de operação.</returns>
        public double CurvaOP(double xLK)
        {
            double yCurvaOP;

            if (xLK >= this.pontoP[0]) // Linha de retificação
            {
                yCurvaOP = xLK * refluxRatio / (refluxRatio + 1) + targetXD / (refluxRatio + 1);
            }
            else // Linha de esgotamento
            {
                yCurvaOP = xLK * ((this.pontoP[1] - targetXB) / (this.pontoP[0] - targetXB)) + targetXB * (1 - ((this.pontoP[1] - targetXB) / (this.pontoP[0] - targetXB)));
            }

            return yCurvaOP;
        }

        /// <summary>
        /// Função auxiliar para calculo da intesecção das curvas de operações.
        /// </summary>
        /// <param name="xLK">Concentração do LK no líquido.</param>
        /// <returns>A diferença entre as curvas de operações.</returns>
        private double RaizP(double xLK)
        {
            return (xLK * (feedConditionQ / (feedConditionQ - 1))) - (feedZF / (feedConditionQ - 1)) - ((xLK * refluxRatio) / (refluxRatio + 1) + (targetXD / (refluxRatio + 1)));
        }

        /// <summary>
        /// Linha q.
        /// </summary>
        /// <param name="xLK">Fração molar do LK na fase líquida.</param>
        /// <returns>O valor y da linha q.</returns>
        private double LinhaQ(double xLK)
        {
            return xLK * (feedConditionQ / (feedConditionQ - 1)) - feedZF / (feedConditionQ - 1);
        }

        /// <summary>
        /// Linha de operação para a retificação.
        /// </summary>
        /// <param name="xLK">Fração molar do LK na fase líquida.</param>
        /// <returns>O valor da linha de operação y(xLK).</returns>
        private double LinhaRetificacao(double xLK)
        {
            return xLK * refluxRatio / (refluxRatio + 1) + targetXD / (refluxRatio + 1);
        }

        /// <summary>
        /// Linha de operação para o esgotamento.
        /// </summary>
        /// <param name="xLK">Fração molar do LK na fase líquida.</param>
        /// <returns>O valor da linha de operação y(xLK).</returns>
        private double LinhaEsgotamento(double xLK)
        {
            if (this.pontoP == null)
            {
                CalculaPontoP();
            }

            return xLK * ((this.pontoP[1] - targetXB) / (this.pontoP[0] - targetXB)) + targetXB * (1 - ((this.pontoP[1] - targetXB) / (this.pontoP[0] - targetXB)));
        }

        /// <summary>
        /// Faz o cálculo do ponto de intesecção entre as linhas de retificação e esgotamento.
        /// </summary>
        public void CalculaPontoP()
        {
            // Ponto de intersecção entre a linha de operação e a linha q
            double[] pontoP = new double[2] { 0, 0 };

            if (this.feedConditionQ != 1) // Condição para o líquido de entrada não saturado
            {

                try
                {
                    pontoP[0] = AchaRaizBrenet(RaizP, 0.0, 1.0);
                }
                catch (Exception)
                {
                    throw new Exception("Erro de Convergencia");
                }

                pontoP[1] = LinhaQ(pontoP[0]);

                this.pontoP = pontoP;
            }
            else // Condição para o líquido de entrada saturado
            {
                pontoP[0] = feedZF;
                pontoP[1] = LinhaRetificacao(feedZF);

                this.pontoP = pontoP;
            }
        }

        #region Funções de Plots para os gráficos
        /// <summary>
        /// Calcula os pontos para o plot da curva de equilibrio com base nos compostos da mistura binária.
        /// </summary>
        /// <param name="div">Número de divisões para o plot (precisão).</param>
        /// <returns>Duas lista com os valores de X e Y, respectivamente, com os pontos para serem plotados.</returns>
        public (List<double> PlotX, List<double> PlotY) PlotEquilibrio(int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            for (double cLK = 0; cLK <= 1.01; cLK = cLK + 1.0 / div)
            {
                PlotX.Add(cLK);

                misturaBinaria.CalculaVapRaoult(cLK);
                PlotY.Add(misturaBinaria.ComposicaoVap[0]);
            }

            return (PlotX, PlotY);
        }

        /// <summary>
        /// Calcula os pontos para o plot dos pratos, conforme a curva de operação e de equilibrio.
        /// </summary>
        /// <returns>Duas lista com os valores de X e Y, respectivamente, com os pontos para serem plotados.</returns>
        public (List<double> PlotX, List<double> PlotY) PlotPratos()
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            double xLK = this.targetXD; // Concentração do LK na fase líquida
            double yLK; // Concentração do LK na fase vapor
            double eq;

            this.CalculaPontoP();

            while (xLK >= this.targetXB)
            {
                if (PlotX.Count > 100)
                {
                    PlotX.Add(xLK);
                    PlotY.Add(CurvaOP(xLK));

                    return (PlotX, PlotY);
                }
                
                // Ponto na linha de Operacao
                PlotX.Add(xLK);
                yLK = CurvaOP(xLK);
                PlotY.Add(yLK);

                // Delegate para calculo da Equacao [EqVap(x) - xV = 0]
                double LinhaOPEq(double x) => misturaBinaria.CalculaVap(x) - yLK;

                try
                {
                    eq = AchaRaizBrenet(LinhaOPEq, 0, 1.0, 1E-4, 200);
                }
                catch (Exception)
                {
                    throw new Exception("Erro de Convergencia");
                }
                
                // Ponto na curva de equilivrio
                PlotY.Add(yLK);
                PlotX.Add(eq);

                xLK = eq;
            }

            PlotX.Add(xLK);
            PlotY.Add(CurvaOP(xLK));

            return (PlotX, PlotY);
        }

        /// <summary>
        /// Calcula os pontos para o plot da curva de operação.
        /// </summary>
        /// <param name="div">Número de divisões para o plot (precisão).</param>
        /// <returns>Duas lista com os valores de X e Y, respectivamente, com os pontos para serem plotados.</returns>
        public (List<double> PlotX, List<double> PlotY) PlotCurvaOP(int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            CalculaPontoP();

            for (double xLK = 0; xLK <= 1.01; xLK = xLK + 1.0 / div)
            {
                if (xLK < this.pontoP[0] && (xLK + 1.0 / div) > this.pontoP[0] )
                {
                    PlotX.Add(this.pontoP[0]);
                    PlotY.Add(this.pontoP[1]);
                }
                else
                {
                    PlotX.Add(xLK);
                    PlotY.Add(CurvaOP(xLK));
                }
            }
            return (PlotX, PlotY);
        }

        /// <summary>
        /// Calcula os pontos para o plot da curva q.
        /// </summary>
        /// <param name="div">Número de divisões para o plot (precisão).</param>
        /// <returns>Duas lista com os valores de X e Y, respectivamente, com os pontos para serem plotados.</returns>
        public (List<double> PlotX, List<double> PlotY) PlotCurvaQ()
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            double delta = 0.4;

            PlotX.Add(feedZF);
            PlotY.Add(feedZF);

            PlotX.Add(pontoP[0]);
            PlotY.Add(pontoP[1]);

            double d = Math.Sqrt(Math.Pow(feedZF - pontoP[0], 2.0) + Math.Pow(feedZF - pontoP[1], 2.0));

            double dx = (delta - d) * (pontoP[0] - feedZF) / d;
            double dy = (delta - d) * (pontoP[1] - feedZF) / d;

            PlotX.Add(pontoP[0] + dx);
            PlotY.Add(pontoP[1] + dy);

            return (PlotX, PlotY);
        }
        #endregion
    }
}
