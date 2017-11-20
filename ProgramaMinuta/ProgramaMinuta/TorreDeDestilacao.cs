using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    class TorreDeDestilacao : EquipamentoOPIII, IDestilacao
    {
        public double numeroPratosTeorico { get; set; }
        public int numeroPretosPratica { get; set; }
        public double refluxo { get; set; }
        public Fluido flidoDest { get; set; }
        public Fluido fluidoBott { get; set; }
        public Fluido fluidoFeed { get; set; }
        public int estagioFeed { get; set; }

        public void calculaPratosMin()
        {
            throw new NotImplementedException();
        }
    }
}