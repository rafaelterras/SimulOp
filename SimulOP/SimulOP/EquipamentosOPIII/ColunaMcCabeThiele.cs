using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class ColunaMcCabeThiele : EquipamentoOPIII
    {
        private MisturaBinaria misturaBinaria;
        private double[] linhaOP;

        public MisturaBinaria MisturaBinaria { get => misturaBinaria; }

        public ColunaMcCabeThiele(MisturaBinaria misturaBinaria)
        {
            this.misturaBinaria = misturaBinaria ?? throw new ArgumentNullException(nameof(misturaBinaria));
        }

        public (List<double> PlotX, List<double> PlotY) PlotEquilibrio(double div)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            for (double cLK = 0; cLK <= 1.01; cLK = cLK + 1.0 / div)
            {
                PlotX.Add(cLK);
                misturaBinaria.CalculaVapRaoult(cLK);
                PlotY.Add(misturaBinaria.ComposicaoVap[0]);
            }

            return (PlotX, PlotY);
        }


        public (List<double> PlotX, List<double> PlotY) PlotPratos(double xD, double xB)
        {
            List<double> PlotX = new List<double>();
            List<double> PlotY = new List<double>();

            double xL = xD;
            double xV;


            while (xL >= xB)
            {   // Ponto na linha de Operacao
                PlotX.Add(xL);
                xV = CurvaOP(xL);
                PlotY.Add(xV);

                // Delegate para calculo da Equacao [EqVap(x) - xV = 0]
                double LinhaOPEq(double x) => misturaBinaria.CalculaVap(x) - xV;
                double eq = AchaRaizBrenet(LinhaOPEq, 0, 1);

                // Ponto na curva de equilivrio
                PlotY.Add(xV);
                PlotX.Add(eq);

                xL = eq;
            }

            PlotX.Add(xL);
            PlotY.Add(CurvaOP(xL));

            return (PlotX, PlotY);
        }


        public double CurvaOP(double cLK)
        {
            return cLK;
        }

    }
}
