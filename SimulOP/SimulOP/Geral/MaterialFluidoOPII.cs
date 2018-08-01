using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialFluidoOPII : MaterialFluidoOPI, IMaterialFluidoOPII
    {
        protected double temperatura; //[K]
        private double mM; // massa molar [g/mol].
        protected double[] coefCorrelDensidade;
        protected double[] coefCorrelViscosidade;
        protected double[] coefCorrelCalorEspecifico;
        protected double[] coefCorrelCondutividadeTermica;
        protected double calorEspecifico; //[J/mol*K]
        protected double condutividadeTermica;
        
        public double MM { get => mM; }
        public double Temperatura
        {
            get => temperatura;
            set
            {
                temperatura = value;
                AtualizaPropriedades();
            }
        }
        public double[] CoefCorrelDensidade { get => coefCorrelDensidade; }
        public double[] CoefCorrelViscosidade { get => coefCorrelViscosidade; }
        public double[] CoefCorrelCalorEspecifico { get => coefCorrelCalorEspecifico; }
        public double[] CoefCorrelCondutividadeTermica { get => coefCorrelCondutividadeTermica; }
        public double CalorEspecifico
        {
            get
            {
                AtualizaCalorEspecifico();
                return this.calorEspecifico;                
            }
        }
        public double CondutividadeTermica
        {
            get
            {
                AtualizaCondutividadeTermica();
                return this.condutividadeTermica;
            }
        }

        public MaterialFluidoOPII(string componente, double mM, double temperatura, 
            double[] coefCorrelDensidade, double[] coefCorrelViscosidade, 
            double[] coefCorrelCalorEspecifico, double[] coefCorrelCondutividadeTermica, 
            double densidade = 1, double viscosidade = 1 ) : base(componente, densidade, viscosidade)
        {
            this.mM = mM;
            this.temperatura = temperatura;
            this.coefCorrelDensidade = coefCorrelDensidade;
            this.coefCorrelViscosidade = coefCorrelViscosidade;
            this.coefCorrelCalorEspecifico = coefCorrelCalorEspecifico;
            this.coefCorrelCondutividadeTermica = coefCorrelCondutividadeTermica;
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
            
            // Densidade em g/ml, temperatura em K.
            dens = this.coefCorrelDensidade[0] * Math.Pow(this.coefCorrelDensidade[1], 
                -Math.Pow((1 - this.temperatura/this.coefCorrelDensidade[2]), this.coefCorrelDensidade[3]));

            this.densidade = dens * 1000; // Densidade para Kg/m^3.
        }

        private void AtualizaViscosidade()
        {
            double visc;

            // Densidade em cP, temperatura em K
            visc = Math.Pow(10, this.CoefCorrelViscosidade[0] + this.coefCorrelViscosidade[1]/this.temperatura + 
                this.coefCorrelViscosidade[2] * this.temperatura + this.coefCorrelViscosidade[3] * Math.Pow(this.temperatura, 2));

            this.viscosidade = visc / 1000; // Densidade para Pa*s.
        }

        private void AtualizaCalorEspecifico()
        {
            double cp;

            // Calor específico em J/mol K, temperatura em K
            cp = this.coefCorrelCalorEspecifico[0] + this.coefCorrelCalorEspecifico[1] * this.temperatura + 
                this.coefCorrelCalorEspecifico[2] * Math.Pow(this.temperatura, 2) +
                this.coefCorrelCalorEspecifico[3] * Math.Pow(this.temperatura, 3);

            this.calorEspecifico = cp * (1000 / this.mM); // Cp em j/Kg k
        }

        private void AtualizaCondutividadeTermica()
        {
            double k;

            // Condutividade térmica em J/m K, temperatura em K
            switch (this.Componente.ToLower())
            {
                case "água":
                    k = this.coefCorrelCondutividadeTermica[0] + this.coefCorrelCondutividadeTermica[1] * this.temperatura + 
                        this.coefCorrelCondutividadeTermica[2] * Math.Pow(this.temperatura, 2);
                    break;
                default:
                    k = Math.Pow(10, this.coefCorrelCondutividadeTermica[0] + this.coefCorrelCondutividadeTermica[1] * Math.Pow(1 - this.temperatura/this.coefCorrelCondutividadeTermica[3], 2/7));
                    break;
            }
            this.condutividadeTermica = k;
        }

        public IMaterialFluidoOPII Clone()
        {
            return new MaterialFluidoOPII(this.Componente, this.mM, this.temperatura,
                this.coefCorrelDensidade, this.coefCorrelViscosidade, this.coefCorrelCalorEspecifico,
                this.coefCorrelCondutividadeTermica);
        }
    }
}
