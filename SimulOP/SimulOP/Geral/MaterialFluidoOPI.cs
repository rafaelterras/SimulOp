using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialFluidoOPI : Material ,  IMaterialFluidoOPI
    {
        protected double densidade;
        protected double viscosidade;

        public double Densidade { get => densidade; }
        public double Viscosidade { get => viscosidade; }

        public MaterialFluidoOPI(string componente, double densidade, double viscosidade) : base(componente)
        {
            this.densidade = densidade;
            this.viscosidade = viscosidade;
        }
        
    }
}
