using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    class Cotovelo : Singularidade 
    {
        /// <summary>
        /// Constructor para o objeto Cotovelo
        /// </summary>
        /// <param name="comprimentoEqv">Comprimento equivalente da singulariedade [m]</param>
        public Cotovelo(double comprimentoEqv) : base (comprimentoEqv,"Cotovelo")
        {
        }
    }
}