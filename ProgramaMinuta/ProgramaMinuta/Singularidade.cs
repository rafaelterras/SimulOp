using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    class Singularidade : EquipamentoOPI, ISingulariedade
    {
        public double comprimentoEqv { get; set; }
        public string tipo { get; set; }
    }
}