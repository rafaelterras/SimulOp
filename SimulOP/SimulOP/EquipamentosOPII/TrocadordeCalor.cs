using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    class TrocadordeCalor : EquipamentoOPII, ITrocadorDeCalor
    {
        public FluidoOPI fluidoQuenteEntrada { get; set; }
        public FluidoOPI fluidoFrioEntrada { get; set; }
        public double coefGlobalTerm { get; set; }
        public double area { get; set; }
        public string tipoEscoamento { get; set; }
        public FluidoOPI fluidoFrioSaida { get; set; }
        public FluidoOPI fluidoQuenteSaida { get; set; }
        public double calorTransferido { get; set; }

        public void CalculaSaidas()
        {
            throw new NotImplementedException();
        }
    }
}