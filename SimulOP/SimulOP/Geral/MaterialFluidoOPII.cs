using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialFluidoOPII : MaterialFluidoOPI, IMaterialFluidoOPII
    {
        protected double temperatura;
        protected double[] coefCorrelDensidade;
        protected double[] coefCorrelViscosidade;
        protected double[] coefCorrelCalorEspecifico;
        protected double[] coefCorrelCondutividadeTermica;
        protected double calorEspecifico;
        protected double condutividadeTermica;

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

        public MaterialFluidoOPII(string componente, double temperatura, 
            double[] coefCorrelDensidade, double[] coefCorrelViscosidade, 
            double[] coefCorrelCalorEspecifico, double[] coefCorrelCondutividadeTermica, 
            double densidade = 1, double viscosidade = 1 ) : base(componente, densidade, viscosidade)
        {
            this.temperatura = temperatura;
            this.coefCorrelDensidade = coefCorrelDensidade;
            this.coefCorrelViscosidade = coefCorrelViscosidade;
            this.coefCorrelCalorEspecifico = coefCorrelCalorEspecifico;
            this.coefCorrelCondutividadeTermica = coefCorrelCondutividadeTermica;
            throw new Exception("Material Fluido OPII ainda não implementado"); // TODO: Verificar como calcular as propriedades
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
            
            // Densidade em g/ml, temperatura em K

            dens = this.coefCorrelDensidade[0] * Math.Pow(this.coefCorrelDensidade[1], 
                -Math.Pow((1 - this.temperatura/this.coefCorrelDensidade[2]), this.coefCorrelDensidade[3]));

            this.densidade = dens;
        }

        private void AtualizaViscosidade()
        {
            double visc;

            // Densidade em cP, temperatura em K

            visc = Math.Pow(10, this.CoefCorrelViscosidade[0] + this.coefCorrelViscosidade[1]/this.temperatura + 
                this.coefCorrelViscosidade[2] * this.temperatura + this.coefCorrelViscosidade[3] * Math.Pow(this.temperatura, 2));

            this.viscosidade = visc;
        }

        private void AtualizaCalorEspecifico()
        {
            double cp;

            // Calor específico em J/mol K, temperatura em K

            cp = this.coefCorrelCalorEspecifico[0] + this.coefCorrelCalorEspecifico[1] * this.temperatura + 
                this.coefCorrelCalorEspecifico[2] * Math.Pow(this.temperatura, 2) + 
                this.coefCorrelCalorEspecifico[3] * Math.Pow(this.temperatura, 3);

            this.calorEspecifico = cp;
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
            return new MaterialFluidoOPII(this.Componente, this.temperatura,
                this.coefCorrelDensidade, this.coefCorrelViscosidade, this.coefCorrelCalorEspecifico,
                this.coefCorrelCondutividadeTermica);
        }
    }
}
