using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    class Bomba : EquipamentoOPI, IBomba
    {
        public double AlturaManometrica { get; set; }
        double IBomba.Vazao { get; set; }
        double IBomba.Potencia { get ; set; }
        int IBomba.EquacaoCurva { get; set; }
    }
}