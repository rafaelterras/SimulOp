using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    class DestiladorContinuo : TorreDeDestilacao
    {
        private MisturaBinaria misturaBinaria;

        public MisturaBinaria MisturaBinaria { get => misturaBinaria; set => misturaBinaria = value; }


        public (List<double> plotX, List<double> plotY) PreparaPlotEquilibrio(int n)
        {
            List<double> plotX = new List<double>();
            List<double> plotY = new List<double>();

            for (int i = 0; i < n; i++)
            {
                plotX.Add(i);
                misturaBinaria.CalculaVapRaoult(i);
                plotY.Add(misturaBinaria.ComposicaoVap[0]);
            }

            return (plotX, plotY);
        }

        public (List<double> plotX, List<double> plotY) PreparaPlotPontos()
        {
            List<double> plotX = new List<double>();
            List<double> plotY = new List<double>();










            return (plotX, plotY);
        }

    }
}