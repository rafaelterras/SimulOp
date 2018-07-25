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
            coCorrente = 0,
            contraCorrente = 1,
        }

        public enum TipoTubo
        {
            anular = 0,
            interno = 1,
        }

        public enum FluidoTroca
        {
            quente = 0,
            frio = 1,
        }
    }
}