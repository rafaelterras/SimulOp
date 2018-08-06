using System;
using System.Linq;

namespace SimulOP
{
    /// <summary>
    /// Classe para representar fluidos ideais em operações unitérias III e quando há necessidade de se calcular a pressão de vapor de um fluido.
    /// </summary>
    public class FluidoIdealOPIII
    {
        #region Inicialização das variaveis e do Constructor
        private MaterialFluidoOPIII material;
        private double temperatura; // em K.
        private double presaoVapor; // em Pa.

        /// <summary>
        /// Temperatura do fluido [K].
        /// </summary>
        public double Temperatura { get => temperatura; set => temperatura = value; }
        /// <summary>
        /// Pressão de vapor na temperatura atual do fluido [Pa].
        /// </summary>
        public double PresaoVapor
        {
            get
            {
                CalculaPvap();
                return presaoVapor;
            }
        }

        /// <summary>
        /// Material que guarda as propriedades físicas do fluido.
        /// </summary>
        public MaterialFluidoOPIII Material { get => material; }

        /// <summary>
        /// Constructor do FluidoIdealOPIII
        /// </summary>
        /// <param name="material">Material com as propriedades físicas.</param>
        /// <param name="temperatura">Temperatura atual do fluido.</param>
        public FluidoIdealOPIII(MaterialFluidoOPIII material, double temperatura)
        {
            this.material = material;
            this.temperatura = temperatura;
        }
        #endregion

        /// <summary>
        /// Calculo da pressão de vapor pela equação de Antonine, para liquidos e gases ideais
        /// </summary>
        private void CalculaPvap()
        {
            // Log10(Pva [bar]) = A - B/(C+T)
            double Pvap = Math.Pow(10.0, material.CoefAntoine[0] - (material.CoefAntoine[1] / (material.CoefAntoine[2] + this.temperatura)));

            this.presaoVapor = Pvap * 1e5;
        }

        /// <summary>
        /// Calculo da pressão de vapor pela equação de Antonine, para liquidos e gases ideais
        /// </summary>
        /// <param name="T">Temperatura em Kelvin.</param>
        /// <returns>Pressão de vapor em Pa.</returns>
        public double PVapor(double T)
        {
            // Log10(Pva [bar]) = A - B/(C+T)
            double Pvap = Math.Pow(10.0, material.CoefAntoine[0] - (material.CoefAntoine[1] / (material.CoefAntoine[2] + T)));

            return Pvap * 1e5;            
        }

        /// <summary>
        /// Converte uma determinada pressão em metros de coluna do fluido.
        /// </summary>
        /// <param name="pressao">Pressão que se deseja converter.</param>
        /// <returns>A pressão em metros de coluna de fluido.</returns>
        public double ConvertePressaoEmM(double pressao)
        {
            double pressaoM;

            pressaoM = pressao / (this.material.Densidade * Equipamentos.g);
            return pressaoM;
        }
    }
}
