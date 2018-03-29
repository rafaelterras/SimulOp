using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    class MisturaBinaria
    {
        private Fluido fluidoLK;
        private Fluido fluidoHK;
        private double[] composicaoLiq;
        private double[] composicaoVap;
        private double alpha;

        private double temperatura;

        public Fluido FluidoLK { get => fluidoLK; }
        public Fluido FluidoHK { get => fluidoHK; }
        public double[] ComposicaoLiq { get => composicaoLiq; set => composicaoLiq = value; }
        public double[] ComposicaoVap { get => composicaoVap; set => composicaoVap = value; }
        public double Alpha { get => alpha; }
        public double Temperatura
        {
            get => temperatura;
            set
            {
                this.temperatura = value;
                fluidoLK.Temperatura = value;
                FluidoHK.Temperatura = value;
            }
        }

        public MisturaBinaria(Fluido fluidoLK, Fluido fluidoHK, double cLK)
        {
            this.fluidoLK = fluidoLK;
            this.fluidoHK = fluidoHK;
            this.composicaoLiq = new double[2] { cLK, 1 - cLK };
            this.composicaoVap = new double[2] { 0, 0 };
        }

        public void CalculaVapRaoult(double cLK)
        {
            this.alpha = fluidoHK.PresaoVapor / fluidoLK.PresaoVapor;
            
            double yLK = (this.alpha * cLK) / (1 + cLK * (this.alpha - 1));

            this.composicaoVap[0] = yLK;
            this.composicaoVap[1] = yLK - 1;
        }

    }
}
