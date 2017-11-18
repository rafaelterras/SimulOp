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
        double vazao { get; set; }
        /// <summary>
        /// Potencia da bomba (W)
        /// </summary>
        double potencia { get; set; }
        /// <summary>
        /// !!!!Verificar depois como vamos representar!!!
        /// </summary>
        int equacaoCurva { get; set; }
        /// <summary>
        /// Altura monometrica da bomba
        /// </summary>
        double alturaManometrica { get; set; }
    }
}