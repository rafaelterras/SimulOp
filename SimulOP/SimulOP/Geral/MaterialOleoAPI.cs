using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialOleoAPI : IMaterialFluidoOPII
    {
        private double grauAPI;
        private double temperatura;
        private double densidade; //[lb/ft^3]
        private double viscosidade;
        private double calorEspecifico;
        private double condutividadeTermica;


        public double GrauAPI { get => grauAPI; }
        public double Temperatura
        {
            get => temperatura;
            set
            {
                this.temperatura = value;
                AtualizaPropriedades();
            }
        }

        public double Densidade { get => densidade; } //[lb/ft^3]
        public double Viscosidade { get => viscosidade; }
        public double CalorEspecifico { get => calorEspecifico; }
        public double CondutividadeTermica { get => condutividadeTermica; }

        public MaterialOleoAPI(double grauAPI, double temperatura)
        {
            this.grauAPI = grauAPI;
            this.temperatura = temperatura;
            AtualizaPropriedades();
        }

        public void AtualizaPropriedades()
        {
            AtualizaDensidade();
            AtualizaViscosidade();
            AtualizaCalorEspecifico();
            AtualizaCondutividadeTermica();
        }

        private void AtualizaDensidade()
        {
            double dens;

            dens = 141.5 / (grauAPI + 131.5);
            dens = dens * EquipamentoOPII.densidadeAguaSImperial;

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

        private void AtualizaCalorEspecifico()
        {
            throw new NotImplementedException();
        }

        private void AtualizaCondutividadeTermica()
        {
            throw new NotImplementedException();
        }

        public IMaterialFluidoOPII Clone()
        {
            return new MaterialOleoAPI(this.grauAPI, this.temperatura);
        }
    }
}
