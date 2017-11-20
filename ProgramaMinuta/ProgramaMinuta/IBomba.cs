using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    interface IBomba
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
        /// Coeficientes do polinomio de 3º grau que aproxima a bomba
        /// </summary>
        double[] equacaoCurva { get; set; }

        /// <summary>
        /// Altura monometrica da bomba
        /// </summary>
        double alturaManometrica { get; set; }

     }
}