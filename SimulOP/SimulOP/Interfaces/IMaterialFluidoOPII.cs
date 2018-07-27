using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public interface IMaterialFluidoOPII
    {
        double Temperatura { get; set; }
        double Viscosidade { get; }
        double Densidade { get; }
        double[] CoefCorrelCalorEspecifico { get; }
        double[] CoefCorrelCondutividadeTermica { get; }

        IMaterialFluidoOPII Clone();
    }
}
