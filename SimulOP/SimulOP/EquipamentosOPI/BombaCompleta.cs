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
        private double pressaoAtm;
        private double nPSHRequerido;


        /// <summary>
        /// A tubulação de qual o fluido entra na bomba
        /// </summary>
        public Tubulacao TubulacaoSuccao { get => tubulacaoSuccao; set => tubulacaoSuccao = value; }
        public FluidoIdealOPIII Fluido { get => fluido; }
        public double NPSHRequerido { get => nPSHRequerido; set => nPSHRequerido = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equacaoCurva"></param>
        /// <param name="fluido"></param>
        /// <param name="tubulacaoSuccao"></param>
        /// <param name="tubulacaoRecalque"></param>
        public BombaCompleta(double[] equacaoCurva, FluidoIdealOPIII fluido, Tubulacao tubulacaoSuccao, Tubulacao tubulacaoDiscarga, double pressaoAtm, double nPSHr, double rendimento = 1.0) : base(equacaoCurva, tubulacaoDiscarga, rendimento)
        {
            this.fluido = fluido;
            this.TubulacaoSuccao = tubulacaoSuccao;
            this.pressaoAtm = pressaoAtm;
            this.nPSHRequerido = nPSHr;
        }
        #endregion
        
        public override double Bernoulli(double vazao)
        {
            return this.CalcAlturaBomba(vazao) - tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) - tubulacaoSuccao.CalculaPerdaCarga(fluido.Material, vazao)
                - tubulacaoDescarga.Elevacao - tubulacaoSuccao.Elevacao;
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

        public override (List<double> plotX, List<double> plotYBomba, List<double> plotYTubo) PreparaPlot(int nMax = 40)
        {
            List<double> listX = new List<double>();
            List<double> listYBomba = new List<double>();
            List<double> listYtubo = new List<double>();

            double h; // Altura da bomba [m]
            double hf; // Equacao da tubulacao [m]
            double vazao;

            for (int i = 0; i < nMax; i++)
            {
                vazao = (i + 1) * (this.vazao / (nMax / 2));

                h = this.CalcAlturaBomba(vazao);
                hf = this.tubulacaoDescarga.CalculaPerdaCarga(this.Fluido.Material, vazao) + this.tubulacaoSuccao.CalculaPerdaCarga(this.Fluido.Material,vazao)
                    + this.tubulacaoDescarga.Elevacao + this.tubulacaoSuccao.Elevacao;
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

        public override void CalculaAlturaManoRequerida(double vazao)
        {
            alturaManometrica = TubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, vazao) + TubulacaoSuccao.Elevacao +
               tubulacaoDescarga.CalculaPerdaCarga(Fluido.Material, vazao) + tubulacaoDescarga.Elevacao;
        }

        public override double CalculaPotencia(double vazao)
        {
            this.potencia = fluido.Material.Densidade * g * vazao * alturaManometrica / rendimento;
            return this.Potencia;
        }

        /// <summary>
        /// Calcula o NPSH disponível de uma bomba.
        /// </summary>
        /// <param name="pressaoVapor"></param>
        /// <returns></returns>
        public double npshDisponivel()
        {
            double pA;
            double pZ;
            double pV;
            double pF;

            pA = pressaoAtm / (Fluido.Material.Densidade * g);
            pZ = tubulacaoSuccao.Elevacao;
            pV = this.fluido.PresaoVapor / (Fluido.Material.Densidade * g);
            pF = tubulacaoSuccao.CalculaPerdaCarga(Fluido.Material, Vazao);

            Console.WriteLine($"Pvap = {pV}");

            return (pA + pZ - pV - pF);
        }
    }
}
