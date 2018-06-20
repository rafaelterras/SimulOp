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
        private double densidade;
        private double viscosidade;

        public double[] CoefAntoine { get => coefAntoine; }
        public double Densidade { get => densidade; }
        public double Viscosidade { get => viscosidade; }

        public MaterialFluidoOPIII(string componente, double densidade, double viscosidade, double[] coefAntoine) : base(componente)
        {
            this.densidade = densidade;
            this.viscosidade = viscosidade;
            this.coefAntoine = coefAntoine;
        }

    }
}
