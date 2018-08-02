using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialOleoAPI : IMaterialFluidoOPII
    {
        private string componente;
        private double grauAPI;
        private double temperatura;
        private double densidade;
        private double viscosidade;
        private double calorEspecifico;
        private double condutividadeTermica;

        public string Componente { get => componente; }

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

        public double Densidade { get => densidade; }
        public double Viscosidade { get => viscosidade; }
        public double CalorEspecifico { get => calorEspecifico; }
        public double CondutividadeTermica { get => condutividadeTermica; }


        public MaterialOleoAPI(double grauAPI, double temperatura)
        {
            this.grauAPI = grauAPI;
            this.temperatura = temperatura;
            this.componente = $"Óleo º{grauAPI} API";
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

            // Densidade em kg/m^3

            dens = 141.5 / (grauAPI + 131.5);
            dens = dens * EquipamentoOPII.densidadeAguaSInternacional;

            this.densidade = dens;
        }

        private void AtualizaViscosidade()
        {
            double visc;
            double primeiroTermo;
            double segundoTermo;
            double expoente;
            double tempFahrenheit;

            // Viscosidade em Pa*s, temperatura em K

            tempFahrenheit = 1.8 * this.temperatura - 459.67; // Conversão de temp em K para F

            primeiroTermo = 0.32 + (1.8 * Math.Pow(10, 7)) / Math.Pow(grauAPI, 4.53);
            segundoTermo = 360 / (tempFahrenheit + 200);
            expoente = Math.Exp(0.43 + (8.33 / grauAPI));
            segundoTermo = Math.Pow(segundoTermo, expoente);
            visc = primeiroTermo * segundoTermo;

            this.viscosidade = visc / 1000;
        }

        private void AtualizaCalorEspecifico()
        {
            double cp;
            double primeiroTermo;
            double tempFahrenheit;
            double segundoTermo;

            // Calor específico em J/kg K, temperatura em K

            tempFahrenheit = 1.8 * this.temperatura - 459.67; // Conversão de temp em K para F

            primeiroTermo = grauAPI * (-1.39 * Math.Pow(10, -6) * tempFahrenheit + 1.847 * Math.Pow(10, -3));
            segundoTermo = 6.312 * Math.Pow(10, -4) * tempFahrenheit;
            cp = primeiroTermo + segundoTermo + 0.352;

            this.calorEspecifico = cp * 4186.798188; // Conversão para J/kg K
        }

        private void AtualizaCondutividadeTermica()
        {
            double k;

            // Condutividade térmica em W/m K, temperatura em K

            k = 0.826855 * (grauAPI + 131.5) * (0.85258 - 0.00054 * temperatura);

            this.condutividadeTermica = k / 1000; // Conversão de mW/m K para W/m K
        }

        public IMaterialFluidoOPII Clone()
        {
            return new MaterialOleoAPI(this.grauAPI, this.temperatura);
        }
    }
}
