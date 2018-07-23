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
        double CalorEspecifico { get; }
        double CondutividadeTermica { get; }

        IMaterialFluidoOPII Clone();
    }
}
