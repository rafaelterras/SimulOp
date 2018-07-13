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

        public double Temperatura { get => temperatura; set => temperatura = value; }
        public double CalorEspecifico { get => calorEspecifico; }
        public double CondutividadeTermica { get => condutividadeTermica; }

        public MaterialFluidoOPII(string componente, double densidade, double viscosidade,
            double temperatura, double calorEspecifico, double condutividadeTermica) : base(componente, densidade, viscosidade)
        {
            this.temperatura = temperatura;
            this.calorEspecifico = calorEspecifico;
            this.condutividadeTermica = condutividadeTermica;
        }

    }
}
