using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    public interface IBomba
    {
        /// <summary>
        /// Vazão de fluido (m^3/h)
        /// </summary>
        double Vazao { get; set; }
        /// <summary>
        /// Potencia da bomba (W)
        /// </summary>
        double Potencia { get; set; }
        /// <summary>
        /// !!!!Verificar depois como vamos representar!!!
        /// </summary>
        int EquacaoCurva { get; set; }
        /// <summary>
        /// Altura monometrica da bomba
        /// </summary>
        double AlturaManometrica { get; set; }
    }
}