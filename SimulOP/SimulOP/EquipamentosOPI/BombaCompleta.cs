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

        /// <summary>
        /// A tubulação de qual o fluido entra na bomba
        /// </summary>
        public Tubulacao TubulacaoSuccao { get => tubulacaoSuccao; set => tubulacaoSuccao = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equacaoCurva"></param>
        /// <param name="fluido"></param>
        /// <param name="tubulacaoSuccao"></param>
        /// <param name="tubulacaoRecalque"></param>
        public BombaCompleta(double[] equacaoCurva, FluidoOPI fluido, Tubulacao tubulacaoSuccao, Tubulacao tubulacaoDiscarga, double pressaoAtm) : base(equacaoCurva, fluido, tubulacaoDiscarga)
        {
            this.TubulacaoSuccao = tubulacaoSuccao;
            this.pressaoAtm = pressaoAtm;
        }
        #endregion

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
