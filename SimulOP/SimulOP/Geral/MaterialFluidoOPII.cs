using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialFluidoOPII: MaterialFluidoOPI, IMaterialFluidoOPII
    {
        protected double temperatura;
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
        public double CalorEspecifico { get => calorEspecifico; }
        public double CondutividadeTermica { get => condutividadeTermica; }

        public MaterialFluidoOPII(string componente, double densidade, double viscosidade,
            double temperatura, double calorEspecifico, double condutividadeTermica) : base(componente, densidade, viscosidade)
        {
            this.temperatura = temperatura;
            this.calorEspecifico = calorEspecifico;
            this.condutividadeTermica = condutividadeTermica;
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
            throw new NotImplementedException();
        }

        private void AtualizaViscosidade()
        {
            throw new NotImplementedException();
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
            return new MaterialFluidoOPII(this.Componente, this.densidade, this.viscosidade, this.temperatura,this.calorEspecifico,this.condutividadeTermica);
        }
    }
}
