using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    class Bomba : EquipamentoOPI, IBomba
    {
        public double alturaManometrica { get; set; }
        double IBomba.vazao { get; set; }
        double IBomba.potencia { get ; set; }
        int IBomba.equacaoCurva { get; set; }
    }
}