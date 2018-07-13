using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialOleoAPI : IMaterialFluidoOPII
    {
        public const double densidadeAguaSImperial = 62.42796529;

        private double grauAPI;
        private double temperatura;
        private double densidade;
        private double viscosidade;
        
        public double GrauAPI{ get => grauAPI; }
        public double Temperatura { get => temperatura; set => temperatura = value; }
        public double Densidade
        {
            get
            {
                AtualizaDensidade();
                return densidade;
            }
        }
        public double Viscosidade
        {
            get
            {
                AtualizaViscosidade();
                return viscosidade;
            }
        }

        public double CalorEspecifico => throw new NotImplementedException();

        public double CondutividadeTermica => throw new NotImplementedException();

        public MaterialOleoAPI(double grauAPI, double temperatura)
        {
            this.grauAPI = grauAPI;
            AtualizaDensidade();
            AtualizaViscosidade();
        }

        private void AtualizaDensidade()
        {
            double dens;

            dens = 141.5 / (grauAPI + 131.5);
            dens = dens * densidadeAguaSImperial;

            this.densidade = dens;
        }

        private void AtualizaViscosidade()
        {
            double visc;
            double primeiroTermo;
            double segundoTermo;
            double a;

            primeiroTermo = 0.32 + (1.8 * Math.Pow(10, 7)) / Math.Pow(grauAPI, 4.53);
            segundoTermo = 360 / (temperatura + 200);
            a = Math.Exp(0.43 + (8.33 / grauAPI));
            segundoTermo = Math.Pow(segundoTermo, a);
            visc = primeiroTermo * segundoTermo;

            this.viscosidade = visc;
        }
    }
}
