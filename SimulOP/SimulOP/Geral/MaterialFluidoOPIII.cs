using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialFluidoOPIII : Material
    {
        private double[] coefAntoine;

        public double[] CoefAntoine { get => coefAntoine; }

        public MaterialFluidoOPIII(string componente, double[] coefAntoine ) : base(componente)
        {
            this.coefAntoine = coefAntoine;
        }

    }
}
