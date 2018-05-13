using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
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
        /// 
        /// </summary>
        public MisturaBinaria MisturaBinaria { get => misturaBinaria; set => misturaBinaria = value; }
        /// <summary>
        /// 
        /// </summary>
        public double TargetXD { get => targetXD; set => targetXD = value; }
        /// <summary>
        /// 
        /// </summary>
        public double TargetXB { get => targetXB; set => targetXB = value; }
        /// <summary>
        /// 
        /// </summary>
        public double FeedZF { get => feedZF; set => feedZF = value; }
        /// <summary>
        /// 
        /// </summary>
        public double FeedConditionQ { get => feedConditionQ; set => feedConditionQ = value; }
        /// <summary>
        /// 
        /// </summary>
        public double RefluxRatio { get => refluxRatio; set => refluxRatio = value; }
        /// <summary>
        /// 
        /// </summary>
        public double[] PontoP { get => pontoP; }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="misturaBinaria"></param>
        /// <param name="targetXD"></param>
        /// <param name="targetXB"></param>
        public ColunaMcCabeThiele(MisturaBinaria misturaBinaria, double targetXD, double targetXB, double feedZF, double refluxRatio, double feedConditionQ)
        {
            this.misturaBinaria = misturaBinaria ?? throw new ArgumentNullException(nameof(misturaBinaria));
            this.targetXB = targetXB;
            this.targetXD = targetXD;
            this.feedZF = feedZF;
            this.refluxRatio = refluxRatio;
            this.feedConditionQ = feedConditionQ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="misturaBinaria"></param>
        /// <param name="targetXD"></param>
        /// <param name="targetXB"></param>
        /// <param name="feedZF"></param>
        /// <param name="condicaoEntrada"></param>
        public ColunaMcCabeThiele(MisturaBinaria misturaBinaria, double targetXD, double targetXB, double feedZF, double refluxRatio, string condicaoEntrada)
        {
            this.misturaBinaria = misturaBinaria ?? throw new ArgumentNullException(nameof(misturaBinaria));
            this.targetXD = targetXD;
            this.targetXB = targetXB;
            this.feedZF = feedZF;
            this.refluxRatio = refluxRatio;
            CondicaoEntrada(condicaoEntrada);
        }

        #endregion

        /// <summary>
        /// Altera o valor q da entrada do fluido, representando o estado de aquecimento/resfriamento do líquido
        /// </summary>
        /// <param name="condicao">Condição do </param>
        public void CondicaoEntrada(string condicao)
        {
            switch (condicao.ToLower())
            {
                case "líquido sub-resfriado":
                    this.feedConditionQ = 1.25;
                    break;
                case "líquido saturado":
                    this.feedConditionQ = 1.0;
                    break;
                case "parcialmente vaporizado":
                    this.feedConditionQ = 0.5;
                    break;
                case "vapor saturado":
                    this.feedConditionQ = 0;
                    break;
                case "vapor super aquecido":
                    this.feedConditionQ = -0.25;
                    break;
                default:
                    throw new Exception($"Condição do líquido de entrada não estabelecida, o valor [{condicao}] não era esperado");
            }
        }

        /// <summary>
        /// Calcula os pontos para o plot da curva de equilibrio com base nos compostos da mistura binária
        /// </summary>
        /// <param name="div">Número de divisões para o plot (precisão)</param>
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
        /// Calcula os pontos para o plot dos pratos, conforme a curva de operação e de equilibrio
        /// </summary>
        /// <returns></returns>
        public (List<double> PlotX, List<double> PlotY) PlotPratos()
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            double xL = this.targetXD;
            double xV;

            this.CalculaPontoP();

            while (xL >= this.targetXB)
            {   // Ponto na linha de Operacao
                PlotX.Add(xL);
                xV = CurvaOP(xL);
                PlotY.Add(xV);

                // Delegate para calculo da Equacao [EqVap(x) - xV = 0]
                double LinhaOPEq(double x) => misturaBinaria.CalculaVap(x) - xV;
                double eq = AchaRaizBrenet(LinhaOPEq, 0, 1);

                // Ponto na curva de equilivrio
                PlotY.Add(xV);
                PlotX.Add(eq);

                xL = eq;
            }

            PlotX.Add(xL);
            PlotY.Add(CurvaOP(xL));

            return (PlotX, PlotY);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="div"></param>
        /// <returns></returns>
        public (List<double> PlotX, List<double> PlotY) PlotCurvaOP(int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            for (double cLK = 0; cLK <= 1.01; cLK = cLK + 1.0 / div)
            {
                PlotX.Add(cLK);
                PlotY.Add(CurvaOP(cLK));
            }

            return (PlotX, PlotY);
        }

        /// <summary>
        /// Representa a linha de operação da coluna, tanto para o esgotamento quanto para a retifiação
        /// </summary>
        /// <param name="cLK">Concentração do Light Key no líquido</param>
        /// <returns>O valor da linha de operação</returns>
        public double CurvaOP(double cLK)
        {
            double yCurvaOP;

            if (cLK >= this.pontoP[0]) // Linha de retificação
            {
                yCurvaOP = cLK * refluxRatio / (refluxRatio + 1) + targetXD / (refluxRatio + 1);
            }
            else // Linha de esgotamento
            {
                yCurvaOP = cLK * ((this.pontoP[1] - targetXB) / (this.pontoP[0] - targetXB)) + targetXB * (1 - ((this.pontoP[1] - targetXB) / (this.pontoP[0] - targetXB)));
            }

            return yCurvaOP;
        }

        /// <summary>
        /// Faz o cálculo do ponto de intesecção entre as linhas de retificação e esgotamento
        /// </summary>
        public void CalculaPontoP()
        {
            // Ponto de intersecção entre a linha de operação e a linha q
            double[] pontoP = new double[2] { 0, 0 };

            if (this.feedConditionQ != 1) // Condição para o líquido de entrada não saturado
            {               
                pontoP[0] = AchaRaizBrenet(RaizP, 0.0, 1.0);
                pontoP[1] = LinhaQ(pontoP[0]);

                this.pontoP = pontoP;
            }
            else // Condição para o líquido de entrada saturado
            {
                pontoP[0] = feedZF;
                pontoP[1] = feedZF * refluxRatio / (refluxRatio + 1) + targetXD / (refluxRatio + 1);

                this.pontoP = pontoP;
            }

            Console.WriteLine($"Ponto P calculado: ({pontoP[0]},{pontoP[1]})");
        }

        /// <summary>
        /// Linha q
        /// </summary>
        /// <param name="xLK">Fração molar do LK na fase líquida</param>
        /// <returns>O valor y da linha q</returns>
        public double LinhaQ(double xLK)
        {
            return xLK * (feedConditionQ / (feedConditionQ - 1)) - feedZF / (feedConditionQ - 1);
        }

        public double LinhaRetif(double xLK)
        {
            return xLK * refluxRatio / (refluxRatio + 1) + targetXD / (refluxRatio + 1);
        }

        private double RaizP(double x)
        {
            return (x * (feedConditionQ / (feedConditionQ - 1))) - (feedZF / (feedConditionQ - 1)) - ((x * refluxRatio) / (refluxRatio + 1) + (targetXD / (refluxRatio + 1)));
        }

    }
}
