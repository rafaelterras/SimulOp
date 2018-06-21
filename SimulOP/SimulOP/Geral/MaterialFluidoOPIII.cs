using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialFluidoOPIII : MaterialFluidoOPI
    {
        private double[] coefAntoine;

        public double[] CoefAntoine { get => coefAntoine; }

        public MaterialFluidoOPIII(string componente, double densidade, double viscosidade, double[] coefAntoine) : base(componente, densidade, viscosidade)
        {
            this.coefAntoine = coefAntoine;
        }

    }
}
