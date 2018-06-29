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
        public FluidoIdealOPIII Fluido { get => fluido; }
        public double NPSHRequerido { get => nPSHRequerido; set => nPSHRequerido = value; }
        public double PressaoSuccao { get => pressaoSuccao; set => pressaoSuccao = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equacaoCurva"></param>
        /// <param name="fluido"></param>
        /// <param name="tubulacaoSuccao"></param>
        /// <param name="tubulacaoRecalque"></param>
        public BombaCompleta(double[] equacaoCurva, FluidoIdealOPIII fluido, Tubulacao tubulacaoSuccao, Tubulacao tubulacaoDiscarga, double pressaoAtm, double nPSHr, double rendimento = 1.0) 
            : base(equacaoCurva, tubulacaoDiscarga, rendimento)
        {
            this.fluido = fluido;
            this.TubulacaoSuccao = tubulacaoSuccao;
            this.pressaoSuccao = pressaoAtm;
            this.nPSHRequerido = nPSHr;
        }
        #endregion
        
        public override double Bernoulli(double vazao)
        {
            return this.CalcAlturaBomba(vazao) - tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) - tubulacaoSuccao.CalculaPerdaCarga(fluido.Material, vazao)
                + tubulacaoDescarga.Elevacao - tubulacaoSuccao.Elevacao +  fluido.ConvertePressaoEmM(pressaoSuccao - 1e5);
        }

        public override void CalculaVazao()
        {
            double vazao;

            vazao = AchaRaizBrenet(Bernoulli, 0.001, 10);

            this.vazao = vazao;
            this.alturaManometrica = CalcAlturaBomba(vazao);
            this.TubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, this.Vazao);
            this.tubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, this.Vazao);
        }

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

        public override double CalculaAlturaManoRequerida(double vazao)
        {
            alturaManometrica = TubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, vazao) - TubulacaoSuccao.Elevacao +
                    tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) + tubulacaoDescarga.Elevacao
                    + fluido.ConvertePressaoEmM(1e5 - pressaoSuccao);
            return alturaManometrica;
        }

        public override double CalculaPotencia(double vazao)
        {
            this.potencia = fluido.Material.Densidade * g * vazao * alturaManometrica / rendimento;
            return this.Potencia;
        }

        /// <summary>
        /// Calcula o NPSH disponível de uma bomba.
        /// </summary>
        /// <returns></returns>
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
