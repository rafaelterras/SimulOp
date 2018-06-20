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
        private double pressaoAtm;
        private double nPSHRequerido;


        /// <summary>
        /// A tubulação de qual o fluido entra na bomba
        /// </summary>
        public Tubulacao TubulacaoSuccao { get => tubulacaoSuccao; set => tubulacaoSuccao = value; }
        public double NPSHRequerido { get => nPSHRequerido; set => nPSHRequerido = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equacaoCurva"></param>
        /// <param name="fluido"></param>
        /// <param name="tubulacaoSuccao"></param>
        /// <param name="tubulacaoRecalque"></param>
        public BombaCompleta(double[] equacaoCurva, FluidoOPI fluido, Tubulacao tubulacaoSuccao, Tubulacao tubulacaoDiscarga, double pressaoAtm, double nPSHr, double rendimento = 1.0) : base(equacaoCurva, fluido, tubulacaoDiscarga, rendimento)
        {
            this.TubulacaoSuccao = tubulacaoSuccao;
            this.pressaoAtm = pressaoAtm;
            this.nPSHRequerido = nPSHr;
        }
        #endregion



        public override double Bernoulli(double vazao)
        {
            return this.CalcAlturaBomba(vazao) - tubulacaoDescarga.CalculaPerdaCarga(Fluido, vazao) - tubulacaoSuccao.CalculaPerdaCarga(fluido, vazao)
                - tubulacaoDescarga.Elevacao - tubulacaoSuccao.Elevacao;
        }

        public override void CalculaVazao()
        {
            double vazao;

            vazao = AchaRaizBrenet(Bernoulli, 0.001, 10);

            this.vazao = vazao;
            this.alturaManometrica = CalcAlturaBomba(vazao);
            this.TubulacaoDescarga.CalculaPerdaCarga(Fluido, this.Vazao);
            this.tubulacaoSuccao.CalculaPerdaCarga(Fluido, this.Vazao);
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
                hf = this.tubulacaoDescarga.CalculaPerdaCarga(this.Fluido, vazao) + this.tubulacaoSuccao.CalculaPerdaCarga(this.Fluido,vazao)
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

        /// <summary>
        /// Calcula o NPSH disponível de uma bomba.
        /// </summary>
        /// <param name="pressaoVapor"></param>
        /// <returns></returns>
        public double npshDisponivel(double pressaoVapor)
        {
            double pA;
            double pZ;
            double pV;
            double pF;

            pA = pressaoAtm / (Fluido.Material.Densidade * g);
            pZ = tubulacaoSuccao.Elevacao;
            pV = pressaoVapor / (Fluido.Material.Densidade * g);
            pF = tubulacaoSuccao.CalculaPerdaCarga(Fluido, Vazao);

            return (pA + pZ - pV - pF);
        }
    }
}
