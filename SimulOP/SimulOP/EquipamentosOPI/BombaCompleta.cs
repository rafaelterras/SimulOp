using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    class BombaCompleta : Bomba
    {
        #region Inicialização das variaveis e do Constructor
        private Tubulacao tubulacaoSuccao;
        private FluidoIdealOPIII fluido;
        private double pressaoSuccao;
        private double nPSHRequerido;
        
        /// <summary>
        /// A tubulação de qual o fluido entra na bomba
        /// </summary>
        public Tubulacao TubulacaoSuccao { get => tubulacaoSuccao; set => tubulacaoSuccao = value; }
        /// <summary>
        /// O fluido que está sendo escoado pela bomba [FluidoOPIII].
        /// </summary>
        public FluidoIdealOPIII Fluido { get => fluido; }
        /// <summary>
        /// NPSH requerido para operar a bomba [m].
        /// </summary>
        public double NPSHRequerido { get => nPSHRequerido; set => nPSHRequerido = value; }
        /// <summary>
        /// Pressão do fluido no tanque de sucção [Pa].
        /// </summary>
        public double PressaoSuccao { get => pressaoSuccao; set => pressaoSuccao = value; }

        /// <summary>
        /// Constructor do objeto BombaCompleta.
        /// </summary>
        /// <param name="equacaoCurva">Coeficientes do polinomio de 3º grau que aproxima a bomba.</param>
        /// <param name="fluido">O fluido que está sendo escoado pela bomba.</param>
        /// <param name="tubulacaoSuccao">A tubulação que a bomba está acloplada na sucção.</param>
        /// <param name="tubulacaoRecalque">A tubulação que a bomba está acloplada na descarga.</param>
        public BombaCompleta(double[] equacaoCurva, FluidoIdealOPIII fluido, Tubulacao tubulacaoSuccao, Tubulacao tubulacaoDescarga, double pressaoAtm, double nPSHr, double rendimento = 1.0) 
            : base(equacaoCurva, tubulacaoDescarga, rendimento)
        {
            this.fluido = fluido;
            this.TubulacaoSuccao = tubulacaoSuccao;
            this.pressaoSuccao = pressaoAtm;
            this.nPSHRequerido = nPSHr;
        }
        #endregion

        /// <summary>
        /// Equação de Bernoulli, da forma Delta(H)_{bomba} - H_{f} - Delta(Z) = 0.
        /// </summary>
        /// <returns>O valor da Equação de bernoulli [m].</returns>
        public override double Bernoulli(double vazao)
        {
            return this.CalcAlturaBomba(vazao) - tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) - tubulacaoSuccao.CalculaPerdaCarga(fluido.Material, vazao)
                + tubulacaoDescarga.Elevacao - tubulacaoSuccao.Elevacao +  fluido.ConvertePressaoEmM(pressaoSuccao - 1e5);
        }

        /// <summary>
        /// Atualiza o valor da vazão [m^3/s] e da altura [m] da bomba utilizando a equação de Bernoulli.
        /// </summary>
        public override void CalculaVazao()
        {
            double vazao;

            vazao = AchaRaizBrenet(Bernoulli, 0.001, 10);

            this.vazao = vazao;
            this.alturaManometrica = CalcAlturaBomba(vazao);
            this.TubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, this.Vazao);
            this.tubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, this.Vazao);
        }

        /// <summary>
        /// Faz o plot para a equação da bomba.
        /// </summary>
        /// <param name="vMin">Vazão minima para o plot [m^3/s].</param>
        /// <param name="vMax">Vazão máxima para o plot [m^3/s].</param>
        /// <param name="div">Divisão para o plot.</param>
        /// <returns>Retorna listas para o plot, plotX = Lista das vazões, plotY = altura da bomba.</returns>
        public (List<double> plotX, List<double> plotY) PlotAlturaBomba(double vMin, double vMax, int div = 50)
        {
            List<double> listX = new List<double>();
            List<double> listYtubo = new List<double>();

            double hf; // Equacao da tubulacao [m]
            double vazao;

            for (int i = 0; i <= div; i++)
            {
                vazao = vMin + i * (vMax - vMin) / div;

               hf = TubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, vazao) - TubulacaoSuccao.Elevacao +
                tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) + tubulacaoDescarga.Elevacao
                + fluido.ConvertePressaoEmM(1e5 - pressaoSuccao);

                listX.Add(vazao);
                listYtubo.Add(hf);
            }
            return (listX, listYtubo);
        }

        /// <summary>
        /// Faz o plot do NPSH disponível.
        /// </summary>
        /// <param name="vMin">Vazão minima para o plot [m^3/s].</param>
        /// <param name="vMax">Vazão máxima para o plot [m^3/s].</param>
        /// <param name="div">Divisão para o plot.</param>
        /// <returns>Retorna listas para o plot, plotX = Lista das vazões, plotY = NPSH dispoivel.</returns>
        public (List<double> plotX, List<double> plotY) PlotNPSHDisponivel(double vMin, double vMax, int div = 50)
        {
            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            double vazao;
            double NPSHDisp;

            for (int i = 0; i <= div; i++)
            {
                vazao = vMin + i * (vMax - vMin) / div;

                NPSHDisp = NPSHDisponivel(vazao);

                listX.Add(vazao);
                listY.Add(NPSHDisp);
            }

            return (listX, listY);
        }

        /// <summary>
        /// Faz o plot para a equação da bomba e a perda de carga da tubulação.
        /// </summary>
        /// <param name="nMax">Divisão para o plot.</param>
        /// <returns>Retorna listas para o plot, plotX = Lista das vazões, plotYBomba = altura da bomba, plotYTubo = perda de carga da tubulação.</returns>
        public override (List<double> plotX, List<double> plotYBomba, List<double> plotYTubo) PreparaPlot(int div = 40)
        {
            List<double> listX = new List<double>();
            List<double> listYBomba = new List<double>();
            List<double> listYtubo = new List<double>();

            double h; // Altura da bomba [m]
            double hf; // Equacao da tubulacao [m]
            double vazao;

            for (int i = 0; i < div; i++)
            {
                vazao = (i + 1) * (this.vazao / (div / 2));

                h = CalcAlturaBomba(vazao);
                hf = TubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, vazao) - TubulacaoSuccao.Elevacao +
                    tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) + tubulacaoDescarga.Elevacao
                    + fluido.ConvertePressaoEmM(1e5 - pressaoSuccao);
                if (h > 0)
                {
                    listX.Add(Math.Round(vazao * 3600, 2));
                    listYBomba.Add(h);
                    listYtubo.Add(hf);
                }
                else
                {
                    break;
                }
            }
            return (listX, listYBomba, listYtubo);
        }

        /// <summary>
        /// Retorna a altura de uma bomba para alcançar a vazão na tubulação.
        /// </summary>
        /// <param name="vazao">A vazão desejada [m^3/s].</param>
        /// <returns>A altura necessária para bombear o fluido.</returns>
        public override double CalculaAlturaManoRequerida(double vazao)
        {
            alturaManometrica = TubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, vazao) - TubulacaoSuccao.Elevacao +
                    tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) + tubulacaoDescarga.Elevacao
                    + fluido.ConvertePressaoEmM(1e5 - pressaoSuccao);
            return alturaManometrica;
        }

        /// <summary>
        /// Calcula a potência elátrica da bomba.
        /// </summary>
        /// <param name="vazao">Vazão de liquido que passa na bomba [m^3/s].</param>
        /// <returns>A potênia da bomba [W].</returns>
        public override double CalculaPotencia(double vazao)
        {
            this.potencia = fluido.Material.Densidade * g * vazao * alturaManometrica / rendimento;
            return this.Potencia;
        }

        /// <summary>
        /// Calcula o NPSH disponível da bomba.
        /// </summary>
        /// <returns>O NPSH disponível.</returns>
        public double NPSHDisponivel()
        {
            double pSuccao;
            double diferenciaAltura;
            double pVap;
            double perdaCarga;

            pSuccao = fluido.ConvertePressaoEmM(pressaoSuccao);
            diferenciaAltura = tubulacaoSuccao.Elevacao;
            pVap = this.fluido.PresaoVapor / (Fluido.Material.Densidade * g);
            perdaCarga = tubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, Vazao);

            return pSuccao - pVap - perdaCarga + diferenciaAltura;
        }

        /// <summary>
        /// Calcula o NPSH disponível para uma determinada vazão.
        /// </summary>
        /// <param name="vazao">Vazão para calcular o NPSH disponível.</param>
        /// <returns>O NPSH disponível.</returns>
        public double NPSHDisponivel(double vazao)
        {
            double pSuccao;
            double diferenciaAltura;
            double pVap;
            double perdaCarga;

            pSuccao = fluido.ConvertePressaoEmM(pressaoSuccao);
            diferenciaAltura = tubulacaoSuccao.Elevacao;
            pVap = this.fluido.PresaoVapor / (Fluido.Material.Densidade * g);
            perdaCarga = tubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, vazao);

            return pSuccao - pVap - perdaCarga + diferenciaAltura;
        }
    }
}
