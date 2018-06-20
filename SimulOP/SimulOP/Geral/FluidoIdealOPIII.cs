using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class FluidoIdealOPIII
    {
        private MaterialFluidoOPIII material;
        private double temperatura;
        private double presaoVapor;
        
        public double Temperatura { get => temperatura; set => temperatura = value; }
        public double PresaoVapor
        {
            get
            {
                CalculaPvap();
                return presaoVapor;
            }
        }

        public MaterialFluidoOPIII Material { get => material; }

        public FluidoIdealOPIII(MaterialFluidoOPIII material, double temperatura)
        {
            this.material = material;
            this.temperatura = temperatura;
        }

        /// <summary>
        /// Calculo da pressão de vapor pela equação de Antonine, para liquidos e gases ideais
        /// </summary>
        private void CalculaPvap()
        {
            double Pvap = Math.Pow(10.0, material.CoefAntoine[0] - (material.CoefAntoine[1] / (material.CoefAntoine[2] + this.temperatura)));

            this.presaoVapor = Pvap * 1e5;
        }

        public double ConvertePressaoEmM(double pressao)
        {
            double pressaoM;

            pressaoM = pressao / (this.material.Densidade * Equipamentos.g);
            return pressaoM;
        }
    }
}
