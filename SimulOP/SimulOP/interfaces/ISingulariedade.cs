using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public interface ISingulariedade
    {
        /// <summary>
        /// Comprimento equivalente da singulariedade
        /// </summary>
        double ComprimentoEqv { get; }
        /// <summary>
        /// Tipo da singulariedade
        /// </summary>
        string Tipo { get; }
    }
}