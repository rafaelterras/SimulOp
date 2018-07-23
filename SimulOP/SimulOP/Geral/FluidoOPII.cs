using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class FluidoOPII
    {
        private IMaterialFluidoOPII material;
        private double temperatura;

        public IMaterialFluidoOPII Material { get => material; }
        public double Temperatura { get => temperatura; }

        public FluidoOPII(IMaterialFluidoOPII material, double temperatura)
        {
            this.material = material;
            this.temperatura = temperatura;
        }

        public FluidoOPII Clone()
        {
            IMaterialFluidoOPII temp = material.Clone();
            return new FluidoOPII(temp,this.temperatura);
        }

    }
}
