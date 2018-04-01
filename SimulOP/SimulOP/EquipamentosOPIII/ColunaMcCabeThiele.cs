using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class ColunaMcCabeThiele
    {
        private MisturaBinaria misturaBinaria;

        public MisturaBinaria MisturaBinaria { get => misturaBinaria; }

        public ColunaMcCabeThiele(MisturaBinaria misturaBinaria)
        {
            this.misturaBinaria = misturaBinaria ?? throw new ArgumentNullException(nameof(misturaBinaria));
        }

        public (List<double> PlotX, List<double> PlotY) PlotEquilibrio(double div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            for (double n = 0; n <= 1.01; n = n + 1.0/div)
            {
                PlotX.Add(n);
                misturaBinaria.CalculaVapRaoult(n);
                PlotY.Add(misturaBinaria.ComposicaoVap[0]);
            }

            return (PlotX, PlotY);
        }


        public (List<double> PlotX, List<double> PlotY) PlotPratos(int div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();





            return (PlotX, PlotY);
        }

    }
}
