using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    class TrocadordeCalor : EquipamentoOPII, ITrocadorDeCalor
    {
        public Fluido fluidoQuenteEntrada { get; set; }
        public Fluido fluidoFrioEntrada { get; set; }
        public double coefGlobalTerm { get; set; }
        public double area { get; set; }
        public string tipoEscoamento { get; set; }
        public Fluido fluidoFrioSaida { get; set; }
        public Fluido fluidoQuenteSaida { get; set; }
        public double calorTransferido { get; set; }

        public void calculaSaidas()
        {
            throw new NotImplementedException();
        }
    }
}