using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public abstract class EquipamentoOPII : Equipamentos
    {
        public enum ConfgCorrentes
        {
            CoCorrente = 0,
            ContraCorrente = 1,
        }
    }
}