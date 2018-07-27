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
        private bool pVapEmMmHg = false;
        private readonly string[] listaMateriaisEmMmHg = new string[] { "etanol" };

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

            if (listaMateriaisEmMmHg.Contains(material.Componente))
            {
                pVapEmMmHg = true;
            }
        }

        /// <summary>
        /// Calculo da pressão de vapor pela equação de Antonine, para liquidos e gases ideais
        /// </summary>
        private void CalculaPvap()
        {
            if (pVapEmMmHg)
            {
                // Log10(Pvap [mmHg]) = A + B/T + C*Log10(T) + D*T + E*T^2
                double logP = material.CoefAntoine[0] + (material.CoefAntoine[1] / this.temperatura) + material.CoefAntoine[2] * Math.Log10(this.temperatura) 
                    + material.CoefAntoine[3] * this.temperatura + material.CoefAntoine[4] * Math.Pow(this.temperatura, 2);
                double Pvap = Math.Pow(10.0, logP);

                this.presaoVapor = Pvap * 133.3; // TODO [VERIFICAR] As unidades
            }
            else
            {   
                // Log10(Pva [bar]) = A - B/(C+T)
                double Pvap = Math.Pow(10.0, material.CoefAntoine[0] - (material.CoefAntoine[1] / (material.CoefAntoine[2] + this.temperatura)));

                this.presaoVapor = Pvap * 1e5;
            }
        }

        /// <summary>
        /// Calculo da pressão de vapor pela equação de Antonine, para liquidos e gases ideais
        /// </summary>
        /// <param name="T">Temperatura em Kelvin.</param>
        /// <returns>Pressão de vapor em Pa.</returns>
        public double PVapor(double T)
        {
            if (pVapEmMmHg)
            {
                // Log10(Pvap [mmHg]) = A + B/T + C*Log10(T) + D*T + E*T^2
                double logP = material.CoefAntoine[0] + (material.CoefAntoine[1] / T) + material.CoefAntoine[2] * Math.Log10(T)
                    + material.CoefAntoine[3] * T + material.CoefAntoine[4] * Math.Pow(T, 2);
                double Pvap = Math.Pow(10.0, logP);

                return Pvap * 133.3; // TODO [VERIFICAR] As unidades
            }
            else
            {
                // Log10(Pva [bar]) = A - B/(C+T)
                double Pvap = Math.Pow(10.0, material.CoefAntoine[0] - (material.CoefAntoine[1] / (material.CoefAntoine[2] + T)));

                return Pvap * 1e5;
            }
        }

        public double ConvertePressaoEmM(double pressao)
        {
            double pressaoM;

            pressaoM = pressao / (this.material.Densidade * Equipamentos.g);
            return pressaoM;
        }
    }
}
